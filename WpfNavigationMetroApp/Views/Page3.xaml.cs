using System.Windows.Controls;
using WpfNavigationMetroApp.ViewModels;

namespace WpfNavigationMetroApp.Views
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
