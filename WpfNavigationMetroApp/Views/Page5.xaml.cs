using System.Windows.Controls;
using WpfNavigationMetroApp.ViewModels;

namespace WpfNavigationMetroApp.Views
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
