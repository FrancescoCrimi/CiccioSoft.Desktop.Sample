using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using FormApp.Services;

namespace FormApp.Views
{
    public partial class Window1 : Form
    {
        private readonly ILogger<Window1> logger;

        public Window1(ILogger<Window1> logger,
                       WindowService windowManagerService,
                       DialogService dialogService,
                       MyService myService)
        {
            InitializeComponent();
            this.logger = logger;
            textBox1.Text = GetHashCode().ToString();
            textBox2.Text = myService.MyId;
            mainWindowToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<MainWindow>();
            window2ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window2>();
            window3ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window3>();
            window4ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window4>();
            window5ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window5>();
            mainDialogToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<MainWindow>();
            dialog2ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window2>();
            dialog3ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window3>();
            dialog4ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window4>();
            dialog5ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window5>();
            button1.Click += (s, e) => windowManagerService.OpenWindow<MainWindow>();
            button2.Click += (s, e) => windowManagerService.OpenWindow<Window2>();
            button3.Click += (s, e) => dialogService.OpenDialog<MainWindow>();
            button4.Click += (s, e) => dialogService.OpenDialog<Window2>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }
    }
}
