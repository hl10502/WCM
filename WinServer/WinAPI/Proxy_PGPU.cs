namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_PGPU
    {
        public string dom0_access;
        public string[] enabled_VGPU_types;
        public string GPU_group;
        public string host;
        public bool is_system_display_device;
        public object other_config;
        public string PCI;
        public string[] resident_VGPUs;
        public object supported_VGPU_max_capacities;
        public string[] supported_VGPU_types;
        public string uuid;
    }
}

