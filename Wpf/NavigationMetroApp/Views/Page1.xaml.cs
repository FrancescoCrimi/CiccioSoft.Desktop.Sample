using System.Windows.Controls;
using Wpf.NavigationMetroApp.ViewModels;

namespace Wpf.NavigationMetroApp.Views
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
