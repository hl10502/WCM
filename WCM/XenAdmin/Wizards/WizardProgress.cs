namespace WCM.XenAdmin.Wizards
{
    using WCM.ConVPX;
    using WCM.ConVPX.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Threading;
    using System.Windows.Forms;
    using WCM.XenAdmin.Controls;

    public class WizardProgress : UserControl
    {
        private int _currentStep;
		private static readonly Color bgBrushColor = Color.FromArgb(0xff, 0xff, 0xff);
        private static readonly SolidBrush bgBrush = new SolidBrush(bgBrushColor);
        private IContainer components = null;
        //private static readonly Color HighlightColorEdge = Color.FromArgb(9, 70, 0xa2);
		private static readonly Color HighlightColorEdge = Color.Blue;
        //private static readonly Color HighlightColorMiddle = Color.FromArgb(10, 80, 200);
		private static readonly Color HighlightColorMiddle = Color.Blue;

        public readonly List<XenTabPage> Steps = new List<XenTabPage>();

        public event EventHandler<WizardProgressEventArgs> EnteringStep;

        public event EventHandler<WizardProgressEventArgs> LeavingStep;

        public WizardProgress()
        {
            this.InitializeComponent();
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(WizardProgress));
            base.SuspendLayout();
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            base.Name = "WizardProgress";
            base.ResumeLayout(false);
        }

        public void NextStep()
        {
            if (!this.OnLeavingStep(true))
            {
                Trace.Assert(!this.IsLastStep);
                int num = this._currentStep + 1;
                while ((num < (this.Steps.Count - 1)) && this.Steps[num].DisableStep)
                {
                    num++;
                }
                if (!this.Steps[num].DisableStep)
                {
                    this._currentStep = num;
                    base.Invalidate();
                    this.OnEnteringStep(true);
                }
            }
        }

        private void OnEnteringStep(bool isForwardsTransition)
        {
            WizardProgressEventArgs e = new WizardProgressEventArgs(isForwardsTransition);
            if (this.EnteringStep != null)
            {
                this.EnteringStep(this, e);
            }
        }

        private bool OnLeavingStep(bool isForwardsTransition)
        {
            WizardProgressEventArgs e = new WizardProgressEventArgs(isForwardsTransition);
            if (this.LeavingStep != null)
            {
                this.LeavingStep(this, e);
            }
            return e.Cancelled;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap image = Resources.wizard_background;
            int height = image.Height;
            int num2 = base.Height - height;
            if (num2 > 0)
            {
                e.Graphics.FillRectangle(bgBrush, new Rectangle(0, 0, base.Width, num2));
            }
            e.Graphics.DrawImage(image, new Rectangle(0, num2, image.Width, height));
            using (LinearGradientBrush brush = new LinearGradientBrush(Point.Empty, new Point(base.Width, 0), HighlightColorEdge, HighlightColorMiddle))
            {
                brush.SetBlendTriangularShape(0.5f);
                float y = 15f;
                for (int i = 0; i < this.Steps.Count; i++)
                {
                    if (i == this.CurrentStep)
                    {
                        if (this.CurrentStepTabPage.HasSubSteps())
                        {
                            e.Graphics.DrawString(this.Steps[i].Text, Program.DefaultFontBold, Brushes.Black, 10f, y);
                            y += 24f;
                            int num5 = 0;
                            foreach (string str in this.CurrentStepTabPage.GetSubSteps())
                            {
                                if (this.CurrentStepTabPage.CurrentSubStep() == num5)
                                {
                                    e.Graphics.FillRectangle(brush, 0f, y, (float) base.Width, 20f);
                                    TextRenderer.DrawText(e.Graphics, str, Program.DefaultFontBold, new Rectangle(10, (int) y, base.Width, 20), Color.White, TextFormatFlags.HidePrefix | TextFormatFlags.VerticalCenter);
                                }
                                else
                                {
                                    TextRenderer.DrawText(e.Graphics, str, Program.DefaultFont, new Rectangle(10, (int) y, base.Width, 20), Color.Black, TextFormatFlags.HidePrefix | TextFormatFlags.VerticalCenter);
                                }
                                y += 24f;
                                num5++;
                            }
                        }
                        else
                        {
                            e.Graphics.FillRectangle(brush, 0f, y, (float) base.Width, 20f);
                            TextRenderer.DrawText(e.Graphics, this.Steps[i].Text, Program.DefaultFontBold, new Rectangle(10, (int) y, base.Width, 20), SystemColors.HighlightText, TextFormatFlags.HidePrefix | TextFormatFlags.VerticalCenter);
                        }
                    }
                    else
                    {
                        TextRenderer.DrawText(e.Graphics, this.Steps[i].Text, Program.DefaultFont, new Rectangle(10, (int) y, base.Width, 20), this.Steps[i].DisableStep ? SystemColors.GrayText : Color.Black, TextFormatFlags.HidePrefix | TextFormatFlags.VerticalCenter);
                    }
                    y += 24f;
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public void PreviousStep()
        {
            Trace.Assert(!this.IsFirstStep);
            if (!this.OnLeavingStep(false))
            {
                int num = this._currentStep - 1;
                while ((num > 0) && this.Steps[num].DisableStep)
                {
                    num--;
                }
                if (!this.Steps[num].DisableStep)
                {
                    this._currentStep = num;
                    base.Invalidate();
                    this.OnEnteringStep(false);
                }
            }
        }

        public int CurrentStep
        {
            get
            {
                return this._currentStep;
            }
        }

        public XenTabPage CurrentStepTabPage
        {
            get
            {
                return this.Steps[this.CurrentStep];
            }
        }

        public bool IsFirstStep
        {
            get
            {
                int num = 0;
                while ((num < this.Steps.Count) && this.Steps[num].DisableStep)
                {
                    num++;
                }
                return (this.CurrentStep == num);
            }
        }

        public bool IsLastStep
        {
            get
            {
                return (this.CurrentStep == (this.Steps.Count - 1));
            }
        }
    }
}

