namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Host
    {
        public string address;
        public string[] allowed_operations;
        public string API_version_major;
        public string API_version_minor;
        public string API_version_vendor;
        public object API_version_vendor_implementation;
        public object bios_strings;
        public object blobs;
        public string[] capabilities;
        public object chipset_info;
        public object cpu_configuration;
        public object cpu_info;
        public string crash_dump_sr;
        public string[] crashdumps;
        public object current_operations;
        public string display;
        public string edition;
        public bool enabled;
        public object external_auth_configuration;
        public string external_auth_service_name;
        public string external_auth_type;
        public object guest_VCPUs_params;
        public string[] ha_network_peers;
        public string[] ha_statefiles;
        public string[] host_CPUs;
        public string hostname;
        public object license_params;
        public object license_server;
        public string local_cache_sr;
        public object logging;
        public string memory_overhead;
        public string metrics;
        public string name_description;
        public string name_label;
        public object other_config;
        public string[] patches;
        public string[] PBDs;
        public string[] PCIs;
        public string[] PGPUs;
        public string[] PIFs;
        public object power_on_config;
        public string power_on_mode;
        public string[] resident_VMs;
        public string sched_policy;
        public object software_version;
        public bool ssl_legacy;
        public string[] supported_bootloaders;
        public string suspend_image_sr;
        public string[] tags;
        public string uuid;
        public string[] virtual_hardware_platform_versions;
    }
}

