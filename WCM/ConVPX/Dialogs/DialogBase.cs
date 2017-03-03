namespace WCM.ConVPX.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WCM.XenAdmin.Core;
    using WCM.XenAdmin.Help;

    public class DialogBase : Form
    {
        private IContainer components = null;

        public DialogBase()
        {
            this.InitializeComponent();
        }

        private void DialogBase_Load(object sender, EventArgs e)
        {
            base.CenterToParent();
            FormFontFixer.Fix(this);
        }

        private void DialogBase_Shown(object sender, EventArgs e)
        {
            if ((base.Modal && (base.Owner != null)) && (base.Owner.WindowState == FormWindowState.Minimized))
            {
                base.Owner.WindowState = FormWindowState.Normal;
                base.CenterToParent();
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

        public bool HasHelp()
        {
            return HelpManager.HasHelpFor(this.HelpName);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x1b0, 0x105);
            base.Name = "DialogBase";
            this.Text = "DialogBase";
            base.HelpButtonClicked += new CancelEventHandler(this.XenDialogBase_HelpButtonClicked);
            base.Load += new EventHandler(this.DialogBase_Load);
            base.Shown += new EventHandler(this.DialogBase_Shown);
            base.HelpRequested += new HelpEventHandler(this.XenDialogBase_HelpRequested);
            base.ResumeLayout(false);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (base.Owner != null)
            {
                base.Owner.Focus();
            }
        }

        private void XenDialogBase_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.Launch(this.HelpName);
            e.Cancel = true;
        }

        private void XenDialogBase_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpManager.Launch(this.HelpName);
            hlpevent.Handled = true;
        }

        internal virtual string HelpName
        {
            get
            {
                return base.Name;
            }
        }
    }
}

