namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Proxy_PIF
    {
        public string[] bond_master_of;
        public string bond_slave_of;
        public string[] capabilities;
        public bool currently_attached;
        public string device;
        public bool disallow_unplug;
        public string DNS;
        public string gateway;
        public string host;
        public string IP;
        public string ip_configuration_mode;
        public string[] IPv6;
        public string ipv6_configuration_mode;
        public string ipv6_gateway;
        public string MAC;
        public bool managed;
        public bool management;
        public string metrics;
        public string MTU;
        public string netmask;
        public string network;
        public object other_config;
        public bool physical;
        public string primary_address_type;
        public object properties;
        public string[] tunnel_access_PIF_of;
        public string[] tunnel_transport_PIF_of;
        public string uuid;
        public string VLAN;
        public string VLAN_master_of;
        public string[] VLAN_slave_of;
    }
}

