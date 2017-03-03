namespace WCM.ConVPX.Controls
{
    using System;

    public class ComboBoxIconExItem
    {
        private int _imageIndex;
        private object _item;

        public ComboBoxIconExItem()
        {
        }

        public ComboBoxIconExItem(object item, int imageIndex)
        {
            this._item = item;
            this._imageIndex = imageIndex;
        }

        public override string ToString()
        {
            return this._item.ToString();
        }

        public int ImageIndex
        {
            get
            {
                return this._imageIndex;
            }
            set
            {
                this._imageIndex = value;
            }
        }

        public object Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }
    }
}

