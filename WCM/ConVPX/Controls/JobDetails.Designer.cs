namespace WCM.ConVPX.Controls
{
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Model;
    using log4net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
	using System.Reflection;

	partial class JobDetails
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(JobDetails));
            this.JobDetailsHeaderPanel = new PanelWithHeader();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.IdLabel = new Label();
            this.StatusDetailsLabel = new Label();
            this.DestSRLabel = new Label();
            this.NetReadLabel = new Label();
            this.DiskWriteLabel = new Label();
            this.ErrorMessageLabel = new Label();
            this.ErrorMessageValueLabel = new Label();
            this.GetJobLogLinkLabel = new LinkLabel();
            this.ElapsedLabel = new Label();
            this.ElapsedValueLabel = new Label();
            this.JobDetailsHeaderPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();

			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			this.label1.Font = new Font(this.label1.Font, this.label1.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			this.label2.Font = new Font(this.label2.Font, this.label2.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			this.label3.Font = new Font(this.label3.Font, this.label3.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			this.label4.Font = new Font(this.label4.Font, this.label4.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			this.label5.Font = new Font(this.label5.Font, this.label5.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.IdLabel, "IdLabel");
			this.IdLabel.Name = "IdLabel";
			this.IdLabel.Size = new Size(150, 20);

			resources.ApplyResources(this.StatusDetailsLabel, "StatusDetailsLabel");
			this.tableLayoutPanel1.SetColumnSpan(this.StatusDetailsLabel, 2);
			this.StatusDetailsLabel.Name = "StatusDetailsLabel";
			resources.ApplyResources(this.DestSRLabel, "DestSRLabel");
			this.DestSRLabel.Name = "DestSRLabel";
			resources.ApplyResources(this.NetReadLabel, "NetReadLabel");
			this.NetReadLabel.Name = "NetReadLabel";
			resources.ApplyResources(this.DiskWriteLabel, "DiskWriteLabel");
			this.DiskWriteLabel.Name = "DiskWriteLabel";
			resources.ApplyResources(this.ErrorMessageLabel, "ErrorMessageLabel");
			this.ErrorMessageLabel.Name = "ErrorMessageLabel";
			this.ErrorMessageLabel.Font = new Font(this.ErrorMessageLabel.Font, this.ErrorMessageLabel.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.ErrorMessageValueLabel, "ErrorMessageValueLabel");
			this.tableLayoutPanel1.SetColumnSpan(this.ErrorMessageValueLabel, 2);
			this.ErrorMessageValueLabel.Name = "ErrorMessageValueLabel";
			this.ErrorMessageValueLabel.Size = new Size(500, 20);
			resources.ApplyResources(this.GetJobLogLinkLabel, "GetJobLogLinkLabel");
			this.GetJobLogLinkLabel.Name = "GetJobLogLinkLabel";
			this.GetJobLogLinkLabel.TabStop = true;
			this.GetJobLogLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.GetJobLogLinkLabel_LinkClicked);
			resources.ApplyResources(this.ElapsedLabel, "ElapsedLabel");
			this.ElapsedLabel.Name = "ElapsedLabel";
			this.ElapsedLabel.Width = 200;
			this.ElapsedLabel.Font = new Font(this.ElapsedLabel.Font, this.ElapsedLabel.Font.Style | FontStyle.Bold);
			resources.ApplyResources(this.ElapsedValueLabel, "ElapsedValueLabel");
			this.tableLayoutPanel1.SetColumnSpan(this.ElapsedValueLabel, 2);
			this.ElapsedValueLabel.Name = "ElapsedValueLabel";

			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.IdLabel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.StatusDetailsLabel, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.DestSRLabel, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.NetReadLabel, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.DiskWriteLabel, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.ErrorMessageLabel, 0, 13);
			this.tableLayoutPanel1.Controls.Add(this.ErrorMessageValueLabel, 1, 13);
			this.tableLayoutPanel1.Controls.Add(this.GetJobLogLinkLabel, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.ElapsedLabel, 0, 11);
			this.tableLayoutPanel1.Controls.Add(this.ElapsedValueLabel, 1, 11);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Size = new Size(970, 300);

            resources.ApplyResources(this.JobDetailsHeaderPanel, "JobDetailsHeaderPanel");
            this.JobDetailsHeaderPanel.BackColor = Color.White;
            this.JobDetailsHeaderPanel.Controls.Add(this.tableLayoutPanel1);
            this.JobDetailsHeaderPanel.HeaderColor1 = Color.FromArgb(0x59, 0x87, 0xd6);
            this.JobDetailsHeaderPanel.HeaderColor2 = Color.FromArgb(3, 0x38, 0x93);
			this.JobDetailsHeaderPanel.HeaderText = "任务摘要"; //Job Summary
            this.JobDetailsHeaderPanel.Icon = null;
            this.JobDetailsHeaderPanel.IconTransparentColor = Color.White;
            this.JobDetailsHeaderPanel.Name = "JobDetailsHeaderPanel";
			this.JobDetailsHeaderPanel.Dock = DockStyle.Fill;
			this.JobDetailsHeaderPanel.Location = new Point(0, 0);
			this.JobDetailsHeaderPanel.Size = new Size(970, 300);

			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.JobDetailsHeaderPanel);
            base.Name = "JobDetails";
            this.JobDetailsHeaderPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }

		private Label DestSRLabel;
		private Label DiskWriteLabel;
		private Label ElapsedLabel;
		private Label ElapsedValueLabel;
		private Label ErrorMessageLabel;
		private Label ErrorMessageValueLabel;
		private LinkLabel GetJobLogLinkLabel;
		private Label IdLabel;
		private PanelWithHeader JobDetailsHeaderPanel;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label NetReadLabel;
		private Label StatusDetailsLabel;
		private TableLayoutPanel tableLayoutPanel1;
    }
}

