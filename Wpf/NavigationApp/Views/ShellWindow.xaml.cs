using System.Windows;
using Wpf.NavigationApp.Contracts.Services;
using Wpf.NavigationApp.ViewModels;

namespace Wpf.NavigationApp.Views
{
    public partial class ShellWindow : Window
    {
        public ShellWindow(ShellViewModel viewModel,
                           INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationService.Initialize(frame);
        }
    }
}
