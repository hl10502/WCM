namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_GPU_group
    {
        public string allocation_algorithm;
        public string[] enabled_VGPU_types;
        public string[] GPU_types;
        public string name_description;
        public string name_label;
        public object other_config;
        public string[] PGPUs;
        public string[] supported_VGPU_types;
        public string uuid;
        public string[] VGPUs;
    }
}

