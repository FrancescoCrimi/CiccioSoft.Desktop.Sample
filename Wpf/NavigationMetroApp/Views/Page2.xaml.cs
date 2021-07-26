using System.Windows.Controls;
using Wpf.NavigationMetroApp.ViewModels;

namespace Wpf.NavigationMetroApp.Views
{
    public partial class Page2 : Page
    {
        public Page2(Page2ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
