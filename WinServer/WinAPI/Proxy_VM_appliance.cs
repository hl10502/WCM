namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VM_appliance
    {
        public string[] allowed_operations;
        public object current_operations;
        public string name_description;
        public string name_label;
        public string uuid;
        public string[] VMs;
    }
}

