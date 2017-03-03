namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VIF_metrics
    {
        public double io_read_kbs;
        public double io_write_kbs;
        public DateTime last_updated;
        public object other_config;
        public string uuid;
    }
}

