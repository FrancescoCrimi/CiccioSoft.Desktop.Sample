using WpfApp.ViewModels;
using System.Windows;

namespace WpfApp.Views
{
    public partial class Window4 : Window
    {
        public Window4(Window4ViewModel window4ViewModel)
        {
            InitializeComponent();
            DataContext = window4ViewModel;
        }
    }
}
