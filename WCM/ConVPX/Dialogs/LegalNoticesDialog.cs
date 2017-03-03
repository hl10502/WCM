namespace WCM.ConVPX.Dialogs
{
    using WCM.ConVPX.Core;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class LegalNoticesDialog : DialogBase
    {
        private Button button1;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;

        public LegalNoticesDialog()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LegalNoticesDialog));
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label3 = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            base.SuspendLayout();
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = SystemColors.Window;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = Color.Transparent;
            this.label3.Name = "label3";
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = Color.Transparent;
            this.label1.Name = "label1";
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = Color.Transparent;
            this.label2.Name = "label2";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label2);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "LegalNoticesDialog";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            base.Dispose();
            Helpers.legalNoticesDialog = null;
        }
    }
}

