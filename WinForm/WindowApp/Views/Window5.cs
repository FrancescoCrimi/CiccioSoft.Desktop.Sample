using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using WinForm.WindowApp.Services;

namespace WinForm.WindowApp.Views
{
    public partial class Window5 : Form
    {
        private readonly ILogger<Window5> logger;

        public Window5(ILogger<Window5> logger,
                       WindowService windowManagerService,
                       DialogService dialogService,
                       MyService myService)
        {
            InitializeComponent();
            this.logger = logger;
            textBox1.Text = GetHashCode().ToString();
            textBox2.Text = myService.MyId;
            mainWindowToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<MainWindow>();
            window1ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window1>();
            window2ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window2>();
            window3ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window3>();
            window4ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window4>();
            mainDialogToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<MainWindow>();
            dialog1ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window1>();
            dialog2ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window2>();
            dialog3ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window3>();
            dialog4ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window4>();
            button1.Click += (s, e) => windowManagerService.OpenWindow<Window4>();
            button2.Click += (s, e) => windowManagerService.OpenWindow<MainWindow>();
            button3.Click += (s, e) => dialogService.OpenDialog<Window4>();
            button4.Click += (s, e) => dialogService.OpenDialog<MainWindow>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }
    }
}
