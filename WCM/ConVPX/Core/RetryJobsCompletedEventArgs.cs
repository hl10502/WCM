namespace WCM.ConVPX.Core
{
    using WCM.ConVPX.Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RetryJobsCompletedEventArgs : EventArgs
    {
        private ArrayList failedRetryJobs;
        private List<ConVpxJobInfo> requestedRetryJobs;

        public RetryJobsCompletedEventArgs(List<ConVpxJobInfo> requestedRetryJobs, ArrayList failedRetryJobs)
        {
            this.RequestedRetryJobs = requestedRetryJobs;
            this.FailedRetryJobs = failedRetryJobs;
        }

        public ArrayList FailedRetryJobs
        {
            get
            {
                return this.failedRetryJobs;
            }
            set
            {
                this.failedRetryJobs = value;
            }
        }

        public List<ConVpxJobInfo> RequestedRetryJobs
        {
            get
            {
                return this.requestedRetryJobs;
            }
            set
            {
                this.requestedRetryJobs = value;
            }
        }
    }
}

