namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VBD
    {
        public string[] allowed_operations;
        public bool bootable;
        public object current_operations;
        public bool currently_attached;
        public string device;
        public bool empty;
        public string metrics;
        public string mode;
        public object other_config;
        public object qos_algorithm_params;
        public string qos_algorithm_type;
        public string[] qos_supported_algorithms;
        public object runtime_properties;
        public string status_code;
        public string status_detail;
        public bool storage_lock;
        public string type;
        public bool unpluggable;
        public string userdevice;
        public string uuid;
        public string VDI;
        public string VM;
    }
}

