using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;
using WpfNavigationMetroApp.Contracts.Services;
using WpfNavigationMetroApp.Helpers;
using WpfNavigationMetroApp.Views;

namespace WpfNavigationMetroApp.ViewModels
{
    public class ShellViewModel : Observable, IDisposable
    {
        private readonly ILogger<ShellViewModel> logger;
        private readonly INavigationService _navigationService;
        private readonly IRightPaneService _rightPaneService;
        private RelayCommand<Type> _menuItemCommand;
        private RelayCommand<Type> _menuOptionsItemCommand;
        private RelayCommand _goBackCommand;
        private ICommand _loadedCommand;

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService navigationService,
                              IRightPaneService rightPaneService)
        {
            this.logger = logger;
            _navigationService = navigationService;
            _rightPaneService = rightPaneService;
            _navigationService.Navigated += OnNavigated;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ICommand LoadedCommand => 
            _loadedCommand ??= new RelayCommand(() =>
                _navigationService.NavigateTo(typeof(Page1)));

        public RelayCommand GoBackCommand
            => _goBackCommand ??= new RelayCommand(
                () => _navigationService.GoBack(),
                () => _navigationService.CanGoBack);

        public ICommand MenuOptionsItemCommand
            => _menuOptionsItemCommand ??= new RelayCommand<Type>(type
                => _rightPaneService.OpenInRightPane(type));

        public ICommand MenuItemCommand
            => _menuItemCommand ??= new RelayCommand<Type>(type
                => _navigationService.NavigateTo(type, null, true));

        private void OnNavigated(object sender, EventArgs e)
        {
            GoBackCommand.OnCanExecuteChanged();
        }

        public void Dispose()
        {
            _navigationService.Navigated -= OnNavigated;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
