namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Blob
    {
        public DateTime last_updated;
        public string mime_type;
        public string name_description;
        public string name_label;
        public bool pubblic;
        public string size;
        public string uuid;
    }
}

