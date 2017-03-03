namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_User
    {
        public string fullname;
        public object other_config;
        public string short_name;
        public string uuid;
    }
}

