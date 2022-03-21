using Timer = System.Windows.Forms.Timer;

namespace AlternatingCaps
{
    /// <summary>
    /// The notification form
    /// </summary>
    public partial class NotificationForm : Form
    {
        private Timer timer = new Timer();

        /// <summary>
        /// Notification form constructor
        /// </summary>
        public NotificationForm(bool isAlternating)
        {
            InitializeComponent();
            updateStatus(isAlternating);

            timer.Tick += new EventHandler(onTimedEvent);
            timer.Interval = Properties.Settings.Default.NotificationTimerDuration;
            timer.Enabled = true;
        }

        /// <summary>
        /// Show the notification in the lower right corner of the screen
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            var screen = Screen.FromPoint(this.Location);
            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Bottom - this.Height);
            base.OnLoad(e);
        }

        private void updateStatus(bool isAlternating)
        {
            if (isAlternating)
            {
                this.BackColor = Color.PaleGreen;
                notificationText.Text =Properties.Resources.StatusTextOn;
                pictureBox.Image = Properties.Resources.LogoOn40;
            }
            else
            {
                this.BackColor = Color.LightCoral;
                notificationText.Text = Properties.Resources.StatusTextOff;
                pictureBox.Image = Properties.Resources.LogoOff40;
            }
        }

        /// <summary>
        /// Close the form automatically
        /// </summary>
        private void onTimedEvent(object source, EventArgs e)
        {
            this.Close();
            timer.Stop();
        }
    }
}