using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using FormApp.Services;

namespace FormApp.Views
{
    public partial class MainWindow : Form
    {
        private readonly ILogger<MainWindow> logger;

        public MainWindow(ILogger<MainWindow> logger,
                          WindowService windowManagerService,
                          DialogService dialogService,
                          MyService myService)
        {
            InitializeComponent();
            this.logger = logger;
            textBox1.Text = GetHashCode().ToString();
            textBox2.Text = myService.MyId;
            window1ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window1>();
            window2ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window2>();
            window3ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window3>();
            window4ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window4>();
            window5ToolStripMenuItem.Click += (s, e) => windowManagerService.OpenWindow<Window5>();
            dialog1ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window1>();
            dialog2ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window2>();
            dialog3ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window3>();
            dialog4ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window4>();
            dialog5ToolStripMenuItem.Click += (s, e) => dialogService.OpenDialog<Window5>();
            button1.Click += (s, e) => windowManagerService.OpenWindow<Window5>();
            button2.Click += (s, e) => windowManagerService.OpenWindow<Window1>();
            button3.Click += (s, e) => dialogService.OpenDialog<Window5>();
            button4.Click += (s, e) => dialogService.OpenDialog<Window1>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }
    }
}
