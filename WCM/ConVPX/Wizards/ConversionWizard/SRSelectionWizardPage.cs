namespace WCM.ConVPX.Wizards.ConversionWizard
{
    using WCM.ConVPX;
    using WCM.ConVPX.Controls;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Properties;
    using WCM.ConVPX.Wizards;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using WCM.XenAdmin.Controls;
    using WCM.XenAdmin.Wizards;
    using WinAPI;
	using System.Reflection;
	using System.Collections;

    public class SRSelectionWizardPage : XenTabPage, IWizardPage
    {
        private List<WinAPI.SR> _availSRs;
        private WinAPI.SR _defaultSR;
        private Dictionary<WinAPI.SR, long> _diskSpaceDict;
        private long _otherUsedDiskSpace;
        private MethodInvoker _updateWizardButtons;
        private Chart chart1;
        private IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label labelError;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected PictureBox pictureBoxError;
        private ComboBoxIconEx SRComboBoxEx;
        private readonly ToolTip SRDisplayNameToolTip = new ToolTip();
        private Label SRLabel;
        private TableLayoutPanel tableLayoutPanel1;

        public SRSelectionWizardPage()
        {
            this.InitializeComponent();
            this.SRComboBoxEx.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SRComboBoxEx.ImageList = Images.ImageList16;
            InitSelectedFieldTooltip(this.SRDisplayNameToolTip);
        }

        public void Build()
        {
            this.SRComboBoxEx.Items.Clear();
            if ((this.AvailableStorageRepositories != null) && (this.AvailableStorageRepositories.Count > 0))
            {
                this.PopulateComboBox();
                this.UpdatePieChart();
                this.ShowErrorFields(false);
            }
            else
            {
                this.labelError.Text = Messages.NO_DETECTED_SRS;
                this.ShowErrorFields(true);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public override bool EnableFinish()
        {
            return false;
        }

        public override bool EnableNext()
        {
            return ((this.AvailableStorageRepositories != null) && (this.AvailableStorageRepositories.Count > 0));
        }

        public override bool EnablePrevious()
        {
            return true;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SRSelectionWizardPage));
            ChartArea item = new ChartArea();
            Legend legend = new Legend();
            Series series = new Series();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.SRLabel = new Label();
            this.SRComboBoxEx = new ComboBoxIconEx();
            this.pictureBoxError = new PictureBox();
            this.labelError = new Label();
            this.chart1 = new Chart();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.label1 = new Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxError).BeginInit();
            this.chart1.BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            manager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.SRLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SRComboBoxEx, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxError, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelError, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            manager.ApplyResources(this.SRLabel, "SRLabel");
            this.SRLabel.Name = "SRLabel";
            this.SRComboBoxEx.DrawMode = DrawMode.OwnerDrawFixed;
            this.SRComboBoxEx.FormattingEnabled = true;
            this.SRComboBoxEx.ImageList = null;
            manager.ApplyResources(this.SRComboBoxEx, "SRComboBoxEx");
            this.SRComboBoxEx.Name = "SRComboBoxEx";
            this.SRComboBoxEx.SelectedIndexChanged += new EventHandler(this.SRComboBoxEx_SelectedIndexChanged);
            manager.ApplyResources(this.pictureBoxError, "pictureBoxError");
            this.pictureBoxError.Image = Resources._000_error_h32bit_16;
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.TabStop = false;
            manager.ApplyResources(this.labelError, "labelError");
            this.labelError.Name = "labelError";
            this.chart1.BackColor = SystemColors.Control;
            this.chart1.BackImageTransparentColor = SystemColors.Control;
            this.chart1.BackSecondaryColor = SystemColors.Control;
            this.chart1.BorderlineColor = SystemColors.Control;
            item.BackColor = SystemColors.Control;
            item.BackSecondaryColor = SystemColors.Control;
            item.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(item);
            this.tableLayoutPanel1.SetColumnSpan(this.chart1, 2);
            legend.BackColor = SystemColors.Control;
            legend.Name = "Legend1";
            this.chart1.Legends.Add(legend);
            manager.ApplyResources(this.chart1, "chart1");
            this.chart1.Name = "chart1";
            series.ChartArea = "ChartArea1";
            series.ChartType = SeriesChartType.Pie;
            series.Color = SystemColors.Control;
            series.Legend = "Legend1";
            series.Name = "Series1";
            this.chart1.Series.Add(series);

            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            manager.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            manager.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            manager.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            this.HelpID = "SRSelectionWizard";
            base.Name = "SRSelectionWizardPage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize) this.pictureBoxError).EndInit();
            this.chart1.EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }

        public static void InitSelectedFieldTooltip(ToolTip tooltip)
        {
            tooltip.Active = true;
            tooltip.AutomaticDelay = 0;
            tooltip.AutoPopDelay = 0xc350;
            tooltip.InitialDelay = 50;
            tooltip.ReshowDelay = 50;
            tooltip.ShowAlways = true;
        }

        public void OnPageExit(WizardProgressEventArgs e)
        {
        }

        public void OnPageShow(WizardProgressEventArgs e)
        {
            this._updateWizardButtons();
        }

        private void PopulateComboBox()
        {
            try
            {
                int num = 0;
                int num2 = -1;
                if (this.AvailableStorageRepositories != null)
                {
                    List<ToStringWrapper<WinAPI.SR>> list = new List<ToStringWrapper<WinAPI.SR>>();
                    foreach (WinAPI.SR sr in this.AvailableStorageRepositories)
                    {
                        try
                        {
                            if ((this._defaultSR != null) && this._defaultSR.uuid.Equals(sr.uuid))
                            {
                                num2 = num;
                            }
                            this._otherUsedDiskSpace = 0L;
                            if (this.OtherUsedDiskSpaceDict.ContainsKey(sr))
                            {
                                this._otherUsedDiskSpace = this.OtherUsedDiskSpaceDict[sr];
                            }
                            list.Add(new ToStringWrapper<WinAPI.SR>(sr, new ToStringDelegate<WinAPI.SR>(Helpers.SrToString)));
                            ToStringWrapper<WinAPI.SR> item = new ToStringWrapper<WinAPI.SR>(sr, Helpers.SrToString(sr, this._otherUsedDiskSpace));
                            int imageIndex = Images.GetImageIndex16For(sr);
                            this.SRComboBoxEx.Items.Add(new ComboBoxIconExItem(item, imageIndex));
                        }
                        catch (Exception exception)
                        {
                            LOG.Error(exception.Message);
                        }
                        num++;
                    }
                }
                if (this.SRComboBoxEx.Items.Count > 0)
                {
                    if (num2 != -1)
                    {
                        this.SRComboBoxEx.SelectedIndex = num2;
                    }
                    else
                    {
                        this.SRComboBoxEx.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
            }
        }

        private void ShowErrorFields(bool value)
        {
            this.labelError.Visible = value;
            this.pictureBoxError.Visible = value;
            this.chart1.Visible = !value;
        }

        private void SRComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdatePieChart();
            try
            {
                if (this.SelectedSR != null)
                {
                    ComboBoxIconExItem selectedItem = (ComboBoxIconExItem) this.SRComboBoxEx.SelectedItem;
                    ToStringWrapper<WinAPI.SR> item = (ToStringWrapper<WinAPI.SR>) selectedItem.Item;
                    if (item != null)
                    {
                        this.SRDisplayNameToolTip.SetToolTip(this.SRComboBoxEx, item.ToString());
                    }
                    else
                    {
                        this.SRDisplayNameToolTip.SetToolTip(this.SRComboBoxEx, "");
                    }
                }
                else
                {
                    this.SRDisplayNameToolTip.SetToolTip(this.SRComboBoxEx, "");
                }
            }
            catch
            {
            }
        }

        private void UpdatePieChart()
        {
            try
            {
                WinAPI.SR selectedSR = this.SelectedSR;
                this._otherUsedDiskSpace = 0L;
                if (this.OtherUsedDiskSpaceDict.ContainsKey(selectedSR))
                {
                    this._otherUsedDiskSpace = this.OtherUsedDiskSpaceDict[selectedSR];
                }
                double num = selectedSR.physical_size;
                double num2 = selectedSR.physical_utilisation + this._otherUsedDiskSpace;
                double num3 = num - num2;
                long bytes = selectedSR.physical_size - (selectedSR.physical_utilisation + this._otherUsedDiskSpace);
                double num5 = (num3 * 100.0) / num;
                double num6 = (num2 * 100.0) / num;
                double[] numArray = new double[] { num6, num5 };
                string[] xValue = new string[] { string.Format(Messages.USED_SPACE, Helpers.DiskSizeString(selectedSR.physical_utilisation + this._otherUsedDiskSpace, 2), num6), string.Format(Messages.FREE_SPACE, Helpers.DiskSizeString(bytes, 2), num5) };
                this.chart1.Series["Series1"].Points.DataBindXY(xValue, new IEnumerable[] { numArray });
                this.chart1.Series["Series1"]["PieLabelStyle"] = "Inside";
                this.chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                this.chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";
                this.chart1.Legends["Legend1"].Enabled = false;
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }


        public List<WinAPI.SR> AvailableStorageRepositories
        {
            get
            {
                return this._availSRs;
            }
            set
            {
                this._availSRs = value;
            }
        }

        public WinAPI.SR DefaultStorageRepository
        {
            get
            {
                return this._defaultSR;
            }
            set
            {
                try
                {
                    this._defaultSR = value;
                }
                catch
                {
                    this._defaultSR = null;
                }
            }
        }

        public Label LabelError
        {
            get
            {
                return this.labelError;
            }
        }

        public long OtherUsedDiskSpace
        {
            get
            {
                return this._otherUsedDiskSpace;
            }
            set
            {
                this._otherUsedDiskSpace = value;
            }
        }

        public Dictionary<WinAPI.SR, long> OtherUsedDiskSpaceDict
        {
            get
            {
                return this._diskSpaceDict;
            }
            set
            {
                this._diskSpaceDict = value;
                this.Build();
            }
        }

        public override string PageTitle
        {
            get
            {
                return Messages.WIZARD_SR_SELECTION_TITLE;
            }
        }

        public PictureBox PictureBoxError
        {
            get
            {
                return this.pictureBoxError;
            }
        }

        public WinAPI.SR SelectedSR
        {
            get
            {
                try
                {
                    ComboBoxIconExItem selectedItem = (ComboBoxIconExItem) this.SRComboBoxEx.SelectedItem;
                    ToStringWrapper<WinAPI.SR> item = (ToStringWrapper<WinAPI.SR>) selectedItem.Item;
                    if (item != null)
                    {
                        return item.item;
                    }
                }
                catch
                {
                }
                return null;
            }
        }

        public override string Text
        {
            get
            {
                return Messages.WIZARD_SR_SELECTION_TEXT;
            }
        }

        public MethodInvoker UpdateWizardButtons
        {
            get
            {
                return this._updateWizardButtons;
            }
            set
            {
                this._updateWizardButtons = value;
            }
        }
    }
}

