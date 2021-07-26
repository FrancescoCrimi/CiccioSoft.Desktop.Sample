using System.Windows.Controls;
using Wpf.NavigationApp.ViewModels;

namespace Wpf.NavigationApp.Views
{
    public partial class Page3 : Page
    {
        public Page3(Page3ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
