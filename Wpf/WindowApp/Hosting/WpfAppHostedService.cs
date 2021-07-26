using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Wpf.WindowApp.Services;

namespace Wpf.WindowApp.Hosting
{
    public class WpfAppHostedService<TWindow> : IHostedService, IDisposable where TWindow : Window
    {
        private readonly ILogger logger;
        private readonly WindowService windowService;

        public WpfAppHostedService(ILogger<WpfAppHostedService<TWindow>> logger,
                                   WindowService windowService)
        {
            this.logger = logger;
            this.windowService = windowService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            windowService.OpenWindow(typeof(TWindow));
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
