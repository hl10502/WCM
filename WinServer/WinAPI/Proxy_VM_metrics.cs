namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VM_metrics
    {
        public DateTime install_time;
        public DateTime last_updated;
        public string memory_actual;
        public object other_config;
        public DateTime start_time;
        public string[] state;
        public string uuid;
        public object VCPUs_CPU;
        public object VCPUs_flags;
        public string VCPUs_number;
        public object VCPUs_params;
        public object VCPUs_utilisation;
    }
}

