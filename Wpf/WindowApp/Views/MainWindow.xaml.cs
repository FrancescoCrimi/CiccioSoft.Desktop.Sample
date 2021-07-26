using System.Windows;
using Wpf.WindowApp.ViewModels;

namespace Wpf.WindowApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }
    }
}
