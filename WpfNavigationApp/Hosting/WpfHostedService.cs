using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfNavigationApp.Hosting
{
    public class WpfHostedService<MainWindow> : IHostedService, IDisposable where MainWindow : Window
    {
        private readonly ILogger logger;
        private readonly IServiceProvider _serviceProvider;

        public WpfHostedService(ILogger<WpfHostedService<MainWindow>> logger,
                                IServiceProvider serviceProvider)
        {
            this.logger = logger;
            _serviceProvider = serviceProvider;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StartAsync: " + GetHashCode().ToString());
            var shellWindow = _serviceProvider.GetService<MainWindow>();
            shellWindow.Show();
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
