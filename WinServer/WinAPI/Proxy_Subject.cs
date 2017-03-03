namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Subject
    {
        public object other_config;
        public string[] roles;
        public string subject_identifier;
        public string uuid;
    }
}

