using System.Windows;
using WpfNavigationApp.Contracts.Services;
using WpfNavigationApp.ViewModels;

namespace WpfNavigationApp.Views
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
