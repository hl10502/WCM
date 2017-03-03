namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_PCI
    {
        public string class_name;
        public string[] dependencies;
        public string device_name;
        public string host;
        public object other_config;
        public string pci_id;
        public string subsystem_device_name;
        public string subsystem_vendor_name;
        public string uuid;
        public string vendor_name;
    }
}

