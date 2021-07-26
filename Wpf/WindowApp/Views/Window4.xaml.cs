using Wpf.WindowApp.ViewModels;
using System.Windows;

namespace Wpf.WindowApp.Views
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
