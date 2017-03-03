namespace ExportImport.CommonTypes
{
    using CookComputing.XmlRpc;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct JobInstance
    {
        public string Id;
        public string JobName;
        public string JobDesc;
        public string XenServerName;
        public string SRName;
        public DateTime CreatedTime;
        public DateTime StartTime;
        public DateTime CompletedTime;
        public string ErrorString;
        public long CompressedBytesRead;
        public long UncompressedBytesWritten;
        public string StateDesc;
        public long PercentComplete;
        public int State;
        public string ClientIpEndPoint;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string XenServerVMUuid;
        public ExportImport.CommonTypes.JobInfo JobInfo;
        public JobInstance(string id)
        {
            this.JobInfo = new ExportImport.CommonTypes.JobInfo();
            this.Id = id;
            this.JobName = "";
            this.JobDesc = "";
            this.XenServerName = "";
            this.SRName = "";
            this.CreatedTime = DateTime.Now;
            this.StartTime = DateTime.MaxValue;
            this.CompletedTime = DateTime.MinValue;
            this.PercentComplete = 0L;
            this.State = 0;
            this.CompressedBytesRead = this.UncompressedBytesWritten = 0L;
            this.StateDesc = "";
            this.ErrorString = "";
            this.ClientIpEndPoint = "";
            this.XenServerVMUuid = "";
        }

        public JobInstance(ExportImport.CommonTypes.JobInfo jobInfo, long id, string jobName, string jobDesc)
        {
            this.JobInfo = jobInfo;
            this.Id = id.ToString();
            this.JobName = jobName;
            this.JobDesc = jobDesc;
            this.XenServerName = "";
            this.SRName = "";
            this.CreatedTime = DateTime.Now;
            this.StartTime = DateTime.MaxValue;
            this.CompletedTime = DateTime.MinValue;
            this.PercentComplete = 0L;
            this.State = 0;
            this.CompressedBytesRead = this.UncompressedBytesWritten = 0L;
            this.StateDesc = "";
            this.ErrorString = "";
            this.ClientIpEndPoint = "";
            this.XenServerVMUuid = "";
        }
    }
}

