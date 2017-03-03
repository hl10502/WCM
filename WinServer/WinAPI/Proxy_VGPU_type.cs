namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VGPU_type
    {
        public string[] enabled_on_GPU_groups;
        public string[] enabled_on_PGPUs;
        public bool experimental;
        public string framebuffer_size;
        public string identifier;
        public string implementation;
        public string max_heads;
        public string max_resolution_x;
        public string max_resolution_y;
        public string model_name;
        public string[] supported_on_GPU_groups;
        public string[] supported_on_PGPUs;
        public string uuid;
        public string vendor_name;
        public string[] VGPUs;
    }
}

