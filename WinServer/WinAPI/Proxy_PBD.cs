namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_PBD
    {
        public bool currently_attached;
        public object device_config;
        public string host;
        public object other_config;
        public string SR;
        public string uuid;
    }
}

