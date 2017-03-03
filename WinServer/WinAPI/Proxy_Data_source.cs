namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Data_source
    {
        public bool enabled;
        public double max;
        public double min;
        public string name_description;
        public string name_label;
        public bool standard;
        public string units;
        public double value;
    }
}

