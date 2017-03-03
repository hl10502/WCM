namespace WCM.ConVPX.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class TextAndImageCell : DataGridViewTextBoxCell
    {
        private Size imageSize;
        private System.Drawing.Image imageValue;

        public override object Clone()
        {
            TextAndImageCell cell = base.Clone() as TextAndImageCell;
            cell.imageValue = this.imageValue;
            cell.imageSize = this.imageSize;
            return cell;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            if (this.Image != null)
            {
                GraphicsContainer container = graphics.BeginContainer();
                graphics.SetClip(cellBounds);
                Size size = this.Image.Size;
                Point point = new Point {
                    X = cellBounds.Location.X,
                    Y = cellBounds.Location.Y
                };
                if (size.Width > 0x10)
                {
                    point.Y += 6;
                }
                else
                {
                    point.Y++;
                }
                graphics.DrawImageUnscaled(this.Image, point);
                graphics.EndContainer(container);
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                if ((base.OwningColumn == null) || (this.OwningTextAndImageColumn == null))
                {
                    return this.imageValue;
                }
                if (this.imageValue != null)
                {
                    return this.imageValue;
                }
                return this.OwningTextAndImageColumn.Image;
            }
            set
            {
                if (this.imageValue != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;
                    int num = 0;
                    if (this.imageSize.Width > 0x10)
                    {
                        num = 20;
                    }
                    if (base.HasStyle)
                    {
                        Padding padding = base.InheritedStyle.Padding;
                        base.Style.Padding = new Padding(this.imageSize.Width + num, padding.Top, padding.Right, padding.Bottom);
                    }
                    else
                    {
                        try
                        {
                            Padding padding2 = base.Style.Padding;
                            base.Style.Padding = new Padding(this.imageSize.Width + num, padding2.Top, padding2.Right, padding2.Bottom);
                        }
                        catch
                        {
                            base.Style.Padding = new Padding(this.imageSize.Width + num, 0, 0, 0);
                        }
                    }
                }
            }
        }

        private TextAndImageColumn OwningTextAndImageColumn
        {
            get
            {
                return (base.OwningColumn as TextAndImageColumn);
            }
        }
    }
}

