using MahApps.Metro.Controls;
using Wpf.NavigationMetroApp.Contracts.Services;
using Wpf.NavigationMetroApp.ViewModels;

namespace Wpf.NavigationMetroApp.Views
{
    public partial class ShellWindow : MetroWindow
    {
        public ShellWindow(ShellViewModel viewModel,
                           INavigationService navigationService,
                           IRightPaneService rightPaneService)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            rightPaneService.Initialize(rightPaneFrame, splitView);
            DataContext = viewModel;
        }
    }
}
