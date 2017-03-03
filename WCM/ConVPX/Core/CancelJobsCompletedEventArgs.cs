namespace WCM.ConVPX.Core
{
    using WCM.ConVPX.Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CancelJobsCompletedEventArgs : EventArgs
    {
        private ArrayList failedCancelJobs;
        private List<ConVpxJobInfo> requestedCancelJobs;

        public CancelJobsCompletedEventArgs(List<ConVpxJobInfo> requestedCancelJobs, ArrayList failedCancelJobs)
        {
            this.RequestedCancelJobs = requestedCancelJobs;
            this.FailedCancelJobs = failedCancelJobs;
        }

        public ArrayList FailedCancelJobs
        {
            get
            {
                return this.failedCancelJobs;
            }
            set
            {
                this.failedCancelJobs = value;
            }
        }

        public List<ConVpxJobInfo> RequestedCancelJobs
        {
            get
            {
                return this.requestedCancelJobs;
            }
            set
            {
                this.requestedCancelJobs = value;
            }
        }
    }
}

