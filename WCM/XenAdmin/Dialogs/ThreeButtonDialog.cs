namespace WCM.XenAdmin.Dialogs
{
    using WCM.ConVPX;
    using WCM.ConVPX.Dialogs;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class ThreeButtonDialog : DialogBase
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private bool closedFromButton;
        private IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private string helpName;
        private Label labelMessage;
        private PictureBox pictureBoxIcon;
        private TableLayoutPanel tableLayoutPanel1;

        public ThreeButtonDialog(Details properties) : this(properties, new TBDButton[] { ButtonOK })
        {
        }

        public ThreeButtonDialog(Details properties, string helpName) : this(properties, new TBDButton[] { ButtonOK })
        {
            this.helpName = helpName;
            base.HelpButton = true;
        }

        public ThreeButtonDialog(Details properties, params TBDButton[] buttons)
        {
            this.helpName = "DefaultHelpTopic";
            Trace.Assert((buttons.Length > 0) && (buttons.Length < 4), "Three button dialog can only have between 1 and 3 buttons.");
            this.InitializeComponent();
            this.pictureBoxIcon.Image = properties.Icon.ToBitmap();
            this.labelMessage.Text = properties.MainMessage;
            if (properties.WindowTitle != null)
            {
                this.Text = properties.WindowTitle;
            }
            this.button1.Visible = true;
            this.button1.Text = buttons[0].label;
            this.button1.DialogResult = buttons[0].result;
            if (buttons[0].defaultAction == ButtonType.ACCEPT)
            {
                base.AcceptButton = this.button1;
            }
            else if (buttons[0].defaultAction == ButtonType.CANCEL)
            {
                base.CancelButton = this.button1;
            }
            if (buttons[0].selected)
            {
                this.button1.Select();
            }
            if (buttons.Length > 1)
            {
                this.button2.Visible = true;
                this.button2.Text = buttons[1].label;
                this.button2.DialogResult = buttons[1].result;
                if (buttons[1].defaultAction == ButtonType.ACCEPT)
                {
                    base.AcceptButton = this.button2;
                }
                else if (buttons[1].defaultAction == ButtonType.CANCEL)
                {
                    base.CancelButton = this.button2;
                }
                if (buttons[1].selected)
                {
                    this.button2.Select();
                }
            }
            else
            {
                this.button2.Visible = false;
            }
            if (buttons.Length > 2)
            {
                this.button3.Visible = true;
                this.button3.Text = buttons[2].label;
                this.button3.DialogResult = buttons[2].result;
                if (buttons[2].defaultAction == ButtonType.ACCEPT)
                {
                    base.AcceptButton = this.button3;
                }
                else if (buttons[2].defaultAction == ButtonType.CANCEL)
                {
                    base.CancelButton = this.button3;
                }
                if (buttons[2].selected)
                {
                    this.button3.Select();
                }
            }
            else
            {
                this.button3.Visible = false;
            }
        }

        public ThreeButtonDialog(Details properties, string helpName, params TBDButton[] buttons) : this(properties, buttons)
        {
            this.helpName = helpName;
            base.HelpButton = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.closedFromButton = true;
            base.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.closedFromButton = true;
            base.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.closedFromButton = true;
            base.Close();
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ThreeButtonDialog));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.pictureBoxIcon = new PictureBox();
            this.labelMessage = new Label();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.button3 = new Button();
            this.button2 = new Button();
            this.button1 = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxIcon).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMessage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.TabStop = false;
            resources.ApplyResources(this.labelMessage, "labelMessage");
            this.labelMessage.MaximumSize = new Size(0x199, 0x270f);
            this.labelMessage.Name = "labelMessage";
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            resources.ApplyResources(this.button1, "button1");
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            base.Controls.Add(this.tableLayoutPanel1);
            base.HelpButton = false;
            base.Name = "ThreeButtonDialog";
            base.FormClosing += new FormClosingEventHandler(this.ThreeButtonDialog_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize) this.pictureBoxIcon).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ThreeButtonDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && !this.closedFromButton)
            {
                if ((base.CancelButton == null) && (this.Buttons.Find(b => b.DialogResult == DialogResult.Cancel) == null))
                {
                    if (this.Buttons.Count == 1)
                    {
                        base.DialogResult = this.Buttons[0].DialogResult;
                    }
                    else if (((this.Buttons.Count == 2) && (this.Buttons[0].DialogResult == DialogResult.Yes)) && (this.Buttons[1].DialogResult == DialogResult.No))
                    {
                        base.DialogResult = DialogResult.No;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    base.DialogResult = DialogResult.Cancel;
                }
            }
        }

        public static TBDButton ButtonCancel
        {
            get
            {
                return new TBDButton(Messages.CANCEL, DialogResult.Cancel);
            }
        }

        public static TBDButton ButtonNo
        {
            get
            {
                return new TBDButton(Messages.NO, DialogResult.No);
            }
        }

        public static TBDButton ButtonOK
        {
            get
            {
                return new TBDButton(Messages.OK, DialogResult.OK);
            }
        }

        public List<Button> Buttons
        {
            get
            {
                List<Button> list = new List<Button> {
                    this.button1
                };
                if (this.button2.Visible)
                {
                    list.Add(this.button2);
                }
                if (this.button3.Visible)
                {
                    list.Add(this.button3);
                }
                return list;
            }
        }

        public static TBDButton ButtonYes
        {
            get
            {
                return new TBDButton(Messages.YES, DialogResult.Yes);
            }
        }

        internal override string HelpName
        {
            get
            {
                return this.helpName;
            }
        }

        public enum ButtonType
        {
            NONE,
            ACCEPT,
            CANCEL
        }

        public class Details
        {
            public System.Drawing.Icon Icon;
            public string MainMessage;
            public string WindowTitle;

            public Details(System.Drawing.Icon Icon, string MainMessage)
            {
                this.MainMessage = "";
                this.Icon = Icon;
                this.MainMessage = MainMessage;
            }

            public Details(System.Drawing.Icon Icon, string MainMessage, string WindowTitle) : this(Icon, MainMessage)
            {
                this.WindowTitle = WindowTitle;
            }
        }

        public class TBDButton
        {
            public ThreeButtonDialog.ButtonType defaultAction;
            public string label;
            public DialogResult result;
            public bool selected;

            public TBDButton(string label, DialogResult result)
            {
                this.label = label;
                this.result = result;
                if ((result == DialogResult.OK) || (result == DialogResult.Yes))
                {
                    this.defaultAction = ThreeButtonDialog.ButtonType.ACCEPT;
                }
                if ((result == DialogResult.No) || (result == DialogResult.Cancel))
                {
                    this.defaultAction = ThreeButtonDialog.ButtonType.CANCEL;
                }
            }

            public TBDButton(string label, DialogResult result, ThreeButtonDialog.ButtonType isDefaultButton) : this(label, result)
            {
                this.defaultAction = isDefaultButton;
            }

            public TBDButton(string label, DialogResult result, ThreeButtonDialog.ButtonType isDefaultButton, bool select) : this(label, result, isDefaultButton)
            {
                this.selected = select;
            }
        }
    }
}

