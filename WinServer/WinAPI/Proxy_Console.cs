namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Console
    {
        public string location;
        public object other_config;
        public string protocol;
        public string uuid;
        public string VM;
    }
}

