namespace ConVPX.Controls
{
    using ConVPX;
    using ConVPX.Core;
    using ConVPX.Model;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
	using System.Reflection;

    partial class JobSummary {

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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(JobSummary));
            this.JobSummaryHeaderPanel = new PanelWithHeader();
            this.dataGridViewJobs = new DataGridView();
            this.ColumnName = new DataGridViewTextBoxColumn();
            this.ColumnSource = new DataGridViewTextBoxColumn();
            this.ColumnDestination = new DataGridViewTextBoxColumn();
            this.ColumnStatus = new TextAndImageColumn();
            this.ColumnStartTime = new DataGridViewTextBoxColumn();
            this.ColumnCompletedTime = new DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.JobSummaryHeaderPanel.SuspendLayout();
            ((ISupportInitialize) this.dataGridViewJobs).BeginInit();
            base.SuspendLayout();
            this.JobSummaryHeaderPanel.Controls.Add(this.dataGridViewJobs);
            resources.ApplyResources(this.JobSummaryHeaderPanel, "JobSummaryHeaderPanel");
            this.JobSummaryHeaderPanel.HeaderColor1 = Color.FromArgb(0x59, 0x87, 0xd6);
            this.JobSummaryHeaderPanel.HeaderColor2 = Color.FromArgb(3, 0x38, 0x93);
			this.JobSummaryHeaderPanel.HeaderText = "任务"; //Jobs
            this.JobSummaryHeaderPanel.Icon = null;
            this.JobSummaryHeaderPanel.IconTransparentColor = Color.White;
            this.JobSummaryHeaderPanel.Name = "JobSummaryHeaderPanel";
            this.dataGridViewJobs.AllowUserToAddRows = false;
            this.dataGridViewJobs.AllowUserToDeleteRows = false;
            this.dataGridViewJobs.AllowUserToResizeRows = false;
            this.dataGridViewJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewJobs.BackgroundColor = SystemColors.Window;
            this.dataGridViewJobs.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJobs.Columns.AddRange(new DataGridViewColumn[] { this.ColumnName, this.ColumnSource, this.ColumnDestination, this.ColumnStatus, this.ColumnStartTime, this.ColumnCompletedTime });
            resources.ApplyResources(this.dataGridViewJobs, "dataGridViewJobs");
            this.dataGridViewJobs.Name = "dataGridViewJobs";
            this.dataGridViewJobs.ReadOnly = true;
            this.dataGridViewJobs.RowHeadersVisible = false;
            this.dataGridViewJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJobs.SelectionChanged += new EventHandler(this.dataGridViewJobs_SelectionChanged);
            this.dataGridViewJobs.MouseClick += new MouseEventHandler(this.dataGridViewJobs_MouseClick);
            this.ColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnName, "ColumnName");
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnSource, "ColumnSource");
            this.ColumnSource.Name = "ColumnSource";
            this.ColumnSource.ReadOnly = true;
            this.ColumnDestination.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnDestination, "ColumnDestination");
            this.ColumnDestination.Name = "ColumnDestination";
            this.ColumnDestination.ReadOnly = true;
            this.ColumnStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnStatus, "ColumnStatus");
            this.ColumnStatus.Image = null;
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStartTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnStartTime, "ColumnStartTime");
            this.ColumnStartTime.Name = "ColumnStartTime";
            this.ColumnStartTime.ReadOnly = true;
            this.ColumnCompletedTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnCompletedTime, "ColumnCompletedTime");
            this.ColumnCompletedTime.Name = "ColumnCompletedTime";
            this.ColumnCompletedTime.ReadOnly = true;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.JobSummaryHeaderPanel);
            base.Name = "JobSummary";
            base.Load += new EventHandler(this.JobSummary_Load);
            this.JobSummaryHeaderPanel.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridViewJobs).EndInit();
            base.ResumeLayout(false);
        }

		private DataGridViewTextBoxColumn ColumnCompletedTime;
		private DataGridViewTextBoxColumn ColumnDestination;
		private DataGridViewTextBoxColumn ColumnName;
		private DataGridViewTextBoxColumn ColumnSource;
		private DataGridViewTextBoxColumn ColumnStartTime;
		private TextAndImageColumn ColumnStatus;
		private ContextMenuStrip contextMenuStrip1;
		private DataGridView dataGridViewJobs;
		private PanelWithHeader JobSummaryHeaderPanel;

    }
}

