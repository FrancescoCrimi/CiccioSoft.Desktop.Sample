using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.WindowApp.Hosting
{
    public class FormHostedService<TForm> : IHostedService, IDisposable where TForm : Form
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public FormHostedService(ILogger<FormHostedService<TForm>> logger,
                                 IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = serviceScopeFactory.CreateScope();
            var window = scope.ServiceProvider.GetService<TForm>();

            Application.Run(window);
            logger.LogDebug("StartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
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
