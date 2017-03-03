namespace WCM.ConVPX.Wizards.ConversionWizard
{
    using ExportImport.CommonTypes;
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Properties;
    using WCM.ConVPX.Wizards;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using WCM.XenAdmin.Controls;
    using WCM.XenAdmin.Wizards;
    using WinAPI;
	using System.Reflection;

    public class VMSelectionWizardPage : XenTabPage, IWizardPage
    {
        private List<VmInstance> _availVMs;
        private string _freeSpace;
        private string _hostname = "";
        private long _otherUsedDiskSpace;
        private string _password = "";
        private string _selectedSpace;
        private WinAPI.SR _SR;
        private MethodInvoker _updateWizardButtons;
        private string _usedSpace;
        private string _username = "";
        private bool _validToAdvance;
        private Chart chart1;
        private LinkLabel ClearAllLinkLabel;
        private IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelError;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected PictureBox pictureBoxError;
        private LinkLabel RefreshLinkLabel;
        private LinkLabel SelectAllLinkLabel;
        private int sortColumn = -1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private const int VM_ICON_INDEX = 0;
        private const int VM_OFF_ICON = 2;
        private const int VM_RUNNING_ICON_INDEX = 3;
        private const int VM_SUSPENDED_ICON_INDEX = 4;
        private const int VM_TEMPLATE_ICON_INDEX = 1;
        private ListView vmListView;

        public VMSelectionWizardPage()
        {
            this.InitializeComponent();
            this.InitializeListView();
            this.vmListView.ItemChecked -= new ItemCheckedEventHandler(this.vmListView_ItemChecked);
        }

        public void Build()
        {
            this.sortColumn = -1;
            this.vmListView.Items.Clear();
            this.BuildVMList();
        }

        private void BuildVMList()
        {
            try
            {
                if (this.AvailableVirtualMachines != null)
                {
                    foreach (VmInstance instance in this.AvailableVirtualMachines)
                    {
                        try
                        {
                            string text = instance.Template ? string.Format(Messages.VM_TEMPLATE_DISPLAY_NAME, instance.Name) : instance.Name;
                            ListViewItem item = new ListViewItem(text, 0) {
                                Tag = instance,
                                Checked = false,
                                ImageIndex = this.GetVmStateIconIndex(instance)
                            };
                            item.SubItems.Add(ConVpxEnums.GetDisplayText<ConVpxEnums.VmState>((ConVpxEnums.VmState) instance.PowerState));
                            item.SubItems.Add(instance.OSType);
                            item.SubItems.Add(string.Format(Messages.DISK_WRITE_BYTES, ((float) (instance.CommittedStorage + instance.UncommittedStorage)) / 1.073742E+09f));
                            this.vmListView.Items.Add(item);
                        }
                        catch (Exception exception)
                        {
                            LOG.Error(exception.Message);
                        }
                    }
                    this.vmListView.Columns[0].Width = -2;
                    this.vmListView.Columns[1].Width = -2;
                    this.vmListView.Columns[2].Width = -2;
                    this.vmListView.Columns[3].Width = -2;
                    this.DisableRunningVMs();
                }
            }
            catch (Exception exception2)
            {
                LOG.Error(exception2, exception2);
            }
        }

        private void ClearAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in this.vmListView.Items)
            {
                item.Checked = false;
            }
        }

        private void DisableRunningVMs()
        {
            try
            {
                if (this.vmListView.Items.Count > 0)
                {
                    foreach (ListViewItem item in this.vmListView.Items)
                    {
                        VmInstance tag = (VmInstance) item.Tag;
						/**
						 0 已关机
						 1 运行中
						 2 挂起中
						 */
						if (tag.PowerState != 0)
                        {
                            item.ForeColor = Color.Silver;
                        }
                        else
                        {
                            item.ForeColor = Color.Black;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
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
            return this._validToAdvance;
        }

        public override bool EnablePrevious()
        {
            return true;
        }

        private double GetTotalEstimatedDiskSize()
        {
            double num = 0.0;
            try
            {
                foreach (ListViewItem item in this.vmListView.Items)
                {
                    if (item.Checked)
                    {
                        VmInstance tag = (VmInstance) item.Tag;
                        num += tag.CommittedStorage + tag.UncommittedStorage;
                    }
                }
            }
            catch
            {
                num = 0.0;
            }
            return num;
        }

        private int GetVmStateIconIndex(VmInstance vm)
        {
            int num = 0;
            if (vm.Template)
            {
                return 1;
            }
            if (vm.PowerState == 0) //已关机
            {
                return 2;
            }
            if (vm.PowerState == 1) //运行中
            {
                return 3;
            }
            if (vm.PowerState == 2) //挂起中
            {
                num = 4;
            }
            return num;
        }

        private bool HasCheckedVM()
        {
            bool flag = false;
            try
            {
                foreach (ListViewItem item in this.vmListView.Items)
                {
                    if ((item != null) && item.Checked)
                    {
                        return true;
                    }
                }
                return flag;
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            return flag;
        }

        private bool HasExceededSelectedSpaceLimit(double freeSpace, double selectedSpace)
        {
            if (selectedSpace > freeSpace)
            {
                this.LabelError.Text = Messages.NOT_ENOUGH_FREE_SPACE;
                this.LabelError.Visible = true;
                this.PictureBoxError.Visible = true;
                this.chart1.Visible = false;
            }
            else
            {
                this.LabelError.Visible = false;
                this.PictureBoxError.Visible = false;
                this.chart1.Visible = true;
            }
            return (selectedSpace > freeSpace);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(VMSelectionWizardPage));
            ChartArea item = new ChartArea();
            Legend legend = new Legend();
            Series series = new Series();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.vmListView = new ListView();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.RefreshLinkLabel = new LinkLabel();
            this.SelectAllLinkLabel = new LinkLabel();
            this.ClearAllLinkLabel = new LinkLabel();
            this.chart1 = new Chart();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.labelError = new Label();
            this.pictureBoxError = new PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.chart1.BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxError).BeginInit();
            base.SuspendLayout();
            manager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.vmListView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            manager.ApplyResources(this.vmListView, "vmListView");
            this.vmListView.Name = "vmListView";
            this.vmListView.UseCompatibleStateImageBehavior = false;
            this.vmListView.ColumnClick += new ColumnClickEventHandler(this.vmListView_ColumnClick);
            this.vmListView.ItemChecked += new ItemCheckedEventHandler(this.vmListView_ItemChecked);
            this.vmListView.VisibleChanged += new EventHandler(this.vmListView_VisibleChanged);
            this.flowLayoutPanel1.Controls.Add(this.RefreshLinkLabel);
            this.flowLayoutPanel1.Controls.Add(this.SelectAllLinkLabel);
            this.flowLayoutPanel1.Controls.Add(this.ClearAllLinkLabel);
            manager.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            manager.ApplyResources(this.RefreshLinkLabel, "RefreshLinkLabel");
            this.RefreshLinkLabel.Name = "RefreshLinkLabel";
            this.RefreshLinkLabel.TabStop = true;
            this.RefreshLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.RefreshLinkLabel_LinkClicked);
            manager.ApplyResources(this.SelectAllLinkLabel, "SelectAllLinkLabel");
            this.SelectAllLinkLabel.Name = "SelectAllLinkLabel";
            this.SelectAllLinkLabel.TabStop = true;
            this.SelectAllLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.SelectAllLinkLabel_LinkClicked);
            manager.ApplyResources(this.ClearAllLinkLabel, "ClearAllLinkLabel");
            this.ClearAllLinkLabel.Name = "ClearAllLinkLabel";
            this.ClearAllLinkLabel.TabStop = true;
            this.ClearAllLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.ClearAllLinkLabel_LinkClicked);
            this.chart1.BackColor = SystemColors.Control;
            this.chart1.BackImageTransparentColor = SystemColors.Control;
            this.chart1.BackSecondaryColor = SystemColors.Control;
            this.chart1.BorderlineColor = SystemColors.Control;
            item.BackColor = SystemColors.Control;
            item.BackSecondaryColor = SystemColors.Control;
            item.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(item);
            manager.ApplyResources(this.chart1, "chart1");
            legend.BackColor = SystemColors.Control;
            legend.Name = "Legend1";
            this.chart1.Legends.Add(legend);
            this.chart1.Name = "chart1";
            series.ChartArea = "ChartArea1";
            series.ChartType = SeriesChartType.Pie;
            series.Color = SystemColors.Control;
            series.Legend = "Legend1";
            series.Name = "Series1";
            this.chart1.Series.Add(series);
            manager.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.pictureBoxError, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelError, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            manager.ApplyResources(this.labelError, "labelError");
            this.labelError.Name = "labelError";

            manager.ApplyResources(this.pictureBoxError, "pictureBoxError");
            this.pictureBoxError.Image = Resources._000_error_h32bit_16;
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.TabStop = false;
            manager.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            this.HelpID = "VMSelectionWizard";
            base.Name = "VMSelectionWizardPage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.chart1.EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((ISupportInitialize) this.pictureBoxError).EndInit();
            base.ResumeLayout(false);
        }

        public void InitializeListView()
        {
            this.vmListView.View = View.Details;
            this.vmListView.LabelEdit = false;
            this.vmListView.AllowColumnReorder = false;
            this.vmListView.CheckBoxes = true;
            this.vmListView.FullRowSelect = true;
            this.vmListView.GridLines = true;
            this.vmListView.Sorting = SortOrder.Ascending;
            this.vmListView.Columns.Add(Messages.VM_NAME, -2, HorizontalAlignment.Left);
            this.vmListView.Columns.Add(Messages.VM_POWER_STATE, -2, HorizontalAlignment.Left);
            this.vmListView.Columns.Add(Messages.VM_OSTYPE, -2, HorizontalAlignment.Left);
            this.vmListView.Columns.Add(Messages.VM_DISK_SIZE, -2, HorizontalAlignment.Left);
            this.vmListView.Columns[0].Width = -2;
            this.vmListView.Columns[1].Width = -2;
            this.vmListView.Columns[2].Width = -2;
            this.vmListView.Columns[3].Width = -2;
            ImageList list = new ImageList();
            ImageList list2 = new ImageList();
            list.Images.Add(Resources.virtual_machine_16);
            list.Images.Add(Resources.vm_template_16);
            list.Images.Add(Resources.virtual_machine_off_16);
            list.Images.Add(Resources.virtual_machine_running_16);
            list.Images.Add(Resources.virtual_machine_suspended_16);
            list2.Images.Add(Resources.virtual_machine_24);
            list2.Images.Add(Resources.vm_template_24);
            list2.Images.Add(Resources.vm_template_24);
            list2.Images.Add(Resources.vm_template_24);
            list2.Images.Add(Resources.vm_template_24);
            this.vmListView.LargeImageList = list2;
            this.vmListView.SmallImageList = list;
        }

        public void OnPageExit(WizardProgressEventArgs e)
        {
            this.vmListView.ItemChecked -= new ItemCheckedEventHandler(this.vmListView_ItemChecked);
        }

        public void OnPageShow(WizardProgressEventArgs e)
        {
            this._updateWizardButtons();
        }

        private void RefreshLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ServerInfo destVMwareServerInfo = new ServerInfo {
                    ServerType = 2,
                    Hostname = this.Hostname,
                    Username = this.Username,
                    Password = this.Password
                };
                this.Cursor = Cursors.WaitCursor;
                this.AvailableVirtualMachines = Commands.GetVMs(Program.ClientConnection, destVMwareServerInfo);
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SelectAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in this.vmListView.Items)
            {
                item.Checked = true;
            }
        }

        public void UpdatePieChart()
        {
            try
            {
                WinAPI.SR selectedSR = this.SelectedSR;
                double totalEstimatedDiskSize = this.GetTotalEstimatedDiskSize();
                double num2 = selectedSR.physical_size;
                double bytes = selectedSR.physical_utilisation + this._otherUsedDiskSpace;
                double freeSpace = num2 - bytes;
                if (this.HasExceededSelectedSpaceLimit(freeSpace, totalEstimatedDiskSize))
                {
                    totalEstimatedDiskSize = freeSpace;
                    freeSpace = 0.0;
                }
                else
                {
                    freeSpace -= totalEstimatedDiskSize;
                }
                double[] numArray = new double[] { bytes, freeSpace, totalEstimatedDiskSize };
                this.FreeSpaceDisplayString = string.Format(Messages.FREE_SPACE2, Helpers.DiskSizeString(freeSpace));
                this.UsedSpaceDisplayString = string.Format(Messages.USED_SPACE2, Helpers.DiskSizeString(bytes));
                this.SelectedSpaceDisplayString = string.Format(Messages.SELECTED_SPACE, Helpers.DiskSizeString(totalEstimatedDiskSize));
                string[] xValue = new string[] { this.UsedSpaceDisplayString, this.FreeSpaceDisplayString, this.SelectedSpaceDisplayString };
                this.chart1.Series["Series1"].Points.DataBindXY(xValue, new IEnumerable[] { numArray });
                this.chart1.Series["Series1"]["PieLabelStyle"] = "Outside";
                this.chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                this.chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";
                this.chart1.Series["Series1"].Points[2]["Exploded"] = "true";
                this.chart1.Legends["Legend1"].Enabled = false;
            }
            catch
            {
            }
        }

        public void UpdateValidToAdvance()
        {
            if (this.HasCheckedVM() && !this.labelError.Visible)
            {
                this._validToAdvance = true;
            }
            else
            {
                this._validToAdvance = false;
            }
            this._updateWizardButtons();
        }

        private void vmListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (e.Column != this.sortColumn)
                {
                    this.sortColumn = e.Column;
                    this.vmListView.Sorting = SortOrder.Ascending;
                }
                else if (this.vmListView.Sorting == SortOrder.Ascending)
                {
                    this.vmListView.Sorting = SortOrder.Descending;
                }
                else
                {
                    this.vmListView.Sorting = SortOrder.Ascending;
                }
                this.vmListView.Sort();
                this.vmListView.ListViewItemSorter = new ListViewItemComparer(e.Column, this.vmListView.Sorting);
            }
            catch
            {
            }
        }

        private void vmListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                ListViewItem item = e.Item;
                VmInstance tag = (VmInstance) item.Tag;
                if (tag.PowerState != 0)
                {
                    if (item.Checked)
                    {
                        item.Checked = false;
                    }
                }
                else
                {
                    this.UpdatePieChart();
                    this.UpdateValidToAdvance();
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }

        private void vmListView_VisibleChanged(object sender, EventArgs e)
        {
            this.vmListView.ItemChecked += new ItemCheckedEventHandler(this.vmListView_ItemChecked);
        }

        public List<VmInstance> AvailableVirtualMachines
        {
            get
            {
                return this._availVMs;
            }
            set
            {
                this._availVMs = value;
                this.Build();
            }
        }

        public string FreeSpaceDisplayString
        {
            get
            {
                return this._freeSpace;
            }
            set
            {
                this._freeSpace = value;
            }
        }

        public string Hostname
        {
            get
            {
                return this._hostname;
            }
            set
            {
                this._hostname = value;
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

        public override string PageTitle
        {
            get
            {
                return Messages.WIZARD_VM_SELECTION_TITLE;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public PictureBox PictureBoxError
        {
            get
            {
                return this.pictureBoxError;
            }
        }

        public string SelectedSpaceDisplayString
        {
            get
            {
                return this._selectedSpace;
            }
            set
            {
                this._selectedSpace = value;
            }
        }

        public WinAPI.SR SelectedSR
        {
            get
            {
                return this._SR;
            }
            set
            {
                this._SR = value;
                this.LabelError.Visible = false;
                this.PictureBoxError.Visible = false;
                this.UpdatePieChart();
            }
        }

        public List<VmInstance> SelectedVMsToConvert
        {
            get
            {
                List<VmInstance> list = new List<VmInstance>();
                try
                {
                    foreach (ListViewItem item in this.vmListView.Items)
                    {
                        if (item.Checked)
                        {
                            VmInstance tag = (VmInstance) item.Tag;
                            list.Add(tag);
                        }
                    }
                }
                catch
                {
                }
                return list;
            }
        }

        public override string Text
        {
            get
            {
                return Messages.WIZARD_VM_SELECTION_TEXT;
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

        public string UsedSpaceDisplayString
        {
            get
            {
                return this._usedSpace;
            }
            set
            {
                this._usedSpace = value;
            }
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        private class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;

            public ListViewItemComparer()
            {
                this.col = 0;
                this.order = SortOrder.Ascending;
            }

            public ListViewItemComparer(int column, SortOrder order)
            {
                this.col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int num = -1;
                try
                {
                    if (this.col != 3)
                    {
                        num = string.Compare(((ListViewItem) x).SubItems[this.col].Text, ((ListViewItem) y).SubItems[this.col].Text);
                    }
                    else
                    {
                        char[] trimChars = new char[] { ' ', 'G', 'B' };
                        string text = ((ListViewItem) x).SubItems[this.col].Text;
                        string str2 = ((ListViewItem) y).SubItems[this.col].Text;
                        string str3 = text.Trim(trimChars);
                        string str4 = str2.Trim(trimChars);
                        decimal num2 = Convert.ToDecimal(str3);
                        decimal num3 = Convert.ToDecimal(str4);
                        num = decimal.Compare(num2, num3);
                    }
                    if (this.order == SortOrder.Descending)
                    {
                        num *= -1;
                    }
                }
                catch
                {
                }
                return num;
            }
        }
    }
}

