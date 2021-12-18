using System.Windows.Controls;
using WpfNavigationApp.ViewModels;

namespace WpfNavigationApp.Views
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
