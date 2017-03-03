namespace WCM.XenAdmin.Wizards
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;
	using log4net;
	using WCM.ConVPX;
	using WCM.XenAdmin.Controls;
	using WCM.XenAdmin.Core;
	using WCM.XenAdmin.Help;

    public partial class XenWizardBase : Form
    {
		protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private bool wizardFinished;

        public XenWizardBase()
        {
            InitializeComponent();
        }

        public void AddPage(XenTabPage page)
        {
            this.AddPage(page, -1);
        }

        public void AddPage(XenTabPage page, int index)
        {
            page.Wizard = this;
            page.StatusChanged += new XenTabPageStatusChanged(this.page_StatusChanged);
            if (index == -1)
            {
                this.wizardProgress.Steps.Add(page);
            }
            else
            {
                this.wizardProgress.Steps.Insert(index, page);
            }
        }

        public void AddPage(XenTabPage newPage, XenTabPage existingPage)
        {
            int index = this.wizardProgress.Steps.IndexOf(existingPage) + 1;
            if (index > this.wizardProgress.Steps.Count)
            {
                index = -1;
            }
            this.AddPage(newPage, index);
        }

        protected virtual bool AllowNextStep()
        {
            return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected virtual void buttonFinish_Click(object sender, EventArgs e)
        {
            this.WizardProgress_LeavingStep(this.CurrentStepTabPage, new WizardProgressEventArgs(true));
            this.wizardFinished = true;
            this.WizardProgress_EnteringStep(null, new WizardProgressEventArgs(true));
            this.FinishWizard();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.NextStep();
            this.SetTitle();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            this.wizardProgress.PreviousStep();
            this.SetTitle();
        }

        internal void DisablePage(XenTabPage WizardTabPage, bool Disable)
        {
            foreach (XenTabPage page in this.Pages)
            {
                if (page == WizardTabPage)
                {
                    page.DisableStep = Disable;
                    break;
                }
            }
        }


        public virtual void FinishCanceled()
        {
            this.wizardFinished = false;
            this.WizardProgress_EnteringStep(null, new WizardProgressEventArgs(false));
        }

        public virtual void FinishWizard()
        {
            base.Close();
            base.Dispose();
        }

        protected bool FocusFirstControl(Control.ControlCollection cc)
        {
            bool flag = false;
            List<Control> list = new List<Control>();
            foreach (Control control in cc)
            {
                list.Add(control);
            }
            list.Sort((c1, c2) => c1.TabIndex.CompareTo(c2.TabIndex));
            if (list.Count > 0)
            {
                foreach (Control control2 in list)
                {
                    if (control2.HasChildren)
                    {
                        flag = this.FocusFirstControl(control2.Controls);
                    }
                    if (!flag)
                    {
                        if ((control2 is Label) || ((control2 is TextBox) && (control2 as TextBox).ReadOnly))
                        {
                            continue;
                        }
                        if (control2.CanSelect)
                        {
                            flag = control2.Focus();
                        }
                    }
                    if (flag)
                    {
                        return flag;
                    }
                }
            }
            return flag;
        }

        public bool HasHelp()
        {
            return HelpManager.HasHelpFor(this.WizardPaneHelpID());
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpManager.Launch(this.WizardPaneHelpID());
        }


        public void NextStep()
        {
            this.wizardProgress.NextStep();
        }

        protected virtual void OnCancel()
        {
            base.DialogResult = DialogResult.Cancel;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (base.Owner != null)
            {
                base.Owner.Focus();
            }
        }

        private void page_StatusChanged(XenTabPage sender)
        {
            this.UpdateWizard();
        }

        private void pictureBoxHelp_Click(object sender, EventArgs e)
        {
            HelpManager.Launch(this.WizardPaneHelpID());
        }

        public void RemovePage(XenTabPage page)
        {
            page.StatusChanged -= new XenTabPageStatusChanged(this.page_StatusChanged);
            this.wizardProgress.Steps.Remove(page);
        }

        public void RemovePages(params XenTabPage[] pages)
        {
            foreach (XenTabPage page in pages)
            {
                this.RemovePage(page);
            }
        }

        private void SetTitle()
        {
            this.labelWizard.Text = this.wizardProgress.CurrentStepTabPage.PageTitle ?? this.xenTabControlBody.SelectedTab.AccessibleDescription;
        }

        protected void UpdateWizard()
        {
            this.buttonPrevious.Enabled = !this.wizardProgress.IsFirstStep && this.wizardProgress.CurrentStepTabPage.EnablePrevious();
            this.buttonFinish.Enabled = ((this.wizardProgress.IsLastStep && !this.wizardFinished) && this.AllowNextStep()) && this.wizardProgress.CurrentStepTabPage.EnableFinish();
            this.buttonNext.Enabled = (!this.wizardProgress.IsLastStep && this.AllowNextStep()) && this.wizardProgress.CurrentStepTabPage.EnableNext();
            this.SetTitle();
            if ((this.wizardProgress.IsLastStep && !this.wizardFinished) && this.AllowNextStep())
            {
                base.AcceptButton = this.buttonFinish;
            }
            else
            {
                base.AcceptButton = this.buttonNext;
            }
        }

        protected virtual string WizardPaneHelpID()
        {
            return (base.GetType().Name + "_" + this.wizardProgress.CurrentStepTabPage.HelpID + "Pane");
        }

        protected virtual void WizardProgress_EnteringStep(object sender, WizardProgressEventArgs e)
        {
            this.xenTabControlBody.SelectedTab = this.wizardProgress.CurrentStepTabPage;
            this.wizardProgress.CurrentStepTabPage.PageLoaded(e.IsForwardsTransition ? PageLoadedDirection.Forward : PageLoadedDirection.Back);
            this.UpdateWizard();
        }

        protected virtual void WizardProgress_LeavingStep(object sender, WizardProgressEventArgs e)
        {
            this.wizardProgress.CurrentStepTabPage.PageLeave(e.IsForwardsTransition ? PageLoadedDirection.Forward : PageLoadedDirection.Back, ref e.Cancelled);
            this.UpdateWizard();
        }

        private void XenWizardBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.wizardFinished)
            {
                if (!this.buttonCancel.Enabled)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.OnCancel();
                }
            }
        }

        private void XenWizardBase_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpManager.Launch(this.WizardPaneHelpID());
        }

        private void XenWizardBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.buttonNext.PerformClick();
            }
        }

        private void XenWizardBase_Load(object sender, EventArgs e)
        {
            if (base.Owner == null)
            {
                base.Owner = Program.MainWindow;
            }
            base.CenterToParent();
            FormFontFixer.Fix(this);
            if (this.wizardProgress.Steps.Count != 0)
            {
                this.wizardProgress.CurrentStepTabPage.PageLoaded(PageLoadedDirection.Forward);
                this.UpdateWizard();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public XenTabPage CurrentStepTabPage
        {
            get
            {
                return this.wizardProgress.CurrentStepTabPage;
            }
        }

        public List<XenTabPage> Pages
        {
            get
            {
                return this.wizardProgress.Steps;
            }
        }
    }
}

