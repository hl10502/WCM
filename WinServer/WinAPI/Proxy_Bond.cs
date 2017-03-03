namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Bond
    {
        public string links_up;
        public string master;
        public string mode;
        public object other_config;
        public string primary_slave;
        public object properties;
        public string[] slaves;
        public string uuid;
    }
}

