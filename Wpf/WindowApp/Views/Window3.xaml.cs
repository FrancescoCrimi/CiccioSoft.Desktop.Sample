using Wpf.WindowApp.ViewModels;
using System.Windows;

namespace Wpf.WindowApp.Views
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
