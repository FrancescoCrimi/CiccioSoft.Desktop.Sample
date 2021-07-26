using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;
using Wpf.NavigationMetroApp.Contracts.Services;
using Wpf.NavigationMetroApp.Contracts.ViewModels;
using Wpf.NavigationMetroApp.Helpers;
using Wpf.NavigationMetroApp.Services;
using Wpf.NavigationMetroApp.Views;

namespace Wpf.NavigationMetroApp.ViewModels
{
    public class Page3ViewModel : Observable, INavigationAware, IDisposable
    {
        private readonly ILogger<Page3ViewModel> logger;
        private readonly INavigationService navigationService;
        private readonly MyService myService;
        private RelayCommand command1;
        private RelayCommand command2;
        private RelayCommand command3;
        private RelayCommand command4;

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

        public ICommand Command1 => command1 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page2)));

        public ICommand Command2 => command2 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page4)));

        public ICommand Command3 => command3 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page2), null, true));

        public ICommand Command4 => command4 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page4), null, true));

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
