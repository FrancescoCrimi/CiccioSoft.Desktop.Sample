using System.Windows.Controls;
using WpfNavigationApp.ViewModels;

namespace WpfNavigationApp.Views
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
