namespace WCM.XenAdmin.Controls
{
    using System;
    using System.Windows.Forms;

    public class ToolStripEx : ToolStrip
    {
        private bool clickThrough;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if ((this.clickThrough && (m.Msg == 0x21L)) && (m.Result == ((IntPtr) 2L)))
            {
                m.Result = (IntPtr) 1L;
            }
        }

        public bool ClickThrough
        {
            get
            {
                return this.clickThrough;
            }
            set
            {
                this.clickThrough = value;
            }
        }
    }
}

