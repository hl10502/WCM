namespace WCM.ConVPX.Wizards.ConversionWizard
{
	using System;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;
	using ExportImport.CommonTypes;
	using log4net;
	using WCM.ConVPX;
	using WCM.ConVPX.Core;
	using WCM.ConVPX.Wizards;
	using WCM.XenAdmin.Controls;
	using WCM.XenAdmin.Wizards;

    public partial class ConversionWizard : XenWizardBase
    {
		private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private string _hostname;
		private string _password;
		private string _userName;
		private ServerInfo _vmwareCredInfo;
		private DoConversionTask _worker;

        public ConversionWizard()
        {
            InitializeComponent();
        }

        private bool AllowFinish()
        {
            IWizardPage currentWizardPage = this.GetCurrentWizardPage(base.wizardProgress.CurrentStepTabPage);
            return ((currentWizardPage != null) && currentWizardPage.EnableFinish());
        }

        protected override bool AllowNextStep()
        {
            IWizardPage currentWizardPage = this.GetCurrentWizardPage(base.wizardProgress.CurrentStepTabPage);
            if (currentWizardPage != null)
            {
                return currentWizardPage.EnableNext();
            }
            return base.AllowNextStep();
        }

        protected bool AllowPrevious()
        {
            IWizardPage currentWizardPage = this.GetCurrentWizardPage(base.wizardProgress.CurrentStepTabPage);
            return ((currentWizardPage != null) && currentWizardPage.EnablePrevious());
        }

        protected override void buttonFinish_Click(object sender, EventArgs e)
        {
            try
            {
                this._worker = new DoConversionTask(Program.ClientConnection, this._vmwareCredInfo, this.VMSelectionWizardPage.SelectedVMsToConvert, this.SRSelectionWizardPage.SelectedSR, this.NetworkOptionsWizardPage.PreserveMAC, this.NetworkOptionsWizardPage.NetworkMappings);
                Program.MainWindow.IsCreateJobsInProgress = true;
                this._worker.Completed += new ConversionVMsCompletedEventHandler(this.worker_Completed);
                this._worker.Start();
                Program.JobPollManager.RequestImmediateUpdate();
                base.FinishWizard();
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }


        public override void FinishWizard()
        {
            base.FinishWizard();
        }

        private IWizardPage GetCurrentWizardPage(XenTabPage t)
        {
            if (t is IWizardPage)
            {
                return (IWizardPage) t;
            }
            foreach (Control control in t.Controls)
            {
                if (control is IWizardPage)
                {
                    return (IWizardPage) control;
                }
            }
            return null;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.CredentialWizardPage.CleanupAfterCollectSetupData();
            Helpers.conVpxWizard = null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void ShowFailedCreateMessage()
        {
            MessageBox.Show(Messages.CREATE_JOBS_FAILURE, Messages.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateButtons()
        {
            base.buttonNext.Enabled = this.AllowNextStep();
            base.buttonPrevious.Enabled = this.AllowPrevious();
            base.buttonFinish.Enabled = this.AllowFinish();
        }

        protected override void WizardProgress_EnteringStep(object sender, WizardProgressEventArgs e)
        {
            if (base.wizardProgress.CurrentStepTabPage == this.CredentialWizardPage)
            {
                this.CredentialWizardPage.OnPageShow(e);
            }
            else if (base.wizardProgress.CurrentStepTabPage == this.VMSelectionWizardPage)
            {
                this.VMSelectionWizardPage.OnPageShow(e);
                if (this.CredentialWizardPage.LabelError.Visible)
                {
                    base.wizardProgress.PreviousStep();
                }
            }
            else if (base.wizardProgress.CurrentStepTabPage == this.SRSelectionWizardPage)
            {
                this.SRSelectionWizardPage.OnPageShow(e);
                if (this.CredentialWizardPage.LabelError.Visible)
                {
                    base.wizardProgress.PreviousStep();
                }
            }
            else if (base.wizardProgress.CurrentStepTabPage == this.SummaryWizardPage)
            {
                this.SummaryWizardPage.OnPageShow(e);
            }
            base.xenTabControlBody.SelectedTab = base.wizardProgress.CurrentStepTabPage;
            base.labelWizard.Text = base.xenTabControlBody.SelectedTab.AccessibleDescription;
            base.FocusFirstControl(base.wizardProgress.CurrentStepTabPage.Controls);
            this.UpdateButtons();
        }

        protected override void WizardProgress_LeavingStep(object sender, WizardProgressEventArgs e)
        {
            try
            {
                if (base.wizardProgress.CurrentStepTabPage == this.CredentialWizardPage)
                {
                    this.CredentialWizardPage.HideAllStatusErrorFields();
                    this.Refresh();
                    this._userName = this.CredentialWizardPage.Username;
                    this._password = this.CredentialWizardPage.Password;
                    this._hostname = this.CredentialWizardPage.Hostname;
                    this._vmwareCredInfo = new ServerInfo();
                    this._vmwareCredInfo.ServerType = 2;
                    this._vmwareCredInfo.Hostname = this._hostname;
                    this._vmwareCredInfo.Username = this._userName;
                    this._vmwareCredInfo.Password = this._password;
                    this.VMSelectionWizardPage.Username = this._userName;
                    this.VMSelectionWizardPage.Password = this._password;
                    this.VMSelectionWizardPage.Hostname = this._hostname;
                    this.CredentialWizardPage.SaveToSettings();
                    this.VMSelectionWizardPage.AvailableVirtualMachines = this.CredentialWizardPage.AvailableVirtualMachines;
                    this.SRSelectionWizardPage.DefaultStorageRepository = this.CredentialWizardPage.DefaultStorageRepository;
                    this.SRSelectionWizardPage.AvailableStorageRepositories = this.CredentialWizardPage.AvailableStorageRepositories;
                    this.SRSelectionWizardPage.OtherUsedDiskSpaceDict = this.CredentialWizardPage.OtherUsedDiskSpaceDict;
                    this.NetworkOptionsWizardPage.VMwareNetworks = this.CredentialWizardPage.VMwareNetworks;
                    this.NetworkOptionsWizardPage.XenServerNetworks = this.CredentialWizardPage.XenServerNetworks;
                    this.NetworkOptionsWizardPage.DefaultXenServerNetwork = this.CredentialWizardPage.DefaultXenServerNetwork;
                }
                else if (base.wizardProgress.CurrentStepTabPage == this.SRSelectionWizardPage)
                {
                    this.VMSelectionWizardPage.SelectedSR = this.SRSelectionWizardPage.SelectedSR;
                    this.VMSelectionWizardPage.OtherUsedDiskSpace = this.SRSelectionWizardPage.OtherUsedDiskSpace;
                    if (this.VMSelectionWizardPage.SelectedSR != null)
                    {
                        this.VMSelectionWizardPage.UpdatePieChart();
                    }
                }
                else if (base.wizardProgress.CurrentStepTabPage == this.VMSelectionWizardPage)
                {
                    this.VMSelectionWizardPage.OnPageExit(e);
                }
                else if (base.wizardProgress.CurrentStepTabPage == this.NetworkOptionsWizardPage)
                {
                    this.SummaryWizardPage.VMwareHostname = this.CredentialWizardPage.Hostname;
                    this.SummaryWizardPage.XenServerHostname = Program.ClientConnection.HostInfo.Hostname;
                    this.SummaryWizardPage.SelectedSR = this.SRSelectionWizardPage.SelectedSR;
                    this.SummaryWizardPage.SelectedVMsToConvert = this.VMSelectionWizardPage.SelectedVMsToConvert;
                    this.SummaryWizardPage.FreeSpaceDisplayString = this.VMSelectionWizardPage.FreeSpaceDisplayString;
                    this.SummaryWizardPage.UsedSpaceDisplayString = this.VMSelectionWizardPage.UsedSpaceDisplayString;
                    this.SummaryWizardPage.SelectedSpaceDisplayString = this.VMSelectionWizardPage.SelectedSpaceDisplayString;
                    this.SummaryWizardPage.PreserveMAC = this.NetworkOptionsWizardPage.PreserveMAC;
                    this.SummaryWizardPage.NetworkMappings = this.NetworkOptionsWizardPage.NetworkMappings;
                    this.SummaryWizardPage.Build();
                }
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void worker_Completed(object sender, EventArgs e)
        {
            try
            {
                Program.MainWindow.IsCreateJobsInProgress = false;
                if (this._worker != null)
                {
                    this._worker.Completed -= new ConversionVMsCompletedEventHandler(this.worker_Completed);
                }
                ConversionVMsCompletedEventArgs args = e as ConversionVMsCompletedEventArgs;
                if ((args != null) && (args.FailedVMs.Count > 0))
                {
                    Program.Invoke(Program.MainWindow, new MethodInvoker(this.ShowFailedCreateMessage), new object[0]);
                    LOG.Error("A conversion job create failure occurred for the following VMs:");
                    foreach (string str in args.FailedVMs)
                    {
                        LOG.Error(str);
                    }
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }
    }
}

