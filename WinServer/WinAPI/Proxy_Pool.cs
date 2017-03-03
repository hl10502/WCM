namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Pool
    {
        public string[] allowed_operations;
        public object blobs;
        public string crash_dump_SR;
        public object current_operations;
        public string default_SR;
        public object guest_agent_config;
        public object gui_config;
        public bool ha_allow_overcommit;
        public string ha_cluster_stack;
        public object ha_configuration;
        public bool ha_enabled;
        public string ha_host_failures_to_tolerate;
        public bool ha_overcommitted;
        public string ha_plan_exists_for;
        public string[] ha_statefiles;
        public object health_check_config;
        public string master;
        public string[] metadata_VDIs;
        public string name_description;
        public string name_label;
        public object other_config;
        public bool redo_log_enabled;
        public string redo_log_vdi;
        public object restrictions;
        public string suspend_image_SR;
        public string[] tags;
        public string uuid;
        public string vswitch_controller;
        public bool wlb_enabled;
        public string wlb_url;
        public string wlb_username;
        public bool wlb_verify_cert;
    }
}

