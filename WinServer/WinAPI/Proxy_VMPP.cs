namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_VMPP
    {
        public object alarm_config;
        public string archive_frequency;
        public DateTime archive_last_run_time;
        public object archive_schedule;
        public object archive_target_config;
        public string archive_target_type;
        public string backup_frequency;
        public DateTime backup_last_run_time;
        public string backup_retention_value;
        public object backup_schedule;
        public string backup_type;
        public bool is_alarm_enabled;
        public bool is_archive_running;
        public bool is_backup_running;
        public bool is_policy_enabled;
        public string name_description;
        public string name_label;
        public string[] recent_alerts;
        public string uuid;
        public string[] VMs;
    }
}

