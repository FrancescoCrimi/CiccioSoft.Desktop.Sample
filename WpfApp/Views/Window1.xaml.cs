using WpfApp.ViewModels;
using System.Windows;

namespace WpfApp.Views
{
    public partial class Window1 : Window
    {
        public Window1(Window1ViewModel window1ViewModel)
        {
            InitializeComponent();
            DataContext = window1ViewModel;
        }
    }
}
