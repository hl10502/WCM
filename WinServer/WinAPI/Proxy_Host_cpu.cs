namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Host_cpu
    {
        public string family;
        public string features;
        public string flags;
        public string host;
        public string model;
        public string modelname;
        public string number;
        public object other_config;
        public string speed;
        public string stepping;
        public double utilisation;
        public string uuid;
        public string vendor;
    }
}

