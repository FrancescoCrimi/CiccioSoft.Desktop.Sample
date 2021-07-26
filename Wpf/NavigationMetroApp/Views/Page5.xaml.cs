using System.Windows.Controls;
using Wpf.NavigationMetroApp.ViewModels;

namespace Wpf.NavigationMetroApp.Views
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
