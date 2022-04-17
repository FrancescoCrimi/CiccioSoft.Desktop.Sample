using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfNavigationMetroApp.Views;

namespace WpfNavigationMetroApp
{
    public class WpfHostLifetime : IHostLifetime, IDisposable
    {
        private readonly ILogger<WpfHostLifetime> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public WpfHostLifetime(ILogger<WpfHostLifetime> logger,
                               IServiceProvider serviceProvider,
                               IHostApplicationLifetime hostApplicationLifetime)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.hostApplicationLifetime = hostApplicationLifetime;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            System.Windows.Application.Current.Exit += ApplicationExit;
            var shellWindow = serviceProvider.GetRequiredService<ShellWindow>();
            shellWindow.Show();
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
