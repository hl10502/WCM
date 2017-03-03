namespace WCM.ConVPX.Core
{
    using ExportImport.ConversionClientLib;
    using WCM.ConVPX;
    using WCM.ConVPX.Model;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Reflection;

    public class DoRetryJobsTask : ThreadWrapperBase
    {
        private ConversionClient _client;
        private ArrayList _failedRetryJobs = new ArrayList();
        private List<ConVpxJobInfo> _jobList;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event RetryJobsCompletedEventHandler Completed;

        public DoRetryJobsTask(ConversionClient client, List<ConVpxJobInfo> jobList)
        {
            this._client = client;
            this._jobList = jobList;
            base.SupportsProgress = false;
        }

        protected override void DoTask()
        {
            foreach (ConVpxJobInfo info in this._jobList)
            {
                try
                {
                    if (Commands.CanRetryJob(info))
                    {
                        Commands.RetryJob(Program.ClientConnection, info.JobId);
                    }
                }
                catch (Exception exception)
                {
                    LOG.Error(exception, exception);
                }
            }
            Program.JobPollManager.RequestImmediateUpdate();
        }

        protected override void OnCompleted()
        {
            if (this.Completed != null)
            {
                this.Completed(this, new RetryJobsCompletedEventArgs(this._jobList, this._failedRetryJobs));
            }
        }
    }
}

