namespace WCM.XenAdmin.Controls
{
    using WCM.ConVPX.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class HelpButton : PictureBox
    {
        private IContainer components = null;
        private Image HoverImage;
        private Image NormalImage;

        public HelpButton()
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(HelpButton));
            ((ISupportInitialize) this).BeginInit();
            base.SuspendLayout();
            resources.ApplyResources(this, "$this");
            ((ISupportInitialize) this).EndInit();
            base.ResumeLayout(false);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.Image = this.HoverImage;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.Image = this.NormalImage;
            base.OnMouseLeave(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.NormalImage = (base.Width == 0x18) ? Resources.help_24 : ((base.Width == 0x20) ? Resources._000_HelpIM_h32bit_32 : Resources._000_HelpIM_h32bit_16);
            this.HoverImage = (base.Width == 0x18) ? Resources.help_24_hover : ((base.Width == 0x20) ? Resources.help_32_hover : Resources.help_16_hover);
            base.Image = this.NormalImage;
        }
    }
}

