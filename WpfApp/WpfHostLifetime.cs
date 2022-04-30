using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfApp.Services;
using WpfApp.Views;

namespace WpfApp
{
    public class WpfHostLifetime : IHostLifetime, IDisposable
    {
        private readonly ILogger logger;
        private readonly IHostEnvironment environment;
        private readonly IHostApplicationLifetime applicationLifetime;
        private readonly WindowService windowService;
        private CancellationTokenRegistration applicationStartedRegistration;
        private CancellationTokenRegistration applicationStoppingRegistration;

        public WpfHostLifetime(ILoggerFactory loggerFactory,
                               IHostEnvironment environment,
                               IHostApplicationLifetime applicationLifetime,
                               WindowService windowService)
        {
            logger = loggerFactory.CreateLogger("Microsoft.Hosting.Lifetime");
            this.environment = environment;
            this.applicationLifetime = applicationLifetime;
            this.windowService = windowService;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            applicationStartedRegistration = applicationLifetime.ApplicationStarted.Register(state =>
            {
                ((WpfHostLifetime)state!).OnApplicationStarted();
            },
            this);
            applicationStoppingRegistration = applicationLifetime.ApplicationStopping.Register(state =>
            {
                ((WpfHostLifetime)state!).OnApplicationStopping();
            },
            this);

            RegisterShutdownHandlers();

            windowService.OpenWindow(typeof(MainWindow));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnApplicationStarted()
        {
            logger.LogInformation("Application started.");
            logger.LogInformation("Hosting environment: {envName}", environment.EnvironmentName);
            logger.LogInformation("Content root path: {contentRoot}", environment.ContentRootPath);
        }

        private void OnApplicationStopping()
        {
            logger.LogInformation("Application is shutting down...");
        }

        private void RegisterShutdownHandlers()
        {
            System.Windows.Application.Current.Exit += ApplicationExit;
        }

        private void ApplicationExit(object sender, System.Windows.ExitEventArgs e)
        {
            applicationLifetime.StopApplication();
            UnregisterShutdownHandlers();
            applicationStartedRegistration.Dispose();
            applicationStoppingRegistration.Dispose();
        }

        private void UnregisterShutdownHandlers()
        {
            System.Windows.Application.Current.Exit -= ApplicationExit;
        }

        public void Dispose()
        {
        }
    }
}
