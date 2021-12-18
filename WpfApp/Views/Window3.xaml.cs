using WpfApp.ViewModels;
using System.Windows;

namespace WpfApp.Views
{
    public partial class Window3 : Window
    {
        public Window3(Window3ViewModel window3ViewModel)
        {
            InitializeComponent();
            DataContext = window3ViewModel;
        }
    }
}
