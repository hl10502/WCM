namespace WCM.ConVPX
{
    using WCM.ConVPX.Controls;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Properties;
    using log4net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using WCM.XenAdmin.Controls;
    using WCM.XenAdmin.Core;
    using WCM.XenAdmin.Help;
	using System.Reflection;

    public partial class MainWindow : Form
    {
		private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public const int JOB_UPDATE_CHECK_TIME_INTERVAL = 0x7d0;

		private DoClearJobsTask _clearJobsWorker;
		private bool _isCreateJobsInProgress;
		private Timer _jobUpdateCheckPollTimer = new Timer();
        

        public MainWindow()
        {
            InitializeComponent();
            FormFontFixer.Fix(this);
            this.UpdateEnablement();
            this.jobSummaryControl.RowSelectionChanged += new EventHandler(this.JobSummaryControl_RowSelectionChanged);
            this.UserAbortJobButton.Enabled = false;
            this.StartPollTimer();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.LaunchAboutDialog();
        }

        private void cancelJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UserAbortJobButton_Click(null, null);
        }

        private void clear_jobs_worker_Completed(object sender, EventArgs e)
        {
            ClearJobsCompletedEventArgs args = e as ClearJobsCompletedEventArgs;
            if (args.FailedClearJobs)
            {
                LOG.Error(args.ExceptionMessage);
            }
            else
            {
                Program.JobPollManager.RequestImmediateUpdate();
            }
            if (this._clearJobsWorker != null)
            {
                this._clearJobsWorker.Completed -= new ClearJobsCompletedEventHandler(this.clear_jobs_worker_Completed);
            }
        }

        private void clearJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Program.ClientConnection != null) && Helpers.Confirm(string.Format(Messages.CLEAR_JOBS_CONFIRM, new object[0]), new object[0]))
            {
                this._clearJobsWorker = new DoClearJobsTask(Program.ClientConnection);
                this._clearJobsWorker.Completed += new ClearJobsCompletedEventHandler(this.clear_jobs_worker_Completed);
                this._clearJobsWorker.Start();
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.launchXSConnectionDialog();
        }

        private bool EnableRetryJobsButton()
        {
            if (!Program.IsApplianceAlive)
            {
                return false;
            }
            return Commands.HasRetryableJobs();
        }

        private bool EnableUserAbortButton()
        {
            if (!Program.IsApplianceAlive)
            {
                return false;
            }
            return Commands.HasCancelableJobs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public bool HasHelp(string topic)
        {
            return HelpManager.HasHelpFor(topic);
        }

        private void heartbeatFailure(object sender, EventArgs e)
        {
            Program.JobPollManager.RequestStop();
            Program.IsApplianceAlive = false;
            lock (Program.JobListLock)
            {
                Program.JobList = null;
                Program.UpdateJobList = true;
            }
            if (Program.JobPollManager != null)
            {
                Program.JobPollManager.HeartbeatFailure -= new HeartbeatFailureEventHandler(this.heartbeatFailure);
            }
            LOG.Error("WCM Heartbeat has failed for multiple retry counts; closing the main connection.");
            Program.Invoke(this, new MethodInvoker(Helpers.CloseAll), new object[0]);
            Program.Invoke(this, new MethodInvoker(this.launchXSConnectionDialog), new object[0]);
        }

        private void helpContentsMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowHelpTOC();
        }


        private void JobSummaryControl_RowSelectionChanged(object sender, EventArgs e)
        {
            this.updateJobDetailView();
        }

        private void launchXSConnectionDialog()
        {
            if (Helpers.LaunchXSConnectDialog() == DialogResult.Yes)
            {
                this.StartJobPollThread();
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            this.launchXSConnectionDialog();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.RefreshJobs();
        }

        public void RefreshJobs()
        {
            if (Program.ClientConnection != null)
            {
                Program.JobPollManager.RequestImmediateUpdate();
            }
        }

        private void refreshJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RefreshJobs();
        }

        private void retryJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.LaunchRetryJobsDialog();
        }

        public static void SaveDatagridviewAsExcel(DataGridView dgv, string excel_file)
        {
            StreamWriter writer = new StreamWriter(excel_file);
            int count = dgv.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                writer.Write(dgv.Columns[i].HeaderText.ToString().ToUpper() + "\t");
            }
            writer.WriteLine();
            for (int j = 0; j < dgv.Rows.Count; j++)
            {
                for (int k = 0; k < count; k++)
                {
                    if (dgv.Rows[j].Cells[k].Value != null)
                    {
                        writer.Write(dgv.Rows[j].Cells[k].Value + "\t");
                    }
                    else
                    {
                        writer.Write("\t");
                    }
                }
                writer.WriteLine();
            }
            writer.Close();
        }

        public static void SaveJobsToFile(DataGridView dgv)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    OverwritePrompt = true,
                    Filter = Messages.CONVERSION_APPLIANCE_PRODUCT_NAME + " Text Files (*.txt)|*.txt|All Files|",
                    FilterIndex = 1
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(dialog.FileName))
                    {
                        File.Delete(dialog.FileName);
                    }
                    SaveDatagridviewAsExcel(dgv, dialog.FileName);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                LOG.Error("Failed to get service log file.", exception);
            }
        }

        private void saveJobSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveJobsToFile(this.jobSummaryControl.JobDataGridView);
        }

        private void saveSupportLogFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logFileBaseName = Program.GetLogFileBaseName();
            string applianceLogFileName = InvisibleMessages.XCM_APPLIANCE_LOG_NAME;
            string logFilePath = Program.GetLogFilePath();
            string workingPath = Path.Combine(logFilePath, InvisibleMessages.XCM_SCRATCH_LOG_DIR);
            string zipFileName = string.Format(InvisibleMessages.XCM_SUPPORT_ZIP_LOG_NAME, string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now));
            Cursor cursor = this.Cursor;
            try
            {
                if (!Program.IsApplianceAlive)
                {
                    this.ShowServerLogWarningMessage();
                }
                FolderBrowserDialog dialog = new FolderBrowserDialog {
                    Description = Messages.DIRECTORY_CHOOSER_LOG_DESCRIPTION
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Helpers.CompressLogFilesAndSave(Program.ClientConnection, logFilePath, workingPath, dialog.SelectedPath, logFileBaseName, zipFileName, applianceLogFileName);
                    this.Cursor = cursor;
                    Process.Start(dialog.SelectedPath);
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            finally
            {
                this.Cursor = cursor;
            }
        }

        public void ShowHelpTOC()
        {
            this.ShowHelpTopic(null);
        }

        public void ShowHelpTopic(string topicID)
        {
            if (parentHelpForm == null)
            {
                parentHelpForm = new Form();
                parentHelpForm.CreateControl();
            }
            string url = Path.Combine(Program.AssemblyDir, InvisibleMessages.MAINWINDOW_HELP_PATH);
            if (topicID == null)
            {
                Help.ShowHelp(parentHelpForm, url, HelpNavigator.TableOfContents);
            }
            else
            {
                Help.ShowHelp(parentHelpForm, url, HelpNavigator.TopicId, topicID);
            }
        }

        private void ShowServerLogWarningMessage()
        {
            MessageBox.Show(Messages.CONNECTION_REQUIRED_FOR_SERVER_LOG, Messages.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void StartJobPollThread()
        {
            try
            {
                if (Program.JobPollManager != null)
                {
                    Program.JobPollManager.HeartbeatFailure -= new HeartbeatFailureEventHandler(this.heartbeatFailure);
                }
                Program.JobPollManager.RequestStop();
                Program.JobPollManager = new JobPollThread();
                if (Program.JobPollManager != null)
                {
                    Program.JobPollManager.HeartbeatFailure += new HeartbeatFailureEventHandler(this.heartbeatFailure);
                }
                Program.JobPollManager.Start();
                Program.JobPollManager.RequestImmediateUpdate();
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
        }

        private void StartPollTimer()
        {
            this._jobUpdateCheckPollTimer.Tick += new EventHandler(this.TimerEventProcessor);
            this._jobUpdateCheckPollTimer.Interval = 0x7d0;
            this._jobUpdateCheckPollTimer.Start();
        }

        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)
        {
            lock (Program.JobListLock)
            {
                if ((Program.ClientConnection != null) && Program.UpdateJobList)
                {
                    this.UpdateJobView();
                }
                if (this.jobSummaryControl.JobDataGridView.Rows.Count == 0)
                {
                    this.MainSplitContainer.Panel2Collapsed = true;
                }
            }
            this.UpdateEnablement();
        }

        private void toolStripConvertButton_Click(object sender, EventArgs e)
        {
            Helpers.LaunchConversionWizard();
        }

        private void UpdateEnablement()
        {
            if (!Program.IsApplianceAlive)
            {
                if (Program.MainWindow != null)
                {
                    Program.MainWindow.Text = Messages.APPLICATION_NAME;
                }
                Program.XenServerVersionInfoDict.Clear();
                Program.ApplianceVersion = "";
            }
            this.saveJobSummaryToolStripMenuItem.Enabled = Program.IsApplianceAlive;
            this.ConvertButton.Enabled = Program.IsApplianceAlive && !this.IsCreateJobsInProgress;
            this.clearJobsToolStripMenuItem.Enabled = Program.IsApplianceAlive && (this.jobSummaryControl.JobDataGridView.Rows.Count > 0);
            this.UserAbortJobButton.Enabled = this.EnableUserAbortButton();
            this.cancelJobsToolStripMenuItem.Enabled = this.EnableUserAbortButton();
            this.retryJobsToolStripMenuItem.Enabled = this.EnableRetryJobsButton();
        }

        private void updateJobDetailView()
        {
            if ((this.jobSummaryControl.JobDataGridView.Rows.Count > 0) && (this.jobSummaryControl.SelectedJob != null))
            {
				this.jobDetails1.Build(this.jobSummaryControl.SelectedJob);
                this.MainSplitContainer.Panel2Collapsed = false;
            }
        }

        private void UpdateJobView()
        {
            try
            {
                this.jobSummaryControl.Build(Program.JobList);
                this.updateJobDetailView();
            }
            catch (Exception exception)
            {
                LOG.Error(exception.Message);
            }
            finally
            {
                Program.UpdateJobList = false;
            }
        }

        private void UserAbortJobButton_Click(object sender, EventArgs e)
        {
            Helpers.LaunchCancelJobsDialog();
        }

        private void viewApplicationLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ViewLogFiles();
        }

        public bool IsCreateJobsInProgress
        {
            get
            {
                return this._isCreateJobsInProgress;
            }
            set
            {
                this._isCreateJobsInProgress = value;
                Program.Invoke(this, new MethodInvoker(this.UpdateEnablement), new object[0]);
            }
        }
    }
}

