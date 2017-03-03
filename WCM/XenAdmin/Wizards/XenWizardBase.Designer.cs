namespace WCM.XenAdmin.Wizards
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using WCM.ConVPX.Properties;
	using WCM.XenAdmin.Controls;

	partial class XenWizardBase
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(XenWizardBase));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panelTop = new Panel();
			this.XSHelpButton = new HelpButton();
			this.labelWizard = new Label();
            this.pictureBoxWizard = new PictureBox();
            this.panelBody = new Panel();
			this.xenTabControlBody = new XenAdmin.Controls.XenTabControl();
            this.xenTabPageComplete = new XenTabPage();
            this.textBoxComplete = new TextBox();
            this.tableLayoutPanelNavigation = new TableLayoutPanel();
            this.buttonNext = new Button();
            this.buttonFinish = new Button();
            this.buttonCancel = new Button();
            this.buttonPrevious = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            //((ISupportInitialize) this.XSHelpButton).BeginInit();
            ((ISupportInitialize) this.pictureBoxWizard).BeginInit();
            this.panelBody.SuspendLayout();
            this.xenTabControlBody.SuspendLayout();
            this.xenTabPageComplete.SuspendLayout();
            this.tableLayoutPanelNavigation.SuspendLayout();
            base.SuspendLayout();
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelBody, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.panelTop.BackColor = Color.FromArgb(0xfb, 0xfb, 0xfb);
            this.tableLayoutPanel1.SetColumnSpan(this.panelTop, 2);
            //this.panelTop.Controls.Add(this.XSHelpButton);
            this.panelTop.Controls.Add(this.labelWizard);
            this.panelTop.Controls.Add(this.pictureBoxWizard);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            //resources.ApplyResources(this.XSHelpButton, "XSHelpButton");
			//this.XSHelpButton.Image = Resources.help_24;
			//this.XSHelpButton.Name = "XSHelpButton";
			//this.XSHelpButton.TabStop = false;
			//this.XSHelpButton.Click += new EventHandler(this.HelpButton_Click);
            resources.ApplyResources(this.labelWizard, "labelWizard");
            this.labelWizard.AutoEllipsis = true;
            this.labelWizard.ForeColor = Color.Black;
            this.labelWizard.Name = "labelWizard";
            resources.ApplyResources(this.pictureBoxWizard, "pictureBoxWizard");
            this.pictureBoxWizard.Image = Resources._000_CreateVM_h32bit_32;
            this.pictureBoxWizard.Name = "pictureBoxWizard";
            this.pictureBoxWizard.TabStop = false;
            this.panelBody.Controls.Add(this.xenTabControlBody);
            resources.ApplyResources(this.panelBody, "panelBody");
            this.panelBody.Name = "panelBody";
            this.xenTabControlBody.Controls.Add(this.xenTabPageComplete);
            resources.ApplyResources(this.xenTabControlBody, "xenTabControlBody");
            this.xenTabControlBody.Name = "xenTabControlBody";
            this.xenTabControlBody.SelectedIndex = 0;
            this.xenTabControlBody.SelectedTab = this.xenTabPageComplete;
            this.xenTabControlBody.TabStop = false;
            this.xenTabPageComplete.Controls.Add(this.textBoxComplete);
            resources.ApplyResources(this.xenTabPageComplete, "xenTabPageComplete");
            this.xenTabPageComplete.HelpID = null;
            this.xenTabPageComplete.Name = "xenTabPageComplete";
            this.textBoxComplete.BackColor = SystemColors.Control;
            this.textBoxComplete.BorderStyle = BorderStyle.None;
            resources.ApplyResources(this.textBoxComplete, "textBoxComplete");
            this.textBoxComplete.Name = "textBoxComplete";
            this.textBoxComplete.ReadOnly = true;
            resources.ApplyResources(this.tableLayoutPanelNavigation, "tableLayoutPanelNavigation");
            this.tableLayoutPanelNavigation.Controls.Add(this.buttonNext, 1, 0);
            this.tableLayoutPanelNavigation.Controls.Add(this.buttonFinish, 2, 0);
            this.tableLayoutPanelNavigation.Controls.Add(this.buttonCancel, 3, 0);
            this.tableLayoutPanelNavigation.Controls.Add(this.buttonPrevious, 0, 0);
            this.tableLayoutPanelNavigation.Name = "tableLayoutPanelNavigation";
            resources.ApplyResources(this.buttonNext, "buttonNext");
            this.buttonNext.MinimumSize = new Size(0x4b, 0x17);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new EventHandler(this.buttonNext_Click);
            resources.ApplyResources(this.buttonFinish, "buttonFinish");
			this.buttonFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new EventHandler(this.buttonFinish_Click);
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            resources.ApplyResources(this.buttonPrevious, "buttonPrevious");
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new EventHandler(this.buttonPrevious_Click);
            resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            base.CancelButton = this.buttonCancel;
            base.Controls.Add(this.tableLayoutPanel1);
            base.Controls.Add(this.tableLayoutPanelNavigation);
            this.DoubleBuffered = true;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "XenWizardBase";
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            base.Load += new EventHandler(this.XenWizardBase_Load);
            base.KeyPress += new KeyPressEventHandler(this.XenWizardBase_KeyPress);
            base.HelpRequested += new HelpEventHandler(this.XenWizardBase_HelpRequested);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            //((ISupportInitialize) this.XSHelpButton).EndInit();
            ((ISupportInitialize) this.pictureBoxWizard).EndInit();
            this.panelBody.ResumeLayout(false);
            this.xenTabControlBody.ResumeLayout(false);
            this.xenTabPageComplete.ResumeLayout(false);
            this.xenTabPageComplete.PerformLayout();
            this.tableLayoutPanelNavigation.ResumeLayout(false);
            this.tableLayoutPanelNavigation.PerformLayout();
            base.ResumeLayout(false);

			base.Icon = Resources.AppIcon;
			this.wizardProgress = new WizardProgress();
			this.wizardProgress.LeavingStep += new EventHandler<WizardProgressEventArgs>(this.WizardProgress_LeavingStep);
			this.wizardProgress.EnteringStep += new EventHandler<WizardProgressEventArgs>(this.WizardProgress_EnteringStep);
			this.wizardProgress.Dock = DockStyle.Fill;
			this.wizardProgress.TabStop = false;
			this.tableLayoutPanel1.Controls.Add(this.wizardProgress);
			base.FormClosing += new FormClosingEventHandler(this.XenWizardBase_FormClosing);
        }

		public Button buttonCancel;
		public Button buttonFinish;
		public Button buttonNext;
		public Button buttonPrevious;
		
		public Label labelWizard;
		public Panel panelBody;
		public Panel panelTop;
		public PictureBox pictureBoxWizard;
		public TableLayoutPanel tableLayoutPanel1;
		public TableLayoutPanel tableLayoutPanelNavigation;
		public TextBox textBoxComplete;
		public WizardProgress wizardProgress;
		public XenTabControl xenTabControlBody;
		public XenTabPage xenTabPageComplete;
		public HelpButton XSHelpButton;
    }
}

