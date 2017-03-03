namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PIF : XenObject<PIF>
    {
        private List<XenRef<Bond>> _bond_master_of;
        private XenRef<Bond> _bond_slave_of;
        private string[] _capabilities;
        private bool _currently_attached;
        private string _device;
        private bool _disallow_unplug;
        private string _DNS;
        private string _gateway;
        private XenRef<Host> _host;
        private string _IP;
        private WinAPI.ip_configuration_mode _ip_configuration_mode;
        private string[] _IPv6;
        private WinAPI.ipv6_configuration_mode _ipv6_configuration_mode;
        private string _ipv6_gateway;
        private string _MAC;
        private bool _managed;
        private bool _management;
        private XenRef<PIF_metrics> _metrics;
        private long _MTU;
        private string _netmask;
        private XenRef<Network> _network;
        private Dictionary<string, string> _other_config;
        private bool _physical;
        private WinAPI.primary_address_type _primary_address_type;
        private Dictionary<string, string> _properties;
        private List<XenRef<Tunnel>> _tunnel_access_PIF_of;
        private List<XenRef<Tunnel>> _tunnel_transport_PIF_of;
        private string _uuid;
        private long _VLAN;
        private XenRef<WinAPI.VLAN> _VLAN_master_of;
        private List<XenRef<WinAPI.VLAN>> _VLAN_slave_of;

        public PIF()
        {
        }

        public PIF(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.device = Marshalling.ParseString(table, "device");
            this.network = Marshalling.ParseRef<Network>(table, "network");
            this.host = Marshalling.ParseRef<Host>(table, "host");
            this.MAC = Marshalling.ParseString(table, "MAC");
            this.MTU = Marshalling.ParseLong(table, "MTU");
            this.VLAN = Marshalling.ParseLong(table, "VLAN");
            this.metrics = Marshalling.ParseRef<PIF_metrics>(table, "metrics");
            this.physical = Marshalling.ParseBool(table, "physical");
            this.currently_attached = Marshalling.ParseBool(table, "currently_attached");
            this.ip_configuration_mode = (WinAPI.ip_configuration_mode) Helper.EnumParseDefault(typeof(WinAPI.ip_configuration_mode), Marshalling.ParseString(table, "ip_configuration_mode"));
            this.IP = Marshalling.ParseString(table, "IP");
            this.netmask = Marshalling.ParseString(table, "netmask");
            this.gateway = Marshalling.ParseString(table, "gateway");
            this.DNS = Marshalling.ParseString(table, "DNS");
            this.bond_slave_of = Marshalling.ParseRef<Bond>(table, "bond_slave_of");
            this.bond_master_of = Marshalling.ParseSetRef<Bond>(table, "bond_master_of");
            this.VLAN_master_of = Marshalling.ParseRef<WinAPI.VLAN>(table, "VLAN_master_of");
            this.VLAN_slave_of = Marshalling.ParseSetRef<WinAPI.VLAN>(table, "VLAN_slave_of");
            this.management = Marshalling.ParseBool(table, "management");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.disallow_unplug = Marshalling.ParseBool(table, "disallow_unplug");
            this.tunnel_access_PIF_of = Marshalling.ParseSetRef<Tunnel>(table, "tunnel_access_PIF_of");
            this.tunnel_transport_PIF_of = Marshalling.ParseSetRef<Tunnel>(table, "tunnel_transport_PIF_of");
            this.ipv6_configuration_mode = (WinAPI.ipv6_configuration_mode) Helper.EnumParseDefault(typeof(WinAPI.ipv6_configuration_mode), Marshalling.ParseString(table, "ipv6_configuration_mode"));
            this.IPv6 = Marshalling.ParseStringArray(table, "IPv6");
            this.ipv6_gateway = Marshalling.ParseString(table, "ipv6_gateway");
            this.primary_address_type = (WinAPI.primary_address_type) Helper.EnumParseDefault(typeof(WinAPI.primary_address_type), Marshalling.ParseString(table, "primary_address_type"));
            this.managed = Marshalling.ParseBool(table, "managed");
            this.properties = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "properties"));
            this.capabilities = Marshalling.ParseStringArray(table, "capabilities");
        }

        public PIF(Proxy_PIF proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public PIF(string uuid, string device, XenRef<Network> network, XenRef<Host> host, string MAC, long MTU, long VLAN, XenRef<PIF_metrics> metrics, bool physical, bool currently_attached, WinAPI.ip_configuration_mode ip_configuration_mode, string IP, string netmask, string gateway, string DNS, XenRef<Bond> bond_slave_of, List<XenRef<Bond>> bond_master_of, XenRef<WinAPI.VLAN> VLAN_master_of, List<XenRef<WinAPI.VLAN>> VLAN_slave_of, bool management, Dictionary<string, string> other_config, bool disallow_unplug, List<XenRef<Tunnel>> tunnel_access_PIF_of, List<XenRef<Tunnel>> tunnel_transport_PIF_of, WinAPI.ipv6_configuration_mode ipv6_configuration_mode, string[] IPv6, string ipv6_gateway, WinAPI.primary_address_type primary_address_type, bool managed, Dictionary<string, string> properties, string[] capabilities)
        {
            this.uuid = uuid;
            this.device = device;
            this.network = network;
            this.host = host;
            this.MAC = MAC;
            this.MTU = MTU;
            this.VLAN = VLAN;
            this.metrics = metrics;
            this.physical = physical;
            this.currently_attached = currently_attached;
            this.ip_configuration_mode = ip_configuration_mode;
            this.IP = IP;
            this.netmask = netmask;
            this.gateway = gateway;
            this.DNS = DNS;
            this.bond_slave_of = bond_slave_of;
            this.bond_master_of = bond_master_of;
            this.VLAN_master_of = VLAN_master_of;
            this.VLAN_slave_of = VLAN_slave_of;
            this.management = management;
            this.other_config = other_config;
            this.disallow_unplug = disallow_unplug;
            this.tunnel_access_PIF_of = tunnel_access_PIF_of;
            this.tunnel_transport_PIF_of = tunnel_transport_PIF_of;
            this.ipv6_configuration_mode = ipv6_configuration_mode;
            this.IPv6 = IPv6;
            this.ipv6_gateway = ipv6_gateway;
            this.primary_address_type = primary_address_type;
            this.managed = managed;
            this.properties = properties;
            this.capabilities = capabilities;
        }

        public static void add_to_other_config(Session session, string _pif, string _key, string _value)
        {
            session.proxy.pif_add_to_other_config(session.uuid, (_pif != null) ? _pif : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<Task> async_create_VLAN(Session session, string _device, string _network, string _host, long _vlan)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_create_vlan(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", _vlan.ToString()).parse());
        }

        public static XenRef<Task> async_db_forget(Session session, string _pif)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_db_forget(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<Task> async_db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug).parse());
        }

        public static XenRef<Task> async_db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug, WinAPI.ipv6_configuration_mode _ipv6_configuration_mode, string[] _ipv6, string _ipv6_gateway, WinAPI.primary_address_type _primary_address_type)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug, ipv6_configuration_mode_helper.ToString(_ipv6_configuration_mode), _ipv6, (_ipv6_gateway != null) ? _ipv6_gateway : "", primary_address_type_helper.ToString(_primary_address_type)).parse());
        }

        public static XenRef<Task> async_db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug, WinAPI.ipv6_configuration_mode _ipv6_configuration_mode, string[] _ipv6, string _ipv6_gateway, WinAPI.primary_address_type _primary_address_type, bool _managed)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug, ipv6_configuration_mode_helper.ToString(_ipv6_configuration_mode), _ipv6, (_ipv6_gateway != null) ? _ipv6_gateway : "", primary_address_type_helper.ToString(_primary_address_type), _managed).parse());
        }

        public static XenRef<Task> async_db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug, WinAPI.ipv6_configuration_mode _ipv6_configuration_mode, string[] _ipv6, string _ipv6_gateway, WinAPI.primary_address_type _primary_address_type, bool _managed, Dictionary<string, string> _properties)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug, ipv6_configuration_mode_helper.ToString(_ipv6_configuration_mode), _ipv6, (_ipv6_gateway != null) ? _ipv6_gateway : "", primary_address_type_helper.ToString(_primary_address_type), _managed, Maps.convert_to_proxy_string_string(_properties)).parse());
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<Task> async_destroy(Session session, string _pif)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_destroy(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<Task> async_forget(Session session, string _pif)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_forget(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<Task> async_introduce(Session session, string _host, string _mac, string _device)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_introduce(session.uuid, (_host != null) ? _host : "", (_mac != null) ? _mac : "", (_device != null) ? _device : "").parse());
        }

        public static XenRef<Task> async_introduce(Session session, string _host, string _mac, string _device, bool _managed)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_introduce(session.uuid, (_host != null) ? _host : "", (_mac != null) ? _mac : "", (_device != null) ? _device : "", _managed).parse());
        }

        public static XenRef<Task> async_plug(Session session, string _pif)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_plug(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<Task> async_reconfigure_ip(Session session, string _pif, WinAPI.ip_configuration_mode _mode, string _ip, string _netmask, string _gateway, string _dns)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_reconfigure_ip(session.uuid, (_pif != null) ? _pif : "", ip_configuration_mode_helper.ToString(_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "").parse());
        }

        public static XenRef<Task> async_reconfigure_ipv6(Session session, string _pif, WinAPI.ipv6_configuration_mode _mode, string _ipv6, string _gateway, string _dns)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_reconfigure_ipv6(session.uuid, (_pif != null) ? _pif : "", ipv6_configuration_mode_helper.ToString(_mode), (_ipv6 != null) ? _ipv6 : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "").parse());
        }

        public static XenRef<Task> async_scan(Session session, string _host)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_scan(session.uuid, (_host != null) ? _host : "").parse());
        }

        public static XenRef<Task> async_set_primary_address_type(Session session, string _pif, WinAPI.primary_address_type _primary_address_type)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_set_primary_address_type(session.uuid, (_pif != null) ? _pif : "", primary_address_type_helper.ToString(_primary_address_type)).parse());
        }

        public static XenRef<Task> async_set_property(Session session, string _pif, string _name, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_set_property(session.uuid, (_pif != null) ? _pif : "", (_name != null) ? _name : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_unplug(Session session, string _pif)
        {
            return XenRef<Task>.Create(session.proxy.async_pif_unplug(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<PIF> create_VLAN(Session session, string _device, string _network, string _host, long _vlan)
        {
            return XenRef<PIF>.Create(session.proxy.pif_create_vlan(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", _vlan.ToString()).parse());
        }

        public static void db_forget(Session session, string _pif)
        {
            session.proxy.pif_db_forget(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static XenRef<PIF> db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug)
        {
            return XenRef<PIF>.Create(session.proxy.pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug).parse());
        }

        public static XenRef<PIF> db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug, WinAPI.ipv6_configuration_mode _ipv6_configuration_mode, string[] _ipv6, string _ipv6_gateway, WinAPI.primary_address_type _primary_address_type)
        {
            return XenRef<PIF>.Create(session.proxy.pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug, ipv6_configuration_mode_helper.ToString(_ipv6_configuration_mode), _ipv6, (_ipv6_gateway != null) ? _ipv6_gateway : "", primary_address_type_helper.ToString(_primary_address_type)).parse());
        }

        public static XenRef<PIF> db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug, WinAPI.ipv6_configuration_mode _ipv6_configuration_mode, string[] _ipv6, string _ipv6_gateway, WinAPI.primary_address_type _primary_address_type, bool _managed)
        {
            return XenRef<PIF>.Create(session.proxy.pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug, ipv6_configuration_mode_helper.ToString(_ipv6_configuration_mode), _ipv6, (_ipv6_gateway != null) ? _ipv6_gateway : "", primary_address_type_helper.ToString(_primary_address_type), _managed).parse());
        }

        public static XenRef<PIF> db_introduce(Session session, string _device, string _network, string _host, string _mac, long _mtu, long _vlan, bool _physical, WinAPI.ip_configuration_mode _ip_configuration_mode, string _ip, string _netmask, string _gateway, string _dns, string _bond_slave_of, string _vlan_master_of, bool _management, Dictionary<string, string> _other_config, bool _disallow_unplug, WinAPI.ipv6_configuration_mode _ipv6_configuration_mode, string[] _ipv6, string _ipv6_gateway, WinAPI.primary_address_type _primary_address_type, bool _managed, Dictionary<string, string> _properties)
        {
            return XenRef<PIF>.Create(session.proxy.pif_db_introduce(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", (_host != null) ? _host : "", (_mac != null) ? _mac : "", _mtu.ToString(), _vlan.ToString(), _physical, ip_configuration_mode_helper.ToString(_ip_configuration_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "", (_bond_slave_of != null) ? _bond_slave_of : "", (_vlan_master_of != null) ? _vlan_master_of : "", _management, Maps.convert_to_proxy_string_string(_other_config), _disallow_unplug, ipv6_configuration_mode_helper.ToString(_ipv6_configuration_mode), _ipv6, (_ipv6_gateway != null) ? _ipv6_gateway : "", primary_address_type_helper.ToString(_primary_address_type), _managed, Maps.convert_to_proxy_string_string(_properties)).parse());
        }

        public bool DeepEquals(PIF other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._device, other._device)) && (Helper.AreEqual2<XenRef<Network>>(this._network, other._network) && Helper.AreEqual2<XenRef<Host>>(this._host, other._host))) && ((Helper.AreEqual2<string>(this._MAC, other._MAC) && Helper.AreEqual2<long>(this._MTU, other._MTU)) && (Helper.AreEqual2<long>(this._VLAN, other._VLAN) && Helper.AreEqual2<XenRef<PIF_metrics>>(this._metrics, other._metrics)))) && (((Helper.AreEqual2<bool>(this._physical, other._physical) && Helper.AreEqual2<bool>(this._currently_attached, other._currently_attached)) && (Helper.AreEqual2<WinAPI.ip_configuration_mode>(this._ip_configuration_mode, other._ip_configuration_mode) && Helper.AreEqual2<string>(this._IP, other._IP))) && ((Helper.AreEqual2<string>(this._netmask, other._netmask) && Helper.AreEqual2<string>(this._gateway, other._gateway)) && (Helper.AreEqual2<string>(this._DNS, other._DNS) && Helper.AreEqual2<XenRef<Bond>>(this._bond_slave_of, other._bond_slave_of))))) && ((((Helper.AreEqual2<List<XenRef<Bond>>>(this._bond_master_of, other._bond_master_of) && Helper.AreEqual2<XenRef<WinAPI.VLAN>>(this._VLAN_master_of, other._VLAN_master_of)) && (Helper.AreEqual2<List<XenRef<WinAPI.VLAN>>>(this._VLAN_slave_of, other._VLAN_slave_of) && Helper.AreEqual2<bool>(this._management, other._management))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<bool>(this._disallow_unplug, other._disallow_unplug)) && (Helper.AreEqual2<List<XenRef<Tunnel>>>(this._tunnel_access_PIF_of, other._tunnel_access_PIF_of) && Helper.AreEqual2<List<XenRef<Tunnel>>>(this._tunnel_transport_PIF_of, other._tunnel_transport_PIF_of)))) && (((Helper.AreEqual2<WinAPI.ipv6_configuration_mode>(this._ipv6_configuration_mode, other._ipv6_configuration_mode) && Helper.AreEqual2<string[]>(this._IPv6, other._IPv6)) && (Helper.AreEqual2<string>(this._ipv6_gateway, other._ipv6_gateway) && Helper.AreEqual2<WinAPI.primary_address_type>(this._primary_address_type, other._primary_address_type))) && (Helper.AreEqual2<bool>(this._managed, other._managed) && Helper.AreEqual2<Dictionary<string, string>>(this._properties, other._properties))))) && Helper.AreEqual2<string[]>(this._capabilities, other._capabilities)));
        }

        [Deprecated("XenServer 4.1")]
        public static void destroy(Session session, string _pif)
        {
            session.proxy.pif_destroy(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static void forget(Session session, string _pif)
        {
            session.proxy.pif_forget(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static List<XenRef<PIF>> get_all(Session session)
        {
            return XenRef<PIF>.Create(session.proxy.pif_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<PIF>, PIF> get_all_records(Session session)
        {
            return XenRef<PIF>.Create<Proxy_PIF>(session.proxy.pif_get_all_records(session.uuid).parse());
        }

        public static List<XenRef<Bond>> get_bond_master_of(Session session, string _pif)
        {
            return XenRef<Bond>.Create(session.proxy.pif_get_bond_master_of(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<Bond> get_bond_slave_of(Session session, string _pif)
        {
            return XenRef<Bond>.Create(session.proxy.pif_get_bond_slave_of(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<PIF> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<PIF>.Create(session.proxy.pif_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static string[] get_capabilities(Session session, string _pif)
        {
            return session.proxy.pif_get_capabilities(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static bool get_currently_attached(Session session, string _pif)
        {
            return session.proxy.pif_get_currently_attached(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static string get_device(Session session, string _pif)
        {
            return session.proxy.pif_get_device(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static bool get_disallow_unplug(Session session, string _pif)
        {
            return session.proxy.pif_get_disallow_unplug(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static string get_DNS(Session session, string _pif)
        {
            return session.proxy.pif_get_dns(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static string get_gateway(Session session, string _pif)
        {
            return session.proxy.pif_get_gateway(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static XenRef<Host> get_host(Session session, string _pif)
        {
            return XenRef<Host>.Create(session.proxy.pif_get_host(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static string get_IP(Session session, string _pif)
        {
            return session.proxy.pif_get_ip(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static WinAPI.ip_configuration_mode get_ip_configuration_mode(Session session, string _pif)
        {
            return (WinAPI.ip_configuration_mode) Helper.EnumParseDefault(typeof(WinAPI.ip_configuration_mode), session.proxy.pif_get_ip_configuration_mode(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static string[] get_IPv6(Session session, string _pif)
        {
            return session.proxy.pif_get_ipv6(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static WinAPI.ipv6_configuration_mode get_ipv6_configuration_mode(Session session, string _pif)
        {
            return (WinAPI.ipv6_configuration_mode) Helper.EnumParseDefault(typeof(WinAPI.ipv6_configuration_mode), session.proxy.pif_get_ipv6_configuration_mode(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static string get_ipv6_gateway(Session session, string _pif)
        {
            return session.proxy.pif_get_ipv6_gateway(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static string get_MAC(Session session, string _pif)
        {
            return session.proxy.pif_get_mac(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static bool get_managed(Session session, string _pif)
        {
            return session.proxy.pif_get_managed(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static bool get_management(Session session, string _pif)
        {
            return session.proxy.pif_get_management(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static XenRef<PIF_metrics> get_metrics(Session session, string _pif)
        {
            return XenRef<PIF_metrics>.Create(session.proxy.pif_get_metrics(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static long get_MTU(Session session, string _pif)
        {
            return long.Parse(session.proxy.pif_get_mtu(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static string get_netmask(Session session, string _pif)
        {
            return session.proxy.pif_get_netmask(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static XenRef<Network> get_network(Session session, string _pif)
        {
            return XenRef<Network>.Create(session.proxy.pif_get_network(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _pif)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pif_get_other_config(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static bool get_physical(Session session, string _pif)
        {
            return session.proxy.pif_get_physical(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static WinAPI.primary_address_type get_primary_address_type(Session session, string _pif)
        {
            return (WinAPI.primary_address_type) Helper.EnumParseDefault(typeof(WinAPI.primary_address_type), session.proxy.pif_get_primary_address_type(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static Dictionary<string, string> get_properties(Session session, string _pif)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pif_get_properties(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static PIF get_record(Session session, string _pif)
        {
            return new PIF(session.proxy.pif_get_record(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static List<XenRef<Tunnel>> get_tunnel_access_PIF_of(Session session, string _pif)
        {
            return XenRef<Tunnel>.Create(session.proxy.pif_get_tunnel_access_pif_of(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static List<XenRef<Tunnel>> get_tunnel_transport_PIF_of(Session session, string _pif)
        {
            return XenRef<Tunnel>.Create(session.proxy.pif_get_tunnel_transport_pif_of(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static string get_uuid(Session session, string _pif)
        {
            return session.proxy.pif_get_uuid(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static long get_VLAN(Session session, string _pif)
        {
            return long.Parse(session.proxy.pif_get_vlan(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<WinAPI.VLAN> get_VLAN_master_of(Session session, string _pif)
        {
            return XenRef<WinAPI.VLAN>.Create(session.proxy.pif_get_vlan_master_of(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static List<XenRef<WinAPI.VLAN>> get_VLAN_slave_of(Session session, string _pif)
        {
            return XenRef<WinAPI.VLAN>.Create(session.proxy.pif_get_vlan_slave_of(session.uuid, (_pif != null) ? _pif : "").parse());
        }

        public static XenRef<PIF> introduce(Session session, string _host, string _mac, string _device)
        {
            return XenRef<PIF>.Create(session.proxy.pif_introduce(session.uuid, (_host != null) ? _host : "", (_mac != null) ? _mac : "", (_device != null) ? _device : "").parse());
        }

        public static XenRef<PIF> introduce(Session session, string _host, string _mac, string _device, bool _managed)
        {
            return XenRef<PIF>.Create(session.proxy.pif_introduce(session.uuid, (_host != null) ? _host : "", (_mac != null) ? _mac : "", (_device != null) ? _device : "", _managed).parse());
        }

        public static void plug(Session session, string _pif)
        {
            session.proxy.pif_plug(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public static void reconfigure_ip(Session session, string _pif, WinAPI.ip_configuration_mode _mode, string _ip, string _netmask, string _gateway, string _dns)
        {
            session.proxy.pif_reconfigure_ip(session.uuid, (_pif != null) ? _pif : "", ip_configuration_mode_helper.ToString(_mode), (_ip != null) ? _ip : "", (_netmask != null) ? _netmask : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "").parse();
        }

        public static void reconfigure_ipv6(Session session, string _pif, WinAPI.ipv6_configuration_mode _mode, string _ipv6, string _gateway, string _dns)
        {
            session.proxy.pif_reconfigure_ipv6(session.uuid, (_pif != null) ? _pif : "", ipv6_configuration_mode_helper.ToString(_mode), (_ipv6 != null) ? _ipv6 : "", (_gateway != null) ? _gateway : "", (_dns != null) ? _dns : "").parse();
        }

        public static void remove_from_other_config(Session session, string _pif, string _key)
        {
            session.proxy.pif_remove_from_other_config(session.uuid, (_pif != null) ? _pif : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, PIF server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<bool>(this._disallow_unplug, server._disallow_unplug))
            {
                set_disallow_unplug(session, opaqueRef, this._disallow_unplug);
            }
            return null;
        }

        public static void scan(Session session, string _host)
        {
            session.proxy.pif_scan(session.uuid, (_host != null) ? _host : "").parse();
        }

        public static void set_disallow_unplug(Session session, string _pif, bool _disallow_unplug)
        {
            session.proxy.pif_set_disallow_unplug(session.uuid, (_pif != null) ? _pif : "", _disallow_unplug).parse();
        }

        public static void set_other_config(Session session, string _pif, Dictionary<string, string> _other_config)
        {
            session.proxy.pif_set_other_config(session.uuid, (_pif != null) ? _pif : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_primary_address_type(Session session, string _pif, WinAPI.primary_address_type _primary_address_type)
        {
            session.proxy.pif_set_primary_address_type(session.uuid, (_pif != null) ? _pif : "", primary_address_type_helper.ToString(_primary_address_type)).parse();
        }

        public static void set_property(Session session, string _pif, string _name, string _value)
        {
            session.proxy.pif_set_property(session.uuid, (_pif != null) ? _pif : "", (_name != null) ? _name : "", (_value != null) ? _value : "").parse();
        }

        public Proxy_PIF ToProxy()
        {
            return new Proxy_PIF { 
                uuid = (this.uuid != null) ? this.uuid : "", device = (this.device != null) ? this.device : "", network = (this.network != null) ? ((string) this.network) : "", host = (this.host != null) ? ((string) this.host) : "", MAC = (this.MAC != null) ? this.MAC : "", MTU = this.MTU.ToString(), VLAN = this.VLAN.ToString(), metrics = (this.metrics != null) ? ((string) this.metrics) : "", physical = this.physical, currently_attached = this.currently_attached, ip_configuration_mode = ip_configuration_mode_helper.ToString(this.ip_configuration_mode), IP = (this.IP != null) ? this.IP : "", netmask = (this.netmask != null) ? this.netmask : "", gateway = (this.gateway != null) ? this.gateway : "", DNS = (this.DNS != null) ? this.DNS : "", bond_slave_of = (this.bond_slave_of != null) ? ((string) this.bond_slave_of) : "", 
                bond_master_of = (this.bond_master_of != null) ? Helper.RefListToStringArray<Bond>(this.bond_master_of) : new string[0], VLAN_master_of = (this.VLAN_master_of != null) ? ((string) this.VLAN_master_of) : "", VLAN_slave_of = (this.VLAN_slave_of != null) ? Helper.RefListToStringArray<WinAPI.VLAN>(this.VLAN_slave_of) : new string[0], management = this.management, other_config = Maps.convert_to_proxy_string_string(this.other_config), disallow_unplug = this.disallow_unplug, tunnel_access_PIF_of = (this.tunnel_access_PIF_of != null) ? Helper.RefListToStringArray<Tunnel>(this.tunnel_access_PIF_of) : new string[0], tunnel_transport_PIF_of = (this.tunnel_transport_PIF_of != null) ? Helper.RefListToStringArray<Tunnel>(this.tunnel_transport_PIF_of) : new string[0], ipv6_configuration_mode = ipv6_configuration_mode_helper.ToString(this.ipv6_configuration_mode), IPv6 = this.IPv6, ipv6_gateway = (this.ipv6_gateway != null) ? this.ipv6_gateway : "", primary_address_type = primary_address_type_helper.ToString(this.primary_address_type), managed = this.managed, properties = Maps.convert_to_proxy_string_string(this.properties), capabilities = this.capabilities
             };
        }

        public static void unplug(Session session, string _pif)
        {
            session.proxy.pif_unplug(session.uuid, (_pif != null) ? _pif : "").parse();
        }

        public override void UpdateFrom(PIF update)
        {
            this.uuid = update.uuid;
            this.device = update.device;
            this.network = update.network;
            this.host = update.host;
            this.MAC = update.MAC;
            this.MTU = update.MTU;
            this.VLAN = update.VLAN;
            this.metrics = update.metrics;
            this.physical = update.physical;
            this.currently_attached = update.currently_attached;
            this.ip_configuration_mode = update.ip_configuration_mode;
            this.IP = update.IP;
            this.netmask = update.netmask;
            this.gateway = update.gateway;
            this.DNS = update.DNS;
            this.bond_slave_of = update.bond_slave_of;
            this.bond_master_of = update.bond_master_of;
            this.VLAN_master_of = update.VLAN_master_of;
            this.VLAN_slave_of = update.VLAN_slave_of;
            this.management = update.management;
            this.other_config = update.other_config;
            this.disallow_unplug = update.disallow_unplug;
            this.tunnel_access_PIF_of = update.tunnel_access_PIF_of;
            this.tunnel_transport_PIF_of = update.tunnel_transport_PIF_of;
            this.ipv6_configuration_mode = update.ipv6_configuration_mode;
            this.IPv6 = update.IPv6;
            this.ipv6_gateway = update.ipv6_gateway;
            this.primary_address_type = update.primary_address_type;
            this.managed = update.managed;
            this.properties = update.properties;
            this.capabilities = update.capabilities;
        }

        internal void UpdateFromProxy(Proxy_PIF proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.device = (proxy.device == null) ? null : proxy.device;
            this.network = (proxy.network == null) ? null : XenRef<Network>.Create(proxy.network);
            this.host = (proxy.host == null) ? null : XenRef<Host>.Create(proxy.host);
            this.MAC = (proxy.MAC == null) ? null : proxy.MAC;
            this.MTU = (proxy.MTU == null) ? 0L : long.Parse(proxy.MTU);
            this.VLAN = (proxy.VLAN == null) ? 0L : long.Parse(proxy.VLAN);
            this.metrics = (proxy.metrics == null) ? null : XenRef<PIF_metrics>.Create(proxy.metrics);
            this.physical = proxy.physical;
            this.currently_attached = proxy.currently_attached;
            this.ip_configuration_mode = (proxy.ip_configuration_mode == null) ? WinAPI.ip_configuration_mode.None : ((WinAPI.ip_configuration_mode) Helper.EnumParseDefault(typeof(WinAPI.ip_configuration_mode), proxy.ip_configuration_mode));
            this.IP = (proxy.IP == null) ? null : proxy.IP;
            this.netmask = (proxy.netmask == null) ? null : proxy.netmask;
            this.gateway = (proxy.gateway == null) ? null : proxy.gateway;
            this.DNS = (proxy.DNS == null) ? null : proxy.DNS;
            this.bond_slave_of = (proxy.bond_slave_of == null) ? null : XenRef<Bond>.Create(proxy.bond_slave_of);
            this.bond_master_of = (proxy.bond_master_of == null) ? null : XenRef<Bond>.Create(proxy.bond_master_of);
            this.VLAN_master_of = (proxy.VLAN_master_of == null) ? null : XenRef<WinAPI.VLAN>.Create(proxy.VLAN_master_of);
            this.VLAN_slave_of = (proxy.VLAN_slave_of == null) ? null : XenRef<WinAPI.VLAN>.Create(proxy.VLAN_slave_of);
            this.management = proxy.management;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.disallow_unplug = proxy.disallow_unplug;
            this.tunnel_access_PIF_of = (proxy.tunnel_access_PIF_of == null) ? null : XenRef<Tunnel>.Create(proxy.tunnel_access_PIF_of);
            this.tunnel_transport_PIF_of = (proxy.tunnel_transport_PIF_of == null) ? null : XenRef<Tunnel>.Create(proxy.tunnel_transport_PIF_of);
            this.ipv6_configuration_mode = (proxy.ipv6_configuration_mode == null) ? WinAPI.ipv6_configuration_mode.None : ((WinAPI.ipv6_configuration_mode) Helper.EnumParseDefault(typeof(WinAPI.ipv6_configuration_mode), proxy.ipv6_configuration_mode));
            this.IPv6 = (proxy.IPv6 == null) ? new string[0] : proxy.IPv6;
            this.ipv6_gateway = (proxy.ipv6_gateway == null) ? null : proxy.ipv6_gateway;
            this.primary_address_type = (proxy.primary_address_type == null) ? WinAPI.primary_address_type.IPv4 : ((WinAPI.primary_address_type) Helper.EnumParseDefault(typeof(WinAPI.primary_address_type), proxy.primary_address_type));
            this.managed = proxy.managed;
            this.properties = (proxy.properties == null) ? null : Maps.convert_from_proxy_string_string(proxy.properties);
            this.capabilities = (proxy.capabilities == null) ? new string[0] : proxy.capabilities;
        }

        public virtual List<XenRef<Bond>> bond_master_of
        {
            get
            {
                return this._bond_master_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._bond_master_of))
                {
                    this._bond_master_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("bond_master_of");
                }
            }
        }

        public virtual XenRef<Bond> bond_slave_of
        {
            get
            {
                return this._bond_slave_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._bond_slave_of))
                {
                    this._bond_slave_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("bond_slave_of");
                }
            }
        }

        public virtual string[] capabilities
        {
            get
            {
                return this._capabilities;
            }
            set
            {
                if (!Helper.AreEqual(value, this._capabilities))
                {
                    this._capabilities = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("capabilities");
                }
            }
        }

        public virtual bool currently_attached
        {
            get
            {
                return this._currently_attached;
            }
            set
            {
                if (!Helper.AreEqual(value, this._currently_attached))
                {
                    this._currently_attached = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("currently_attached");
                }
            }
        }

        public virtual string device
        {
            get
            {
                return this._device;
            }
            set
            {
                if (!Helper.AreEqual(value, this._device))
                {
                    this._device = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("device");
                }
            }
        }

        public virtual bool disallow_unplug
        {
            get
            {
                return this._disallow_unplug;
            }
            set
            {
                if (!Helper.AreEqual(value, this._disallow_unplug))
                {
                    this._disallow_unplug = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("disallow_unplug");
                }
            }
        }

        public virtual string DNS
        {
            get
            {
                return this._DNS;
            }
            set
            {
                if (!Helper.AreEqual(value, this._DNS))
                {
                    this._DNS = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("DNS");
                }
            }
        }

        public virtual string gateway
        {
            get
            {
                return this._gateway;
            }
            set
            {
                if (!Helper.AreEqual(value, this._gateway))
                {
                    this._gateway = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("gateway");
                }
            }
        }

        public virtual XenRef<Host> host
        {
            get
            {
                return this._host;
            }
            set
            {
                if (!Helper.AreEqual(value, this._host))
                {
                    this._host = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("host");
                }
            }
        }

        public virtual string IP
        {
            get
            {
                return this._IP;
            }
            set
            {
                if (!Helper.AreEqual(value, this._IP))
                {
                    this._IP = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("IP");
                }
            }
        }

        public virtual WinAPI.ip_configuration_mode ip_configuration_mode
        {
            get
            {
                return this._ip_configuration_mode;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ip_configuration_mode))
                {
                    this._ip_configuration_mode = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ip_configuration_mode");
                }
            }
        }

        public virtual string[] IPv6
        {
            get
            {
                return this._IPv6;
            }
            set
            {
                if (!Helper.AreEqual(value, this._IPv6))
                {
                    this._IPv6 = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("IPv6");
                }
            }
        }

        public virtual WinAPI.ipv6_configuration_mode ipv6_configuration_mode
        {
            get
            {
                return this._ipv6_configuration_mode;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ipv6_configuration_mode))
                {
                    this._ipv6_configuration_mode = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ipv6_configuration_mode");
                }
            }
        }

        public virtual string ipv6_gateway
        {
            get
            {
                return this._ipv6_gateway;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ipv6_gateway))
                {
                    this._ipv6_gateway = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ipv6_gateway");
                }
            }
        }

        public virtual string MAC
        {
            get
            {
                return this._MAC;
            }
            set
            {
                if (!Helper.AreEqual(value, this._MAC))
                {
                    this._MAC = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("MAC");
                }
            }
        }

        public virtual bool managed
        {
            get
            {
                return this._managed;
            }
            set
            {
                if (!Helper.AreEqual(value, this._managed))
                {
                    this._managed = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("managed");
                }
            }
        }

        public virtual bool management
        {
            get
            {
                return this._management;
            }
            set
            {
                if (!Helper.AreEqual(value, this._management))
                {
                    this._management = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("management");
                }
            }
        }

        public virtual XenRef<PIF_metrics> metrics
        {
            get
            {
                return this._metrics;
            }
            set
            {
                if (!Helper.AreEqual(value, this._metrics))
                {
                    this._metrics = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("metrics");
                }
            }
        }

        public virtual long MTU
        {
            get
            {
                return this._MTU;
            }
            set
            {
                if (!Helper.AreEqual(value, this._MTU))
                {
                    this._MTU = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("MTU");
                }
            }
        }

        public virtual string netmask
        {
            get
            {
                return this._netmask;
            }
            set
            {
                if (!Helper.AreEqual(value, this._netmask))
                {
                    this._netmask = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("netmask");
                }
            }
        }

        public virtual XenRef<Network> network
        {
            get
            {
                return this._network;
            }
            set
            {
                if (!Helper.AreEqual(value, this._network))
                {
                    this._network = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("network");
                }
            }
        }

        public virtual Dictionary<string, string> other_config
        {
            get
            {
                return this._other_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._other_config))
                {
                    this._other_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("other_config");
                }
            }
        }

        public virtual bool physical
        {
            get
            {
                return this._physical;
            }
            set
            {
                if (!Helper.AreEqual(value, this._physical))
                {
                    this._physical = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("physical");
                }
            }
        }

        public virtual WinAPI.primary_address_type primary_address_type
        {
            get
            {
                return this._primary_address_type;
            }
            set
            {
                if (!Helper.AreEqual(value, this._primary_address_type))
                {
                    this._primary_address_type = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("primary_address_type");
                }
            }
        }

        public virtual Dictionary<string, string> properties
        {
            get
            {
                return this._properties;
            }
            set
            {
                if (!Helper.AreEqual(value, this._properties))
                {
                    this._properties = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("properties");
                }
            }
        }

        public virtual List<XenRef<Tunnel>> tunnel_access_PIF_of
        {
            get
            {
                return this._tunnel_access_PIF_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._tunnel_access_PIF_of))
                {
                    this._tunnel_access_PIF_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("tunnel_access_PIF_of");
                }
            }
        }

        public virtual List<XenRef<Tunnel>> tunnel_transport_PIF_of
        {
            get
            {
                return this._tunnel_transport_PIF_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._tunnel_transport_PIF_of))
                {
                    this._tunnel_transport_PIF_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("tunnel_transport_PIF_of");
                }
            }
        }

        public virtual string uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                if (!Helper.AreEqual(value, this._uuid))
                {
                    this._uuid = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("uuid");
                }
            }
        }

        public virtual long VLAN
        {
            get
            {
                return this._VLAN;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VLAN))
                {
                    this._VLAN = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VLAN");
                }
            }
        }

        public virtual XenRef<WinAPI.VLAN> VLAN_master_of
        {
            get
            {
                return this._VLAN_master_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VLAN_master_of))
                {
                    this._VLAN_master_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VLAN_master_of");
                }
            }
        }

        public virtual List<XenRef<WinAPI.VLAN>> VLAN_slave_of
        {
            get
            {
                return this._VLAN_slave_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VLAN_slave_of))
                {
                    this._VLAN_slave_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VLAN_slave_of");
                }
            }
        }
    }
}

