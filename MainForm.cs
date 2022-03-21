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
        private static NotificationForm? notificationForm = null;

        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            trayIcon = this.notifyIcon;
            switchMenuItem = this.switchAlternateMenuItem;

            notificationsShowMenuItem.Checked = Properties.Settings.Default.ShowNotifications;
            notificationsPositionToolStripComboBox.SelectedIndex = Properties.Settings.Default.NotificationsHorizontalPosition;
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
            if (notificationForm != null) notificationForm.Close();

            notificationForm = new NotificationForm(isAlternating);
            notificationForm.ShowNotification((FormHorizontalPosition)Properties.Settings.Default.NotificationsHorizontalPosition);
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

        private void notificationsPositionToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NotificationsHorizontalPosition = notificationsPositionToolStripComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}