namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VLAN
    {
        public object other_config;
        public string tag;
        public string tagged_PIF;
        public string untagged_PIF;
        public string uuid;
    }
}

