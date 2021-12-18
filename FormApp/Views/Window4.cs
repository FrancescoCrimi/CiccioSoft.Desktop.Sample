using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using FormApp.Services;

namespace FormApp.Views
{
    public partial class Window4 : Form
    {
        private readonly ILogger<Window4> logger;

        public Window4(ILogger<Window4> logger,
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
            window5ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window5>();
            mainDialogToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<MainWindow>();
            dialog1ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window1>();
            dialog2ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window2>();
            dialog3ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window3>();
            dialog5ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window5>();
            button1.Click += (s, e) => windowManagerService.OpenWindow<Window3>();
            button2.Click += (s, e) => windowManagerService.OpenWindow<Window5>();
            button3.Click += (s, e) => dialogService.OpenDialog<Window3>();
            button4.Click += (s, e) => dialogService.OpenDialog<Window5>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }
    }
}
