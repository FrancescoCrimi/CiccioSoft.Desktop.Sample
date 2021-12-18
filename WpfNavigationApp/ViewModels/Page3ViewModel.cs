using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;
using WpfNavigationApp.Contracts.Services;
using WpfNavigationApp.Contracts.ViewModels;
using WpfNavigationApp.Services;

namespace WpfNavigationApp.ViewModels
{
    public class Page3ViewModel : Observable, INavigationAware, IDisposable
    {
        private readonly ILogger<Page3ViewModel> logger;
        private readonly INavigationService navigationService;
        private readonly MyService myService;
        private RelayCommand<Type> newNavigationCommand;
        private RelayCommand<Type> navigateCommand;

        public Page3ViewModel(ILogger<Page3ViewModel> logger,
                              INavigationService navigationService,
                              MyService myService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.myService = myService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public string MyId => GetHashCode().ToString();

        public string MyModelId => myService.MyId;

        public ICommand NewNavigationCommand
            => newNavigationCommand ??= new RelayCommand<Type>(type
                => navigationService.NavigateTo(type, null, true));

        public ICommand NavigateCommand
            => navigateCommand ??= new RelayCommand<Type>(type
                => navigationService.NavigateTo(type));

        public void OnNavigatedFrom()
        {
            logger.LogDebug("OnNavigatedFrom: " + GetHashCode().ToString());
        }

        public void OnNavigatedTo(object parameter)
        {
            logger.LogDebug("OnNavigatedTo: " + GetHashCode().ToString());
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
