using FormApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public class FormHostLifetime : IHostLifetime, IDisposable
    {
        private readonly ILogger logger;
        private readonly IHostEnvironment environment;
        private readonly IHostApplicationLifetime applicationLifetime;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private CancellationTokenRegistration applicationStartedRegistration;
        private CancellationTokenRegistration applicationStoppingRegistration;

        public FormHostLifetime(ILoggerFactory loggerFactory,
                                IHostEnvironment environment,
                                IHostApplicationLifetime applicationLifetime,            
                                IServiceScopeFactory serviceScopeFactory)
        {
            logger = loggerFactory.CreateLogger("Microsoft.Hosting.Lifetime");
            this.environment = environment;
            this.applicationLifetime = applicationLifetime;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            applicationStartedRegistration = applicationLifetime.ApplicationStarted.Register(state =>
            {
                ((FormHostLifetime)state!).OnApplicationStarted();
            },
            this);
            applicationStoppingRegistration = applicationLifetime.ApplicationStopping.Register(state =>
            {
                ((FormHostLifetime)state!).OnApplicationStopping();
            },
            this);

            RegisterShutdownHandlers();

            var threadfrm = new Thread(StartForm);
            threadfrm.SetApartmentState(ApartmentState.STA);
            threadfrm.Name = "StartForm Thread";
            threadfrm.Start();

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
            Application.ApplicationExit += ApplicationExit;
        }

        private void StartForm()
        {
            ApplicationConfiguration.Initialize();
            var scope = serviceScopeFactory.CreateScope();
            var window = scope.ServiceProvider.GetService<MainWindow>();
            Application.Run(window);
        }

        private void ApplicationExit(object? sender, EventArgs e)
        {
            applicationLifetime.StopApplication();
            UnregisterShutdownHandlers();
            applicationStartedRegistration.Dispose();
            applicationStoppingRegistration.Dispose();
        }

        private void UnregisterShutdownHandlers()
        {
            Application.ApplicationExit -= ApplicationExit;
        }

        public void Dispose()
        {
        }
    }
}
