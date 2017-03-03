namespace WCM.ConVPX.Dialogs {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;
	using log4net;
	using WCM.ConVPX;
	using WCM.ConVPX.Core;
	using WCM.ConVPX.Model;
	using WCM.ConVPX.Properties;

	public class RetryJobsDialog : DialogBase {
		private List<ConVpxJobInfo> _availJobs;
		private DoRetryJobsTask _worker;
		public static int BALLOON_DURATION = 0x1388;
		private Button CancelButton2;
		private LinkLabel ClearAllLinkLabel;
		private IContainer components = null;
		private FlowLayoutPanel flowLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel2;
		private FlowLayoutPanel flowLayoutPanel3;
		private readonly ToolTip InvalidParamToolTip;
		private ListView jobsListView;
		private Label label1;
		private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		public Button OKButton2;
		private LinkLabel SelectAllLinkLabel;
		private int sortColumn;
		private TableLayoutPanel tableLayoutPanel1;

		public RetryJobsDialog() {
			this.sortColumn = -1;
			this.InitializeComponent();
			this.InitializeListView();
			this.InvalidParamToolTip = new ToolTip();
			this.InvalidParamToolTip.IsBalloon = true;
			this.InvalidParamToolTip.ToolTipIcon = ToolTipIcon.Warning;
			this.InvalidParamToolTip.ToolTipTitle = Messages.INVALID_ACTION;
		}

		public RetryJobsDialog(List<ConVpxJobInfo> availJobs) : this() {
			this.AvailableJobs = availJobs;
		}

		public void Build() {
			this.jobsListView.Items.Clear();
			this.BuildJobsList();
		}

		public void BuildJobsList() {
			try {
				if (this.AvailableJobs != null) {
					foreach (ConVpxJobInfo info in this.AvailableJobs) {
						try {
							ListViewItem item = new ListViewItem(info.Title, 0) {
								Tag = info,
								Checked = false
							};
							item.SubItems.Add(info.JobId);
							this.jobsListView.Items.Add(item);
						}
						catch (Exception exception) {
							LOG.Error(exception.Message);
						}
					}
					this.jobsListView.Columns[0].Width = -2;
					this.jobsListView.Columns[1].Width = -2;
				}
			}
			catch {
			}
		}

		private void CancelButton2_Click(object sender, EventArgs e) {
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void ClearAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			foreach (ListViewItem item in this.jobsListView.Items) {
				item.Checked = false;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && (this.components != null)) {
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool HasCheckedJob() {
			foreach (ListViewItem item in this.jobsListView.Items) {
				if (item.Checked) {
					return true;
				}
			}
			return false;
		}

		private void InitializeComponent() {
			ComponentResourceManager resources = new ComponentResourceManager(typeof(RetryJobsDialog));
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.label1 = new Label();
			this.flowLayoutPanel2 = new FlowLayoutPanel();
			this.CancelButton2 = new Button();
			this.OKButton2 = new Button();
			this.flowLayoutPanel3 = new FlowLayoutPanel();
			this.SelectAllLinkLabel = new LinkLabel();
			this.ClearAllLinkLabel = new LinkLabel();
			this.jobsListView = new ListView();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.jobsListView, 0, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
			this.flowLayoutPanel2.Controls.Add(this.CancelButton2);
			this.flowLayoutPanel2.Controls.Add(this.OKButton2);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			resources.ApplyResources(this.CancelButton2, "CancelButton2");
			this.CancelButton2.CausesValidation = false;
			this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton2.Name = "CancelButton2";
			this.CancelButton2.UseVisualStyleBackColor = true;
			this.CancelButton2.Click += new EventHandler(this.CancelButton2_Click);
			resources.ApplyResources(this.OKButton2, "OKButton2");
			this.OKButton2.Name = "OKButton2";
			this.OKButton2.UseVisualStyleBackColor = true;
			this.OKButton2.Click += new EventHandler(this.OKButton2_Click);
			this.flowLayoutPanel3.Controls.Add(this.SelectAllLinkLabel);
			this.flowLayoutPanel3.Controls.Add(this.ClearAllLinkLabel);
			resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			resources.ApplyResources(this.SelectAllLinkLabel, "SelectAllLinkLabel");
			this.SelectAllLinkLabel.Name = "SelectAllLinkLabel";
			this.SelectAllLinkLabel.TabStop = true;
			this.SelectAllLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.SelectAllLinkLabel_LinkClicked);
			resources.ApplyResources(this.ClearAllLinkLabel, "ClearAllLinkLabel");
			this.ClearAllLinkLabel.Name = "ClearAllLinkLabel";
			this.ClearAllLinkLabel.TabStop = true;
			this.ClearAllLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.ClearAllLinkLabel_LinkClicked);
			resources.ApplyResources(this.jobsListView, "jobsListView");
			this.jobsListView.Name = "jobsListView";
			this.jobsListView.UseCompatibleStateImageBehavior = false;
			this.jobsListView.ColumnClick += new ColumnClickEventHandler(this.jobsListView_ColumnClick);
			this.jobsListView.ItemChecked += new ItemCheckedEventHandler(this.jobsListView_ItemChecked);
			base.AcceptButton = this.OKButton2;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.CancelButton2;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.HelpButton = false;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "RetryJobsDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void InitializeListView() {
			this.jobsListView.View = View.Details;
			this.jobsListView.LabelEdit = false;
			this.jobsListView.AllowColumnReorder = false;
			this.jobsListView.CheckBoxes = true;
			this.jobsListView.FullRowSelect = true;
			this.jobsListView.GridLines = true;
			this.jobsListView.Sorting = SortOrder.Ascending;
			this.jobsListView.Columns.Add(Messages.JOB_NAME, -2, HorizontalAlignment.Left);
			this.jobsListView.Columns.Add(Messages.JOB_ID, -2, HorizontalAlignment.Left);
			this.jobsListView.Columns[0].Width = -2;
			this.jobsListView.Columns[1].Width = -2;
			ImageList list = new ImageList();
			ImageList list2 = new ImageList();
			list.Images.Add(Resources.job_status_default_16);
			list2.Images.Add(Resources.virtual_machine_24);
			this.jobsListView.LargeImageList = list2;
			this.jobsListView.SmallImageList = list;
		}

		private void jobsListView_ColumnClick(object sender, ColumnClickEventArgs e) {
			try {
				if (e.Column != this.sortColumn) {
					this.sortColumn = e.Column;
					this.jobsListView.Sorting = SortOrder.Ascending;
				}
				else if (this.jobsListView.Sorting == SortOrder.Ascending) {
					this.jobsListView.Sorting = SortOrder.Descending;
				}
				else {
					this.jobsListView.Sorting = SortOrder.Ascending;
				}
				this.jobsListView.Sort();
				this.jobsListView.ListViewItemSorter = new ListViewItemComparer(e.Column, this.jobsListView.Sorting);
			}
			catch {
			}
		}

		private void jobsListView_ItemChecked(object sender, ItemCheckedEventArgs e) {
			this.OKButton2.Enabled = this.HasCheckedJob();
		}

		private void OKButton2_Click(object sender, EventArgs e) {
			List<ConVpxJobInfo> selectedJobsToCancel = this.SelectedJobsToCancel;
			if (selectedJobsToCancel.Count > 0) {
				this._worker = new DoRetryJobsTask(Program.ClientConnection, selectedJobsToCancel);
				this._worker.Completed += new RetryJobsCompletedEventHandler(this.worker_Completed);
				this._worker.Start();
				base.DialogResult = DialogResult.Yes;
				base.Close();
			}
			else {
				ShowBalloonMessage(this.jobsListView, Messages.NO_JOBS_SELECTED, this.InvalidParamToolTip);
			}
		}

		protected override void OnClosing(CancelEventArgs e) {
			this.InvalidParamToolTip.Dispose();
			base.OnClosing(e);
			base.Dispose();
			Helpers.retryJobsDialog = null;
		}

		protected override void OnShown(EventArgs e) {
			if (this.jobsListView.CanSelect) {
				this.jobsListView.Focus();
			}
			base.OnShown(e);
		}

		private void SelectAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			foreach (ListViewItem item in this.jobsListView.Items) {
				item.Checked = true;
			}
		}

		public static void ShowBalloonMessage(Control control, string caption, ToolTip toolTip) {
			toolTip.IsBalloon = true;
			toolTip.Active = true;
			toolTip.SetToolTip(control, caption);
			toolTip.Show(caption, control, BALLOON_DURATION);
		}

		private void worker_Completed(object sender, EventArgs e) {
			Program.JobPollManager.RequestImmediateUpdate();
			if (this._worker != null) {
				this._worker.Completed -= new RetryJobsCompletedEventHandler(this.worker_Completed);
			}
		}

		public List<ConVpxJobInfo> AvailableJobs {
			get {
				return this._availJobs;
			}
			set {
				this._availJobs = value;
				this.Build();
			}
		}

		internal override string HelpName {
			get {
				return "RetryJobsDialog";
			}
		}

		public List<ConVpxJobInfo> SelectedJobsToCancel {
			get {
				List<ConVpxJobInfo> list = new List<ConVpxJobInfo>();
				try {
					foreach (ListViewItem item in this.jobsListView.Items) {
						if (item.Checked) {
							ConVpxJobInfo tag = (ConVpxJobInfo)item.Tag;
							list.Add(tag);
						}
					}
				}
				catch {
				}
				return list;
			}
		}

		private class ListViewItemComparer : IComparer {
			private int col;
			private SortOrder order;

			public ListViewItemComparer() {
				this.col = 0;
				this.order = SortOrder.Ascending;
			}

			public ListViewItemComparer(int column, SortOrder order) {
				this.col = column;
				this.order = order;
			}

			public int Compare(object x, object y) {
				int num = -1;
				try {
					num = string.Compare(((ListViewItem)x).SubItems[this.col].Text, ((ListViewItem)y).SubItems[this.col].Text);
					if (this.order == SortOrder.Descending) {
						num *= -1;
					}
				}
				catch {
				}
				return num;
			}
		}
	}
}

