namespace WCM.ConVPX.Controls
{
    using System;
    using System.Drawing;

    public class Slice
    {
        private static int countNoName;
        private Color sliceColor;
        private string sliceName;
        private int sliceRange;

        private Slice()
        {
        }

        public Slice(string name, int range, Color color)
        {
            if (name == "")
            {
                this.sliceName = "Slice " + countNoName.ToString();
                countNoName++;
            }
            else
            {
                this.sliceName = name;
            }
            if (range < 0)
            {
                range = 0;
            }
            else
            {
                this.sliceRange = range;
            }
            this.sliceColor = color;
        }

        public Color GetSliceColor()
        {
            return this.sliceColor;
        }

        public string GetSliceName()
        {
            return this.sliceName;
        }

        public int GetSliceRange()
        {
            return this.sliceRange;
        }

        public void SetSliceColor(Color color)
        {
            this.sliceColor = color;
        }

        public void SetSliceName(string name)
        {
            if (name == "")
            {
                this.sliceName = "Slice " + countNoName.ToString();
                countNoName++;
            }
            else
            {
                this.sliceName = name;
            }
        }

        public void SetSliceRange(int range)
        {
            if (range < 0)
            {
                range = 0;
            }
            else
            {
                this.sliceRange = range;
            }
        }
    }
}

