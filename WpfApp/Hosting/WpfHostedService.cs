using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Services;

namespace WpfApp.Hosting
{
    public class WpfHostedService<MainWindow> : IHostedService, IDisposable where MainWindow : Window
    {
        private readonly ILogger logger;
        private readonly WindowService windowService;

        public WpfHostedService(ILogger<WpfHostedService<MainWindow>> logger,
                                WindowService windowService)
        {
            this.logger = logger;
            this.windowService = windowService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            windowService.OpenWindow(typeof(MainWindow));
            logger.LogDebug("StartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed" + GetHashCode().ToString());
        }
    }
}
