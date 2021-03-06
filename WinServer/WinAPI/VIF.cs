﻿namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VIF : XenObject<VIF>
    {
        private List<vif_operations> _allowed_operations;
        private Dictionary<string, vif_operations> _current_operations;
        private bool _currently_attached;
        private string _device;
        private string[] _ipv4_allowed;
        private string[] _ipv6_allowed;
        private vif_locking_mode _locking_mode;
        private string _MAC;
        private bool _MAC_autogenerated;
        private XenRef<VIF_metrics> _metrics;
        private long _MTU;
        private XenRef<Network> _network;
        private Dictionary<string, string> _other_config;
        private Dictionary<string, string> _qos_algorithm_params;
        private string _qos_algorithm_type;
        private string[] _qos_supported_algorithms;
        private Dictionary<string, string> _runtime_properties;
        private long _status_code;
        private string _status_detail;
        private string _uuid;
        private XenRef<WinAPI.VM> _VM;

        public VIF()
        {
        }

        public VIF(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.allowed_operations = Helper.StringArrayToEnumList<vif_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_vif_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.device = Marshalling.ParseString(table, "device");
            this.network = Marshalling.ParseRef<Network>(table, "network");
            this.VM = Marshalling.ParseRef<WinAPI.VM>(table, "VM");
            this.MAC = Marshalling.ParseString(table, "MAC");
            this.MTU = Marshalling.ParseLong(table, "MTU");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.currently_attached = Marshalling.ParseBool(table, "currently_attached");
            this.status_code = Marshalling.ParseLong(table, "status_code");
            this.status_detail = Marshalling.ParseString(table, "status_detail");
            this.runtime_properties = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "runtime_properties"));
            this.qos_algorithm_type = Marshalling.ParseString(table, "qos_algorithm_type");
            this.qos_algorithm_params = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "qos_algorithm_params"));
            this.qos_supported_algorithms = Marshalling.ParseStringArray(table, "qos_supported_algorithms");
            this.metrics = Marshalling.ParseRef<VIF_metrics>(table, "metrics");
            this.MAC_autogenerated = Marshalling.ParseBool(table, "MAC_autogenerated");
            this.locking_mode = (vif_locking_mode) Helper.EnumParseDefault(typeof(vif_locking_mode), Marshalling.ParseString(table, "locking_mode"));
            this.ipv4_allowed = Marshalling.ParseStringArray(table, "ipv4_allowed");
            this.ipv6_allowed = Marshalling.ParseStringArray(table, "ipv6_allowed");
        }

        public VIF(Proxy_VIF proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VIF(string uuid, List<vif_operations> allowed_operations, Dictionary<string, vif_operations> current_operations, string device, XenRef<Network> network, XenRef<WinAPI.VM> VM, string MAC, long MTU, Dictionary<string, string> other_config, bool currently_attached, long status_code, string status_detail, Dictionary<string, string> runtime_properties, string qos_algorithm_type, Dictionary<string, string> qos_algorithm_params, string[] qos_supported_algorithms, XenRef<VIF_metrics> metrics, bool MAC_autogenerated, vif_locking_mode locking_mode, string[] ipv4_allowed, string[] ipv6_allowed)
        {
            this.uuid = uuid;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.device = device;
            this.network = network;
            this.VM = VM;
            this.MAC = MAC;
            this.MTU = MTU;
            this.other_config = other_config;
            this.currently_attached = currently_attached;
            this.status_code = status_code;
            this.status_detail = status_detail;
            this.runtime_properties = runtime_properties;
            this.qos_algorithm_type = qos_algorithm_type;
            this.qos_algorithm_params = qos_algorithm_params;
            this.qos_supported_algorithms = qos_supported_algorithms;
            this.metrics = metrics;
            this.MAC_autogenerated = MAC_autogenerated;
            this.locking_mode = locking_mode;
            this.ipv4_allowed = ipv4_allowed;
            this.ipv6_allowed = ipv6_allowed;
        }

        public static void add_ipv4_allowed(Session session, string _vif, string _value)
        {
            session.proxy.vif_add_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse();
        }

        public static void add_ipv6_allowed(Session session, string _vif, string _value)
        {
            session.proxy.vif_add_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_other_config(Session session, string _vif, string _key, string _value)
        {
            session.proxy.vif_add_to_other_config(session.uuid, (_vif != null) ? _vif : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_qos_algorithm_params(Session session, string _vif, string _key, string _value)
        {
            session.proxy.vif_add_to_qos_algorithm_params(session.uuid, (_vif != null) ? _vif : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_add_ipv4_allowed(Session session, string _vif, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_add_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_add_ipv6_allowed(Session session, string _vif, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_add_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_create(Session session, VIF _record)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _vif)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_destroy(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static XenRef<Task> async_plug(Session session, string _vif)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_plug(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static XenRef<Task> async_remove_ipv4_allowed(Session session, string _vif, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_remove_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_remove_ipv6_allowed(Session session, string _vif, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_remove_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_set_ipv4_allowed(Session session, string _vif, string[] _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_set_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "", _value).parse());
        }

        public static XenRef<Task> async_set_ipv6_allowed(Session session, string _vif, string[] _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_set_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "", _value).parse());
        }

        public static XenRef<Task> async_set_locking_mode(Session session, string _vif, vif_locking_mode _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_set_locking_mode(session.uuid, (_vif != null) ? _vif : "", vif_locking_mode_helper.ToString(_value)).parse());
        }

        public static XenRef<Task> async_unplug(Session session, string _vif)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_unplug(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static XenRef<Task> async_unplug_force(Session session, string _vif)
        {
            return XenRef<Task>.Create(session.proxy.async_vif_unplug_force(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static XenRef<VIF> create(Session session, VIF _record)
        {
            return XenRef<VIF>.Create(session.proxy.vif_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(VIF other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, vif_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<List<vif_operations>>(this._allowed_operations, other._allowed_operations)) && (Helper.AreEqual2<string>(this._device, other._device) && Helper.AreEqual2<XenRef<Network>>(this._network, other._network))) && ((Helper.AreEqual2<XenRef<WinAPI.VM>>(this._VM, other._VM) && Helper.AreEqual2<string>(this._MAC, other._MAC)) && (Helper.AreEqual2<long>(this._MTU, other._MTU) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)))) && (((Helper.AreEqual2<bool>(this._currently_attached, other._currently_attached) && Helper.AreEqual2<long>(this._status_code, other._status_code)) && (Helper.AreEqual2<string>(this._status_detail, other._status_detail) && Helper.AreEqual2<Dictionary<string, string>>(this._runtime_properties, other._runtime_properties))) && ((Helper.AreEqual2<string>(this._qos_algorithm_type, other._qos_algorithm_type) && Helper.AreEqual2<Dictionary<string, string>>(this._qos_algorithm_params, other._qos_algorithm_params)) && (Helper.AreEqual2<string[]>(this._qos_supported_algorithms, other._qos_supported_algorithms) && Helper.AreEqual2<XenRef<VIF_metrics>>(this._metrics, other._metrics))))) && ((Helper.AreEqual2<bool>(this._MAC_autogenerated, other._MAC_autogenerated) && Helper.AreEqual2<vif_locking_mode>(this._locking_mode, other._locking_mode)) && Helper.AreEqual2<string[]>(this._ipv4_allowed, other._ipv4_allowed))) && Helper.AreEqual2<string[]>(this._ipv6_allowed, other._ipv6_allowed));
        }

        public static void destroy(Session session, string _vif)
        {
            session.proxy.vif_destroy(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static List<XenRef<VIF>> get_all(Session session)
        {
            return XenRef<VIF>.Create(session.proxy.vif_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VIF>, VIF> get_all_records(Session session)
        {
            return XenRef<VIF>.Create<Proxy_VIF>(session.proxy.vif_get_all_records(session.uuid).parse());
        }

        public static List<vif_operations> get_allowed_operations(Session session, string _vif)
        {
            return Helper.StringArrayToEnumList<vif_operations>(session.proxy.vif_get_allowed_operations(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static XenRef<VIF> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VIF>.Create(session.proxy.vif_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, vif_operations> get_current_operations(Session session, string _vif)
        {
            return Maps.convert_from_proxy_string_vif_operations(session.proxy.vif_get_current_operations(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static bool get_currently_attached(Session session, string _vif)
        {
            return session.proxy.vif_get_currently_attached(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static string get_device(Session session, string _vif)
        {
            return session.proxy.vif_get_device(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static string[] get_ipv4_allowed(Session session, string _vif)
        {
            return session.proxy.vif_get_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static string[] get_ipv6_allowed(Session session, string _vif)
        {
            return session.proxy.vif_get_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static vif_locking_mode get_locking_mode(Session session, string _vif)
        {
            return (vif_locking_mode) Helper.EnumParseDefault(typeof(vif_locking_mode), session.proxy.vif_get_locking_mode(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static string get_MAC(Session session, string _vif)
        {
            return session.proxy.vif_get_mac(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static bool get_MAC_autogenerated(Session session, string _vif)
        {
            return session.proxy.vif_get_mac_autogenerated(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static XenRef<VIF_metrics> get_metrics(Session session, string _vif)
        {
            return XenRef<VIF_metrics>.Create(session.proxy.vif_get_metrics(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static long get_MTU(Session session, string _vif)
        {
            return long.Parse(session.proxy.vif_get_mtu(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static XenRef<Network> get_network(Session session, string _vif)
        {
            return XenRef<Network>.Create(session.proxy.vif_get_network(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _vif)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vif_get_other_config(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static Dictionary<string, string> get_qos_algorithm_params(Session session, string _vif)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vif_get_qos_algorithm_params(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static string get_qos_algorithm_type(Session session, string _vif)
        {
            return session.proxy.vif_get_qos_algorithm_type(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static string[] get_qos_supported_algorithms(Session session, string _vif)
        {
            return session.proxy.vif_get_qos_supported_algorithms(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static VIF get_record(Session session, string _vif)
        {
            return new VIF(session.proxy.vif_get_record(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static Dictionary<string, string> get_runtime_properties(Session session, string _vif)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vif_get_runtime_properties(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static long get_status_code(Session session, string _vif)
        {
            return long.Parse(session.proxy.vif_get_status_code(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static string get_status_detail(Session session, string _vif)
        {
            return session.proxy.vif_get_status_detail(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static string get_uuid(Session session, string _vif)
        {
            return session.proxy.vif_get_uuid(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static XenRef<WinAPI.VM> get_VM(Session session, string _vif)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.vif_get_vm(session.uuid, (_vif != null) ? _vif : "").parse());
        }

        public static void plug(Session session, string _vif)
        {
            session.proxy.vif_plug(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static void remove_from_other_config(Session session, string _vif, string _key)
        {
            session.proxy.vif_remove_from_other_config(session.uuid, (_vif != null) ? _vif : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_qos_algorithm_params(Session session, string _vif, string _key)
        {
            session.proxy.vif_remove_from_qos_algorithm_params(session.uuid, (_vif != null) ? _vif : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_ipv4_allowed(Session session, string _vif, string _value)
        {
            session.proxy.vif_remove_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse();
        }

        public static void remove_ipv6_allowed(Session session, string _vif, string _value)
        {
            session.proxy.vif_remove_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "", (_value != null) ? _value : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, VIF server)
        {
            if (opaqueRef == null)
            {
                Proxy_VIF y_vif = this.ToProxy();
                return session.proxy.vif_create(session.uuid, y_vif).parse();
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<string>(this._qos_algorithm_type, server._qos_algorithm_type))
            {
                set_qos_algorithm_type(session, opaqueRef, this._qos_algorithm_type);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._qos_algorithm_params, server._qos_algorithm_params))
            {
                set_qos_algorithm_params(session, opaqueRef, this._qos_algorithm_params);
            }
            if (!Helper.AreEqual2<vif_locking_mode>(this._locking_mode, server._locking_mode))
            {
                set_locking_mode(session, opaqueRef, this._locking_mode);
            }
            if (!Helper.AreEqual2<string[]>(this._ipv4_allowed, server._ipv4_allowed))
            {
                set_ipv4_allowed(session, opaqueRef, this._ipv4_allowed);
            }
            if (!Helper.AreEqual2<string[]>(this._ipv6_allowed, server._ipv6_allowed))
            {
                set_ipv6_allowed(session, opaqueRef, this._ipv6_allowed);
            }
            return null;
        }

        public static void set_ipv4_allowed(Session session, string _vif, string[] _value)
        {
            session.proxy.vif_set_ipv4_allowed(session.uuid, (_vif != null) ? _vif : "", _value).parse();
        }

        public static void set_ipv6_allowed(Session session, string _vif, string[] _value)
        {
            session.proxy.vif_set_ipv6_allowed(session.uuid, (_vif != null) ? _vif : "", _value).parse();
        }

        public static void set_locking_mode(Session session, string _vif, vif_locking_mode _value)
        {
            session.proxy.vif_set_locking_mode(session.uuid, (_vif != null) ? _vif : "", vif_locking_mode_helper.ToString(_value)).parse();
        }

        public static void set_other_config(Session session, string _vif, Dictionary<string, string> _other_config)
        {
            session.proxy.vif_set_other_config(session.uuid, (_vif != null) ? _vif : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_qos_algorithm_params(Session session, string _vif, Dictionary<string, string> _algorithm_params)
        {
            session.proxy.vif_set_qos_algorithm_params(session.uuid, (_vif != null) ? _vif : "", Maps.convert_to_proxy_string_string(_algorithm_params)).parse();
        }

        public static void set_qos_algorithm_type(Session session, string _vif, string _algorithm_type)
        {
            session.proxy.vif_set_qos_algorithm_type(session.uuid, (_vif != null) ? _vif : "", (_algorithm_type != null) ? _algorithm_type : "").parse();
        }

        public Proxy_VIF ToProxy()
        {
            return new Proxy_VIF { 
                uuid = (this.uuid != null) ? this.uuid : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<vif_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_vif_operations(this.current_operations), device = (this.device != null) ? this.device : "", network = (this.network != null) ? ((string) this.network) : "", VM = (this.VM != null) ? ((string) this.VM) : "", MAC = (this.MAC != null) ? this.MAC : "", MTU = this.MTU.ToString(), other_config = Maps.convert_to_proxy_string_string(this.other_config), currently_attached = this.currently_attached, status_code = this.status_code.ToString(), status_detail = (this.status_detail != null) ? this.status_detail : "", runtime_properties = Maps.convert_to_proxy_string_string(this.runtime_properties), qos_algorithm_type = (this.qos_algorithm_type != null) ? this.qos_algorithm_type : "", qos_algorithm_params = Maps.convert_to_proxy_string_string(this.qos_algorithm_params), qos_supported_algorithms = this.qos_supported_algorithms, 
                metrics = (this.metrics != null) ? ((string) this.metrics) : "", MAC_autogenerated = this.MAC_autogenerated, locking_mode = vif_locking_mode_helper.ToString(this.locking_mode), ipv4_allowed = this.ipv4_allowed, ipv6_allowed = this.ipv6_allowed
             };
        }

        public static void unplug(Session session, string _vif)
        {
            session.proxy.vif_unplug(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public static void unplug_force(Session session, string _vif)
        {
            session.proxy.vif_unplug_force(session.uuid, (_vif != null) ? _vif : "").parse();
        }

        public override void UpdateFrom(VIF update)
        {
            this.uuid = update.uuid;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.device = update.device;
            this.network = update.network;
            this.VM = update.VM;
            this.MAC = update.MAC;
            this.MTU = update.MTU;
            this.other_config = update.other_config;
            this.currently_attached = update.currently_attached;
            this.status_code = update.status_code;
            this.status_detail = update.status_detail;
            this.runtime_properties = update.runtime_properties;
            this.qos_algorithm_type = update.qos_algorithm_type;
            this.qos_algorithm_params = update.qos_algorithm_params;
            this.qos_supported_algorithms = update.qos_supported_algorithms;
            this.metrics = update.metrics;
            this.MAC_autogenerated = update.MAC_autogenerated;
            this.locking_mode = update.locking_mode;
            this.ipv4_allowed = update.ipv4_allowed;
            this.ipv6_allowed = update.ipv6_allowed;
        }

        internal void UpdateFromProxy(Proxy_VIF proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<vif_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_vif_operations(proxy.current_operations);
            this.device = (proxy.device == null) ? null : proxy.device;
            this.network = (proxy.network == null) ? null : XenRef<Network>.Create(proxy.network);
            this.VM = (proxy.VM == null) ? null : XenRef<WinAPI.VM>.Create(proxy.VM);
            this.MAC = (proxy.MAC == null) ? null : proxy.MAC;
            this.MTU = (proxy.MTU == null) ? 0L : long.Parse(proxy.MTU);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.currently_attached = proxy.currently_attached;
            this.status_code = (proxy.status_code == null) ? 0L : long.Parse(proxy.status_code);
            this.status_detail = (proxy.status_detail == null) ? null : proxy.status_detail;
            this.runtime_properties = (proxy.runtime_properties == null) ? null : Maps.convert_from_proxy_string_string(proxy.runtime_properties);
            this.qos_algorithm_type = (proxy.qos_algorithm_type == null) ? null : proxy.qos_algorithm_type;
            this.qos_algorithm_params = (proxy.qos_algorithm_params == null) ? null : Maps.convert_from_proxy_string_string(proxy.qos_algorithm_params);
            this.qos_supported_algorithms = (proxy.qos_supported_algorithms == null) ? new string[0] : proxy.qos_supported_algorithms;
            this.metrics = (proxy.metrics == null) ? null : XenRef<VIF_metrics>.Create(proxy.metrics);
            this.MAC_autogenerated = proxy.MAC_autogenerated;
            this.locking_mode = (proxy.locking_mode == null) ? vif_locking_mode.network_default : ((vif_locking_mode) Helper.EnumParseDefault(typeof(vif_locking_mode), proxy.locking_mode));
            this.ipv4_allowed = (proxy.ipv4_allowed == null) ? new string[0] : proxy.ipv4_allowed;
            this.ipv6_allowed = (proxy.ipv6_allowed == null) ? new string[0] : proxy.ipv6_allowed;
        }

        public virtual List<vif_operations> allowed_operations
        {
            get
            {
                return this._allowed_operations;
            }
            set
            {
                if (!Helper.AreEqual(value, this._allowed_operations))
                {
                    this._allowed_operations = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("allowed_operations");
                }
            }
        }

        public virtual Dictionary<string, vif_operations> current_operations
        {
            get
            {
                return this._current_operations;
            }
            set
            {
                if (!Helper.AreEqual(value, this._current_operations))
                {
                    this._current_operations = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("current_operations");
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

        public virtual string[] ipv4_allowed
        {
            get
            {
                return this._ipv4_allowed;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ipv4_allowed))
                {
                    this._ipv4_allowed = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ipv4_allowed");
                }
            }
        }

        public virtual string[] ipv6_allowed
        {
            get
            {
                return this._ipv6_allowed;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ipv6_allowed))
                {
                    this._ipv6_allowed = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ipv6_allowed");
                }
            }
        }

        public virtual vif_locking_mode locking_mode
        {
            get
            {
                return this._locking_mode;
            }
            set
            {
                if (!Helper.AreEqual(value, this._locking_mode))
                {
                    this._locking_mode = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("locking_mode");
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

        public virtual bool MAC_autogenerated
        {
            get
            {
                return this._MAC_autogenerated;
            }
            set
            {
                if (!Helper.AreEqual(value, this._MAC_autogenerated))
                {
                    this._MAC_autogenerated = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("MAC_autogenerated");
                }
            }
        }

        public virtual XenRef<VIF_metrics> metrics
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

        public virtual Dictionary<string, string> qos_algorithm_params
        {
            get
            {
                return this._qos_algorithm_params;
            }
            set
            {
                if (!Helper.AreEqual(value, this._qos_algorithm_params))
                {
                    this._qos_algorithm_params = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("qos_algorithm_params");
                }
            }
        }

        public virtual string qos_algorithm_type
        {
            get
            {
                return this._qos_algorithm_type;
            }
            set
            {
                if (!Helper.AreEqual(value, this._qos_algorithm_type))
                {
                    this._qos_algorithm_type = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("qos_algorithm_type");
                }
            }
        }

        public virtual string[] qos_supported_algorithms
        {
            get
            {
                return this._qos_supported_algorithms;
            }
            set
            {
                if (!Helper.AreEqual(value, this._qos_supported_algorithms))
                {
                    this._qos_supported_algorithms = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("qos_supported_algorithms");
                }
            }
        }

        public virtual Dictionary<string, string> runtime_properties
        {
            get
            {
                return this._runtime_properties;
            }
            set
            {
                if (!Helper.AreEqual(value, this._runtime_properties))
                {
                    this._runtime_properties = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("runtime_properties");
                }
            }
        }

        public virtual long status_code
        {
            get
            {
                return this._status_code;
            }
            set
            {
                if (!Helper.AreEqual(value, this._status_code))
                {
                    this._status_code = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("status_code");
                }
            }
        }

        public virtual string status_detail
        {
            get
            {
                return this._status_detail;
            }
            set
            {
                if (!Helper.AreEqual(value, this._status_detail))
                {
                    this._status_detail = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("status_detail");
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

        public virtual XenRef<WinAPI.VM> VM
        {
            get
            {
                return this._VM;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VM))
                {
                    this._VM = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VM");
                }
            }
        }
    }
}

