namespace WCM.ConVPX.Wizards.ConversionWizard
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;
	using ExportImport.CommonTypes;
	using log4net;
	using WCM.ConVPX;
	using WCM.ConVPX.Core;
	using WCM.ConVPX.Properties;
	using WCM.ConVPX.Wizards;
	using WCM.XenAdmin.Controls;
	using WCM.XenAdmin.Wizards;
	using WinAPI;

    public class CredentialWizardPage : XenTabPage, IWizardPage
    {
        private List<WinAPI.SR> _availSRs;
        private List<VmInstance> _availVMs;
        private DoCollectSetupDataTask _dataCollectionWorker;
        private WinAPI.SR _defaultSR;
        private Dictionary<WinAPI.SR, long> _diskSpaceDict;
        private string _hostname;
		private string _userName;
        private string _password;
        private MethodInvoker _updateWizardButtons;
        private bool _validToAdvance;
        private ServerInfo _vmwareCredInfo;
        private NetworkInstance[] _vmwareNetworks;
        private Network _xsDefaultNetwork;
        private Dictionary<XenRef<Network>, Network> _xsNetworks;
        private PictureBox CheckPicBox;
        private IContainer components = null;
        private Button ConnectButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labelError;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected PictureBox pictureBoxError;
        private ProgressBar progressBar1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox VMwareGroupBox;
        private TextBox VMwarePassTextBox;
        private ComboBox VMwareServerComboBox;
        private TextBox VMwareUserTextBox;
        private Label waitMessageValueLabel;

        public CredentialWizardPage()
        {
            this.InitializeComponent();
            this.Build();
        }

        private void Build()
        {
            bool flag = false;
            try
            {
                StringCollection vMwareHosts = ConVPX.Settings.GetVMwareHosts();
                if (vMwareHosts.Count > 0)
                {
                    foreach (string str in vMwareHosts)
                    {
                        this.VMwareServerComboBox.Items.Add(str);
                        flag = true;
                    }
                    if (flag)
                    {
                        this.VMwareServerComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
            }
        }

        public void CleanupAfterCollectSetupData()
        {
            try
            {
                if (this._dataCollectionWorker != null)
                {
                    this._dataCollectionWorker.StopTask();
                    this._dataCollectionWorker.Completed -= new CollectSetupDataCompletedEventHandler(this.worker_Completed);
                }
            }
            catch
            {
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (Program.ClientConnection != null)
            {
                this.LabelError.Visible = false;
                this.PictureBoxError.Visible = false;
                this.CheckPicBox.Visible = false;
                this.VMwareGroupBox.Enabled = false;
                this._validToAdvance = false;
                this.UpdateValidToAdvance();
                this.CleanupAfterCollectSetupData();
               
                this._vmwareCredInfo = new ServerInfo();
                this._vmwareCredInfo.ServerType = 2;
				this._vmwareCredInfo.Hostname = this.Hostname;
				this._vmwareCredInfo.Username = this.Username;
				this._vmwareCredInfo.Password = this.Password;
                this._dataCollectionWorker = new DoCollectSetupDataTask(Program.ClientConnection, Program.XenServerHostInfo, this._vmwareCredInfo);
                this._dataCollectionWorker.Completed += new CollectSetupDataCompletedEventHandler(this.worker_Completed);
                this._dataCollectionWorker.Start();
                this.waitMessageValueLabel.Text = Messages.WIZARD_CONNECTION_ATTEMPT_MESSAGE;
                this.flowLayoutPanel2.Visible = true;
                this.progressBar1.Visible = true;
                this.UpdateConnectButtonEnablement();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public override bool EnableFinish()
        {
            return false;
        }

        public override bool EnableNext()
        {
            return this._validToAdvance;
        }

        public override bool EnablePrevious()
        {
            return false;
        }

        public void HideAllStatusErrorFields()
        {
            this.LabelError.Visible = false;
            this.PictureBoxError.Visible = false;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(CredentialWizardPage));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.VMwareGroupBox = new GroupBox();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.label3 = new Label();
            this.label4 = new Label();
            this.VMwareUserTextBox = new TextBox();
            this.VMwarePassTextBox = new TextBox();
            this.label5 = new Label();
            this.VMwareServerComboBox = new ComboBox();
            this.ConnectButton = new Button();
            this.tableLayoutPanel3 = new TableLayoutPanel();
            this.pictureBoxError = new PictureBox();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.labelError = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.flowLayoutPanel2 = new FlowLayoutPanel();
            this.progressBar1 = new ProgressBar();
            this.tableLayoutPanel4 = new TableLayoutPanel();
            this.CheckPicBox = new PictureBox();
            this.flowLayoutPanel3 = new FlowLayoutPanel();
            this.waitMessageValueLabel = new Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.VMwareGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxError).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((ISupportInitialize) this.CheckPicBox).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            base.SuspendLayout();
            manager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.VMwareGroupBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            manager.ApplyResources(this.VMwareGroupBox, "VMwareGroupBox");
            this.VMwareGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.VMwareGroupBox.Name = "VMwareGroupBox";
            this.VMwareGroupBox.TabStop = false;
            manager.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.VMwareUserTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.VMwarePassTextBox, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.VMwareServerComboBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.ConnectButton, 1, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            manager.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            manager.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            manager.ApplyResources(this.VMwareUserTextBox, "VMwareUserTextBox");
            this.VMwareUserTextBox.Name = "VMwareUserTextBox";
            this.VMwareUserTextBox.TextChanged += new EventHandler(this.VMwareUserTextBox_TextChanged);
            manager.ApplyResources(this.VMwarePassTextBox, "VMwarePassTextBox");
            this.VMwarePassTextBox.Name = "VMwarePassTextBox";
            this.VMwarePassTextBox.UseSystemPasswordChar = true;
            this.VMwarePassTextBox.TextChanged += new EventHandler(this.VMwarePassTextBox_TextChanged);
            manager.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.VMwareServerComboBox.FormattingEnabled = true;
            manager.ApplyResources(this.VMwareServerComboBox, "VMwareServerComboBox");
            this.VMwareServerComboBox.Name = "VMwareServerComboBox";
            this.VMwareServerComboBox.SelectedIndexChanged += new EventHandler(this.VMwareServerComboBox_SelectedIndexChanged);
            this.VMwareServerComboBox.TextChanged += new EventHandler(this.VMwareServerComboBox_TextChanged);
            manager.ApplyResources(this.ConnectButton, "ConnectButton");
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new EventHandler(this.ConnectButton_Click);
            manager.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.pictureBoxError, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            manager.ApplyResources(this.pictureBoxError, "pictureBoxError");
            this.pictureBoxError.Image = Resources._000_error_h32bit_16;
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.TabStop = false;
            this.flowLayoutPanel1.Controls.Add(this.labelError);
            manager.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            manager.ApplyResources(this.labelError, "labelError");
            this.labelError.Name = "labelError";
            manager.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            manager.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.flowLayoutPanel2.Controls.Add(this.progressBar1);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel4);
            manager.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            manager.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            manager.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.CheckPicBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.CheckPicBox.Image = Resources.check16;
            manager.ApplyResources(this.CheckPicBox, "CheckPicBox");
            this.CheckPicBox.Name = "CheckPicBox";
            this.CheckPicBox.TabStop = false;
            this.flowLayoutPanel3.Controls.Add(this.waitMessageValueLabel);
            manager.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            manager.ApplyResources(this.waitMessageValueLabel, "waitMessageValueLabel");
            this.waitMessageValueLabel.Name = "waitMessageValueLabel";
            manager.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            this.HelpID = "CredentialWizard";
            base.Name = "CredentialWizardPage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.VMwareGroupBox.ResumeLayout(false);
            this.VMwareGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((ISupportInitialize) this.pictureBoxError).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((ISupportInitialize) this.CheckPicBox).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            base.ResumeLayout(false);
        }

        public void OnPageExit(WizardProgressEventArgs e)
        {
        }

        public void OnPageShow(WizardProgressEventArgs e)
        {
            this._updateWizardButtons();
        }

        public void SaveToSettings()
        {
            try
            {
                StringCollection toStoreList = new StringCollection();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                if (this.VMwareServerComboBox.Items.Count > 0)
                {
                    foreach (object obj2 in this.VMwareServerComboBox.Items)
                    {
                        dictionary.Add((string) obj2, (string) obj2);
                    }
                }
                if ((this.VMwareServerComboBox.Text.Trim().Length > 0) && !dictionary.ContainsKey(this.VMwareServerComboBox.Text.Trim()))
                {
                    dictionary.Add(this.VMwareServerComboBox.Text.Trim(), this.VMwareServerComboBox.Text.Trim());
                }
                foreach (KeyValuePair<string, string> pair in dictionary)
                {
                    toStoreList.Add(pair.Key);
                }
                if (toStoreList.Count > 0)
                {
                    ConVPX.Settings.SetVMwareHosts(toStoreList);
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }

        public void UpdateConnectButtonEnablement()
        {
            if ((this.Hostname.Length > 0) && (this.Username.Length > 0))
            {
				this.ConnectButton.Enabled = true;
				if (!this.Hostname.Equals(this._hostname) || !this.Username.Equals(this._userName) || !this.Password.Equals(this._password)) {
					this._validToAdvance = false;
				}
				else {
					this._validToAdvance = true;
				}
            }
            else
            {
                this.ConnectButton.Enabled = false;
				this._validToAdvance = false;
            }

            this.UpdateValidToAdvance();
        }

        public void UpdateValidToAdvance()
        {
            this._updateWizardButtons();
        }

        private void VMwarePassTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateConnectButtonEnablement();
        }

        private void VMwareServerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateConnectButtonEnablement();
        }

        private void VMwareServerComboBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateConnectButtonEnablement();
        }

        private void VMwareUserTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateConnectButtonEnablement();
        }

        private void worker_Completed(object sender, EventArgs e)
        {
            Program.Invoke(Program.MainWindow, new EventHandler<CollectSetupDataCompletedEventArgs>(this.worker_Completed_), new object[] { sender, e });
        }

        private void worker_Completed_(object sender, EventArgs e)
        {
            CollectSetupDataCompletedEventArgs args = e as CollectSetupDataCompletedEventArgs;
            try
            {
                this.VMwareGroupBox.Enabled = true;
                if (!args.FailedCollectSetupData)
                {
					this._hostname = this.Hostname;
					this._userName = this.Username;
					this._password = this.Password;

					this.CheckPicBox.Visible = true;
                    this.waitMessageValueLabel.Text = string.Format(Messages.WIZARD_CONNECTION_SUCCESS_MESSAGE, this.Hostname);
                    this.AvailableStorageRepositories = args.AvailableStorageRepositories;
                    this.DefaultStorageRepository = args.DefaultStorageRepository;
                    this.AvailableVirtualMachines = args.AvailableVirtualMachines;
                    this.OtherUsedDiskSpaceDict = args.OtherUsedDiskSpaceDict;
                    this.VMwareNetworks = args.VMwareNetworks;
                    this.XenServerNetworks = args.XenServerNetworks;
                    this.DefaultXenServerNetwork = args.DefaultXenServerNetwork;
                    this._validToAdvance = true;
                    this.UpdateValidToAdvance();
                }
                else
                {
					this._hostname = "";
					this._userName = "";
					this._password = "";

					this._validToAdvance = false;
                    this.UpdateValidToAdvance();
                    this.flowLayoutPanel2.Visible = false;
                    this.LabelError.Text = args.FriendlyExceptionMessage;
                    this.LabelError.Visible = true;
                    this.PictureBoxError.Visible = true;
                    LOG.Error(args.CollectSetupDataException, args.CollectSetupDataException);
                }
            }
            catch
            {
            }
            this.progressBar1.Visible = false;
            this.CleanupAfterCollectSetupData();
            this.UpdateConnectButtonEnablement();
        }

        public List<WinAPI.SR> AvailableStorageRepositories
        {
            get
            {
                return this._availSRs;
            }
            set
            {
                this._availSRs = value;
            }
        }

        public List<VmInstance> AvailableVirtualMachines
        {
            get
            {
                return this._availVMs;
            }
            set
            {
                this._availVMs = value;
            }
        }

        public WinAPI.SR DefaultStorageRepository
        {
            get
            {
                return this._defaultSR;
            }
            set
            {
                try
                {
                    this._defaultSR = value;
                }
                catch
                {
                    this._defaultSR = null;
                }
            }
        }

        public Network DefaultXenServerNetwork
        {
            get
            {
                return this._xsDefaultNetwork;
            }
            set
            {
                this._xsDefaultNetwork = value;
            }
        }

        public string Hostname
        {
            get
            {
                return this.VMwareServerComboBox.Text.Trim();
            }
        }

        public Label LabelError
        {
            get
            {
                return this.labelError;
            }
        }

        public Dictionary<WinAPI.SR, long> OtherUsedDiskSpaceDict
        {
            get
            {
                return this._diskSpaceDict;
            }
            set
            {
                this._diskSpaceDict = value;
            }
        }

        public override string PageTitle
        {
            get
            {
                return "请输入连接的VMware信息";
            }
        }

        public string Password
        {
            get
            {
                return this.VMwarePassTextBox.Text.Trim();
            }
        }

        public PictureBox PictureBoxError
        {
            get
            {
                return this.pictureBoxError;
            }
        }

        public override string Text
        {
            get
            {
				return "连接VMware"; //Credentials
            }
        }

        public MethodInvoker UpdateWizardButtons
        {
            get
            {
                return this._updateWizardButtons;
            }
            set
            {
                this._updateWizardButtons = value;
            }
        }

        public string Username
        {
            get
            {
                return this.VMwareUserTextBox.Text.Trim();
            }
        }

        public NetworkInstance[] VMwareNetworks
        {
            get
            {
                return this._vmwareNetworks;
            }
            set
            {
                this._vmwareNetworks = value;
            }
        }

        public Dictionary<XenRef<Network>, Network> XenServerNetworks
        {
            get
            {
                return this._xsNetworks;
            }
            set
            {
                this._xsNetworks = value;
            }
        }
    }
}

