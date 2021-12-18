using System.Windows.Controls;
using WpfNavigationMetroApp.ViewModels;

namespace WpfNavigationMetroApp.Views
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
