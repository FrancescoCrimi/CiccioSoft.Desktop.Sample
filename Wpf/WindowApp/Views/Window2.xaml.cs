using Wpf.WindowApp.ViewModels;
using System.Windows;

namespace Wpf.WindowApp.Views
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
