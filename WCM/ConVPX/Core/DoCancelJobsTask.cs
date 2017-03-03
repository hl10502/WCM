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

    public class DoCancelJobsTask : ThreadWrapperBase
    {
        private ConversionClient _client;
        private ArrayList _failedCancelJobs = new ArrayList();
        private List<ConVpxJobInfo> _jobList;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event CancelJobsCompletedEventHandler Completed;

        public DoCancelJobsTask(ConversionClient client, List<ConVpxJobInfo> jobList)
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
                    if (Commands.CanCancelJob(info))
                    {
                        Commands.DeleteJob(Program.ClientConnection, info.JobId);
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
                this.Completed(this, new CancelJobsCompletedEventArgs(this._jobList, this._failedCancelJobs));
            }
        }
    }
}

