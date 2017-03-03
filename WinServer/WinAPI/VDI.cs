namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VDI : XenObject<VDI>
    {
        private bool _allow_caching;
        private List<vdi_operations> _allowed_operations;
        private List<XenRef<Crashdump>> _crash_dumps;
        private Dictionary<string, vdi_operations> _current_operations;
        private bool _is_a_snapshot;
        private string _location;
        private bool _managed;
        private bool _metadata_latest;
        private XenRef<Pool> _metadata_of_pool;
        private bool _missing;
        private string _name_description;
        private string _name_label;
        private WinAPI.on_boot _on_boot;
        private Dictionary<string, string> _other_config;
        private XenRef<VDI> _parent;
        private long _physical_utilisation;
        private bool _read_only;
        private bool _sharable;
        private Dictionary<string, string> _sm_config;
        private XenRef<VDI> _snapshot_of;
        private DateTime _snapshot_time;
        private List<XenRef<VDI>> _snapshots;
        private XenRef<WinAPI.SR> _SR;
        private bool _storage_lock;
        private string[] _tags;
        private vdi_type _type;
        private string _uuid;
        private List<XenRef<VBD>> _VBDs;
        private long _virtual_size;
        private Dictionary<string, string> _xenstore_data;

        public VDI()
        {
        }

        public VDI(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.allowed_operations = Helper.StringArrayToEnumList<vdi_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_vdi_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.SR = Marshalling.ParseRef<WinAPI.SR>(table, "SR");
            this.VBDs = Marshalling.ParseSetRef<VBD>(table, "VBDs");
            this.crash_dumps = Marshalling.ParseSetRef<Crashdump>(table, "crash_dumps");
            this.virtual_size = Marshalling.ParseLong(table, "virtual_size");
            this.physical_utilisation = Marshalling.ParseLong(table, "physical_utilisation");
            this.type = (vdi_type) Helper.EnumParseDefault(typeof(vdi_type), Marshalling.ParseString(table, "type"));
            this.sharable = Marshalling.ParseBool(table, "sharable");
            this.read_only = Marshalling.ParseBool(table, "read_only");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.storage_lock = Marshalling.ParseBool(table, "storage_lock");
            this.location = Marshalling.ParseString(table, "location");
            this.managed = Marshalling.ParseBool(table, "managed");
            this.missing = Marshalling.ParseBool(table, "missing");
            this.parent = Marshalling.ParseRef<VDI>(table, "parent");
            this.xenstore_data = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "xenstore_data"));
            this.sm_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "sm_config"));
            this.is_a_snapshot = Marshalling.ParseBool(table, "is_a_snapshot");
            this.snapshot_of = Marshalling.ParseRef<VDI>(table, "snapshot_of");
            this.snapshots = Marshalling.ParseSetRef<VDI>(table, "snapshots");
            this.snapshot_time = Marshalling.ParseDateTime(table, "snapshot_time");
            this.tags = Marshalling.ParseStringArray(table, "tags");
            this.allow_caching = Marshalling.ParseBool(table, "allow_caching");
            this.on_boot = (WinAPI.on_boot) Helper.EnumParseDefault(typeof(WinAPI.on_boot), Marshalling.ParseString(table, "on_boot"));
            this.metadata_of_pool = Marshalling.ParseRef<Pool>(table, "metadata_of_pool");
            this.metadata_latest = Marshalling.ParseBool(table, "metadata_latest");
        }

        public VDI(Proxy_VDI proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VDI(string uuid, string name_label, string name_description, List<vdi_operations> allowed_operations, Dictionary<string, vdi_operations> current_operations, XenRef<WinAPI.SR> SR, List<XenRef<VBD>> VBDs, List<XenRef<Crashdump>> crash_dumps, long virtual_size, long physical_utilisation, vdi_type type, bool sharable, bool read_only, Dictionary<string, string> other_config, bool storage_lock, string location, bool managed, bool missing, XenRef<VDI> parent, Dictionary<string, string> xenstore_data, Dictionary<string, string> sm_config, bool is_a_snapshot, XenRef<VDI> snapshot_of, List<XenRef<VDI>> snapshots, DateTime snapshot_time, string[] tags, bool allow_caching, WinAPI.on_boot on_boot, XenRef<Pool> metadata_of_pool, bool metadata_latest)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.SR = SR;
            this.VBDs = VBDs;
            this.crash_dumps = crash_dumps;
            this.virtual_size = virtual_size;
            this.physical_utilisation = physical_utilisation;
            this.type = type;
            this.sharable = sharable;
            this.read_only = read_only;
            this.other_config = other_config;
            this.storage_lock = storage_lock;
            this.location = location;
            this.managed = managed;
            this.missing = missing;
            this.parent = parent;
            this.xenstore_data = xenstore_data;
            this.sm_config = sm_config;
            this.is_a_snapshot = is_a_snapshot;
            this.snapshot_of = snapshot_of;
            this.snapshots = snapshots;
            this.snapshot_time = snapshot_time;
            this.tags = tags;
            this.allow_caching = allow_caching;
            this.on_boot = on_boot;
            this.metadata_of_pool = metadata_of_pool;
            this.metadata_latest = metadata_latest;
        }

        public static void add_tags(Session session, string _vdi, string _value)
        {
            session.proxy.vdi_add_tags(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_other_config(Session session, string _vdi, string _key, string _value)
        {
            session.proxy.vdi_add_to_other_config(session.uuid, (_vdi != null) ? _vdi : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_sm_config(Session session, string _vdi, string _key, string _value)
        {
            session.proxy.vdi_add_to_sm_config(session.uuid, (_vdi != null) ? _vdi : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_xenstore_data(Session session, string _vdi, string _key, string _value)
        {
            session.proxy.vdi_add_to_xenstore_data(session.uuid, (_vdi != null) ? _vdi : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_clone(Session session, string _vdi, Dictionary<string, string> _driver_params)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_clone(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_driver_params)).parse());
        }

        public static XenRef<Task> async_copy(Session session, string _vdi, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_copy(session.uuid, (_vdi != null) ? _vdi : "", (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_copy(Session session, string _vdi, string _sr, string _base_vdi, string _into_vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_copy(session.uuid, (_vdi != null) ? _vdi : "", (_sr != null) ? _sr : "", (_base_vdi != null) ? _base_vdi : "", (_into_vdi != null) ? _into_vdi : "").parse());
        }

        public static XenRef<Task> async_create(Session session, VDI _record)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_db_forget(Session session, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_db_forget(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<Task> async_db_introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_db_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<Task> async_db_introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config, bool _managed, long _virtual_size, long _physical_utilisation, string _metadata_of_pool, bool _is_a_snapshot, DateTime _snapshot_time, string _snapshot_of)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_db_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config), _managed, _virtual_size.ToString(), _physical_utilisation.ToString(), (_metadata_of_pool != null) ? _metadata_of_pool : "", _is_a_snapshot, _snapshot_time, (_snapshot_of != null) ? _snapshot_of : "").parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_destroy(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<Task> async_forget(Session session, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_forget(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<Task> async_introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<Task> async_introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config, bool _managed, long _virtual_size, long _physical_utilisation, string _metadata_of_pool, bool _is_a_snapshot, DateTime _snapshot_time, string _snapshot_of)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config), _managed, _virtual_size.ToString(), _physical_utilisation.ToString(), (_metadata_of_pool != null) ? _metadata_of_pool : "", _is_a_snapshot, _snapshot_time, (_snapshot_of != null) ? _snapshot_of : "").parse());
        }

        public static XenRef<Task> async_open_database(Session session, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_open_database(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<Task> async_pool_migrate(Session session, string _vdi, string _sr, Dictionary<string, string> _options)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_pool_migrate(session.uuid, (_vdi != null) ? _vdi : "", (_sr != null) ? _sr : "", Maps.convert_to_proxy_string_string(_options)).parse());
        }

        public static XenRef<Task> async_read_database_pool_uuid(Session session, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_read_database_pool_uuid(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<Task> async_resize(Session session, string _vdi, long _size)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_resize(session.uuid, (_vdi != null) ? _vdi : "", _size.ToString()).parse());
        }

        public static XenRef<Task> async_resize_online(Session session, string _vdi, long _size)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_resize_online(session.uuid, (_vdi != null) ? _vdi : "", _size.ToString()).parse());
        }

        public static XenRef<Task> async_set_allow_caching(Session session, string _vdi, bool _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_set_allow_caching(session.uuid, (_vdi != null) ? _vdi : "", _value).parse());
        }

        public static XenRef<Task> async_set_name_description(Session session, string _vdi, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_set_name_description(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_set_name_label(Session session, string _vdi, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_set_name_label(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_set_on_boot(Session session, string _vdi, WinAPI.on_boot _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_set_on_boot(session.uuid, (_vdi != null) ? _vdi : "", on_boot_helper.ToString(_value)).parse());
        }

        public static XenRef<Task> async_snapshot(Session session, string _vdi, Dictionary<string, string> _driver_params)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_snapshot(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_driver_params)).parse());
        }

        public static XenRef<Task> async_update(Session session, string _vdi)
        {
            return XenRef<Task>.Create(session.proxy.async_vdi_update(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<VDI> clone(Session session, string _vdi, Dictionary<string, string> _driver_params)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_clone(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_driver_params)).parse());
        }

        public static XenRef<VDI> copy(Session session, string _vdi, string _sr)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_copy(session.uuid, (_vdi != null) ? _vdi : "", (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<VDI> copy(Session session, string _vdi, string _sr, string _base_vdi, string _into_vdi)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_copy(session.uuid, (_vdi != null) ? _vdi : "", (_sr != null) ? _sr : "", (_base_vdi != null) ? _base_vdi : "", (_into_vdi != null) ? _into_vdi : "").parse());
        }

        public static XenRef<VDI> create(Session session, VDI _record)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_create(session.uuid, _record.ToProxy()).parse());
        }

        public static void db_forget(Session session, string _vdi)
        {
            session.proxy.vdi_db_forget(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static XenRef<VDI> db_introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_db_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<VDI> db_introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config, bool _managed, long _virtual_size, long _physical_utilisation, string _metadata_of_pool, bool _is_a_snapshot, DateTime _snapshot_time, string _snapshot_of)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_db_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config), _managed, _virtual_size.ToString(), _physical_utilisation.ToString(), (_metadata_of_pool != null) ? _metadata_of_pool : "", _is_a_snapshot, _snapshot_time, (_snapshot_of != null) ? _snapshot_of : "").parse());
        }

        public bool DeepEquals(VDI other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, vdi_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<List<vdi_operations>>(this._allowed_operations, other._allowed_operations))) && ((Helper.AreEqual2<XenRef<WinAPI.SR>>(this._SR, other._SR) && Helper.AreEqual2<List<XenRef<VBD>>>(this._VBDs, other._VBDs)) && (Helper.AreEqual2<List<XenRef<Crashdump>>>(this._crash_dumps, other._crash_dumps) && Helper.AreEqual2<long>(this._virtual_size, other._virtual_size)))) && (((Helper.AreEqual2<long>(this._physical_utilisation, other._physical_utilisation) && Helper.AreEqual2<vdi_type>(this._type, other._type)) && (Helper.AreEqual2<bool>(this._sharable, other._sharable) && Helper.AreEqual2<bool>(this._read_only, other._read_only))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<bool>(this._storage_lock, other._storage_lock)) && (Helper.AreEqual2<string>(this._location, other._location) && Helper.AreEqual2<bool>(this._managed, other._managed))))) && ((((Helper.AreEqual2<bool>(this._missing, other._missing) && Helper.AreEqual2<XenRef<VDI>>(this._parent, other._parent)) && (Helper.AreEqual2<Dictionary<string, string>>(this._xenstore_data, other._xenstore_data) && Helper.AreEqual2<Dictionary<string, string>>(this._sm_config, other._sm_config))) && ((Helper.AreEqual2<bool>(this._is_a_snapshot, other._is_a_snapshot) && Helper.AreEqual2<XenRef<VDI>>(this._snapshot_of, other._snapshot_of)) && (Helper.AreEqual2<List<XenRef<VDI>>>(this._snapshots, other._snapshots) && Helper.AreEqual2<DateTime>(this._snapshot_time, other._snapshot_time)))) && ((Helper.AreEqual2<string[]>(this._tags, other._tags) && Helper.AreEqual2<bool>(this._allow_caching, other._allow_caching)) && (Helper.AreEqual2<WinAPI.on_boot>(this._on_boot, other._on_boot) && Helper.AreEqual2<XenRef<Pool>>(this._metadata_of_pool, other._metadata_of_pool))))) && Helper.AreEqual2<bool>(this._metadata_latest, other._metadata_latest));
        }

        public static void destroy(Session session, string _vdi)
        {
            session.proxy.vdi_destroy(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static void forget(Session session, string _vdi)
        {
            session.proxy.vdi_forget(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static List<XenRef<VDI>> get_all(Session session)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VDI>, VDI> get_all_records(Session session)
        {
            return XenRef<VDI>.Create<Proxy_VDI>(session.proxy.vdi_get_all_records(session.uuid).parse());
        }

        public static bool get_allow_caching(Session session, string _vdi)
        {
            return session.proxy.vdi_get_allow_caching(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static List<vdi_operations> get_allowed_operations(Session session, string _vdi)
        {
            return Helper.StringArrayToEnumList<vdi_operations>(session.proxy.vdi_get_allowed_operations(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static List<XenRef<VDI>> get_by_name_label(Session session, string _label)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<VDI> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static List<XenRef<Crashdump>> get_crash_dumps(Session session, string _vdi)
        {
            return XenRef<Crashdump>.Create(session.proxy.vdi_get_crash_dumps(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static Dictionary<string, vdi_operations> get_current_operations(Session session, string _vdi)
        {
            return Maps.convert_from_proxy_string_vdi_operations(session.proxy.vdi_get_current_operations(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static bool get_is_a_snapshot(Session session, string _vdi)
        {
            return session.proxy.vdi_get_is_a_snapshot(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static string get_location(Session session, string _vdi)
        {
            return session.proxy.vdi_get_location(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static bool get_managed(Session session, string _vdi)
        {
            return session.proxy.vdi_get_managed(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static bool get_metadata_latest(Session session, string _vdi)
        {
            return session.proxy.vdi_get_metadata_latest(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static XenRef<Pool> get_metadata_of_pool(Session session, string _vdi)
        {
            return XenRef<Pool>.Create(session.proxy.vdi_get_metadata_of_pool(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static bool get_missing(Session session, string _vdi)
        {
            return session.proxy.vdi_get_missing(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static string get_name_description(Session session, string _vdi)
        {
            return session.proxy.vdi_get_name_description(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static string get_name_label(Session session, string _vdi)
        {
            return session.proxy.vdi_get_name_label(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static WinAPI.on_boot get_on_boot(Session session, string _vdi)
        {
            return (WinAPI.on_boot) Helper.EnumParseDefault(typeof(WinAPI.on_boot), session.proxy.vdi_get_on_boot(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _vdi)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vdi_get_other_config(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<VDI> get_parent(Session session, string _vdi)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_get_parent(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static long get_physical_utilisation(Session session, string _vdi)
        {
            return long.Parse(session.proxy.vdi_get_physical_utilisation(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static bool get_read_only(Session session, string _vdi)
        {
            return session.proxy.vdi_get_read_only(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static VDI get_record(Session session, string _vdi)
        {
            return new VDI(session.proxy.vdi_get_record(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static bool get_sharable(Session session, string _vdi)
        {
            return session.proxy.vdi_get_sharable(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static Dictionary<string, string> get_sm_config(Session session, string _vdi)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vdi_get_sm_config(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<VDI> get_snapshot_of(Session session, string _vdi)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_get_snapshot_of(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static DateTime get_snapshot_time(Session session, string _vdi)
        {
            return session.proxy.vdi_get_snapshot_time(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static List<XenRef<VDI>> get_snapshots(Session session, string _vdi)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_get_snapshots(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<WinAPI.SR> get_SR(Session session, string _vdi)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.vdi_get_sr(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static bool get_storage_lock(Session session, string _vdi)
        {
            return session.proxy.vdi_get_storage_lock(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static string[] get_tags(Session session, string _vdi)
        {
            return session.proxy.vdi_get_tags(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static vdi_type get_type(Session session, string _vdi)
        {
            return (vdi_type) Helper.EnumParseDefault(typeof(vdi_type), session.proxy.vdi_get_type(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static string get_uuid(Session session, string _vdi)
        {
            return session.proxy.vdi_get_uuid(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static List<XenRef<VBD>> get_VBDs(Session session, string _vdi)
        {
            return XenRef<VBD>.Create(session.proxy.vdi_get_vbds(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static long get_virtual_size(Session session, string _vdi)
        {
            return long.Parse(session.proxy.vdi_get_virtual_size(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static Dictionary<string, string> get_xenstore_data(Session session, string _vdi)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vdi_get_xenstore_data(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<VDI> introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<VDI> introduce(Session session, string _uuid, string _name_label, string _name_description, string _sr, vdi_type _type, bool _sharable, bool _read_only, Dictionary<string, string> _other_config, string _location, Dictionary<string, string> _xenstore_data, Dictionary<string, string> _sm_config, bool _managed, long _virtual_size, long _physical_utilisation, string _metadata_of_pool, bool _is_a_snapshot, DateTime _snapshot_time, string _snapshot_of)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_sr != null) ? _sr : "", vdi_type_helper.ToString(_type), _sharable, _read_only, Maps.convert_to_proxy_string_string(_other_config), (_location != null) ? _location : "", Maps.convert_to_proxy_string_string(_xenstore_data), Maps.convert_to_proxy_string_string(_sm_config), _managed, _virtual_size.ToString(), _physical_utilisation.ToString(), (_metadata_of_pool != null) ? _metadata_of_pool : "", _is_a_snapshot, _snapshot_time, (_snapshot_of != null) ? _snapshot_of : "").parse());
        }

        public static XenRef<Session> open_database(Session session, string _vdi)
        {
            return XenRef<Session>.Create(session.proxy.vdi_open_database(session.uuid, (_vdi != null) ? _vdi : "").parse());
        }

        public static XenRef<VDI> pool_migrate(Session session, string _vdi, string _sr, Dictionary<string, string> _options)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_pool_migrate(session.uuid, (_vdi != null) ? _vdi : "", (_sr != null) ? _sr : "", Maps.convert_to_proxy_string_string(_options)).parse());
        }

        public static string read_database_pool_uuid(Session session, string _vdi)
        {
            return session.proxy.vdi_read_database_pool_uuid(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public static void remove_from_other_config(Session session, string _vdi, string _key)
        {
            session.proxy.vdi_remove_from_other_config(session.uuid, (_vdi != null) ? _vdi : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_sm_config(Session session, string _vdi, string _key)
        {
            session.proxy.vdi_remove_from_sm_config(session.uuid, (_vdi != null) ? _vdi : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_xenstore_data(Session session, string _vdi, string _key)
        {
            session.proxy.vdi_remove_from_xenstore_data(session.uuid, (_vdi != null) ? _vdi : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_tags(Session session, string _vdi, string _value)
        {
            session.proxy.vdi_remove_tags(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse();
        }

        public static void resize(Session session, string _vdi, long _size)
        {
            session.proxy.vdi_resize(session.uuid, (_vdi != null) ? _vdi : "", _size.ToString()).parse();
        }

        public static void resize_online(Session session, string _vdi, long _size)
        {
            session.proxy.vdi_resize_online(session.uuid, (_vdi != null) ? _vdi : "", _size.ToString()).parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, VDI server)
        {
            if (opaqueRef == null)
            {
                Proxy_VDI y_vdi = this.ToProxy();
                return session.proxy.vdi_create(session.uuid, y_vdi).parse();
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._xenstore_data, server._xenstore_data))
            {
                set_xenstore_data(session, opaqueRef, this._xenstore_data);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._sm_config, server._sm_config))
            {
                set_sm_config(session, opaqueRef, this._sm_config);
            }
            if (!Helper.AreEqual2<string[]>(this._tags, server._tags))
            {
                set_tags(session, opaqueRef, this._tags);
            }
            if (!Helper.AreEqual2<string>(this._name_label, server._name_label))
            {
                set_name_label(session, opaqueRef, this._name_label);
            }
            if (!Helper.AreEqual2<string>(this._name_description, server._name_description))
            {
                set_name_description(session, opaqueRef, this._name_description);
            }
            if (!Helper.AreEqual2<long>(this._virtual_size, server._virtual_size))
            {
                set_virtual_size(session, opaqueRef, this._virtual_size);
            }
            if (!Helper.AreEqual2<bool>(this._sharable, server._sharable))
            {
                set_sharable(session, opaqueRef, this._sharable);
            }
            if (!Helper.AreEqual2<bool>(this._read_only, server._read_only))
            {
                set_read_only(session, opaqueRef, this._read_only);
            }
            return null;
        }

        public static void set_allow_caching(Session session, string _vdi, bool _value)
        {
            session.proxy.vdi_set_allow_caching(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_is_a_snapshot(Session session, string _vdi, bool _value)
        {
            session.proxy.vdi_set_is_a_snapshot(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_managed(Session session, string _vdi, bool _value)
        {
            session.proxy.vdi_set_managed(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_metadata_of_pool(Session session, string _vdi, string _value)
        {
            session.proxy.vdi_set_metadata_of_pool(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse();
        }

        public static void set_missing(Session session, string _vdi, bool _value)
        {
            session.proxy.vdi_set_missing(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_name_description(Session session, string _vdi, string _value)
        {
            session.proxy.vdi_set_name_description(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse();
        }

        public static void set_name_label(Session session, string _vdi, string _value)
        {
            session.proxy.vdi_set_name_label(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse();
        }

        public static void set_on_boot(Session session, string _vdi, WinAPI.on_boot _value)
        {
            session.proxy.vdi_set_on_boot(session.uuid, (_vdi != null) ? _vdi : "", on_boot_helper.ToString(_value)).parse();
        }

        public static void set_other_config(Session session, string _vdi, Dictionary<string, string> _other_config)
        {
            session.proxy.vdi_set_other_config(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_physical_utilisation(Session session, string _vdi, long _value)
        {
            session.proxy.vdi_set_physical_utilisation(session.uuid, (_vdi != null) ? _vdi : "", _value.ToString()).parse();
        }

        public static void set_read_only(Session session, string _vdi, bool _value)
        {
            session.proxy.vdi_set_read_only(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_sharable(Session session, string _vdi, bool _value)
        {
            session.proxy.vdi_set_sharable(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_sm_config(Session session, string _vdi, Dictionary<string, string> _sm_config)
        {
            session.proxy.vdi_set_sm_config(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_sm_config)).parse();
        }

        public static void set_snapshot_of(Session session, string _vdi, string _value)
        {
            session.proxy.vdi_set_snapshot_of(session.uuid, (_vdi != null) ? _vdi : "", (_value != null) ? _value : "").parse();
        }

        public static void set_snapshot_time(Session session, string _vdi, DateTime _value)
        {
            session.proxy.vdi_set_snapshot_time(session.uuid, (_vdi != null) ? _vdi : "", _value).parse();
        }

        public static void set_tags(Session session, string _vdi, string[] _tags)
        {
            session.proxy.vdi_set_tags(session.uuid, (_vdi != null) ? _vdi : "", _tags).parse();
        }

        public static void set_virtual_size(Session session, string _vdi, long _value)
        {
            session.proxy.vdi_set_virtual_size(session.uuid, (_vdi != null) ? _vdi : "", _value.ToString()).parse();
        }

        public static void set_xenstore_data(Session session, string _vdi, Dictionary<string, string> _xenstore_data)
        {
            session.proxy.vdi_set_xenstore_data(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_xenstore_data)).parse();
        }

        public static XenRef<VDI> snapshot(Session session, string _vdi, Dictionary<string, string> _driver_params)
        {
            return XenRef<VDI>.Create(session.proxy.vdi_snapshot(session.uuid, (_vdi != null) ? _vdi : "", Maps.convert_to_proxy_string_string(_driver_params)).parse());
        }

        public Proxy_VDI ToProxy()
        {
            return new Proxy_VDI { 
                uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<vdi_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_vdi_operations(this.current_operations), SR = (this.SR != null) ? ((string) this.SR) : "", VBDs = (this.VBDs != null) ? Helper.RefListToStringArray<VBD>(this.VBDs) : new string[0], crash_dumps = (this.crash_dumps != null) ? Helper.RefListToStringArray<Crashdump>(this.crash_dumps) : new string[0], virtual_size = this.virtual_size.ToString(), physical_utilisation = this.physical_utilisation.ToString(), type = vdi_type_helper.ToString(this.type), sharable = this.sharable, read_only = this.read_only, other_config = Maps.convert_to_proxy_string_string(this.other_config), storage_lock = this.storage_lock, location = (this.location != null) ? this.location : "", 
                managed = this.managed, missing = this.missing, parent = (this.parent != null) ? ((string) this.parent) : "", xenstore_data = Maps.convert_to_proxy_string_string(this.xenstore_data), sm_config = Maps.convert_to_proxy_string_string(this.sm_config), is_a_snapshot = this.is_a_snapshot, snapshot_of = (this.snapshot_of != null) ? ((string) this.snapshot_of) : "", snapshots = (this.snapshots != null) ? Helper.RefListToStringArray<VDI>(this.snapshots) : new string[0], snapshot_time = this.snapshot_time, tags = this.tags, allow_caching = this.allow_caching, on_boot = on_boot_helper.ToString(this.on_boot), metadata_of_pool = (this.metadata_of_pool != null) ? ((string) this.metadata_of_pool) : "", metadata_latest = this.metadata_latest
             };
        }

        public static void update(Session session, string _vdi)
        {
            session.proxy.vdi_update(session.uuid, (_vdi != null) ? _vdi : "").parse();
        }

        public override void UpdateFrom(VDI update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.SR = update.SR;
            this.VBDs = update.VBDs;
            this.crash_dumps = update.crash_dumps;
            this.virtual_size = update.virtual_size;
            this.physical_utilisation = update.physical_utilisation;
            this.type = update.type;
            this.sharable = update.sharable;
            this.read_only = update.read_only;
            this.other_config = update.other_config;
            this.storage_lock = update.storage_lock;
            this.location = update.location;
            this.managed = update.managed;
            this.missing = update.missing;
            this.parent = update.parent;
            this.xenstore_data = update.xenstore_data;
            this.sm_config = update.sm_config;
            this.is_a_snapshot = update.is_a_snapshot;
            this.snapshot_of = update.snapshot_of;
            this.snapshots = update.snapshots;
            this.snapshot_time = update.snapshot_time;
            this.tags = update.tags;
            this.allow_caching = update.allow_caching;
            this.on_boot = update.on_boot;
            this.metadata_of_pool = update.metadata_of_pool;
            this.metadata_latest = update.metadata_latest;
        }

        internal void UpdateFromProxy(Proxy_VDI proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<vdi_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_vdi_operations(proxy.current_operations);
            this.SR = (proxy.SR == null) ? null : XenRef<WinAPI.SR>.Create(proxy.SR);
            this.VBDs = (proxy.VBDs == null) ? null : XenRef<VBD>.Create(proxy.VBDs);
            this.crash_dumps = (proxy.crash_dumps == null) ? null : XenRef<Crashdump>.Create(proxy.crash_dumps);
            this.virtual_size = (proxy.virtual_size == null) ? 0L : long.Parse(proxy.virtual_size);
            this.physical_utilisation = (proxy.physical_utilisation == null) ? 0L : long.Parse(proxy.physical_utilisation);
            this.type = (proxy.type == null) ? vdi_type.system : ((vdi_type) Helper.EnumParseDefault(typeof(vdi_type), proxy.type));
            this.sharable = proxy.sharable;
            this.read_only = proxy.read_only;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.storage_lock = proxy.storage_lock;
            this.location = (proxy.location == null) ? null : proxy.location;
            this.managed = proxy.managed;
            this.missing = proxy.missing;
            this.parent = (proxy.parent == null) ? null : XenRef<VDI>.Create(proxy.parent);
            this.xenstore_data = (proxy.xenstore_data == null) ? null : Maps.convert_from_proxy_string_string(proxy.xenstore_data);
            this.sm_config = (proxy.sm_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.sm_config);
            this.is_a_snapshot = proxy.is_a_snapshot;
            this.snapshot_of = (proxy.snapshot_of == null) ? null : XenRef<VDI>.Create(proxy.snapshot_of);
            this.snapshots = (proxy.snapshots == null) ? null : XenRef<VDI>.Create(proxy.snapshots);
            this.snapshot_time = proxy.snapshot_time;
            this.tags = (proxy.tags == null) ? new string[0] : proxy.tags;
            this.allow_caching = proxy.allow_caching;
            this.on_boot = (proxy.on_boot == null) ? WinAPI.on_boot.reset : ((WinAPI.on_boot) Helper.EnumParseDefault(typeof(WinAPI.on_boot), proxy.on_boot));
            this.metadata_of_pool = (proxy.metadata_of_pool == null) ? null : XenRef<Pool>.Create(proxy.metadata_of_pool);
            this.metadata_latest = proxy.metadata_latest;
        }

        public virtual bool allow_caching
        {
            get
            {
                return this._allow_caching;
            }
            set
            {
                if (!Helper.AreEqual(value, this._allow_caching))
                {
                    this._allow_caching = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("allow_caching");
                }
            }
        }

        public virtual List<vdi_operations> allowed_operations
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

        public virtual List<XenRef<Crashdump>> crash_dumps
        {
            get
            {
                return this._crash_dumps;
            }
            set
            {
                if (!Helper.AreEqual(value, this._crash_dumps))
                {
                    this._crash_dumps = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("crash_dumps");
                }
            }
        }

        public virtual Dictionary<string, vdi_operations> current_operations
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

        public virtual bool is_a_snapshot
        {
            get
            {
                return this._is_a_snapshot;
            }
            set
            {
                if (!Helper.AreEqual(value, this._is_a_snapshot))
                {
                    this._is_a_snapshot = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("is_a_snapshot");
                }
            }
        }

        public virtual string location
        {
            get
            {
                return this._location;
            }
            set
            {
                if (!Helper.AreEqual(value, this._location))
                {
                    this._location = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("location");
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

        public virtual bool metadata_latest
        {
            get
            {
                return this._metadata_latest;
            }
            set
            {
                if (!Helper.AreEqual(value, this._metadata_latest))
                {
                    this._metadata_latest = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("metadata_latest");
                }
            }
        }

        public virtual XenRef<Pool> metadata_of_pool
        {
            get
            {
                return this._metadata_of_pool;
            }
            set
            {
                if (!Helper.AreEqual(value, this._metadata_of_pool))
                {
                    this._metadata_of_pool = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("metadata_of_pool");
                }
            }
        }

        public virtual bool missing
        {
            get
            {
                return this._missing;
            }
            set
            {
                if (!Helper.AreEqual(value, this._missing))
                {
                    this._missing = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("missing");
                }
            }
        }

        public virtual string name_description
        {
            get
            {
                return this._name_description;
            }
            set
            {
                if (!Helper.AreEqual(value, this._name_description))
                {
                    this._name_description = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("name_description");
                }
            }
        }

        public virtual string name_label
        {
            get
            {
                return this._name_label;
            }
            set
            {
                if (!Helper.AreEqual(value, this._name_label))
                {
                    this._name_label = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("name_label");
                }
            }
        }

        public virtual WinAPI.on_boot on_boot
        {
            get
            {
                return this._on_boot;
            }
            set
            {
                if (!Helper.AreEqual(value, this._on_boot))
                {
                    this._on_boot = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("on_boot");
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

        public virtual XenRef<VDI> parent
        {
            get
            {
                return this._parent;
            }
            set
            {
                if (!Helper.AreEqual(value, this._parent))
                {
                    this._parent = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("parent");
                }
            }
        }

        public virtual long physical_utilisation
        {
            get
            {
                return this._physical_utilisation;
            }
            set
            {
                if (!Helper.AreEqual(value, this._physical_utilisation))
                {
                    this._physical_utilisation = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("physical_utilisation");
                }
            }
        }

        public virtual bool read_only
        {
            get
            {
                return this._read_only;
            }
            set
            {
                if (!Helper.AreEqual(value, this._read_only))
                {
                    this._read_only = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("read_only");
                }
            }
        }

        public virtual bool sharable
        {
            get
            {
                return this._sharable;
            }
            set
            {
                if (!Helper.AreEqual(value, this._sharable))
                {
                    this._sharable = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("sharable");
                }
            }
        }

        public virtual Dictionary<string, string> sm_config
        {
            get
            {
                return this._sm_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._sm_config))
                {
                    this._sm_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("sm_config");
                }
            }
        }

        public virtual XenRef<VDI> snapshot_of
        {
            get
            {
                return this._snapshot_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._snapshot_of))
                {
                    this._snapshot_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("snapshot_of");
                }
            }
        }

        public virtual DateTime snapshot_time
        {
            get
            {
                return this._snapshot_time;
            }
            set
            {
                if (!Helper.AreEqual(value, this._snapshot_time))
                {
                    this._snapshot_time = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("snapshot_time");
                }
            }
        }

        public virtual List<XenRef<VDI>> snapshots
        {
            get
            {
                return this._snapshots;
            }
            set
            {
                if (!Helper.AreEqual(value, this._snapshots))
                {
                    this._snapshots = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("snapshots");
                }
            }
        }

        public virtual XenRef<WinAPI.SR> SR
        {
            get
            {
                return this._SR;
            }
            set
            {
                if (!Helper.AreEqual(value, this._SR))
                {
                    this._SR = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("SR");
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

        public virtual string[] tags
        {
            get
            {
                return this._tags;
            }
            set
            {
                if (!Helper.AreEqual(value, this._tags))
                {
                    this._tags = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("tags");
                }
            }
        }

        public virtual vdi_type type
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

        public virtual List<XenRef<VBD>> VBDs
        {
            get
            {
                return this._VBDs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VBDs))
                {
                    this._VBDs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VBDs");
                }
            }
        }

        public virtual long virtual_size
        {
            get
            {
                return this._virtual_size;
            }
            set
            {
                if (!Helper.AreEqual(value, this._virtual_size))
                {
                    this._virtual_size = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("virtual_size");
                }
            }
        }

        public virtual Dictionary<string, string> xenstore_data
        {
            get
            {
                return this._xenstore_data;
            }
            set
            {
                if (!Helper.AreEqual(value, this._xenstore_data))
                {
                    this._xenstore_data = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("xenstore_data");
                }
            }
        }
    }
}

