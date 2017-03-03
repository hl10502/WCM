namespace WCM.ConVPX.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class PanelWithHeader : Panel
    {
        private Color _headerColor1 = Color.FromArgb(0x59, 0x87, 0xd6);
        private Color _headerColor2 = Color.FromArgb(3, 0x38, 0x93);
        private Font _headerFont = new Font("Arial", 12f, FontStyle.Bold);
        private int _headerHeight = 0x19;
        private string _headerText = "header title";
        private Image _icon;
        private Color _iconTransparentColor = Color.White;
        private IContainer components = null;

        public PanelWithHeader()
        {
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.InitializeComponent();
            base.Padding = new Padding(5, this._headerHeight + 4, 5, 4);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawBorder(Graphics graphics)
        {
            using (Pen pen = new Pen(this._headerColor2))
            {
                graphics.DrawRectangle(pen, 0, 0, base.Width - 1, base.Height - 1);
            }
        }

        private void DrawHeader(Graphics graphics)
        {
            Rectangle rect = new Rectangle(1, 1, base.Width - 2, this._headerHeight);
            using (Brush brush = new LinearGradientBrush(rect, this._headerColor1, this._headerColor2, LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, rect);
            }
        }

        private void DrawIcon(Graphics graphics)
        {
            if (this._icon != null)
            {
                Point point = new Point((base.Width - this._icon.Width) - 2, (this._headerHeight - this._icon.Height) / 2);
                Bitmap image = new Bitmap(this._icon);
                image.MakeTransparent(this._iconTransparentColor);
                graphics.DrawImage(image, point);
            }
        }

        private void DrawText(Graphics graphics)
        {
            if (!string.IsNullOrEmpty(this._headerText))
            {
                SizeF ef = graphics.MeasureString(this._headerText, this._headerFont);
                using (Brush brush = new SolidBrush(Color.White))
                {
                    graphics.DrawString(this._headerText, this._headerFont, brush, (float) 5f, (float) ((this._headerHeight - ef.Height) / 2f));
                }
            }
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.Paint += new PaintEventHandler(this.PanelWithHeader_Paint);
            base.ResumeLayout(false);
        }

        private void PanelWithHeader_Paint(object sender, PaintEventArgs e)
        {
            if (this._headerHeight > 1)
            {
                this.DrawBorder(e.Graphics);
                this.DrawHeader(e.Graphics);
                this.DrawText(e.Graphics);
                this.DrawIcon(e.Graphics);
            }
        }

        [Browsable(true), Category("Owf")]
        public Color HeaderColor1
        {
            get
            {
                return this._headerColor1;
            }
            set
            {
                this._headerColor1 = value;
                base.Invalidate();
            }
        }

        [Category("Owf"), Browsable(true)]
        public Color HeaderColor2
        {
            get
            {
                return this._headerColor2;
            }
            set
            {
                this._headerColor2 = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("Owf")]
        public string HeaderText
        {
            get
            {
                return this._headerText;
            }
            set
            {
                this._headerText = value;
                base.Invalidate();
            }
        }

        [Category("Owf"), Browsable(true)]
        public Image Icon
        {
            get
            {
                return this._icon;
            }
            set
            {
                this._icon = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("Owf")]
        public Color IconTransparentColor
        {
            get
            {
                return this._iconTransparentColor;
            }
            set
            {
                this._iconTransparentColor = value;
                base.Invalidate();
            }
        }
    }
}

