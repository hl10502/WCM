namespace WCM.ConVPX.Wizards.ConversionWizard {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;
	using WCM.ConVPX;
	using WCM.ConVPX.Controls;
	using WCM.ConVPX.Core;
	using WCM.ConVPX.Wizards;
	using CookComputing.XmlRpc;
	using ExportImport.CommonTypes;
	using log4net;
	using WinAPI;
	using WCM.XenAdmin.Controls;
	using WCM.XenAdmin.Wizards;
	using System.Drawing;

	public class NetworkOptionsWizardPage : XenTabPage, IWizardPage {

		private System.ComponentModel.IContainer components = null;

		private MethodInvoker _updateWizardButtons;
		private NetworkInstance[] _vmwareNetworks;
		private Network _xsDefaultNetwork;
		private Dictionary<XenRef<Network>, Network> _xsNetworks;
		private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private NetworkOptionsControl networkOptionsControl1;

		public NetworkOptionsWizardPage() {
			this.InitializeComponent();
		}

		public void Build() {
			List<ToStringWrapper<NetworkInstance>> list = new List<ToStringWrapper<NetworkInstance>>();
			new List<ToStringWrapper<Network>>();
			try {
				this.networkOptionsControl1.TheDataGridView.Rows.Clear();
				if (this.VMwareNetworks != null) {
					foreach (NetworkInstance instance in this.VMwareNetworks) {
						NetworkInstance item = instance;
						ToStringWrapper<NetworkInstance> wrapper = new ToStringWrapper<NetworkInstance>(item, item.Name);
						list.Add(wrapper);
					}
				}
				foreach (ToStringWrapper<NetworkInstance> wrapper2 in list) {
					DataGridViewRow dataGridViewRow = new DataGridViewRow();
					DataGridViewTextBoxCell dataGridViewCell = new DataGridViewTextBoxCell {
						Tag = wrapper2,
						Value = wrapper2.ToString()
					};
					dataGridViewRow.Cells.Add(dataGridViewCell);
					DataGridViewComboBoxCell cell3 = (DataGridViewComboBoxCell)this.FillGridComboBox().Clone();
					if (cell3.Items.Count > 0) {
						cell3.DisplayMember = "ToStringProperty";
						cell3.ValueMember = "Self";
						cell3.Value = cell3.Items[this.GetDefaultIndex()];
						dataGridViewRow.Cells.Add(cell3);
					}
					else {
						DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell {
							Value = Messages.WIZARD_SELECT_NETWORK_PAGE_NO_AVAIL_NETWORKS
						};
						dataGridViewRow.Cells.Add(cell4);
						cell4.ReadOnly = true;
					}
					this.networkOptionsControl1.TheDataGridView.Rows.Add(dataGridViewRow);
				}
			}
			catch (Exception exception) {
				LOG.Error(exception, exception);
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && (this.components != null)) {
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public override bool EnableFinish() {
			return false;
		}

		public override bool EnableNext() {
			return true;
		}

		public override bool EnablePrevious() {
			return true;
		}

		private DataGridViewComboBoxCell FillGridComboBox() {
			DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell {
				FlatStyle = FlatStyle.Flat
			};
			if (this.XenServerNetworks != null) {
				foreach (KeyValuePair<XenRef<Network>, Network> pair in this.XenServerNetworks) {
					try {
						Network item = pair.Value;
						ToStringWrapper<Network> wrapper = new ToStringWrapper<Network>(item, item.name_label);
						if (!cell.Items.Contains(wrapper)) {
							cell.Items.Add(wrapper);
						}
					}
					catch (Exception exception) {
						LOG.Error(exception.Message);
					}
				}
			}
			return cell;
		}

		private int GetDefaultIndex() {
			if ((this.XenServerNetworks != null) && (this.DefaultXenServerNetwork != null)) {
				int num2 = 0;
				foreach (KeyValuePair<XenRef<Network>, Network> pair in this.XenServerNetworks) {
					try {
						if (pair.Value.uuid.Equals(this.DefaultXenServerNetwork.uuid)) {
							return num2;
						}
						num2++;
					}
					catch (Exception exception) {
						LOG.Error(exception.Message);
					}
				}
			}
			return 0;
		}

		private void InitializeComponent() {
			ComponentResourceManager manager = new ComponentResourceManager(typeof(NetworkOptionsWizardPage));
			this.networkOptionsControl1 = new NetworkOptionsControl();
			base.SuspendLayout();
			manager.ApplyResources(this.networkOptionsControl1, "networkOptionsControl1");
			this.networkOptionsControl1.Name = "networkOptionsControl1";
			manager.ApplyResources(this, "$this");
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.networkOptionsControl1);
			this.HelpID = "NetworkOptionsWizard";
			base.Name = "NetworkOptionsWizardPage";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void OnPageExit(WizardProgressEventArgs e) {
		}

		public void OnPageShow(WizardProgressEventArgs e) {
			this._updateWizardButtons();
		}

		public Network DefaultXenServerNetwork {
			get {
				return this._xsDefaultNetwork;
			}
			set {
				this._xsDefaultNetwork = value;
				this.Build();
			}
		}

		public XmlRpcStruct NetworkMappings {
			get {
				XmlRpcStruct struct2 = new XmlRpcStruct();
				foreach (DataGridViewRow row in (IEnumerable)this.networkOptionsControl1.TheDataGridView.Rows) {
					struct2.Add(((ToStringWrapper<NetworkInstance>)row.Cells[0].Tag).ToString(), (row.Cells[1].Value as ToStringWrapper<Network>).ToString());
				}
				return struct2;
			}
		}

		public override string PageTitle {
			get {
				return Messages.WIZARD_NETWORK_OPTIONS_TITLE;
			}
		}

		public bool PreserveMAC {
			get {
				return this.networkOptionsControl1.PreserveMAC;
			}
		}

		public override string Text {
			get {
				return Messages.WIZARD_NETWORK_OPTIONS_TEXT;
			}
		}

		public MethodInvoker UpdateWizardButtons {
			get {
				return this._updateWizardButtons;
			}
			set {
				this._updateWizardButtons = value;
			}
		}

		public NetworkInstance[] VMwareNetworks {
			get {
				return this._vmwareNetworks;
			}
			set {
				this._vmwareNetworks = value;
			}
		}

		public Dictionary<XenRef<Network>, Network> XenServerNetworks {
			get {
				return this._xsNetworks;
			}
			set {
				this._xsNetworks = value;
			}
		}
	}
}

