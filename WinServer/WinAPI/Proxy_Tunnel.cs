namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Tunnel
    {
        public string access_PIF;
        public object other_config;
        public object status;
        public string transport_PIF;
        public string uuid;
    }
}

