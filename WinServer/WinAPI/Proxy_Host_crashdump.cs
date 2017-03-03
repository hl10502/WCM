namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Host_crashdump
    {
        public string host;
        public object other_config;
        public string size;
        public DateTime timestamp;
        public string uuid;
    }
}

