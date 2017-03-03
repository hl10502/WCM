namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VM_guest_metrics
    {
        public object disks;
        public DateTime last_updated;
        public bool live;
        public object memory;
        public bool network_paths_optimized;
        public object networks;
        public object os_version;
        public object other;
        public object other_config;
        public bool PV_drivers_up_to_date;
        public object PV_drivers_version;
        public bool storage_paths_optimized;
        public string uuid;
    }
}

