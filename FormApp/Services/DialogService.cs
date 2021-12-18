using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace FormApp.Services
{
    public class DialogService : IDisposable
    {
        private readonly ILogger<DialogService> logger;
        private readonly IServiceProvider serviceProvider;

        public DialogService(ILogger<DialogService> logger,
                             IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public DialogResult OpenDialog<TWindow>() where TWindow : Form
        {
            var win = serviceProvider.GetService<TWindow>();
            return win.ShowDialog();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
