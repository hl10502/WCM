namespace WCM.ConVPX.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ComboBoxIconEx : ComboBox
    {
        private IContainer components = null;
        private System.Windows.Forms.ImageList imageList;

        public ComboBoxIconEx()
        {
            this.InitializeComponent();
            base.DrawMode = DrawMode.OwnerDrawFixed;
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
            this.components = new Container();
        }

        protected override void OnDrawItem(DrawItemEventArgs ea)
        {
            ea.DrawBackground();
            ea.DrawFocusRectangle();
            Size imageSize = this.imageList.ImageSize;
            Rectangle bounds = ea.Bounds;
            try
            {
                ComboBoxIconExItem item = (ComboBoxIconExItem) base.Items[ea.Index];
                if (item.ImageIndex != -1)
                {
                    this.imageList.Draw(ea.Graphics, bounds.Left, bounds.Top, item.ImageIndex);
                    ea.Graphics.DrawString(item.ToString(), ea.Font, new SolidBrush(ea.ForeColor), (float) (bounds.Left + imageSize.Width), (float) bounds.Top);
                }
                else
                {
                    ea.Graphics.DrawString(item.ToString(), ea.Font, new SolidBrush(ea.ForeColor), (float) bounds.Left, (float) bounds.Top);
                }
            }
            catch
            {
                if (ea.Index != -1)
                {
                    ea.Graphics.DrawString(base.Items[ea.Index].ToString(), ea.Font, new SolidBrush(ea.ForeColor), (float) bounds.Left, (float) bounds.Top);
                }
                else
                {
                    ea.Graphics.DrawString(this.Text, ea.Font, new SolidBrush(ea.ForeColor), (float) bounds.Left, (float) bounds.Top);
                }
            }
            base.OnDrawItem(ea);
        }

        public System.Windows.Forms.ImageList ImageList
        {
            get
            {
                return this.imageList;
            }
            set
            {
                this.imageList = value;
            }
        }
    }
}

