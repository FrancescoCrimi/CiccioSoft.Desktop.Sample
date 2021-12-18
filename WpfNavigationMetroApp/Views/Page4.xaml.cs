using System.Windows.Controls;
using WpfNavigationMetroApp.ViewModels;

namespace WpfNavigationMetroApp.Views
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
