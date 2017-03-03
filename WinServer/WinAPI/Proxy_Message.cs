namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Message
    {
        public string body;
        public string cls;
        public string name;
        public string obj_uuid;
        public string priority;
        public DateTime timestamp;
        public string uuid;
    }
}

