namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Session
    {
        public string auth_user_name;
        public string auth_user_sid;
        public bool is_local_superuser;
        public DateTime last_active;
        public string originator;
        public object other_config;
        public string parent;
        public bool pool;
        public string[] rbac_permissions;
        public string subject;
        public string[] tasks;
        public string this_host;
        public string this_user;
        public string uuid;
        public DateTime validation_time;
    }
}

