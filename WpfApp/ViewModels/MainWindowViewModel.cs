using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<MainWindowViewModel> logger;
        private readonly MyService myService;
        private readonly WindowService windowManagerService;
        private readonly DialogService windowDialogService;
        private RelayCommand<Type> openWindowCommand;
        private RelayCommand<Type> openDialogCommand;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger,
                                   MyService myService,
                                   WindowService windowManagerService,
                                   DialogService windowDialogService)
        {
            this.logger = logger;
            this.myService = myService;
            this.windowManagerService = windowManagerService;
            this.windowDialogService = windowDialogService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public string MyId => GetHashCode().ToString();

        public string MyModelId => myService.MyId;

        public ICommand OpenWindowCommand =>
            openWindowCommand ??= new RelayCommand<Type>(type =>
                windowManagerService.OpenWindow(type));

        public ICommand OpenDialogCommand =>
            openDialogCommand ??= new RelayCommand<Type>(type =>
                windowDialogService.OpenDialog(type));

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
