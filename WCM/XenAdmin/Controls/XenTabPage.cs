namespace WCM.XenAdmin.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using WCM.XenAdmin.Wizards;

    [Designer(typeof(ParentControlDesigner))]
    public class XenTabPage : UserControl
    {
        private IContainer components = null;
        public bool DisableStep;
        public bool FirstRunOnly;
        private string helpID;
        private int SubStep;
        private List<string> SubSteps = new List<string>();
        private bool UseSubSteps;
        public XenWizardBase Wizard;

        public event XenTabPageStatusChanged StatusChanged;

        public XenTabPage()
        {
            this.InitializeComponent();
        }

        public void AddSubStep(string subStepHeading)
        {
            if (!this.UseSubSteps)
            {
                this.UseSubSteps = true;
            }
            this.SubSteps.Add(subStepHeading);
        }

        public int CurrentSubStep()
        {
            if (!this.UseSubSteps)
            {
                return -1;
            }
            return this.SubStep;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public virtual bool EnableFinish()
        {
            return true;
        }

        public virtual bool EnableNext()
        {
            return true;
        }

        public virtual bool EnablePrevious()
        {
            return true;
        }

        public List<string> GetSubSteps()
        {
            if (!this.UseSubSteps)
            {
                return null;
            }
            return this.SubSteps;
        }

        public bool HasSubSteps()
        {
            return this.UseSubSteps;
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.ResumeLayout(false);
        }

        public void NextSubStep()
        {
            if (this.UseSubSteps)
            {
                if (this.SubStep < (this.SubSteps.Count - 1))
                {
                    this.SubStep++;
                }
                base.ParentForm.Refresh();
            }
        }

        protected void OnPageUpdated()
        {
            if (this.StatusChanged != null)
            {
                this.StatusChanged(this);
            }
        }

        public virtual void PageLeave(PageLoadedDirection direction, ref bool cancel)
        {
        }

        public virtual void PageLoaded(PageLoadedDirection direction)
        {
        }

        public void PreviousSubStep()
        {
            if (this.UseSubSteps)
            {
                if (this.SubStep > 0)
                {
                    this.SubStep--;
                }
                base.ParentForm.Refresh();
            }
        }

        public virtual string HelpID
        {
            get
            {
                return this.helpID;
            }
            set
            {
                this.helpID = value;
            }
        }

        public virtual string NextText
        {
            get
            {
				return "&下一步 >"; //Next
            }
        }

        public virtual List<KeyValuePair<string, string>> PageSummary
        {
            get
            {
                return new List<KeyValuePair<string, string>>();
            }
        }

        public virtual string PageTitle
        {
            get
            {
                return null;
            }
        }

        protected override bool ScaleChildren
        {
            get
            {
                return false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true), EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}

