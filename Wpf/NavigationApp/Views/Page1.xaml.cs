using System.Windows.Controls;
using Wpf.NavigationApp.ViewModels;

namespace Wpf.NavigationApp.Views
{
    public partial class Page1 : Page
    {
        public Page1(Page1ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
