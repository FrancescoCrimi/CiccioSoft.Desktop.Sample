using System.Windows.Controls;
using Wpf.NavigationApp.ViewModels;

namespace Wpf.NavigationApp.Views
{
    public partial class Page5 : Page
    {
        public Page5(Page5ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
