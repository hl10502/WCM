namespace WCM.ConVPX.Wizards.ConversionWizard
{
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using ExportImport.CommonTypes;
	using WCM.ConVPX;
	using WCM.ConVPX.Core;

	partial class ConversionWizard
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ConversionWizard));
            this.CredentialWizardPage = new CredentialWizardPage();
            this.VMSelectionWizardPage = new VMSelectionWizardPage();
            this.SRSelectionWizardPage = new SRSelectionWizardPage();
            this.NetworkOptionsWizardPage = new NetworkOptionsWizardPage();
            this.SummaryWizardPage = new SummaryWizardPage();
            ((ISupportInitialize) base.pictureBoxWizard).BeginInit();
            base.xenTabControlBody.SuspendLayout();
            base.xenTabPageComplete.SuspendLayout();
            ((ISupportInitialize) base.XSHelpButton).BeginInit();
            base.SuspendLayout();
            base.pictureBoxWizard.Font = new Font("Segoe UI", 9f);
            base.xenTabControlBody.Controls.Add(this.NetworkOptionsWizardPage);
            base.xenTabControlBody.Controls.Add(this.SummaryWizardPage);
            base.xenTabControlBody.Controls.Add(this.SRSelectionWizardPage);
            base.xenTabControlBody.Controls.Add(this.VMSelectionWizardPage);
            base.xenTabControlBody.Controls.Add(this.CredentialWizardPage);
            base.xenTabControlBody.Font = new Font("Segoe UI", 9f);
            base.xenTabControlBody.SelectedIndex = 4;
            base.xenTabControlBody.SelectedTab = this.CredentialWizardPage;
            base.xenTabControlBody.Size = new Size(580, 0x177);
            base.xenTabControlBody.Controls.SetChildIndex(base.xenTabPageComplete, 0);
            base.xenTabControlBody.Controls.SetChildIndex(this.CredentialWizardPage, 0);
            base.xenTabControlBody.Controls.SetChildIndex(this.VMSelectionWizardPage, 0);
            base.xenTabControlBody.Controls.SetChildIndex(this.SRSelectionWizardPage, 0);
            base.xenTabControlBody.Controls.SetChildIndex(this.SummaryWizardPage, 0);
            base.xenTabControlBody.Controls.SetChildIndex(this.NetworkOptionsWizardPage, 0);
            base.xenTabPageComplete.Font = new Font("Segoe UI", 9f);
            base.labelWizard.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            base.labelWizard.Size = new Size(0x2cb, 60);
            base.textBoxComplete.Font = new Font("Segoe UI", 9f);
            base.XSHelpButton.Font = new Font("Segoe UI", 9f);
            base.XSHelpButton.Location = new Point(0x301, 0x12);
            this.CredentialWizardPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.CredentialWizardPage.AvailableStorageRepositories = null;
            this.CredentialWizardPage.AvailableVirtualMachines = null;
            this.CredentialWizardPage.DefaultStorageRepository = null;
            this.CredentialWizardPage.DefaultXenServerNetwork = null;
            this.CredentialWizardPage.Dock = DockStyle.Fill;
            this.CredentialWizardPage.Font = new Font("Segoe UI", 9f);
            this.CredentialWizardPage.HelpID = "CredentialWizard";
            this.CredentialWizardPage.Location = new Point(0, 0);
            this.CredentialWizardPage.Name = "CredentialWizardPage";
            this.CredentialWizardPage.OtherUsedDiskSpaceDict = null;
            this.CredentialWizardPage.Size = new Size(580, 0x177);
            this.CredentialWizardPage.TabIndex = 2;
            this.CredentialWizardPage.Text = "Credentials";
            this.CredentialWizardPage.UpdateWizardButtons = null;
            this.CredentialWizardPage.VMwareNetworks = null;
            this.CredentialWizardPage.XenServerNetworks = null;
            this.VMSelectionWizardPage.AvailableVirtualMachines = null;
            this.VMSelectionWizardPage.Dock = DockStyle.Fill;
            this.VMSelectionWizardPage.Font = new Font("Segoe UI", 9f);
            this.VMSelectionWizardPage.FreeSpaceDisplayString = null;
            this.VMSelectionWizardPage.HelpID = "VMSelectionWizard";
            this.VMSelectionWizardPage.Hostname = "";
            this.VMSelectionWizardPage.Location = new Point(0, 0);
            this.VMSelectionWizardPage.Name = "VMSelectionWizardPage";
            this.VMSelectionWizardPage.OtherUsedDiskSpace = 0L;
            this.VMSelectionWizardPage.Password = "";
            this.VMSelectionWizardPage.SelectedSpaceDisplayString = null;
            this.VMSelectionWizardPage.SelectedSR = null;
            this.VMSelectionWizardPage.Size = new Size(580, 0x173);
            this.VMSelectionWizardPage.TabIndex = 1;
            this.VMSelectionWizardPage.Text = "Virtual Machines";
            this.VMSelectionWizardPage.UpdateWizardButtons = null;
            this.VMSelectionWizardPage.UsedSpaceDisplayString = null;
            this.VMSelectionWizardPage.Username = "";
            this.SRSelectionWizardPage.AvailableStorageRepositories = null;
            this.SRSelectionWizardPage.DefaultStorageRepository = null;
            this.SRSelectionWizardPage.Dock = DockStyle.Fill;
            this.SRSelectionWizardPage.Font = new Font("Segoe UI", 9f);
            this.SRSelectionWizardPage.HelpID = "SRSelectionWizard";
            this.SRSelectionWizardPage.Location = new Point(0, 0);
            this.SRSelectionWizardPage.Name = "SRSelectionWizardPage";
            this.SRSelectionWizardPage.OtherUsedDiskSpace = 0L;
            this.SRSelectionWizardPage.OtherUsedDiskSpaceDict = null;
            this.SRSelectionWizardPage.Size = new Size(580, 0x173);
            this.SRSelectionWizardPage.TabIndex = 1;
            this.SRSelectionWizardPage.Text = "Storage Repository";
            this.SRSelectionWizardPage.UpdateWizardButtons = null;
            this.NetworkOptionsWizardPage.DefaultXenServerNetwork = null;
            this.NetworkOptionsWizardPage.Dock = DockStyle.Fill;
            this.NetworkOptionsWizardPage.Font = new Font("Segoe UI", 9f);
            this.NetworkOptionsWizardPage.HelpID = "NetworkOptionsWizard";
            this.NetworkOptionsWizardPage.Location = new Point(0, 0);
            this.NetworkOptionsWizardPage.Name = "NetworkOptionsWizardPage";
            this.NetworkOptionsWizardPage.Size = new Size(580, 0x173);
            this.NetworkOptionsWizardPage.TabIndex = 1;
            this.NetworkOptionsWizardPage.Text = "Networks";
            this.NetworkOptionsWizardPage.UpdateWizardButtons = null;
            this.NetworkOptionsWizardPage.VMwareNetworks = null;
            this.NetworkOptionsWizardPage.XenServerNetworks = null;
            this.SummaryWizardPage.Dock = DockStyle.Fill;
            this.SummaryWizardPage.Font = new Font("Segoe UI", 9f);
            this.SummaryWizardPage.FreeSpaceDisplayString = null;
            this.SummaryWizardPage.HelpID = "SummaryWizard";
            this.SummaryWizardPage.Location = new Point(0, 0);
            this.SummaryWizardPage.Name = "SummaryWizardPage";
            this.SummaryWizardPage.NetworkMappings = null;
            this.SummaryWizardPage.PreserveMAC = false;
            this.SummaryWizardPage.SelectedSpaceDisplayString = null;
            this.SummaryWizardPage.SelectedSR = null;
            this.SummaryWizardPage.SelectedVMsToConvert = null;
            this.SummaryWizardPage.Size = new Size(580, 0x173);
            this.SummaryWizardPage.TabIndex = 1;
            this.SummaryWizardPage.Text = "Summary";
            this.SummaryWizardPage.UpdateWizardButtons = null;
            this.SummaryWizardPage.UsedSpaceDisplayString = null;
            this.SummaryWizardPage.VMwareHostname = null;
            this.SummaryWizardPage.XenServerHostname = null;
            base.AutoScaleDimensions = new SizeF(7f, 15f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.ClientSize = new Size(0x330, 520);
            this.Font = new Font("Segoe UI", 9f);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "ConversionWizard";
            this.Text = "ConversionWizard";
            ((ISupportInitialize) base.pictureBoxWizard).EndInit();
            base.xenTabControlBody.ResumeLayout(false);
            base.xenTabPageComplete.ResumeLayout(false);
            base.xenTabPageComplete.PerformLayout();
            ((ISupportInitialize) base.XSHelpButton).EndInit();
            base.ResumeLayout(false);

			base.AddPage(this.CredentialWizardPage);
			base.AddPage(this.SRSelectionWizardPage);
			base.AddPage(this.VMSelectionWizardPage);
			base.AddPage(this.NetworkOptionsWizardPage);
			base.AddPage(this.SummaryWizardPage);
			this.SRSelectionWizardPage.UpdateWizardButtons = new MethodInvoker(this.UpdateButtons);
			this.VMSelectionWizardPage.UpdateWizardButtons = new MethodInvoker(this.UpdateButtons);
			this.CredentialWizardPage.UpdateWizardButtons = new MethodInvoker(this.UpdateButtons);
			this.SummaryWizardPage.UpdateWizardButtons = new MethodInvoker(this.UpdateButtons);
			this.NetworkOptionsWizardPage.UpdateWizardButtons = new MethodInvoker(this.UpdateButtons);
			base.labelWizard.Text = base.xenTabControlBody.SelectedTab.AccessibleDescription;
			this.Text = Messages.CONVERT_VM_WIZARD_TITLE;
			this.UpdateButtons();
        }

		private CredentialWizardPage CredentialWizardPage;
		private NetworkOptionsWizardPage NetworkOptionsWizardPage;
		private SRSelectionWizardPage SRSelectionWizardPage;
		private SummaryWizardPage SummaryWizardPage;
		private VMSelectionWizardPage VMSelectionWizardPage;
    }
}

