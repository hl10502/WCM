namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_PIF_metrics
    {
        public bool carrier;
        public string device_id;
        public string device_name;
        public bool duplex;
        public double io_read_kbs;
        public double io_write_kbs;
        public DateTime last_updated;
        public object other_config;
        public string pci_bus_path;
        public string speed;
        public string uuid;
        public string vendor_id;
        public string vendor_name;
    }
}

