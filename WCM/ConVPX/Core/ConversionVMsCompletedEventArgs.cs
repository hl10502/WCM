namespace WCM.ConVPX.Core
{
    using ExportImport.CommonTypes;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ConversionVMsCompletedEventArgs : EventArgs
    {
        private ArrayList failedVMs;
        private List<VmInstance> requestedVMs;

        public ConversionVMsCompletedEventArgs(List<VmInstance> requestedVMs, ArrayList failedVMs)
        {
            this.RequestedVMs = requestedVMs;
            this.FailedVMs = failedVMs;
        }

        public ArrayList FailedVMs
        {
            get
            {
                return this.failedVMs;
            }
            set
            {
                this.failedVMs = value;
            }
        }

        public List<VmInstance> RequestedVMs
        {
            get
            {
                return this.requestedVMs;
            }
            set
            {
                this.requestedVMs = value;
            }
        }
    }
}

