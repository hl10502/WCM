namespace WCM.ConVPX.Core
{
    using System;

    public class ConnectCompletedEventArgs : EventArgs
    {
        private Exception _connException;
        private bool _failedConnect;

        public ConnectCompletedEventArgs(bool failedConnect, Exception exception)
        {
            this.FailedConnect = failedConnect;
            this.ConnectionException = exception;
        }

        public Exception ConnectionException
        {
            get
            {
                return this._connException;
            }
            set
            {
                this._connException = value;
            }
        }

        public bool FailedConnect
        {
            get
            {
                return this._failedConnect;
            }
            set
            {
                this._failedConnect = value;
            }
        }
    }
}

