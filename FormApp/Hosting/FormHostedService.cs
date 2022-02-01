using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp.Hosting
{
    public class FormHostedService<MainWindow> : IHostedService, IDisposable where MainWindow : Form
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public FormHostedService(ILogger<FormHostedService<MainWindow>> logger,
                                 IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public  Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StartAsync: " + GetHashCode().ToString());

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var scope = serviceScopeFactory.CreateScope();
            var window = scope.ServiceProvider.GetService<MainWindow>();
            return Task.Run(() => Application.Run(window));
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
