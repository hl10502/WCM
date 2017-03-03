namespace WCM.ConVPX.Controls {
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;

	public partial class NetworkOptionsControl : UserControl {
		
		private System.ComponentModel.IContainer components = null;

		public NetworkOptionsControl() {
			this.InitializeComponent();
		}
		
		protected override void Dispose(bool disposing) {
			if (disposing && (this.components != null)) {
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent() {
			ComponentResourceManager resources = new ComponentResourceManager(typeof(NetworkOptionsControl));
			this.m_dataGridView = new DataGridView();
			this.ColumnVMwareNetworkName = new DataGridViewTextBoxColumn();
			this.ColumnXenServerNetworkName = new DataGridViewComboBoxColumn();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.cboPreserveMAC = new CheckBox();
			this.label1 = new Label();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			((ISupportInitialize)this.m_dataGridView).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.m_dataGridView.AllowUserToAddRows = false;
			this.m_dataGridView.AllowUserToDeleteRows = false;
			this.m_dataGridView.AllowUserToResizeRows = false;
			this.m_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.m_dataGridView.BackgroundColor = SystemColors.Window;
			this.m_dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
			this.m_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dataGridView.Columns.AddRange(new DataGridViewColumn[] { this.ColumnVMwareNetworkName, this.ColumnXenServerNetworkName });
			this.m_dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
			resources.ApplyResources(this.m_dataGridView, "m_dataGridView");
			this.m_dataGridView.Name = "m_dataGridView";
			this.m_dataGridView.RowHeadersVisible = false;
			this.m_dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.m_dataGridView.Size = new Size(500, 210);
			this.ColumnVMwareNetworkName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			resources.ApplyResources(this.ColumnVMwareNetworkName, "ColumnVMwareNetworkName");
			this.ColumnVMwareNetworkName.Name = "ColumnVMwareNetworkName";
			this.ColumnVMwareNetworkName.ReadOnly = true;
			this.ColumnVMwareNetworkName.Resizable = DataGridViewTriState.True;
			this.ColumnXenServerNetworkName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnXenServerNetworkName.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
			this.ColumnXenServerNetworkName.FlatStyle = FlatStyle.Flat;
			resources.ApplyResources(this.ColumnXenServerNetworkName, "ColumnXenServerNetworkName");
			this.ColumnXenServerNetworkName.Name = "ColumnXenServerNetworkName";
			this.ColumnXenServerNetworkName.Resizable = DataGridViewTriState.True;
			this.ColumnXenServerNetworkName.SortMode = DataGridViewColumnSortMode.Automatic;
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.m_dataGridView, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.cboPreserveMAC, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.cboPreserveMAC, "cboPreserveMAC");
			this.cboPreserveMAC.Size = new Size(200, 30);
			this.cboPreserveMAC.AutoSize = false;
			this.cboPreserveMAC.Name = "cboPreserveMAC";
			this.cboPreserveMAC.UseVisualStyleBackColor = true;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Size = new Size(500, 60);
			this.label1.AutoSize = false;
			this.label1.Name = "label1";
			this.dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.True;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.tableLayoutPanel1.Size = new Size(580, 300);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "NetworkOptionsControl";
			((ISupportInitialize)this.m_dataGridView).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}

		public bool PreserveMAC {
			get {
				return this.cboPreserveMAC.Checked;
			}
		}

		public DataGridView TheDataGridView {
			get {
				return this.m_dataGridView;
			}
		}

		private CheckBox cboPreserveMAC;
		private DataGridViewTextBoxColumn ColumnVMwareNetworkName;
		private DataGridViewComboBoxColumn ColumnXenServerNetworkName;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private Label label1;
		private DataGridView m_dataGridView;
		private TableLayoutPanel tableLayoutPanel1;
	}
}

