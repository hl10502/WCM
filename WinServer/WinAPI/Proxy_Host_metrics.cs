namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Host_metrics
    {
        public DateTime last_updated;
        public bool live;
        public string memory_free;
        public string memory_total;
        public object other_config;
        public string uuid;
    }
}

