using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using WinForm.WindowApp.Services;

namespace WinForm.WindowApp.Views
{
    public partial class Window2 : Form
    {
        private readonly ILogger<Window2> logger;

        public Window2(ILogger<Window2> logger,
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
            window3ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window3>();
            window4ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window4>();
            window5ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window5>();
            mainDialogToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<MainWindow>();
            dialog1ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window1>();
            dialog3ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window3>();
            dialog4ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window4>();
            dialog5ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window5>();
            button1.Click += (s, e) => windowManagerService.OpenWindow<Window1>();
            button2.Click += (s, e) => windowManagerService.OpenWindow<Window3>();
            button3.Click += (s, e) => dialogService.OpenDialog<Window1>();
            button4.Click += (s, e) => dialogService.OpenDialog<Window3>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }
    }
}
