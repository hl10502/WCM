namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Task
    {
        public string[] allowed_operations;
        public string backtrace;
        public DateTime created;
        public object current_operations;
        public string[] error_info;
        public DateTime finished;
        public string name_description;
        public string name_label;
        public object other_config;
        public double progress;
        public string resident_on;
        public string result;
        public string status;
        public string subtask_of;
        public string[] subtasks;
        public string type;
        public string uuid;
    }
}

