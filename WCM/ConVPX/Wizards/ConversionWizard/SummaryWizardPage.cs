namespace WCM.ConVPX.Wizards.ConversionWizard
{
    using ExportImport.CommonTypes;
    using WCM.ConVPX;
    using WCM.ConVPX.Wizards;
    using CookComputing.XmlRpc;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using WCM.XenAdmin.Controls;
    using WCM.XenAdmin.Wizards;
    using WinAPI;
	using System.Reflection;

    public class SummaryWizardPage : XenTabPage, IWizardPage
    {
        private string _freeSpace;
        private XmlRpcStruct _networkMappings;
        private bool _preserveMAC;
        private string _selectedSpace;
        private WinAPI.SR _selectedSR;
        private List<VmInstance> _selectedVMsToConvert;
        private MethodInvoker _updateWizardButtons;
        private string _usedSpace;
        private string _vmwareHostname;
        private string _XSHostname;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public const int NOIMAGE = 0x270f;
        private TreeView summaryTreeView;
        private TableLayoutPanel tableLayoutPanel1;

        public SummaryWizardPage()
        {
            this.InitializeComponent();
            this.summaryTreeView.LineColor = SystemColors.GrayText;
            this.summaryTreeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.summaryTreeView.DrawNode += new DrawTreeNodeEventHandler(this.summaryTreeView_DrawNode);
            this.summaryTreeView.AfterCollapse += new TreeViewEventHandler(this.summaryTreeView_AfterCollapse);
        }

        public void Build()
        {
            try
            {
                this.summaryTreeView.Nodes.Clear();
                this.summaryTreeView.ImageList = Images.ImageList16;
                this.summaryTreeView.Font = new Font(this.summaryTreeView.Font, FontStyle.Bold);
                this.summaryTreeView.Nodes.Add(Messages.NODE_SOURCE_SERVER, Messages.NODE_SOURCE_SERVER, 0x270f, 0x270f).Nodes.Add(this.VMwareHostname, this.VMwareHostname, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                this.summaryTreeView.Nodes.Add(Messages.NODE_DEST_SERVER, Messages.NODE_DEST_SERVER, 0x270f, 0x270f).Nodes.Add(this.XenServerHostname, this.XenServerHostname, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                string key = string.Format(Messages.NODE_VIRTUAL_MACHINES, this.SelectedVMsToConvert.Count.ToString());
                TreeNode node = this.summaryTreeView.Nodes.Add(key, key, 0x270f, 0x270f);
                foreach (VmInstance instance in this.SelectedVMsToConvert)
                {
                    TreeNode node2 = this.BuildTreeNode(instance);
                    node2.NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                    node.Nodes.Add(node2);
                }
                node = this.summaryTreeView.Nodes.Add(Messages.NODE_NETWORK_OPTIONS, Messages.NODE_NETWORK_OPTIONS, 0x270f, 0x270f);
				string preserveMACText = "否";
				if (this.PreserveMAC) {
					preserveMACText = "是";
				}
                //string str2 = string.Format(Messages.NODE_PRESERVE_MAC, this.PreserveMAC.ToString());
				string str2 = string.Format(Messages.NODE_PRESERVE_MAC, preserveMACText);
                node.Nodes.Add(str2, str2, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                node.Nodes.Add(this.BuildMappingTreeNode());
                node = this.summaryTreeView.Nodes.Add(Messages.NODE_SR, Messages.NODE_SR, 0x270f, 0x270f);
                TreeNode node4 = this.BuildTreeNode(this.SelectedSR);
                node4.Nodes.Add(this.FreeSpaceDisplayString, this.FreeSpaceDisplayString, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                node4.Nodes.Add(this.UsedSpaceDisplayString, this.UsedSpaceDisplayString, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                node4.Nodes.Add(this.SelectedSpaceDisplayString, this.SelectedSpaceDisplayString, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                node.Nodes.Add(node4);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            this.summaryTreeView.ExpandAll();
        }

        private TreeNode BuildMappingTreeNode()
        {
            TreeNode node = null;
            try
            {
                node = new TreeNode(Messages.NODE_NETWORK_MAPPINGS, 0x270f, 0x270f);
                if (this._networkMappings == null)
                {
                    return node;
                }
                foreach (DictionaryEntry entry in this._networkMappings)
                {
                    string introduced7 = entry.Key.ToString();
                    string key = string.Format(Messages.NODE_NETWORK_MAP_DISPLAY, introduced7, entry.Value.ToString());
                    node.Nodes.Add(key, key, 0x270f, 0x270f).NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular);
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            return node;
        }

        private TreeNode BuildTreeNode(VmInstance vm)
        {
            TreeNode node = null;
            try
            {
                int imageIndex = Images.GetImageIndex16For(vm);
                string text = vm.Template ? string.Format(Messages.VM_TEMPLATE_DISPLAY_NAME, vm.Name) : vm.Name;
                node = new TreeNode(text, imageIndex, imageIndex);
            }
            catch
            {
            }
            return node;
        }

        private TreeNode BuildTreeNode(WinAPI.SR sr)
        {
            TreeNode node = null;
            try
            {
                int imageIndex = Images.GetImageIndex16For(sr);
                node = new TreeNode(this.SelectedSR.name_label, imageIndex, imageIndex) {
                    NodeFont = new Font(this.summaryTreeView.Font, FontStyle.Regular)
                };
            }
            catch
            {
            }
            return node;
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
            return true;
        }

        public override bool EnableNext()
        {
            return false;
        }

        public override bool EnablePrevious()
        {
            return true;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SummaryWizardPage));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.summaryTreeView = new TreeView();
            this.label2 = new Label();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            manager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.summaryTreeView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            manager.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            manager.ApplyResources(this.summaryTreeView, "summaryTreeView");
            this.summaryTreeView.BackColor = SystemColors.Window;
            this.summaryTreeView.Name = "summaryTreeView";
            manager.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            manager.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            base.Name = "SummaryWizardPage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }

        public void OnPageExit(WizardProgressEventArgs e)
        {
        }

        public void OnPageShow(WizardProgressEventArgs e)
        {
            this._updateWizardButtons();
        }

        private void summaryTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if ((!this.summaryTreeView.CheckBoxes && (Images.ImageList16 != null)) && (e.Node.ImageIndex >= Images.ImageList16.Images.Count))
            {
                this.summaryTreeView.Invalidate(e.Node.Bounds);
            }
        }

        private void summaryTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            if ((this.summaryTreeView.ShowLines && (Images.ImageList16 != null)) && (e.Node.ImageIndex >= Images.ImageList16.Images.Count))
            {
                int width = Images.ImageList16.ImageSize.Width;
                int height = Images.ImageList16.ImageSize.Height;
                int num2 = (e.Node.Bounds.Left - 2) - (width / 2);
                int num3 = (e.Node.Bounds.Top + (e.Node.Bounds.Bottom + 3)) / 2;
                using (Pen pen = new Pen(this.summaryTreeView.LineColor, 1f))
                {
                    pen.DashStyle = DashStyle.Dot;
                    e.Graphics.DrawLine(pen, num2 - (width / 2), num3, num2 + (width / 2), num3);
                    if (!this.summaryTreeView.CheckBoxes && e.Node.IsExpanded)
                    {
                        e.Graphics.DrawLine(pen, num2 - 1, num3, num2 - 1, num3 + (width / 2));
                    }
                }
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

        public XmlRpcStruct NetworkMappings
        {
            get
            {
                return this._networkMappings;
            }
            set
            {
                this._networkMappings = value;
            }
        }

        public override string PageTitle
        {
            get
            {
                //return "All of the necessary conversion details have been supplied.  Please review the settings below.";
				return "请检查下面的转换细节信息";
            }
        }

        public bool PreserveMAC
        {
            get
            {
                return this._preserveMAC;
            }
            set
            {
                this._preserveMAC = value;
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
                return this._selectedSR;
            }
            set
            {
                this._selectedSR = value;
            }
        }

        public List<VmInstance> SelectedVMsToConvert
        {
            get
            {
                return this._selectedVMsToConvert;
            }
            set
            {
                this._selectedVMsToConvert = value;
            }
        }

        public override string Text
        {
            get
            {
				return "汇总"; //Summary
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

        public string VMwareHostname
        {
            get
            {
                return this._vmwareHostname;
            }
            set
            {
                this._vmwareHostname = value;
            }
        }

        public string XenServerHostname
        {
            get
            {
                return this._XSHostname;
            }
            set
            {
                this._XSHostname = value;
            }
        }
    }
}

