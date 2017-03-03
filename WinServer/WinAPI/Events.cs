namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Events
    {
        public Proxy_Event[] events;
        public string token;
        public object valid_ref_counts;
    }
}

