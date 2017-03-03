namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_SR
    {
        public string[] allowed_operations;
        public object blobs;
        public bool clustered;
        public string content_type;
        public object current_operations;
        public string introduced_by;
        public bool local_cache_enabled;
        public string name_description;
        public string name_label;
        public object other_config;
        public string[] PBDs;
        public string physical_size;
        public string physical_utilisation;
        public bool shared;
        public object sm_config;
        public string[] tags;
        public string type;
        public string uuid;
        public string[] VDIs;
        public string virtual_allocation;
    }
}

