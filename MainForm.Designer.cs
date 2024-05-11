namespace AlternatingCaps
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.switchAlternateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsPositionToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Alternating Caps (Off)";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchAlternateMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(213, 110);
            // 
            // switchAlternateMenuItem
            // 
            this.switchAlternateMenuItem.CheckOnClick = true;
            this.switchAlternateMenuItem.Name = "switchAlternateMenuItem";
            this.switchAlternateMenuItem.Size = new System.Drawing.Size(212, 24);
            this.switchAlternateMenuItem.Text = "Turn ON (\"End\" Key)";
            this.switchAlternateMenuItem.Click += new System.EventHandler(this.switchAlternateMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notificationsShowMenuItem,
            this.notificationsPositionToolStripComboBox});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // notificationsShowMenuItem
            // 
            this.notificationsShowMenuItem.CheckOnClick = true;
            this.notificationsShowMenuItem.Name = "notificationsShowMenuItem";
            this.notificationsShowMenuItem.Size = new System.Drawing.Size(224, 26);
            this.notificationsShowMenuItem.Text = "Show notifications?";
            this.notificationsShowMenuItem.Click += new System.EventHandler(this.notificationsShowMenuItem_Click);
            // 
            // notificationsPositionToolStripComboBox
            // 
            this.notificationsPositionToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.notificationsPositionToolStripComboBox.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.notificationsPositionToolStripComboBox.MaxDropDownItems = 3;
            this.notificationsPositionToolStripComboBox.Name = "notificationsPositionToolStripComboBox";
            this.notificationsPositionToolStripComboBox.Size = new System.Drawing.Size(134, 28);
            this.notificationsPositionToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.notificationsPositionToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(209, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 121);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Alternating Caps (Off)";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem switchAlternateMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem notificationsShowMenuItem;
        private ToolStripComboBox notificationsPositionToolStripComboBox;
    }
}