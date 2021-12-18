using MahApps.Metro.Controls;
using WpfNavigationMetroApp.Contracts.Services;
using WpfNavigationMetroApp.ViewModels;

namespace WpfNavigationMetroApp.Views
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
