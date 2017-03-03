namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VDI
    {
        public bool allow_caching;
        public string[] allowed_operations;
        public string[] crash_dumps;
        public object current_operations;
        public bool is_a_snapshot;
        public string location;
        public bool managed;
        public bool metadata_latest;
        public string metadata_of_pool;
        public bool missing;
        public string name_description;
        public string name_label;
        public string on_boot;
        public object other_config;
        public string parent;
        public string physical_utilisation;
        public bool read_only;
        public bool sharable;
        public object sm_config;
        public string snapshot_of;
        public DateTime snapshot_time;
        public string[] snapshots;
        public string SR;
        public bool storage_lock;
        public string[] tags;
        public string type;
        public string uuid;
        public string[] VBDs;
        public string virtual_size;
        public object xenstore_data;
    }
}

