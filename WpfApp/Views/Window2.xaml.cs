using WpfApp.ViewModels;
using System.Windows;

namespace WpfApp.Views
{
    public partial class Window2 : Window
    {
        public Window2(Window2ViewModel window2ViewModel)
        {
            InitializeComponent();
            DataContext = window2ViewModel;
        }
    }
}
