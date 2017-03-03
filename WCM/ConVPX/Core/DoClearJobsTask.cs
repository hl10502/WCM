namespace WCM.ConVPX.Core
{
    using ExportImport.ConversionClientLib;
    using WCM.ConVPX;
    using log4net;
    using System;
    using System.Threading;
    using System.Reflection;

    public class DoClearJobsTask : ThreadWrapperBase
    {
        private ConversionClient _client;
        private string _exceptionMessage;
        private bool _failedClearJobs;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event ClearJobsCompletedEventHandler Completed;

        public DoClearJobsTask(ConversionClient client)
        {
            this._client = client;
            base.SupportsProgress = false;
        }

        protected override void DoTask()
        {
            this._failedClearJobs = false;
            this._exceptionMessage = "";
            try
            {
                Commands.ClearJobs(Program.ClientConnection);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
                this._exceptionMessage = exception.Message;
                this._failedClearJobs = true;
            }
        }

        protected override void OnCompleted()
        {
            if (this.Completed != null)
            {
                this.Completed(this, new ClearJobsCompletedEventArgs(this._failedClearJobs, this._exceptionMessage));
            }
        }
    }
}

