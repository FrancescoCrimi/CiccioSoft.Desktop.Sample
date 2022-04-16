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
        private readonly ILogger<FormHostLifetime> logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public FormHostLifetime(ILogger<FormHostLifetime> logger,
                                IServiceScopeFactory serviceScopeFactory,
                                IHostApplicationLifetime hostApplicationLifetime)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            this.hostApplicationLifetime = hostApplicationLifetime;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("WaitForStartAsync: " + GetHashCode().ToString());
            Application.ApplicationExit += ApplicationExit;

            var threadfrm = new Thread(StartForm);
            threadfrm.SetApartmentState(ApartmentState.STA);
            threadfrm.Name = "StartForm Thread";
            threadfrm.Start();

            return Task.CompletedTask;
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
            Application.ApplicationExit -= ApplicationExit;
            hostApplicationLifetime.StopApplication();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
