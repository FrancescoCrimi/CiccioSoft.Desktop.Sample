using System.Windows.Controls;
using Wpf.NavigationApp.ViewModels;

namespace Wpf.NavigationApp.Views
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
