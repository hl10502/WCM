namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Pool_patch
    {
        public string[] after_apply_guidance;
        public string[] host_patches;
        public string name_description;
        public string name_label;
        public object other_config;
        public bool pool_applied;
        public string size;
        public string uuid;
        public string version;
    }
}

