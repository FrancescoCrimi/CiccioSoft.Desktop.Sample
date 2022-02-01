using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using WpfNavigationApp.Contracts;
using WpfNavigationApp.Views;

namespace WpfNavigationApp.ViewModels
{
    public class ShellViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<ShellViewModel> logger;
        private readonly INavigationService navigationService;
        private RelayCommand<Type> menuItemCommand;
        private ICommand loadedCommand;

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ICommand LoadedCommand => 
            loadedCommand ??= new RelayCommand(() =>
                navigationService.NavigateTo(typeof(Page1)));

        public ICommand MenuItemCommand
            => menuItemCommand ??= new RelayCommand<Type>(type
                => navigationService.NavigateTo(type, null, true));

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
