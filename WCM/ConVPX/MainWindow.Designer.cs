namespace WCM.ConVPX
{
    using WCM.ConVPX.Controls;
    using WCM.ConVPX.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WCM.XenAdmin.Controls;

    partial class MainWindow
    {
		private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainWindow));
            this.MainMenuBar = new MenuStripEx();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.saveJobSummaryToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.jobsToolStripMenuItem = new ToolStripMenuItem();
            this.clearJobsToolStripMenuItem = new ToolStripMenuItem();
            this.cancelJobsToolStripMenuItem = new ToolStripMenuItem();
            this.retryJobsToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.helpContentsMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.saveSupportLogFilesToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.AboutMenuItem = new ToolStripMenuItem();
            this.MainToolStrip = new ToolStripEx();
            this.ConnectButton = new ToolStripButton();
            this.ConvertButton = new ToolStripButton();
            this.UserAbortJobButton = new ToolStripButton();
            this.MainSplitContainer = new SplitContainer();
			this.jobSummaryControl = new JobSummary();
			this.jobDetails1 = new JobDetails();
            this.MainMenuBar.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.MainSplitContainer.BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            base.SuspendLayout();
            this.MainMenuBar.ClickThrough = false;
            //this.MainMenuBar.Items.AddRange(new ToolStripItem[] { this.fileToolStripMenuItem, this.jobsToolStripMenuItem, this.helpToolStripMenuItem });
			this.MainMenuBar.Items.AddRange(new ToolStripItem[] { this.fileToolStripMenuItem, this.jobsToolStripMenuItem});
            this.MainMenuBar.Location = new Point(0, 0);
            this.MainMenuBar.Name = "MainMenuBar";
            this.MainMenuBar.Size = new Size(970, 0x18);
            this.MainMenuBar.TabIndex = 0;
            this.MainMenuBar.Text = "menuStripEx1";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.saveJobSummaryToolStripMenuItem, this.toolStripSeparator2, this.exitToolStripMenuItem });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(0x25, 20);
			this.fileToolStripMenuItem.Text = "&文件"; //File
            this.saveJobSummaryToolStripMenuItem.Name = "saveJobSummaryToolStripMenuItem";
            this.saveJobSummaryToolStripMenuItem.Size = new Size(0xb6, 0x16);
			this.saveJobSummaryToolStripMenuItem.Text = "&保存任务摘要..."; //Save Job Summary
            this.saveJobSummaryToolStripMenuItem.Click += new EventHandler(this.saveJobSummaryToolStripMenuItem_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(0xb3, 6);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(0xb6, 0x16);
			this.exitToolStripMenuItem.Text = "&退出"; //Exit
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.jobsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.clearJobsToolStripMenuItem, this.cancelJobsToolStripMenuItem, this.retryJobsToolStripMenuItem });
            this.jobsToolStripMenuItem.Name = "jobsToolStripMenuItem";
            this.jobsToolStripMenuItem.Size = new Size(0x2a, 20);
			this.jobsToolStripMenuItem.Text = "&任务"; //Jobs
            this.clearJobsToolStripMenuItem.Name = "clearJobsToolStripMenuItem";
            this.clearJobsToolStripMenuItem.Size = new Size(0x91, 0x16);
			this.clearJobsToolStripMenuItem.Text = "&清除任务"; //Clear Jobs
            this.clearJobsToolStripMenuItem.Click += new EventHandler(this.clearJobsToolStripMenuItem_Click);
            this.cancelJobsToolStripMenuItem.Image = Resources._000_Abort_h32bit_16;
            this.cancelJobsToolStripMenuItem.Name = "cancelJobsToolStripMenuItem";
            this.cancelJobsToolStripMenuItem.Size = new Size(0x91, 0x16);
			this.cancelJobsToolStripMenuItem.Text = "&取消任务..."; //Cancel Jobs
            this.cancelJobsToolStripMenuItem.Click += new EventHandler(this.cancelJobsToolStripMenuItem_Click);
            this.retryJobsToolStripMenuItem.Name = "retryJobsToolStripMenuItem";
            this.retryJobsToolStripMenuItem.Size = new Size(0x91, 0x16);
			this.retryJobsToolStripMenuItem.Text = "&重试任务..."; //Retry Jobs
            this.retryJobsToolStripMenuItem.Click += new EventHandler(this.retryJobsToolStripMenuItem_Click);
			//this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.helpContentsMenuItem, this.toolStripSeparator1, this.saveSupportLogFilesToolStripMenuItem, this.toolStripSeparator3, this.AboutMenuItem });
			//this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			//this.helpToolStripMenuItem.Size = new Size(0x2c, 20);
			//this.helpToolStripMenuItem.Text = "&Help";
			//this.helpContentsMenuItem.Name = "helpContentsMenuItem";
			//this.helpContentsMenuItem.Size = new Size(0x113, 0x16);
			//this.helpContentsMenuItem.Text = "Help &Contents";
			//this.helpContentsMenuItem.Click += new EventHandler(this.helpContentsMenuItem_Click);
			//this.toolStripSeparator1.Name = "toolStripSeparator1";
			//this.toolStripSeparator1.Size = new Size(0x110, 6);
			//this.saveSupportLogFilesToolStripMenuItem.Name = "saveSupportLogFilesToolStripMenuItem";
			//this.saveSupportLogFilesToolStripMenuItem.Size = new Size(0x113, 0x16);
			//this.saveSupportLogFilesToolStripMenuItem.Text = "&Save Support Log Files...";
			//this.saveSupportLogFilesToolStripMenuItem.Click += new EventHandler(this.saveSupportLogFilesToolStripMenuItem_Click);
			//this.toolStripSeparator3.Name = "toolStripSeparator3";
			//this.toolStripSeparator3.Size = new Size(0x110, 6);
			//this.AboutMenuItem.Name = "AboutMenuItem";
			//this.AboutMenuItem.Size = new Size(0x113, 0x16);
			//this.AboutMenuItem.Text = "&About WinServer Conversion Manager";
			//this.AboutMenuItem.Click += new EventHandler(this.AboutMenuItem_Click);
            this.MainToolStrip.ClickThrough = false;
            this.MainToolStrip.Items.AddRange(new ToolStripItem[] { this.ConnectButton, this.ConvertButton, this.UserAbortJobButton });
            this.MainToolStrip.Location = new Point(0, 0x18);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new Size(970, 0x19);
            this.MainToolStrip.TabIndex = 1;
            this.MainToolStrip.Text = "toolStripEx1";
            this.ConnectButton.Image = Resources.xenserver_16;
            this.ConnectButton.ImageTransparentColor = Color.Magenta;
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new Size(0x48, 0x16);
			this.ConnectButton.Text = "连接"; //Connect
            this.ConnectButton.Click += new EventHandler(this.ConnectButton_Click);
            this.ConvertButton.Image = Resources.convert_machine_16;
            this.ConvertButton.ImageTransparentColor = Color.Magenta;
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new Size(0x45, 0x16);
			this.ConvertButton.Text = "转换"; //Convert
            this.ConvertButton.Click += new EventHandler(this.toolStripConvertButton_Click);
            this.UserAbortJobButton.Image = Resources._000_Abort_h32bit_16;
            this.UserAbortJobButton.ImageTransparentColor = Color.Magenta;
            this.UserAbortJobButton.Name = "UserAbortJobButton";
            this.UserAbortJobButton.Size = new Size(0x59, 0x16);
			this.UserAbortJobButton.Text = "取消任务"; //Cancel Jobs
            this.UserAbortJobButton.Click += new EventHandler(this.UserAbortJobButton_Click);

			this.jobSummaryControl.Dock = DockStyle.Fill;
			this.jobSummaryControl.Location = new Point(0, 0);
			this.jobSummaryControl.Name = "jobSummaryControl";
			this.jobSummaryControl.Size = new Size(970, 0x284);
			this.jobSummaryControl.TabIndex = 0;
			this.jobDetails1.Dock = DockStyle.Fill;
			this.jobDetails1.Location = new Point(0, 0);
			this.jobDetails1.Name = "jobDetails1";
			this.jobDetails1.Size = new Size(970, 0x2e);
			this.jobDetails1.TabIndex = 0;

            this.MainSplitContainer.Dock = DockStyle.Fill;
            this.MainSplitContainer.Location = new Point(0, 0x31);
            this.MainSplitContainer.Name = "MainSplitContainer";
			this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.MainSplitContainer.Panel1.Controls.Add(this.jobSummaryControl);
            this.MainSplitContainer.Panel2.Controls.Add(this.jobDetails1);
            this.MainSplitContainer.Panel2Collapsed = true;
            this.MainSplitContainer.Size = new Size(970, 0x284);
            this.MainSplitContainer.SplitterDistance = 0x18b;
            this.MainSplitContainer.TabIndex = 2;
            
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(970, 0x2b5);
            base.Controls.Add(this.MainSplitContainer);
            base.Controls.Add(this.MainToolStrip);
            base.Controls.Add(this.MainMenuBar);
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            //base.Icon = Resources.AppIcon;
            base.MainMenuStrip = this.MainMenuBar;
            base.Name = "MainWindow";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "WinServer Conversion Manager";
            base.Shown += new EventHandler(this.MainWindow_Shown);
            this.MainMenuBar.ResumeLayout(false);
            this.MainMenuBar.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

		private ToolStripMenuItem AboutMenuItem;
		private ToolStripMenuItem cancelJobsToolStripMenuItem;
		private ToolStripMenuItem clearJobsToolStripMenuItem;
		private ToolStripButton ConnectButton;
		private ToolStripButton ConvertButton;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem helpContentsMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private JobDetails jobDetails1;
		private ToolStripMenuItem jobsToolStripMenuItem;
		private JobSummary jobSummaryControl;
		private MenuStripEx MainMenuBar;
		private SplitContainer MainSplitContainer;
		private ToolStripEx MainToolStrip;
		private static Form parentHelpForm;
		private ToolStripMenuItem retryJobsToolStripMenuItem;
		private ToolStripMenuItem saveJobSummaryToolStripMenuItem;
		private ToolStripMenuItem saveSupportLogFilesToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripButton UserAbortJobButton;
    }
}

