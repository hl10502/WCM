namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VBD : XenObject<VBD>
    {
        private List<vbd_operations> _allowed_operations;
        private bool _bootable;
        private Dictionary<string, vbd_operations> _current_operations;
        private bool _currently_attached;
        private string _device;
        private bool _empty;
        private XenRef<VBD_metrics> _metrics;
        private vbd_mode _mode;
        private Dictionary<string, string> _other_config;
        private Dictionary<string, string> _qos_algorithm_params;
        private string _qos_algorithm_type;
        private string[] _qos_supported_algorithms;
        private Dictionary<string, string> _runtime_properties;
        private long _status_code;
        private string _status_detail;
        private bool _storage_lock;
        private vbd_type _type;
        private bool _unpluggable;
        private string _userdevice;
        private string _uuid;
        private XenRef<WinAPI.VDI> _VDI;
        private XenRef<WinAPI.VM> _VM;

        public VBD()
        {
        }

        public VBD(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.allowed_operations = Helper.StringArrayToEnumList<vbd_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_vbd_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.VM = Marshalling.ParseRef<WinAPI.VM>(table, "VM");
            this.VDI = Marshalling.ParseRef<WinAPI.VDI>(table, "VDI");
            this.device = Marshalling.ParseString(table, "device");
            this.userdevice = Marshalling.ParseString(table, "userdevice");
            this.bootable = Marshalling.ParseBool(table, "bootable");
            this.mode = (vbd_mode) Helper.EnumParseDefault(typeof(vbd_mode), Marshalling.ParseString(table, "mode"));
            this.type = (vbd_type) Helper.EnumParseDefault(typeof(vbd_type), Marshalling.ParseString(table, "type"));
            this.unpluggable = Marshalling.ParseBool(table, "unpluggable");
            this.storage_lock = Marshalling.ParseBool(table, "storage_lock");
            this.empty = Marshalling.ParseBool(table, "empty");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.currently_attached = Marshalling.ParseBool(table, "currently_attached");
            this.status_code = Marshalling.ParseLong(table, "status_code");
            this.status_detail = Marshalling.ParseString(table, "status_detail");
            this.runtime_properties = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "runtime_properties"));
            this.qos_algorithm_type = Marshalling.ParseString(table, "qos_algorithm_type");
            this.qos_algorithm_params = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "qos_algorithm_params"));
            this.qos_supported_algorithms = Marshalling.ParseStringArray(table, "qos_supported_algorithms");
            this.metrics = Marshalling.ParseRef<VBD_metrics>(table, "metrics");
        }

        public VBD(Proxy_VBD proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VBD(string uuid, List<vbd_operations> allowed_operations, Dictionary<string, vbd_operations> current_operations, XenRef<WinAPI.VM> VM, XenRef<WinAPI.VDI> VDI, string device, string userdevice, bool bootable, vbd_mode mode, vbd_type type, bool unpluggable, bool storage_lock, bool empty, Dictionary<string, string> other_config, bool currently_attached, long status_code, string status_detail, Dictionary<string, string> runtime_properties, string qos_algorithm_type, Dictionary<string, string> qos_algorithm_params, string[] qos_supported_algorithms, XenRef<VBD_metrics> metrics)
        {
            this.uuid = uuid;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.VM = VM;
            this.VDI = VDI;
            this.device = device;
            this.userdevice = userdevice;
            this.bootable = bootable;
            this.mode = mode;
            this.type = type;
            this.unpluggable = unpluggable;
            this.storage_lock = storage_lock;
            this.empty = empty;
            this.other_config = other_config;
            this.currently_attached = currently_attached;
            this.status_code = status_code;
            this.status_detail = status_detail;
            this.runtime_properties = runtime_properties;
            this.qos_algorithm_type = qos_algorithm_type;
            this.qos_algorithm_params = qos_algorithm_params;
            this.qos_supported_algorithms = qos_supported_algorithms;
            this.metrics = metrics;
        }

        public static void add_to_other_config(Session session, string _vbd, string _key, string _value)
        {
            session.proxy.vbd_add_to_other_config(session.uuid, (_vbd != null) ? _vbd : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_qos_algorithm_params(Session session, string _vbd, string _key, string _value)
        {
            session.proxy.vbd_add_to_qos_algorithm_params(session.uuid, (_vbd != null) ? _vbd : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void assert_attachable(Session session, string _vbd)
        {
            session.proxy.vbd_assert_attachable(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static XenRef<Task> async_assert_attachable(Session session, string _vbd)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_assert_attachable(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<Task> async_create(Session session, VBD _record)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _vbd)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_destroy(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<Task> async_eject(Session session, string _vbd)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_eject(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<Task> async_insert(Session session, string _vbd, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_insert(session.uuid, (_vbd != null) ? _vbd : "", (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<Task> async_plug(Session session, string _vbd)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_plug(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<Task> async_unplug(Session session, string _vbd)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_unplug(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<Task> async_unplug_force(Session session, string _vbd)
        {
            return XenRef<Task>.Create(session.proxy.async_vbd_unplug_force(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<VBD> create(Session session, VBD _record)
        {
            return XenRef<VBD>.Create(session.proxy.vbd_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(VBD other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, vbd_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<List<vbd_operations>>(this._allowed_operations, other._allowed_operations)) && (Helper.AreEqual2<XenRef<WinAPI.VM>>(this._VM, other._VM) && Helper.AreEqual2<XenRef<WinAPI.VDI>>(this._VDI, other._VDI))) && ((Helper.AreEqual2<string>(this._device, other._device) && Helper.AreEqual2<string>(this._userdevice, other._userdevice)) && (Helper.AreEqual2<bool>(this._bootable, other._bootable) && Helper.AreEqual2<vbd_mode>(this._mode, other._mode)))) && (((Helper.AreEqual2<vbd_type>(this._type, other._type) && Helper.AreEqual2<bool>(this._unpluggable, other._unpluggable)) && (Helper.AreEqual2<bool>(this._storage_lock, other._storage_lock) && Helper.AreEqual2<bool>(this._empty, other._empty))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<bool>(this._currently_attached, other._currently_attached)) && (Helper.AreEqual2<long>(this._status_code, other._status_code) && Helper.AreEqual2<string>(this._status_detail, other._status_detail))))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._runtime_properties, other._runtime_properties) && Helper.AreEqual2<string>(this._qos_algorithm_type, other._qos_algorithm_type)) && (Helper.AreEqual2<Dictionary<string, string>>(this._qos_algorithm_params, other._qos_algorithm_params) && Helper.AreEqual2<string[]>(this._qos_supported_algorithms, other._qos_supported_algorithms)))) && Helper.AreEqual2<XenRef<VBD_metrics>>(this._metrics, other._metrics));
        }

        public static void destroy(Session session, string _vbd)
        {
            session.proxy.vbd_destroy(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static void eject(Session session, string _vbd)
        {
            session.proxy.vbd_eject(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static List<XenRef<VBD>> get_all(Session session)
        {
            return XenRef<VBD>.Create(session.proxy.vbd_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VBD>, VBD> get_all_records(Session session)
        {
            return XenRef<VBD>.Create<Proxy_VBD>(session.proxy.vbd_get_all_records(session.uuid).parse());
        }

        public static List<vbd_operations> get_allowed_operations(Session session, string _vbd)
        {
            return Helper.StringArrayToEnumList<vbd_operations>(session.proxy.vbd_get_allowed_operations(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static bool get_bootable(Session session, string _vbd)
        {
            return session.proxy.vbd_get_bootable(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static XenRef<VBD> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VBD>.Create(session.proxy.vbd_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, vbd_operations> get_current_operations(Session session, string _vbd)
        {
            return Maps.convert_from_proxy_string_vbd_operations(session.proxy.vbd_get_current_operations(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static bool get_currently_attached(Session session, string _vbd)
        {
            return session.proxy.vbd_get_currently_attached(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static string get_device(Session session, string _vbd)
        {
            return session.proxy.vbd_get_device(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static bool get_empty(Session session, string _vbd)
        {
            return session.proxy.vbd_get_empty(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static XenRef<VBD_metrics> get_metrics(Session session, string _vbd)
        {
            return XenRef<VBD_metrics>.Create(session.proxy.vbd_get_metrics(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static vbd_mode get_mode(Session session, string _vbd)
        {
            return (vbd_mode) Helper.EnumParseDefault(typeof(vbd_mode), session.proxy.vbd_get_mode(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _vbd)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vbd_get_other_config(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static Dictionary<string, string> get_qos_algorithm_params(Session session, string _vbd)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vbd_get_qos_algorithm_params(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static string get_qos_algorithm_type(Session session, string _vbd)
        {
            return session.proxy.vbd_get_qos_algorithm_type(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static string[] get_qos_supported_algorithms(Session session, string _vbd)
        {
            return session.proxy.vbd_get_qos_supported_algorithms(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static VBD get_record(Session session, string _vbd)
        {
            return new VBD(session.proxy.vbd_get_record(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static Dictionary<string, string> get_runtime_properties(Session session, string _vbd)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vbd_get_runtime_properties(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static long get_status_code(Session session, string _vbd)
        {
            return long.Parse(session.proxy.vbd_get_status_code(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static string get_status_detail(Session session, string _vbd)
        {
            return session.proxy.vbd_get_status_detail(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static bool get_storage_lock(Session session, string _vbd)
        {
            return session.proxy.vbd_get_storage_lock(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static vbd_type get_type(Session session, string _vbd)
        {
            return (vbd_type) Helper.EnumParseDefault(typeof(vbd_type), session.proxy.vbd_get_type(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static bool get_unpluggable(Session session, string _vbd)
        {
            return session.proxy.vbd_get_unpluggable(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static string get_userdevice(Session session, string _vbd)
        {
            return session.proxy.vbd_get_userdevice(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static string get_uuid(Session session, string _vbd)
        {
            return session.proxy.vbd_get_uuid(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static XenRef<WinAPI.VDI> get_VDI(Session session, string _vbd)
        {
            return XenRef<WinAPI.VDI>.Create(session.proxy.vbd_get_vdi(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static XenRef<WinAPI.VM> get_VM(Session session, string _vbd)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.vbd_get_vm(session.uuid, (_vbd != null) ? _vbd : "").parse());
        }

        public static void insert(Session session, string _vbd, string _vdi)
        {
            session.proxy.vbd_insert(session.uuid, (_vbd != null) ? _vbd : "", (_vdi != null) ? _vdi : "").parse();
        }

        public static void plug(Session session, string _vbd)
        {
            session.proxy.vbd_plug(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static void remove_from_other_config(Session session, string _vbd, string _key)
        {
            session.proxy.vbd_remove_from_other_config(session.uuid, (_vbd != null) ? _vbd : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_qos_algorithm_params(Session session, string _vbd, string _key)
        {
            session.proxy.vbd_remove_from_qos_algorithm_params(session.uuid, (_vbd != null) ? _vbd : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, VBD server)
        {
            if (opaqueRef == null)
            {
                Proxy_VBD y_vbd = this.ToProxy();
                return session.proxy.vbd_create(session.uuid, y_vbd).parse();
            }
            if (!Helper.AreEqual2<string>(this._userdevice, server._userdevice))
            {
                set_userdevice(session, opaqueRef, this._userdevice);
            }
            if (!Helper.AreEqual2<bool>(this._bootable, server._bootable))
            {
                set_bootable(session, opaqueRef, this._bootable);
            }
            if (!Helper.AreEqual2<vbd_mode>(this._mode, server._mode))
            {
                set_mode(session, opaqueRef, this._mode);
            }
            if (!Helper.AreEqual2<vbd_type>(this._type, server._type))
            {
                set_type(session, opaqueRef, this._type);
            }
            if (!Helper.AreEqual2<bool>(this._unpluggable, server._unpluggable))
            {
                set_unpluggable(session, opaqueRef, this._unpluggable);
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
            return null;
        }

        public static void set_bootable(Session session, string _vbd, bool _bootable)
        {
            session.proxy.vbd_set_bootable(session.uuid, (_vbd != null) ? _vbd : "", _bootable).parse();
        }

        public static void set_mode(Session session, string _vbd, vbd_mode _mode)
        {
            session.proxy.vbd_set_mode(session.uuid, (_vbd != null) ? _vbd : "", vbd_mode_helper.ToString(_mode)).parse();
        }

        public static void set_other_config(Session session, string _vbd, Dictionary<string, string> _other_config)
        {
            session.proxy.vbd_set_other_config(session.uuid, (_vbd != null) ? _vbd : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_qos_algorithm_params(Session session, string _vbd, Dictionary<string, string> _algorithm_params)
        {
            session.proxy.vbd_set_qos_algorithm_params(session.uuid, (_vbd != null) ? _vbd : "", Maps.convert_to_proxy_string_string(_algorithm_params)).parse();
        }

        public static void set_qos_algorithm_type(Session session, string _vbd, string _algorithm_type)
        {
            session.proxy.vbd_set_qos_algorithm_type(session.uuid, (_vbd != null) ? _vbd : "", (_algorithm_type != null) ? _algorithm_type : "").parse();
        }

        public static void set_type(Session session, string _vbd, vbd_type _type)
        {
            session.proxy.vbd_set_type(session.uuid, (_vbd != null) ? _vbd : "", vbd_type_helper.ToString(_type)).parse();
        }

        public static void set_unpluggable(Session session, string _vbd, bool _unpluggable)
        {
            session.proxy.vbd_set_unpluggable(session.uuid, (_vbd != null) ? _vbd : "", _unpluggable).parse();
        }

        public static void set_userdevice(Session session, string _vbd, string _userdevice)
        {
            session.proxy.vbd_set_userdevice(session.uuid, (_vbd != null) ? _vbd : "", (_userdevice != null) ? _userdevice : "").parse();
        }

        public Proxy_VBD ToProxy()
        {
            return new Proxy_VBD { 
                uuid = (this.uuid != null) ? this.uuid : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<vbd_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_vbd_operations(this.current_operations), VM = (this.VM != null) ? ((string) this.VM) : "", VDI = (this.VDI != null) ? ((string) this.VDI) : "", device = (this.device != null) ? this.device : "", userdevice = (this.userdevice != null) ? this.userdevice : "", bootable = this.bootable, mode = vbd_mode_helper.ToString(this.mode), type = vbd_type_helper.ToString(this.type), unpluggable = this.unpluggable, storage_lock = this.storage_lock, empty = this.empty, other_config = Maps.convert_to_proxy_string_string(this.other_config), currently_attached = this.currently_attached, status_code = this.status_code.ToString(), 
                status_detail = (this.status_detail != null) ? this.status_detail : "", runtime_properties = Maps.convert_to_proxy_string_string(this.runtime_properties), qos_algorithm_type = (this.qos_algorithm_type != null) ? this.qos_algorithm_type : "", qos_algorithm_params = Maps.convert_to_proxy_string_string(this.qos_algorithm_params), qos_supported_algorithms = this.qos_supported_algorithms, metrics = (this.metrics != null) ? ((string) this.metrics) : ""
             };
        }

        public static void unplug(Session session, string _vbd)
        {
            session.proxy.vbd_unplug(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public static void unplug_force(Session session, string _vbd)
        {
            session.proxy.vbd_unplug_force(session.uuid, (_vbd != null) ? _vbd : "").parse();
        }

        public override void UpdateFrom(VBD update)
        {
            this.uuid = update.uuid;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.VM = update.VM;
            this.VDI = update.VDI;
            this.device = update.device;
            this.userdevice = update.userdevice;
            this.bootable = update.bootable;
            this.mode = update.mode;
            this.type = update.type;
            this.unpluggable = update.unpluggable;
            this.storage_lock = update.storage_lock;
            this.empty = update.empty;
            this.other_config = update.other_config;
            this.currently_attached = update.currently_attached;
            this.status_code = update.status_code;
            this.status_detail = update.status_detail;
            this.runtime_properties = update.runtime_properties;
            this.qos_algorithm_type = update.qos_algorithm_type;
            this.qos_algorithm_params = update.qos_algorithm_params;
            this.qos_supported_algorithms = update.qos_supported_algorithms;
            this.metrics = update.metrics;
        }

        internal void UpdateFromProxy(Proxy_VBD proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<vbd_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_vbd_operations(proxy.current_operations);
            this.VM = (proxy.VM == null) ? null : XenRef<WinAPI.VM>.Create(proxy.VM);
            this.VDI = (proxy.VDI == null) ? null : XenRef<WinAPI.VDI>.Create(proxy.VDI);
            this.device = (proxy.device == null) ? null : proxy.device;
            this.userdevice = (proxy.userdevice == null) ? null : proxy.userdevice;
            this.bootable = proxy.bootable;
            this.mode = (proxy.mode == null) ? vbd_mode.RO : ((vbd_mode) Helper.EnumParseDefault(typeof(vbd_mode), proxy.mode));
            this.type = (proxy.type == null) ? vbd_type.CD : ((vbd_type) Helper.EnumParseDefault(typeof(vbd_type), proxy.type));
            this.unpluggable = proxy.unpluggable;
            this.storage_lock = proxy.storage_lock;
            this.empty = proxy.empty;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.currently_attached = proxy.currently_attached;
            this.status_code = (proxy.status_code == null) ? 0L : long.Parse(proxy.status_code);
            this.status_detail = (proxy.status_detail == null) ? null : proxy.status_detail;
            this.runtime_properties = (proxy.runtime_properties == null) ? null : Maps.convert_from_proxy_string_string(proxy.runtime_properties);
            this.qos_algorithm_type = (proxy.qos_algorithm_type == null) ? null : proxy.qos_algorithm_type;
            this.qos_algorithm_params = (proxy.qos_algorithm_params == null) ? null : Maps.convert_from_proxy_string_string(proxy.qos_algorithm_params);
            this.qos_supported_algorithms = (proxy.qos_supported_algorithms == null) ? new string[0] : proxy.qos_supported_algorithms;
            this.metrics = (proxy.metrics == null) ? null : XenRef<VBD_metrics>.Create(proxy.metrics);
        }

        public virtual List<vbd_operations> allowed_operations
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

        public virtual bool bootable
        {
            get
            {
                return this._bootable;
            }
            set
            {
                if (!Helper.AreEqual(value, this._bootable))
                {
                    this._bootable = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("bootable");
                }
            }
        }

        public virtual Dictionary<string, vbd_operations> current_operations
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

        public virtual bool empty
        {
            get
            {
                return this._empty;
            }
            set
            {
                if (!Helper.AreEqual(value, this._empty))
                {
                    this._empty = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("empty");
                }
            }
        }

        public virtual XenRef<VBD_metrics> metrics
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

        public virtual vbd_mode mode
        {
            get
            {
                return this._mode;
            }
            set
            {
                if (!Helper.AreEqual(value, this._mode))
                {
                    this._mode = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("mode");
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

        public virtual bool storage_lock
        {
            get
            {
                return this._storage_lock;
            }
            set
            {
                if (!Helper.AreEqual(value, this._storage_lock))
                {
                    this._storage_lock = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("storage_lock");
                }
            }
        }

        public virtual vbd_type type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (!Helper.AreEqual(value, this._type))
                {
                    this._type = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("type");
                }
            }
        }

        public virtual bool unpluggable
        {
            get
            {
                return this._unpluggable;
            }
            set
            {
                if (!Helper.AreEqual(value, this._unpluggable))
                {
                    this._unpluggable = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("unpluggable");
                }
            }
        }

        public virtual string userdevice
        {
            get
            {
                return this._userdevice;
            }
            set
            {
                if (!Helper.AreEqual(value, this._userdevice))
                {
                    this._userdevice = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("userdevice");
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

        public virtual XenRef<WinAPI.VDI> VDI
        {
            get
            {
                return this._VDI;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VDI))
                {
                    this._VDI = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VDI");
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

