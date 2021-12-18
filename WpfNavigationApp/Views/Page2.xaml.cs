using System.Windows.Controls;
using WpfNavigationApp.ViewModels;

namespace WpfNavigationApp.Views
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
