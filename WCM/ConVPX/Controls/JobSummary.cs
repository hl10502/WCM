namespace WCM.ConVPX.Controls
{
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Model;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
	using System.Reflection;

    public partial class JobSummary : UserControl
    {
        private DoCancelJobsTask _cancel_job_worker;
        private DoRetryJobsTask _retry_job_worker;
        public const int CUSTOM_CONTENT_HEIGHT = 30;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler RowSelectionChanged;

        public JobSummary()
        {
            InitializeComponent();
        }

        public void Build(ConVpxJobInfoList list)
        {
            JobRow row = null;
            DataGridViewSelectedRowCollection selectedRows = this.dataGridViewJobs.SelectedRows;
            if (selectedRows.Count == 1)
            {
                row = selectedRows[0] as JobRow;
            }
            this.dataGridViewJobs.SuspendLayout();
            try
            {
                this.dataGridViewJobs.Rows.Clear();
                if (list != null)
                {
                    foreach (ConVpxJobInfo info in list)
                    {
                        JobRow dataGridViewRow = new JobRow(info);
                        this.dataGridViewJobs.Rows.Add(dataGridViewRow);
                    }
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception.Message);
            }
            finally
            {
                try
                {
                    if ((this.dataGridViewJobs.Rows.Count > 0) && (row != null))
                    {
                        foreach (DataGridViewRow row3 in (IEnumerable) this.dataGridViewJobs.Rows)
                        {
                            JobRow row4 = row3 as JobRow;
                            if (row4.JOB.JobId.Equals(row.JOB.JobId))
                            {
                                row3.Selected = true;
                            }
                            else
                            {
                                row3.Selected = false;
                            }
                        }
                        if ((this.dataGridViewJobs.SortedColumn != null) && (this.dataGridViewJobs.SortOrder != SortOrder.None))
                        {
                            this.dataGridViewJobs.Sort(this.dataGridViewJobs.SortedColumn, (this.dataGridViewJobs.SortOrder == SortOrder.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending);
                        }
                    }
                }
                catch (Exception exception2)
                {
                    LOG.Error(exception2, exception2);
                }
                this.dataGridViewJobs.ResumeLayout();
            }
        }

        private void cancel_job_worker_Completed(object sender, EventArgs e)
        {
            Program.JobPollManager.RequestImmediateUpdate();
            if (this._cancel_job_worker != null)
            {
                this._cancel_job_worker.Completed -= new CancelJobsCompletedEventHandler(this.cancel_job_worker_Completed);
            }
        }

        private void CancelMenuItemClick(object sender, EventArgs e)
        {
            List<ConVpxJobInfo> jobList = new List<ConVpxJobInfo>();
            ConVpxJobInfo selectedJob = this.SelectedJob;
            if ((selectedJob != null) && Helpers.Confirm(string.Format(string.Format(Messages.CANCEL_JOB_CONFIRM, selectedJob.Title), new object[0]), new object[0]))
            {
                jobList.Add(selectedJob);
                this._cancel_job_worker = new DoCancelJobsTask(Program.ClientConnection, jobList);
                this._cancel_job_worker.Completed += new CancelJobsCompletedEventHandler(this.cancel_job_worker_Completed);
                this._cancel_job_worker.Start();
            }
        }

        private void dataGridViewJobs_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (this.dataGridViewJobs.SelectedRows.Count > 0))
            {
                try
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        DataGridView.HitTestInfo info = this.dataGridViewJobs.HitTest(e.X, e.Y);
                        if ((info.Type == DataGridViewHitTestType.Cell) && (this.dataGridViewJobs.Rows.Count >= 0))
                        {
                            if (!this.dataGridViewJobs.Rows[info.RowIndex].Selected)
                            {
                                this.dataGridViewJobs.CurrentCell = this.dataGridViewJobs[info.ColumnIndex, info.RowIndex];
                            }
                            this.contextMenuStrip1.Items.Clear();
                            ToolStripMenuItem item = new ToolStripMenuItem(Messages.CANCEL_JOB_MENU_ITEM, null, new EventHandler(this.CancelMenuItemClick));
                            ToolStripMenuItem item2 = new ToolStripMenuItem(Messages.RETRY_JOB_MENU_ITEM, null, new EventHandler(this.RetryMenuItemClick));
                            ConVpxJobInfo selectedJob = this.SelectedJob;
                            item.Enabled = Commands.CanCancelJob(selectedJob);
                            item2.Enabled = Commands.CanRetryJob(selectedJob);
                            this.contextMenuStrip1.Items.Add(item);
                            this.contextMenuStrip1.Items.Add(new ToolStripSeparator());
                            this.contextMenuStrip1.Items.Add(item2);
                            this.contextMenuStrip1.Show(this.dataGridViewJobs, new Point(e.X, e.Y));
                        }
                    }
                }
                catch (Exception exception)
                {
                    LOG.Error(exception, exception);
                }
            }
        }

        private void dataGridViewJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (this.RowSelectionChanged != null)
            {
                this.RowSelectionChanged(this, e);
            }
        }

        private void dataGridViewJobs_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                e.SortResult = string.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                if ((e.SortResult == 0) && (e.Column.Name != "ColumnName"))
                {
                    e.SortResult = string.Compare(this.dataGridViewJobs.Rows[e.RowIndex1].Cells["ColumnName"].Value.ToString(), this.dataGridViewJobs.Rows[e.RowIndex2].Cells["ColumnName"].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            e.Handled = true;
        }

        private void JobSummary_Load(object sender, EventArgs e)
        {
            Padding padding = new Padding(0, 1, 0, 30);
            this.dataGridViewJobs.RowTemplate.DefaultCellStyle.Padding = padding;
            this.dataGridViewJobs.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            DataGridViewRow rowTemplate = this.dataGridViewJobs.RowTemplate;
            rowTemplate.Height += 30;
            this.dataGridViewJobs.SortCompare += new DataGridViewSortCompareEventHandler(this.dataGridViewJobs_SortCompare);
        }

        private void retry_job_worker_Completed(object sender, EventArgs e)
        {
            Program.JobPollManager.RequestImmediateUpdate();
            if (this._retry_job_worker != null)
            {
                this._retry_job_worker.Completed -= new RetryJobsCompletedEventHandler(this.retry_job_worker_Completed);
            }
        }

        private void RetryMenuItemClick(object sender, EventArgs e)
        {
            List<ConVpxJobInfo> jobList = new List<ConVpxJobInfo>();
            ConVpxJobInfo selectedJob = this.SelectedJob;
            if ((selectedJob != null) && Helpers.Confirm(string.Format(string.Format(Messages.RETRY_JOB_CONFIRM, selectedJob.Title), new object[0]), new object[0]))
            {
                jobList.Add(selectedJob);
                this._retry_job_worker = new DoRetryJobsTask(Program.ClientConnection, jobList);
                this._retry_job_worker.Completed += new RetryJobsCompletedEventHandler(this.retry_job_worker_Completed);
                this._retry_job_worker.Start();
            }
        }

        public DataGridView JobDataGridView
        {
            get
            {
                return this.dataGridViewJobs;
            }
        }

        public ConVpxJobInfo SelectedJob
        {
            get
            {
                JobRow row = null;
                ConVpxJobInfo jOB = null;
                DataGridViewSelectedRowCollection selectedRows = this.dataGridViewJobs.SelectedRows;
                if (selectedRows.Count == 1)
                {
                    row = selectedRows[0] as JobRow;
                    if (row != null)
                    {
                        jOB = row.JOB;
                    }
                }
                return jOB;
            }
        }

        public class JobRow : DataGridViewRow
        {
            public ConVpxJobInfo JOB;
            private const int NUMBER_OF_COLUMNS = 6;

            public JobRow(ConVpxJobInfo job)
            {
				if ("Incomplete".Equals(job.Status)) {
					job.StateDisplay = "未完成";
				}
				this.JOB = job;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 3)
                    {
                        TextAndImageCell tiCell = new TextAndImageCell();
                        this.UpdateJobStatusColumn(tiCell, job, i);
                    }
                    else
                    {
                        base.Cells.Add(new DataGridViewTextBoxCell());
                        base.Cells[i].Value = this.GetCellText(i);
                    }
                }
            }

            private object GetCellText(int cellIndex)
            {
                string str = "-";
                switch (cellIndex)
                {
                    case 0:
                        return this.JOB.Title;

                    case 1:
                        return this.JOB.Source;

                    case 2:
                        return this.JOB.Destination;

                    case 3:
                        return this.JOB.Status;

                    case 4:
                        if (Commands.HasStartTS(this.JOB))
                        {
                            return this.JOB.StartDateTime;
                        }
                        return str;

                    case 5:
                        if (Commands.HasCompletionTS(this.JOB))
                        {
                            return this.JOB.CompletedDateTime;
                        }
                        return str;
                }
                return "";
            }

            private void UpdateJobStatusColumn(TextAndImageCell tiCell, ConVpxJobInfo job, int index)
            {
                if (job.State == 2)
                {
                    long p = 0L;
                    try
                    {
                        p = job.PercentComplete / 10L;
                    }
                    catch
                    {
                        p = 0L;
                    }
                    tiCell.Value = " " + job.PercentComplete.ToString() + "%";
                    tiCell.Image = Images.GetProgressImage(p);
                }
                else
                {
                    tiCell.Value = this.GetCellText(index);
                    tiCell.Image = Images.GetImage16For(job);
                }
                base.Cells.Add(tiCell);
            }
        }
    }
}

