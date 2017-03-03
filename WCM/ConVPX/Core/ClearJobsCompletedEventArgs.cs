namespace WCM.ConVPX.Core
{
    using System;

    public class ClearJobsCompletedEventArgs : EventArgs
    {
        private string _exceptionMessage;
        private bool _failedClearJobs;

        public ClearJobsCompletedEventArgs(bool failedClearJobs, string exceptionMessage)
        {
            this.FailedClearJobs = failedClearJobs;
            this.ExceptionMessage = exceptionMessage;
        }

        public string ExceptionMessage
        {
            get
            {
                return this._exceptionMessage;
            }
            set
            {
                this._exceptionMessage = value;
            }
        }

        public bool FailedClearJobs
        {
            get
            {
                return this._failedClearJobs;
            }
            set
            {
                this._failedClearJobs = value;
            }
        }
    }
}

