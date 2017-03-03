namespace WCM.ConVPX.Controls
{
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Model;
    using log4net;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
	using System.Reflection;

    public partial class JobDetails : UserControl
    {
		private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private ConVpxJobInfo _job;

        public JobDetails()
        {
            InitializeComponent();
            this.ClearFields();
            this.ErrorMessageValueLabel.Visible = false;
            this.ErrorMessageLabel.Visible = false;
        }

        public void Build(ConVpxJobInfo job)
        {
			base.SuspendLayout();
            try
            {
                this._job = job;
				this.IdLabel.Text = job.JobId;
				this.StatusDetailsLabel.Text = job.Status; //job.StateDescription
                this.DestSRLabel.Text = job.TargetSR;
                this.NetReadLabel.Text = string.Format(Messages.NETWORK_READ_BYTES, ((float) job.CompressedBytesRead) / 1.073742E+09f);
                this.DiskWriteLabel.Text = string.Format(Messages.DISK_WRITE_BYTES, ((float) job.UncompressedBytesWritten) / 1.073742E+09f);
                this.ErrorMessageValueLabel.Text = job.ErrorMessage;
                this.JobDetailsHeaderPanel.Icon = Images.GetImage16For(job);
                if (job.ErrorMessage.Length > 0)
                {
                    this.ErrorMessageValueLabel.Visible = true;
                    this.ErrorMessageLabel.Visible = true;
                }
                else
                {
                    this.ErrorMessageValueLabel.Visible = false;
                    this.ErrorMessageLabel.Visible = false;
                }
                if (job.CompletedDateTime.Year != DateTime.MinValue.Year)
                {
                    TimeSpan elapsed = job.CompletedDateTime.Subtract(job.StartDateTime);
                    string durationUnitString = this.GetDurationUnitString(elapsed);
                    if (!job.StartDateTime.Equals(job.CompletedDateTime))
                    {
                        this.ElapsedValueLabel.Text = string.Format(Messages.ELAPSED_TIME_IN_MINUTES, elapsed, durationUnitString);
                    }
                    else
                    {
                        this.ElapsedValueLabel.Text = "-";
                    }
                }
                else
                {
                    this.ElapsedValueLabel.Text = "-";
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            base.ResumeLayout();
        }

        private void ClearFields()
        {
            this.IdLabel.Text = "";
            this.StatusDetailsLabel.Text = "";
            this.DestSRLabel.Text = "";
            this.NetReadLabel.Text = "";
            this.DiskWriteLabel.Text = "";
            this.ErrorMessageValueLabel.Text = "";
            this.ElapsedValueLabel.Text = "-";
        }


        private string GetDurationUnitString(TimeSpan elapsed)
        {
            if (elapsed.Days > 0)
            {
                return Messages.DAYS_LABEL;
            }
            if (elapsed.Hours > 0)
            {
                return Messages.HOURS_LABEL;
            }
            if (elapsed.Minutes > 0)
            {
                return Messages.MINUTES_LABEL;
            }
            if (elapsed.Seconds > 0)
            {
                return Messages.SECONDS_LABEL;
            }
            return "";
        }

        private void GetJobLogLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string jobLog = Commands.GetJobLog(Program.XenServerHostInfo, this._job.JobId);
                this.SendToNotepad(jobLog);
            }
            catch (Exception exception)
            {
                LOG.Error(exception.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void SendToNotepad(string text)
        {
			text = text.Replace("Xen", "Win"); //将日志中的Xen改成Win
            text = text.Replace("Citrix", "Winhong"); //将日志中的Citrix改成Winhong
			text = text.Replace("XCM", "WCM"); //将日志中的XCM改成WCM
			Clipboard.SetDataObject(text.Replace("\n", "\r\n"), false, 2, 10);
            Process.Start("notepad.exe").WaitForInputIdle(0x2710);
            SendKeys.Send("^V");
        }
    }
}

