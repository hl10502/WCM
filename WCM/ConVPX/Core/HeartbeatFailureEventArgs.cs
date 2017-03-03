namespace WCM.ConVPX.Core
{
    using System;

    public class HeartbeatFailureEventArgs : EventArgs
    {
        private bool isConnectionHealthy;

        public HeartbeatFailureEventArgs(bool isConnectionHealthy)
        {
            this.IsConnectionHealthy = isConnectionHealthy;
        }

        public bool IsConnectionHealthy
        {
            get
            {
                return this.isConnectionHealthy;
            }
            set
            {
                this.isConnectionHealthy = value;
            }
        }
    }
}

