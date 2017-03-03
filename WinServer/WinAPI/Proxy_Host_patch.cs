namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Host_patch
    {
        public bool applied;
        public string host;
        public string name_description;
        public string name_label;
        public object other_config;
        public string pool_patch;
        public string size;
        public DateTime timestamp_applied;
        public string uuid;
        public string version;
    }
}

