namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_Role
    {
        public string name_description;
        public string name_label;
        public string[] subroles;
        public string uuid;
    }
}

