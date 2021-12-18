using System.Windows.Controls;
using WpfNavigationApp.ViewModels;

namespace WpfNavigationApp.Views
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
