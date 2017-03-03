namespace WCM.XenAdmin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [Designer(typeof(ParentControlDesigner))]
    public class XenTabControl : Control
    {
        private IContainer components = null;
        private XenTabPage selectedTab;

        public event EventHandler TabChanged;

        public XenTabControl()
        {
            this.InitializeComponent();
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
            base.SuspendLayout();
            base.ResumeLayout(false);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Visible = false;
        }

        private void OnTabChanged(EventArgs ea)
        {
            if (this.TabChanged != null)
            {
                this.TabChanged(this, ea);
            }
        }

        protected override bool ScaleChildren
        {
            get
            {
                return false;
            }
        }

        public int SelectedIndex
        {
            get
            {
                if ((this.selectedTab != null) && base.Controls.Contains(this.selectedTab))
                {
                    return base.Controls.GetChildIndex(this.selectedTab);
                }
                return -1;
            }
            set
            {
                this.SelectedTab = ((value >= -1) && (value < base.Controls.Count)) ? ((XenTabPage) base.Controls[value]) : null;
            }
        }

        public XenTabPage SelectedTab
        {
            get
            {
                return this.selectedTab;
            }
            set
            {
                if (this.selectedTab != value)
                {
                    if (this.selectedTab != null)
                    {
                        this.selectedTab.Visible = false;
                    }
                    this.selectedTab = value;
                    if (this.selectedTab != null)
                    {
                        this.selectedTab.Visible = true;
                    }
                    this.OnTabChanged(new EventArgs());
                    base.Invalidate();
                    base.Update();
                }
            }
        }
    }
}

