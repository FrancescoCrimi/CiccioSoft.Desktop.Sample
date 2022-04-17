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
        private readonly ILogger<WpfHostLifetime> logger;
        private readonly WindowService windowService;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public WpfHostLifetime(ILogger<WpfHostLifetime> logger,
                               WindowService windowService,
                               IHostApplicationLifetime hostApplicationLifetime)
        {
            this.logger = logger;
            this.windowService = windowService;
            this.hostApplicationLifetime = hostApplicationLifetime;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            System.Windows.Application.Current.Exit += ApplicationExit;
            windowService.OpenWindow(typeof(MainWindow));
            logger.LogDebug("WaitForStartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        private void ApplicationExit(object sender, System.Windows.ExitEventArgs e)
        {
            System.Windows.Application.Current.Exit -= ApplicationExit;
            hostApplicationLifetime.StopApplication();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
