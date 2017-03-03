namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VM
    {
        public string actions_after_crash;
        public string actions_after_reboot;
        public string actions_after_shutdown;
        public string affinity;
        public string[] allowed_operations;
        public string appliance;
        public string[] attached_PCIs;
        public bool auto_update_drivers;
        public object bios_strings;
        public object blobs;
        public object blocked_operations;
        public string[] children;
        public string[] consoles;
        public string[] crash_dumps;
        public object current_operations;
        public string domarch;
        public string domid;
        public string generation_id;
        public string guest_metrics;
        public bool ha_always_run;
        public string ha_restart_priority;
        public string hardware_platform_version;
        public object HVM_boot_params;
        public string HVM_boot_policy;
        public double HVM_shadow_multiplier;
        public bool is_a_snapshot;
        public bool is_a_template;
        public bool is_control_domain;
        public bool is_snapshot_from_vmpp;
        public object last_boot_CPU_flags;
        public string last_booted_record;
        public string memory_dynamic_max;
        public string memory_dynamic_min;
        public string memory_overhead;
        public string memory_static_max;
        public string memory_static_min;
        public string memory_target;
        public string metrics;
        public string name_description;
        public string name_label;
        public string order;
        public object other_config;
        public string parent;
        public string PCI_bus;
        public object platform;
        public string power_state;
        public string protection_policy;
        public string PV_args;
        public string PV_bootloader;
        public string PV_bootloader_args;
        public string PV_kernel;
        public string PV_legacy_args;
        public string PV_ramdisk;
        public string recommendations;
        public string resident_on;
        public string shutdown_delay;
        public object snapshot_info;
        public string snapshot_metadata;
        public string snapshot_of;
        public DateTime snapshot_time;
        public string[] snapshots;
        public string start_delay;
        public string suspend_SR;
        public string suspend_VDI;
        public string[] tags;
        public string transportable_snapshot_id;
        public string user_version;
        public string uuid;
        public string[] VBDs;
        public string VCPUs_at_startup;
        public string VCPUs_max;
        public object VCPUs_params;
        public string version;
        public string[] VGPUs;
        public string[] VIFs;
        public string[] VTPMs;
        public object xenstore_data;
    }
}

