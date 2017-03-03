namespace WCM.ConVPX.Core
{
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using WCM.ConVPX;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using WinAPI;
    using System.Reflection;

    public class DoCollectSetupDataTask : ThreadWrapperBase
    {
        private ConversionClient _client;
        private WinAPI.SR _defaultSR;
        private Dictionary<WinAPI.SR, long> _diskSpaceDict;
        private Exception _exception;
        private bool _failedCollectSetupData;
        private string _friendExceptionMessage = "";
        private List<WinAPI.SR> _SRs;
        private List<VmInstance> _vmList;
        private ServerInfo _vmwareCredInfo;
        private NetworkInstance[] _vmwareNetworks;
        private ServerInfo _xenServerHostInfo;
        private Network _xsDefaultNetwork;
        private Dictionary<XenRef<Network>, Network> _xsNetworks;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event CollectSetupDataCompletedEventHandler Completed;

        public DoCollectSetupDataTask(ConversionClient client, ServerInfo xenServerHostInfo, ServerInfo vmwareCredInfo)
        {
            this._client = client;
            this._xenServerHostInfo = xenServerHostInfo;
            this._vmwareCredInfo = vmwareCredInfo;
            base.SupportsProgress = false;
        }

        protected override void DoTask()
        {
            this._failedCollectSetupData = false;
            try
            {
                this._vmList = Commands.GetVMs(this._client, this._vmwareCredInfo);
                if ((this._vmList != null) && (this._vmList.Count <= 0))
                {
                    this._exception = new Exception(Messages.NO_VMS_DETECTED_ON_SERVER);
                    this._failedCollectSetupData = true;
                    this._friendExceptionMessage = Messages.NO_VMS_DETECTED_ON_SERVER;
                }
            }
            catch (Exception exception)
            {
                this._exception = exception;
                this._failedCollectSetupData = true;
                string str = string.Format(Messages.ERROR_CONNECTING_BLURB, "XenServer");
                this._friendExceptionMessage = str;
            }
            if (!this._failedCollectSetupData)
            {
                this._SRs = this._client.GetSRList(this._xenServerHostInfo);
                this._defaultSR = this._client.GetDefaultSR(this._xenServerHostInfo);
                this._diskSpaceDict = this._client.GetReservedDiskSpaceDict(this._SRs);
                if ((this._SRs == null) || (this._SRs.Count <= 0))
                {
                    this._exception = new Exception(Messages.NO_DETECTED_SRS);
                    this._failedCollectSetupData = true;
                    this._friendExceptionMessage = Messages.NO_DETECTED_SRS;
                }
            }
            if (!this._failedCollectSetupData)
            {
                try
                {
                    this._xsNetworks = this._client.GetXenServerNetworks(this._xenServerHostInfo);
                    this._xsDefaultNetwork = this._client.GetDefaultXenServerNetwork(this._xenServerHostInfo);
                    this._vmwareNetworks = this._client.GetHypervisorNetworks(this._vmwareCredInfo);
                }
                catch (Exception exception2)
                {
                    this._exception = exception2;
                    this._failedCollectSetupData = true;
                    this._friendExceptionMessage = Messages.ERROR_NETWORK_GET_BLURB;
                }
            }
        }

        protected override void OnCompleted()
        {
            if (this.Completed != null)
            {
                if (!this._failedCollectSetupData)
                {
                    this.Completed(this, new CollectSetupDataCompletedEventArgs(this._failedCollectSetupData, this._exception, "", this._vmList, this._vmwareNetworks, this._SRs, this._defaultSR, this._diskSpaceDict, this._xsNetworks, this._xsDefaultNetwork));
                }
                else
                {
                    this.Completed(this, new CollectSetupDataCompletedEventArgs(this._failedCollectSetupData, this._exception, this._friendExceptionMessage));
                }
            }
        }
    }
}

