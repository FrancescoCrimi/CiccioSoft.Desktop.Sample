using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using WpfNavigationMetroApp.Contracts;
using WpfNavigationMetroApp.Helpers;
using WpfNavigationMetroApp.Services;
using WpfNavigationMetroApp.Views;

namespace WpfNavigationMetroApp.ViewModels
{
    public class Page2ViewModel : ObservableRecipient, INavigationAware, IDisposable
    {
        private readonly ILogger<Page2ViewModel> logger;
        private readonly INavigationService navigationService;
        private readonly MyService myService;
        private RelayCommand command1;
        private RelayCommand command2;
        private RelayCommand command3;
        private RelayCommand command4;

        public Page2ViewModel(ILogger<Page2ViewModel> logger,
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
            => navigationService.NavigateTo(typeof(Page1)));

        public ICommand Command2 => command2 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page3)));

        public ICommand Command3 => command3 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page1), null, true));

        public ICommand Command4 => command4 ??= new RelayCommand(()
            => navigationService.NavigateTo(typeof(Page3), null, true));

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
