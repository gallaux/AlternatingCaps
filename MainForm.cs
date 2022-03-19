namespace AlternatingCaps
{
    public partial class MainForm : Form
    {
        public static bool isAlternating = false;

        private static NotifyIcon? trayIcon = null;
        private static ToolStripMenuItem? switchMenuItem = null;

        private static readonly string IconTextOff = "Alternating Caps (Off)";
        private static readonly string IconTextOn = "aLtErNaTiNg cApS (oN)";

        private static readonly string MenuTextOff = "Turn OFF (\"End\" Key)";
        private static readonly string MenuTextOn = "Turn ON (\"End\" Key)";

        public MainForm()
        {
            InitializeComponent();

            trayIcon = this.notifyIcon;
            switchMenuItem = this.switchAlternateMenuItem;
        }

        public static void SwitchAlternateCaps()
        {
            isAlternating = !isAlternating;

            if (trayIcon != null) trayIcon.Text = isAlternating ? IconTextOn : IconTextOff;
            if (switchMenuItem != null) switchMenuItem.Text = isAlternating ? MenuTextOff : MenuTextOn;
        }

        private void switchAlternateMenuItem_Click(object sender, EventArgs e)
        {
            SwitchAlternateCaps();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}