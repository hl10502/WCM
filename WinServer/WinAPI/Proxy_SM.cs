namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_SM
    {
        public string[] capabilities;
        public object configuration;
        public string copyright;
        public string driver_filename;
        public object features;
        public string name_description;
        public string name_label;
        public object other_config;
        public string required_api_version;
        public string[] required_cluster_stack;
        public string type;
        public string uuid;
        public string vendor;
        public string version;
    }
}

