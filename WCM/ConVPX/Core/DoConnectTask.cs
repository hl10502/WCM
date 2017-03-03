namespace WCM.ConVPX.Core
{
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using log4net;
    using System;
    using System.Reflection;
    using System.Threading;

    public class DoConnectTask : ThreadWrapperBase
    {
        private ConversionClient _client;
        private Exception _exception;
        private bool _failedConnect;
        private ServerInfo _xenServerHostInfo;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event ConnectCompletedEventHandler Completed;

        public DoConnectTask(ConversionClient client, ServerInfo xenServerHostInfo)
        {
            this._client = client;
            this._xenServerHostInfo = xenServerHostInfo;
            base.SupportsProgress = false;
        }

        protected override void DoTask()
        {
            this._failedConnect = false;
            try
            {
                this._client.Connect(this._xenServerHostInfo);
            }
            catch (Exception exception)
            {
                LOG.Error(exception, exception);
                this._exception = exception;
                this._failedConnect = true;
            }
        }

        protected override void OnCompleted()
        {
            if (this.Completed != null)
            {
                this.Completed(this, new ConnectCompletedEventArgs(this._failedConnect, this._exception));
            }
        }
    }
}

