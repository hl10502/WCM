namespace WCM.ConVPX.Core
{
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using WCM.ConVPX;
    using WCM.ConVPX.Model;
    using WCM.ConVPX.Properties;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;
    using WinAPI;
    using System.Reflection;

    internal static class Commands
    {
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static bool CanCancelJob(ConVpxJobInfo job)
        {
            bool flag = false;
            if ((job == null) || ((job.State != 2) && (job.State != 1)))
            {
                return flag;
            }
            return true;
        }

        public static bool CanRetryJob(ConVpxJobInfo job)
        {
            bool flag = false;
            if ((job == null) || ((job.State != 5) && (job.State != 4)))
            {
                return flag;
            }
            return true;
        }

        public static void ClearJobs(ConversionClient client)
        {
            try
            {
                client.ClearJobs();
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
                throw exception;
            }
        }

        public static void DeleteJob(ConversionClient client, string jobId)
        {
            try
            {
                client.DeleteJob(jobId);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
                throw exception;
            }
        }

        public static bool DoConversion(ConversionClient client, ServerInfo destVMwareServerInfo, List<VmInstance> vms, WinAPI.SR sr)
        {
            bool flag = false;
            try
            {
                foreach (VmInstance instance in vms)
                {
                    JobInfo jobInfo = new JobInfo {
                        SourceVmUUID = instance.UUID,
                        SourceVmName = instance.Name
                    };
                    jobInfo.ImportInfo.SRuuid = sr.uuid;
                    jobInfo.Source = destVMwareServerInfo;
                    client.CreateJob(jobInfo);
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                LOG.Error("DoConversion failed to submit job.", exception);
            }
            return flag;
        }

        public static List<ConVpxJobInfo> GetCancelableJobs()
        {
            List<ConVpxJobInfo> list = new List<ConVpxJobInfo>();
            foreach (ConVpxJobInfo info in Program.JobList)
            {
                if (CanCancelJob(info))
                {
                    list.Add(info);
                }
            }
            return list;
        }

        public static JobInstance GetJob(ServerInfo xsHostInfo, string jobID)
        {
            JobInstance job = new JobInstance();
            try
            {
                ConversionClient client = new ConversionClient(ConVPX.Properties.Settings.Default.RequestRegularTimeout, ConVPX.Properties.Settings.Default.RequestCompositeTimeout);
                client.Connect(xsHostInfo);
                job = client.GetJob(jobID);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            return job;
        }

        public static List<JobInstance> GetJobInstanceList(ConversionClient client)
        {
            List<JobInstance> list = new List<JobInstance>();
            try
            {
                JobInstance[] allJobs = client.GetAllJobs();
                if (allJobs != null)
                {
                    list.AddRange(allJobs);
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
            return list;
        }

        public static ConVpxJobInfoList GetJobList(ConversionClient client)
        {
            ConVpxJobInfoList list = null;
            try
            {
                list = new ConVpxJobInfoList(client.GetAllJobs());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list;
        }

        public static string GetJobLog(ServerInfo xsHostInfo, string jobID)
        {
            string jobLog = "";
            try
            {
                ConversionClient client = new ConversionClient(ConVPX.Properties.Settings.Default.RequestRegularTimeout, ConVPX.Properties.Settings.Default.RequestCompositeTimeout);
                client.Connect(xsHostInfo);
                jobLog = client.GetJobLog(jobID);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
            }
            return jobLog;
        }

        public static List<ConVpxJobInfo> GetRetryableJobs()
        {
            List<ConVpxJobInfo> list = new List<ConVpxJobInfo>();
            foreach (ConVpxJobInfo info in Program.JobList)
            {
                if (CanRetryJob(info))
                {
                    list.Add(info);
                }
            }
            return list;
        }

        public static string GetVersion(ConversionClient client)
        {
            string version = "";
            try
            {
                version = client.GetVersion();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return version;
        }

        public static List<VmInstance> GetVMs(ConversionClient client, ServerInfo destVMwareServerInfo)
        {
            List<VmInstance> list = new List<VmInstance>();
            try
            {
                VmInstance[] virtualMachines = client.GetVirtualMachines(destVMwareServerInfo);
                if (virtualMachines != null)
                {
                    list.AddRange(virtualMachines);
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
                list = null;
                throw exception;
            }
            return list;
        }

        public static bool HasCancelableJobs()
        {
            if (Program.JobList != null)
            {
                foreach (ConVpxJobInfo info in Program.JobList)
                {
                    if (CanCancelJob(info))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool HasCompletionTS(ConVpxJobInfo job)
        {
            bool flag = false;
            if (job != null)
            {
                if (((job.State == 3) || (job.State == 6)) || ((job.State == 4) || (job.State == 5)))
                {
                    flag = true;
                }
                if (job.CompletedDateTime.Year == DateTime.MinValue.Year)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public static bool HasRetryableJobs()
        {
            if (Program.JobList != null)
            {
                foreach (ConVpxJobInfo info in Program.JobList)
                {
                    if (CanRetryJob(info))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool HasStartTS(ConVpxJobInfo job)
        {
            bool flag = true;
            if (job == null)
            {
                return flag;
            }
            if (job.StartDateTime.Year == DateTime.MaxValue.Year)
            {
                flag = false;
            }
            return (((job.State != 0) && (job.State != 1)) && flag);
        }

        public static bool IsApplianceAlive(ConversionClient client, int numRetries, int retryTimeout)
        {
            bool flag = false;
            while ((numRetries > 0) && !flag)
            {
                try
                {
                    GetVersion(client);
                    return true;
                }
                catch (Exception exception)
                {
                    if (exception is WebException)
                    {
                        WebException exception2 = exception as WebException;
                        if ((exception2.Status == WebExceptionStatus.ConnectionClosed) || (exception2.Status == WebExceptionStatus.ConnectFailure))
                        {
                            numRetries = 0;
                        }
                    }
                    LOG.Error(exception, exception);
                    numRetries--;
                    if (retryTimeout > 0)
                    {
                        Thread.Sleep(retryTimeout);
                    }
                    continue;
                }
            }
            return flag;
        }

        public static void RetryJob(ConversionClient client, string jobId)
        {
            try
            {
                client.RetryJob(jobId);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
                throw exception;
            }
        }

        public static void SaveServerLogFile(ConversionClient client)
        {
            string str = string.Format(Messages.CONVERSION_APPLIANCE_PRODUCT_NAME, "XenServer");
            try
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    OverwritePrompt = true,
                    Filter = str + Messages.SAVE_FILTER_LOG_FILES + "  (*.log)|*.log|" + Messages.SAVE_FILTER_TEXT_FILES + " (*.txt)|*.txt|" + Messages.SAVE_FILTER_ALL_FILES + "|",
                    FilterIndex = 1
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (System.IO.File.Exists(dialog.FileName))
                    {
                        System.IO.File.Delete(dialog.FileName);
                    }
                    ConVPX.Core.Helpers.CopyStringToFile(client.GetLog(), dialog.FileName);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception exception)
            {
                LOG.Error("Failed to get service log file.", exception);
            }
        }
    }
}

