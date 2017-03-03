namespace ExportImport.CommonTypes
{
    using CookComputing.XmlRpc;
    using System;

    public interface IConversion
    {
        [XmlRpcMethod("job.clear")]
        void ClearJobs(ServiceCred cred);
        [XmlRpcMethod("job.create")]
        JobInstance CreateJob(ServiceCred cred, JobInfo jobInfo);
        [XmlRpcMethod("job.delete")]
        void DeleteJob(ServiceCred cred, string jobId);
        [XmlRpcMethod("svc.vm_fixups")]
        void DoVMFixups(ServiceCred cred, string vmUUID);
        [XmlRpcMethod("job.get_all")]
        JobInstance[] GetAllJobs(ServiceCred cred);
        [XmlRpcMethod("svc.get_networks")]
        NetworkInstance[] GetHypervisorNetworks(ServiceCred cred, ServerInfo source);
        [XmlRpcMethod("job.get")]
        JobInstance GetJob(ServiceCred cred, string jobId);
        [XmlRpcMethod("job.getlog")]
        string GetJobLog(ServiceCred cred, string jobId);
        [XmlRpcMethod("svc.getlog")]
        string GetLog(ServiceCred cred);
        [XmlRpcMethod("job.get_reserveddiskspace")]
        long GetReservedDiskSpace(ServiceCred cred, string sruuid);
        [XmlRpcMethod("svc.get_version")]
        string GetVersion();
        [XmlRpcMethod("svc.get_vmlist")]
        VmInstance[] GetVirtualMachines(ServiceCred cred, ServerInfo source);
        [XmlRpcMethod("svc.log")]
        void LogMessage(ServiceCred cred, int level, string msg);
        [XmlRpcMethod("job.retry")]
        JobInstance RetryJob(ServiceCred cred, string jobId);
        [XmlRpcMethod("job.update_progress")]
        void UpdateJobProgress(string jobId, JobProgressData jobProgressData);
    }
}

