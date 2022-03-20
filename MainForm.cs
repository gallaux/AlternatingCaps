using System.Resources;

namespace AlternatingCaps
{
    /// <summary>
    /// The main (and only) hidden form
    /// </summary>
    public partial class MainForm : Form
    {
        private static bool isAlternating = false;
        private static NotifyIcon? trayIcon = null;
        private static ToolStripMenuItem? switchMenuItem = null;

        private static readonly ResourceManager? resources = new ResourceManager(typeof(MainForm));

        /// <summary>
        /// Form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            trayIcon = this.notifyIcon;
            switchMenuItem = this.switchAlternateMenuItem;
        }

        /// <summary>
        /// Switch the Alternating Caps feature On/Off. Update the tray icon and menu item text accordingly
        /// </summary>
        /// <returns>Whether the Alternating Caps feature is On/Off</returns>
        public static bool SwitchAlternateCaps()
        {
            isAlternating = !isAlternating;
            string newState = isAlternating ? "On" : "Off";

            if (trayIcon != null)
            {
                trayIcon.Icon = (Icon)resources.GetObject($"notifyIcon{newState}.Icon");
                trayIcon.Text = (string)resources.GetObject($"IconText{newState}");
            }
            if (switchMenuItem != null)
            {
                switchMenuItem.Text = (string)resources.GetObject($"MenuText{newState}");
            }

            return isAlternating;
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