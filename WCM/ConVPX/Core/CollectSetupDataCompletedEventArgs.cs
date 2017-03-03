namespace WCM.ConVPX.Core
{
    using ExportImport.CommonTypes;
    using System;
    using System.Collections.Generic;
    using WinAPI;

    public class CollectSetupDataCompletedEventArgs : EventArgs
    {
        private List<WinAPI.SR> _availSRs;
        private List<VmInstance> _availVMs;
        private WinAPI.SR _defaultSR;
        private Dictionary<WinAPI.SR, long> _diskSpaceDict;
        private Exception _exception;
        private bool _failedCollectSetupData;
        private string _friendExceptionMessage;
        private NetworkInstance[] _vmwareNetworks;
        private Network _xsDefaultNetwork;
        private Dictionary<XenRef<Network>, Network> _xsNetworks;

        public CollectSetupDataCompletedEventArgs(bool failedCollectSetupData, Exception exception, string friendlyExceptionMessage)
        {
            this._friendExceptionMessage = "";
            this.FailedCollectSetupData = failedCollectSetupData;
            this.CollectSetupDataException = exception;
            this._friendExceptionMessage = friendlyExceptionMessage;
        }

        public CollectSetupDataCompletedEventArgs(bool failedCollectSetupData, Exception exception, string friendlyExceptionMessage, List<VmInstance> vmList, NetworkInstance[] vmwareNetworks, List<WinAPI.SR> SRs, WinAPI.SR defaultSR, Dictionary<WinAPI.SR, long> diskSpaceDict, Dictionary<XenRef<Network>, Network> xsNetworks, Network xsDefaultNetwork) : this(failedCollectSetupData, exception, friendlyExceptionMessage)
        {
            this._availVMs = vmList;
            this._vmwareNetworks = vmwareNetworks;
            this._availSRs = SRs;
            this._defaultSR = defaultSR;
            this._diskSpaceDict = diskSpaceDict;
            this._xsNetworks = xsNetworks;
            this._xsDefaultNetwork = xsDefaultNetwork;
        }

        public List<WinAPI.SR> AvailableStorageRepositories
        {
            get
            {
                return this._availSRs;
            }
            set
            {
                this._availSRs = value;
            }
        }

        public List<VmInstance> AvailableVirtualMachines
        {
            get
            {
                return this._availVMs;
            }
            set
            {
                this._availVMs = value;
            }
        }

        public Exception CollectSetupDataException
        {
            get
            {
                return this._exception;
            }
            set
            {
                this._exception = value;
            }
        }

        public WinAPI.SR DefaultStorageRepository
        {
            get
            {
                return this._defaultSR;
            }
            set
            {
                try
                {
                    this._defaultSR = value;
                }
                catch
                {
                    this._defaultSR = null;
                }
            }
        }

        public Network DefaultXenServerNetwork
        {
            get
            {
                return this._xsDefaultNetwork;
            }
            set
            {
                this._xsDefaultNetwork = value;
            }
        }

        public bool FailedCollectSetupData
        {
            get
            {
                return this._failedCollectSetupData;
            }
            set
            {
                this._failedCollectSetupData = value;
            }
        }

        public string FriendlyExceptionMessage
        {
            get
            {
                return this._friendExceptionMessage;
            }
            set
            {
                this._friendExceptionMessage = value;
            }
        }

        public Dictionary<WinAPI.SR, long> OtherUsedDiskSpaceDict
        {
            get
            {
                return this._diskSpaceDict;
            }
            set
            {
                this._diskSpaceDict = value;
            }
        }

        public NetworkInstance[] VMwareNetworks
        {
            get
            {
                return this._vmwareNetworks;
            }
            set
            {
                this._vmwareNetworks = value;
            }
        }

        public Dictionary<XenRef<Network>, Network> XenServerNetworks
        {
            get
            {
                return this._xsNetworks;
            }
            set
            {
                this._xsNetworks = value;
            }
        }
    }
}

