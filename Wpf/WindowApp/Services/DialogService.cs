using Wpf.WindowApp.Contracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;

namespace Wpf.WindowApp.Services
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

        public bool? OpenDialog(Type windowType, object parameter = null)
        {
            if (windowType.IsAssignableTo(typeof(System.Windows.Window)))
            {

                var window = (System.Windows.Window)serviceProvider.GetService(windowType);
                if (window?.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(parameter);
                }
                return window.ShowDialog();
            }
            return null;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
