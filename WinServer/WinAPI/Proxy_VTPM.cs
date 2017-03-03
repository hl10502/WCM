namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VTPM
    {
        public string backend;
        public string uuid;
        public string VM;
    }
}

