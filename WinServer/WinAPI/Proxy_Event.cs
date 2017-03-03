namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Event
    {
        [XmlRpcMember("class")]
        public string class_;
        public string id;
        [XmlRpcMember("ref")]
        public string opaqueRef;
        public string operation;
        [XmlRpcMember("snapshot")]
        public object snapshot;
        public string timestamp;
    }
}

