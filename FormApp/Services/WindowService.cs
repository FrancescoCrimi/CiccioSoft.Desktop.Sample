using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace FormApp.Services
{
    public class WindowService : IDisposable
    {
        private readonly ILogger<WindowService> logger;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public WindowService(ILogger<WindowService> logger,
                             IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void OpenWindow<TWindow>() where TWindow : Form
        {
            var scope = serviceScopeFactory.CreateScope();
            var window = scope.ServiceProvider.GetService<TWindow>();
            void WindowDisposed(object sender, EventArgs e)
            {
                window.Disposed -= WindowDisposed;
                scope.Dispose();
            }
            window.Disposed += WindowDisposed;
            window.Show();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
