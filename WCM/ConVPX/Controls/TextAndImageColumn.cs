namespace WCM.ConVPX.Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class TextAndImageColumn : DataGridViewTextBoxColumn
    {
        private Size imageSize;
        private System.Drawing.Image imageValue;

        public TextAndImageColumn()
        {
            this.CellTemplate = new TextAndImageCell();
        }

        public override object Clone()
        {
            TextAndImageColumn column = base.Clone() as TextAndImageColumn;
            column.imageValue = this.imageValue;
            column.imageSize = this.imageSize;
            return column;
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this.imageValue;
            }
            set
            {
                if (this.Image != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;
                    if (this.InheritedStyle != null)
                    {
                        Padding padding = this.InheritedStyle.Padding;
                        this.DefaultCellStyle.Padding = new Padding(this.imageSize.Width, padding.Top, padding.Right, padding.Bottom);
                    }
                    else
                    {
                        try
                        {
                            Padding padding2 = new Padding(0, 1, 0, 30);
                            this.DefaultCellStyle.Padding = new Padding(this.imageSize.Width, padding2.Top, padding2.Right, padding2.Bottom);
                        }
                        catch
                        {
                            this.DefaultCellStyle.Padding = new Padding(this.imageSize.Width, 0, 0, 0);
                        }
                    }
                }
            }
        }

        internal Size ImageSize
        {
            get
            {
                return this.imageSize;
            }
        }

        private TextAndImageCell TextAndImageCellTemplate
        {
            get
            {
                return (this.CellTemplate as TextAndImageCell);
            }
        }
    }
}

