namespace AlternatingCaps
{
    /// <summary>
    /// The main (hidden) form
    /// </summary>
    public partial class MainForm : Form
    {
        private static bool isAlternating = false;
        private static NotifyIcon? trayIcon = null;
        private static ToolStripMenuItem? switchMenuItem = null;

        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            trayIcon = this.notifyIcon;
            switchMenuItem = this.switchAlternateMenuItem;
            notificationsShowMenuItem.Checked = Properties.Settings.Default.ShowNotifications;
        }

        /// <summary>
        /// Switch the Alternating Caps feature On/Off. Update the tray icon and menu item text accordingly
        /// </summary>
        /// <returns>Whether the Alternating Caps feature is On/Off</returns>
        public static bool SwitchAlternateCaps()
        {
            isAlternating = !isAlternating;

            if (trayIcon != null)
            {
                trayIcon.Icon = isAlternating ? Properties.Resources.NotifyIconOn : Properties.Resources.NotifyIconOff;
                trayIcon.Text = isAlternating ? Properties.Resources.StatusTextOn : Properties.Resources.StatusTextOff;
            }
            if (switchMenuItem != null)
            {
                switchMenuItem.Text = isAlternating ? Properties.Resources.MenuTextOff : Properties.Resources.MenuTextOn;
                switchMenuItem.Checked = isAlternating;
            }

            if (Properties.Settings.Default.ShowNotifications) showNotification();

            return isAlternating;
        }

        private static void showNotification()
        {
            var notification = Application.OpenForms.OfType<NotificationForm>();
            if (notification.Any()) notification.First().Close();

            NotificationForm notificationForm = new NotificationForm(isAlternating);
            notificationForm.Show();
        }

        private void switchAlternateMenuItem_Click(object sender, EventArgs e)
        {
            SwitchAlternateCaps();
        }

        private void notificationsShowMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowNotifications = notificationsShowMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}