namespace WCM.ConVPX.Core
{
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using WCM.ConVPX;
    using CookComputing.XmlRpc;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using WinAPI;
    using System.Reflection;

    public class DoConversionTask : ThreadWrapperBase
    {
        private ConversionClient _client;
        private ServerInfo _destVMwareServerInfo;
        private ArrayList _failedVMs = new ArrayList();
        private XmlRpcStruct _networkMappings;
        private bool _preserveMAC;
        private WinAPI.SR _sr;
        private List<VmInstance> _vms;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event ConversionVMsCompletedEventHandler Completed;

        public DoConversionTask(ConversionClient client, ServerInfo destVMwareServerInfo, List<VmInstance> vms, WinAPI.SR sr, bool preserveMAC, XmlRpcStruct networkMappings)
        {
            this._client = client;
            this._destVMwareServerInfo = destVMwareServerInfo;
            this._vms = vms;
            this._sr = sr;
            this._preserveMAC = preserveMAC;
            this._networkMappings = networkMappings;
            base.SupportsProgress = false;
        }

        protected override void DoTask()
        {
            foreach (VmInstance instance in this._vms)
            {
                JobInfo jobInfo = new JobInfo {
                    SourceVmUUID = instance.UUID,
                    SourceVmName = instance.Name
                };
                jobInfo.ImportInfo.SRuuid = this._sr.uuid;
                jobInfo.PreserveMAC = new bool?(this._preserveMAC);
                jobInfo.NetworkMappings = this._networkMappings;
                jobInfo.Source = this._destVMwareServerInfo;
                try
                {
                    this._client.CreateJob(jobInfo);
                }
                catch (Exception exception)
                {
                    this._failedVMs.Add(instance.Name);
                    LOG.Error(exception, exception);
                }
            }
            Program.JobPollManager.RequestImmediateUpdate();
        }

        protected override void OnCompleted()
        {
            if (this.Completed != null)
            {
                this.Completed(this, new ConversionVMsCompletedEventArgs(this._vms, this._failedVMs));
            }
        }
    }
}

