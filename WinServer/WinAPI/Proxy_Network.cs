namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Network
    {
        public string[] allowed_operations;
        public object assigned_ips;
        public object blobs;
        public string bridge;
        public object current_operations;
        public string default_locking_mode;
        public string MTU;
        public string name_description;
        public string name_label;
        public object other_config;
        public string[] PIFs;
        public string[] tags;
        public string uuid;
        public string[] VIFs;
    }
}

