using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;
using Wpf.WindowApp.Contracts.ViewModels;
using Wpf.WindowApp.Helpers;
using Wpf.WindowApp.Services;

namespace Wpf.WindowApp.ViewModels
{
    public class Window5ViewModel : Observable, INavigationAware, IDisposable
    {
        private readonly ILogger<Window5ViewModel> logger;
        private readonly MyService myService;
        private readonly WindowService windowManagerService;
        private readonly DialogService windowDialogService;
        private RelayCommand<Type> openWindowCommand;
        private RelayCommand<Type> openDialogCommand;

        public Window5ViewModel(ILogger<Window5ViewModel> logger,
                                MyService myService,
                                WindowService windowManagerService,
                                DialogService windowDialogService)
        {
            this.logger = logger;
            this.myService = myService;
            this.windowManagerService = windowManagerService;
            this.windowDialogService = windowDialogService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
            logger.LogDebug("WindowManagerService " + windowManagerService.GetHashCode().ToString());
        }

        public string MyId => GetHashCode().ToString();

        public string MyModelId => myService.MyId;

        public ICommand OpenWindowCommand =>
            openWindowCommand ??= new RelayCommand<Type>(type =>
                windowManagerService.OpenWindow(type));

        public ICommand OpenDialogCommand =>
            openDialogCommand ??= new RelayCommand<Type>(type =>
                windowDialogService.OpenDialog(type));

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
