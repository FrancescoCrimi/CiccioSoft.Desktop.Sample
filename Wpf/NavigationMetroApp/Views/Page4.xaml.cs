using System.Windows.Controls;
using Wpf.NavigationMetroApp.ViewModels;

namespace Wpf.NavigationMetroApp.Views
{
    public partial class Page4 : Page
    {
        public Page4(Page4ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
