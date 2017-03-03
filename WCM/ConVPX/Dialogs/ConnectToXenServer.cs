namespace WCM.ConVPX.Dialogs
{
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Properties;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
	using System.Reflection;

    public class ConnectToXenServer : DialogBase
    {
        private string _applianceVersion = "";
        private ConversionClient _clientConnection;
        private DoConnectTask _connectJobsWorker;
        private ServerInfo _xenServerHostInfo;
        private Dictionary<string, string> _xenServerVersionInfoDict = new Dictionary<string, string>();
        public static int BALLOON_DURATION = 0x1388;
        protected Button btnCancel;
        protected Button btnOK;
        private IContainer components = null;
        protected FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        protected GroupBox groupBox1;
        private readonly ToolTip InvalidParamToolTip;
        protected Label labelError;
        protected Label labelInstructions;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected Label PasswordLabel;
        protected TextBox PasswordTextBox;
        protected PictureBox pictureBoxError;
        private ProgressBar progressBar1;
        protected ComboBox ServerNameComboBox;
        protected Label ServerNameLabel;
        protected TableLayoutPanel tableLayoutPanelCreds;
        protected TableLayoutPanel tableLayoutPanelType;
        protected Label UsernameLabel;
        protected TextBox UsernameTextBox;
        private Label waitMessageValueLabel;

        public ConnectToXenServer()
        {
            this.InitializeComponent();
            this.InvalidParamToolTip = new ToolTip();
            this.InvalidParamToolTip.IsBalloon = true;
            this.InvalidParamToolTip.ToolTipIcon = ToolTipIcon.Warning;
            this.InvalidParamToolTip.ToolTipTitle = Messages.INVALID_PARAMETER;
            this.waitMessageValueLabel.Text = Messages.PLEASE_WAIT_STARTING_APPLIANCE;
            this.Build();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            this.CleanupAfterConnectionAtempt();
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            this.pictureBoxError.Visible = false;
            this.Refresh();
            this.flowLayoutPanel2.Visible = true;
            if (this.isValidToSubmit(true))
            {
                try
                {
                    this.btnOK.Enabled = false;
                    this._xenServerHostInfo = new ServerInfo();
                    this._xenServerHostInfo.ServerType = 0;
                    this._xenServerHostInfo.Hostname = this.ServerNameComboBox.Text.Trim();
                    this._xenServerHostInfo.Username = this.UsernameTextBox.Text.Trim();
                    this._xenServerHostInfo.Password = this.PasswordTextBox.Text.Trim();
                    this._clientConnection = new ConversionClient(ConVPX.Properties.Settings.Default.RequestRegularTimeout, ConVPX.Properties.Settings.Default.RequestCompositeTimeout);
                    this._connectJobsWorker = new DoConnectTask(this._clientConnection, this._xenServerHostInfo);
                    this._connectJobsWorker.Completed += new ConnectCompletedEventHandler(this.connect_worker_Completed);
                    this._connectJobsWorker.Start();
                }
                catch (Exception exception)
                {
                    LOG.Error(exception.Message);
                    this.CleanupAfterConnectionAtempt();
                }
            }
        }

        private void Build()
        {
            bool flag = false;
            try
            {
                StringCollection xenServerHosts = ConVPX.Settings.GetXenServerHosts();
                if (xenServerHosts.Count > 0)
                {
                    foreach (string str in xenServerHosts)
                    {
                        this.ServerNameComboBox.Items.Add(str);
                        flag = true;
                    }
                    if (flag)
                    {
                        this.ServerNameComboBox.SelectedIndex = 0;
                        string selectedXenServerHost = ConVPX.Settings.GetSelectedXenServerHost();
                        if (selectedXenServerHost.Length > 0)
                        {
                            try
                            {
                                this.ServerNameComboBox.SelectedIndex = this.ServerNameComboBox.Items.IndexOf(selectedXenServerHost);
                            }
                            catch
                            {
                                this.ServerNameComboBox.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }

        private void Cleanup()
        {
            this.InvalidParamToolTip.Dispose();
        }

        private void CleanupAfterConnectionAtempt()
        {
            try
            {
                if (this._connectJobsWorker != null)
                {
                    this._connectJobsWorker.StopTask();
                    this._connectJobsWorker.Completed -= new ConnectCompletedEventHandler(this.connect_worker_Completed);
                }
            }
            catch
            {
            }
        }

        private void ClearAll()
        {
            this.UsernameTextBox.Text = "";
            this.PasswordTextBox.Text = "";
        }

        private void connect_worker_Completed(object sender, EventArgs e)
        {
            Program.Invoke(Program.MainWindow, new EventHandler<ConnectCompletedEventArgs>(this.connect_worker_Completed_), new object[] { sender, e });
        }

        private void connect_worker_Completed_(object sender, EventArgs e)
        {
            ConnectCompletedEventArgs args = e as ConnectCompletedEventArgs;
            try
            {
                if (!args.FailedConnect)
                {
                    this._xenServerVersionInfoDict = this._clientConnection.GetXenServerVersionInfo(this._xenServerHostInfo);
                    this._applianceVersion = Commands.GetVersion(this._clientConnection);
                    Program.ClientConnection = this._clientConnection;
                    Program.XenServerHostInfo = this._xenServerHostInfo;
                    Program.XenServerVersionInfoDict = this._xenServerVersionInfoDict;
                    Program.ApplianceVersion = this._applianceVersion;
                    Program.MainWindow.Text = Messages.APPLICATION_NAME + " : [" + Program.ClientConnection.GetXenServerFriendlyName(Program.XenServerHostInfo) + "]";
                    Program.IsApplianceAlive = true;
                    this.SaveToSettings();
                    this.Cleanup();
                    base.DialogResult = DialogResult.Yes;
                    base.Close();
                }
                else
                {
                    this.labelError.Text = Helpers.GetConnectionReason(args.ConnectionException, this.ServerNameComboBox.Text.Trim());
                    this.flowLayoutPanel2.Visible = false;
                    this.labelError.Visible = true;
                    this.pictureBoxError.Visible = true;
                    LOG.Error(args.ConnectionException.Message);
                }
                if (this._connectJobsWorker != null)
                {
                    this._connectJobsWorker.Completed -= new ConnectCompletedEventHandler(this.connect_worker_Completed);
                }
            }
            catch
            {
            }
            this.CleanupAfterConnectionAtempt();
            this.btnOK.Enabled = true;
        }

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ConnectToXenServer));
            this.tableLayoutPanelType = new TableLayoutPanel();
            this.ServerNameComboBox = new ComboBox();
            this.groupBox1 = new GroupBox();
            this.tableLayoutPanelCreds = new TableLayoutPanel();
            this.UsernameLabel = new Label();
            this.PasswordLabel = new Label();
            this.PasswordTextBox = new TextBox();
            this.UsernameTextBox = new TextBox();
            this.labelError = new Label();
            this.pictureBoxError = new PictureBox();
            this.ServerNameLabel = new Label();
            this.labelInstructions = new Label();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.flowLayoutPanel2 = new FlowLayoutPanel();
            this.progressBar1 = new ProgressBar();
            this.flowLayoutPanel3 = new FlowLayoutPanel();
            this.waitMessageValueLabel = new Label();
            this.tableLayoutPanelType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanelCreds.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxError).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            base.SuspendLayout();
            resources.ApplyResources(this.tableLayoutPanelType, "tableLayoutPanelType");
            this.tableLayoutPanelType.Controls.Add(this.ServerNameComboBox, 1, 2);
            this.tableLayoutPanelType.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanelType.Controls.Add(this.ServerNameLabel, 0, 2);
            this.tableLayoutPanelType.Controls.Add(this.labelInstructions, 0, 0);
            this.tableLayoutPanelType.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.tableLayoutPanelType.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.tableLayoutPanelType.Name = "tableLayoutPanelType";
            resources.ApplyResources(this.ServerNameComboBox, "ServerNameComboBox");
            this.ServerNameComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.ServerNameComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.tableLayoutPanelType.SetColumnSpan(this.ServerNameComboBox, 2);
            this.ServerNameComboBox.Name = "ServerNameComboBox";
            this.ServerNameComboBox.SelectedIndexChanged += new EventHandler(this.ServerNameComboBox_SelectedIndexChanged);
            this.ServerNameComboBox.TextChanged += new EventHandler(this.ServerNameComboBox_TextChanged);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.tableLayoutPanelType.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.tableLayoutPanelCreds);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.tableLayoutPanelCreds, "tableLayoutPanelCreds");
            this.tableLayoutPanelCreds.Controls.Add(this.UsernameLabel, 0, 0);
            this.tableLayoutPanelCreds.Controls.Add(this.PasswordLabel, 0, 1);
            this.tableLayoutPanelCreds.Controls.Add(this.PasswordTextBox, 1, 1);
            this.tableLayoutPanelCreds.Controls.Add(this.UsernameTextBox, 1, 0);
            this.tableLayoutPanelCreds.Controls.Add(this.labelError, 1, 2);
            this.tableLayoutPanelCreds.Controls.Add(this.pictureBoxError, 0, 2);
            this.tableLayoutPanelCreds.Name = "tableLayoutPanelCreds";
            resources.ApplyResources(this.UsernameLabel, "UsernameLabel");
            this.UsernameLabel.Name = "UsernameLabel";
            resources.ApplyResources(this.PasswordLabel, "PasswordLabel");
            this.PasswordLabel.Name = "PasswordLabel";
            resources.ApplyResources(this.PasswordTextBox, "PasswordTextBox");
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.TextChanged += new EventHandler(this.PasswordTextBox_TextChanged);
            resources.ApplyResources(this.UsernameTextBox, "UsernameTextBox");
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.TextChanged += new EventHandler(this.UsernameTextBox_TextChanged);
            resources.ApplyResources(this.labelError, "labelError");
            this.labelError.Name = "labelError";
            resources.ApplyResources(this.pictureBoxError, "pictureBoxError");
            this.pictureBoxError.Image = Resources._000_error_h32bit_16;
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.TabStop = false;
            resources.ApplyResources(this.ServerNameLabel, "ServerNameLabel");
            this.ServerNameLabel.Name = "ServerNameLabel";
            resources.ApplyResources(this.labelInstructions, "labelInstructions");
            this.tableLayoutPanelType.SetColumnSpan(this.labelInstructions, 3);
            this.labelInstructions.MaximumSize = new Size(0x19e, 0x73);
            this.labelInstructions.Name = "labelInstructions";
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.tableLayoutPanelType.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.tableLayoutPanelType.SetColumnSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Controls.Add(this.progressBar1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.flowLayoutPanel3.Controls.Add(this.waitMessageValueLabel);
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            resources.ApplyResources(this.waitMessageValueLabel, "waitMessageValueLabel");
            this.waitMessageValueLabel.Name = "waitMessageValueLabel";
            base.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.Controls.Add(this.tableLayoutPanelType);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.HelpButton = false;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ConnectToWinServer";
            this.tableLayoutPanelType.ResumeLayout(false);
            this.tableLayoutPanelType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanelCreds.ResumeLayout(false);
            this.tableLayoutPanelCreds.PerformLayout();
            ((ISupportInitialize) this.pictureBoxError).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private bool isValidToSubmit(bool showBalloon)
        {
            bool flag = true;
            if (this.ServerNameComboBox.Text.Trim().Length == 0)
            {
                if (showBalloon)
                {
                    ShowBalloonMessage(this.ServerNameComboBox, Messages.INVALID_PARAMETER, this.InvalidParamToolTip);
                }
                return false;
            }
            if (this.UsernameTextBox.Text.Trim().Length == 0)
            {
                if (showBalloon)
                {
                    ShowBalloonMessage(this.UsernameTextBox, Messages.INVALID_PARAMETER, this.InvalidParamToolTip);
                }
                return false;
            }
            if (this.PasswordTextBox.Text.Trim().Length != 0)
            {
                return flag;
            }
            if (showBalloon)
            {
                ShowBalloonMessage(this.PasswordTextBox, Messages.INVALID_PARAMETER, this.InvalidParamToolTip);
            }
            return false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.InvalidParamToolTip.Dispose();
            base.OnClosing(e);
            base.Dispose();
            Helpers.connectionDialog = null;
        }

        protected override void OnShown(EventArgs e)
        {
            if (this.ServerNameComboBox.CanSelect)
            {
                this.ServerNameComboBox.Focus();
            }
            base.OnShown(e);
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = this.isValidToSubmit(false);
        }

        private void SaveToSettings()
        {
            try
            {
                StringCollection toStoreList = new StringCollection();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                if (this.ServerNameComboBox.Items.Count > 0)
                {
                    foreach (object obj2 in this.ServerNameComboBox.Items)
                    {
                        dictionary.Add((string) obj2, (string) obj2);
                    }
                }
                if (this.ServerNameComboBox.Text.Trim().Length > 0)
                {
                    if (!dictionary.ContainsKey(this.ServerNameComboBox.Text.Trim()))
                    {
                        dictionary.Add(this.ServerNameComboBox.Text.Trim(), this.ServerNameComboBox.Text.Trim());
                    }
                    ConVPX.Settings.SetSelectedXenServerHost(this.ServerNameComboBox.Text.Trim());
                }
                foreach (KeyValuePair<string, string> pair in dictionary)
                {
                    toStoreList.Add(pair.Key);
                }
                if (toStoreList.Count > 0)
                {
                    ConVPX.Settings.SetXenServerHosts(toStoreList);
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }

        private void ServerNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = this.isValidToSubmit(false);
        }

        private void ServerNameComboBox_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = this.isValidToSubmit(false);
        }

        public static void ShowBalloonMessage(Control control, string caption, ToolTip toolTip)
        {
            toolTip.IsBalloon = true;
            toolTip.Active = true;
            toolTip.SetToolTip(control, caption);
            toolTip.Show(caption, control, BALLOON_DURATION);
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = this.isValidToSubmit(false);
        }

        internal override string HelpName
        {
            get
            {
                return "ConnectToWinServer";
            }
        }
    }
}

