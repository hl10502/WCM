namespace WCM.ConVPX.Dialogs
{
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Properties;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class AboutDialog : DialogBase
    {
        private Label ApplianceVersionLabel;
        private IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private LinkLabel LegalNoticesLinkLabel;
        private Button OkButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label VersionLabel;
        private Label XSBuildDateValueLabel;
        private Label XSBuildNumberValueLabel;
        private Label XSBuildVersionValueLabel;

        public AboutDialog()
        {
            this.InitializeComponent();
            this.ClearFields();
            this.Build();
        }

        private void Build()
        {
            base.Icon = Resources.upsell_32;
            Version version = Program.Version;
            this.VersionLabel.Text = string.Format(Messages.VERSION_NUMBER, new object[] { version.Major, version.Minor, version.Build, version.Revision });
            this.ApplianceVersionLabel.Text = Program.ApplianceVersion;
            if (Program.XenServerVersionInfoDict.Count == 3)
            {
                this.XSBuildDateValueLabel.Text = Program.XenServerVersionInfoDict["date"];
                this.XSBuildNumberValueLabel.Text = Program.XenServerVersionInfoDict["build_number"];
                this.XSBuildVersionValueLabel.Text = Program.XenServerVersionInfoDict["product_version"];
            }
        }

        private void ClearFields()
        {
            this.VersionLabel.Text = "";
            this.ApplianceVersionLabel.Text = "";
            this.XSBuildDateValueLabel.Text = "";
            this.XSBuildNumberValueLabel.Text = "";
            this.XSBuildVersionValueLabel.Text = "";
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AboutDialog));
            this.OkButton = new Button();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.VersionLabel = new Label();
            this.label2 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.ApplianceVersionLabel = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.XSBuildDateValueLabel = new Label();
            this.XSBuildNumberValueLabel = new Label();
            this.XSBuildVersionValueLabel = new Label();
            this.label1 = new Label();
            this.LegalNoticesLinkLabel = new LinkLabel();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            resources.ApplyResources(this.OkButton, "OkButton");
            this.OkButton.Name = "OkButton";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new EventHandler(this.OkButton_Click);
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.VersionLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ApplianceVersionLabel, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.XSBuildDateValueLabel, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.XSBuildNumberValueLabel, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.XSBuildVersionValueLabel, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LegalNoticesLinkLabel, 0, 0x11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            resources.ApplyResources(this.VersionLabel, "VersionLabel");
            this.VersionLabel.Name = "VersionLabel";
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label4, "label4");
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Name = "label4";
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            resources.ApplyResources(this.ApplianceVersionLabel, "ApplianceVersionLabel");
            this.ApplianceVersionLabel.Name = "ApplianceVersionLabel";
            resources.ApplyResources(this.label6, "label6");
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 2);
            this.label6.Name = "label6";
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            resources.ApplyResources(this.XSBuildDateValueLabel, "XSBuildDateValueLabel");
            this.XSBuildDateValueLabel.Name = "XSBuildDateValueLabel";
            resources.ApplyResources(this.XSBuildNumberValueLabel, "XSBuildNumberValueLabel");
            this.XSBuildNumberValueLabel.Name = "XSBuildNumberValueLabel";
            resources.ApplyResources(this.XSBuildVersionValueLabel, "XSBuildVersionValueLabel");
            this.XSBuildVersionValueLabel.Name = "XSBuildVersionValueLabel";
            resources.ApplyResources(this.label1, "label1");
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Name = "label1";
            resources.ApplyResources(this.LegalNoticesLinkLabel, "LegalNoticesLinkLabel");
            this.tableLayoutPanel1.SetColumnSpan(this.LegalNoticesLinkLabel, 2);
            this.LegalNoticesLinkLabel.Name = "LegalNoticesLinkLabel";
            this.LegalNoticesLinkLabel.TabStop = true;
            this.LegalNoticesLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LegalNoticesLinkLabel_LinkClicked);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.OkButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            base.AcceptButton = this.OkButton;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AboutDialog";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void LegalNoticesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Helpers.LaunchLegalNoticesDialog();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            base.Dispose();
            Helpers.aboutDialog = null;
        }
    }
}

