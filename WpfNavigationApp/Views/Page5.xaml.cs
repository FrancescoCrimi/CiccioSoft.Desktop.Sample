using System.Windows.Controls;
using WpfNavigationApp.ViewModels;

namespace WpfNavigationApp.Views
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
