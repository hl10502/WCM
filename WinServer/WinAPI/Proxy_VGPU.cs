namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VGPU
    {
        public bool currently_attached;
        public string device;
        public string GPU_group;
        public object other_config;
        public string resident_on;
        public string type;
        public string uuid;
        public string VM;
    }
}

