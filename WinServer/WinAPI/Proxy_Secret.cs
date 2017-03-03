namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Secret
    {
        public object other_config;
        public string uuid;
        public string value;
    }
}

