namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SR : XenObject<WinAPI.SR>
    {
        private List<storage_operations> _allowed_operations;
        private Dictionary<string, XenRef<Blob>> _blobs;
        private bool _clustered;
        private string _content_type;
        private Dictionary<string, storage_operations> _current_operations;
        private XenRef<DR_task> _introduced_by;
        private bool _local_cache_enabled;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private List<XenRef<PBD>> _PBDs;
        private long _physical_size;
        private long _physical_utilisation;
        private bool _shared;
        private Dictionary<string, string> _sm_config;
        private string[] _tags;
        private string _type;
        private string _uuid;
        private List<XenRef<VDI>> _VDIs;
        private long _virtual_allocation;

        public SR()
        {
        }

        public SR(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.allowed_operations = Helper.StringArrayToEnumList<storage_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_storage_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.VDIs = Marshalling.ParseSetRef<VDI>(table, "VDIs");
            this.PBDs = Marshalling.ParseSetRef<PBD>(table, "PBDs");
            this.virtual_allocation = Marshalling.ParseLong(table, "virtual_allocation");
            this.physical_utilisation = Marshalling.ParseLong(table, "physical_utilisation");
            this.physical_size = Marshalling.ParseLong(table, "physical_size");
            this.type = Marshalling.ParseString(table, "type");
            this.content_type = Marshalling.ParseString(table, "content_type");
            this.shared = Marshalling.ParseBool(table, "shared");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.tags = Marshalling.ParseStringArray(table, "tags");
            this.sm_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "sm_config"));
            this.blobs = Maps.convert_from_proxy_string_XenRefBlob(Marshalling.ParseHashTable(table, "blobs"));
            this.local_cache_enabled = Marshalling.ParseBool(table, "local_cache_enabled");
            this.introduced_by = Marshalling.ParseRef<DR_task>(table, "introduced_by");
            this.clustered = Marshalling.ParseBool(table, "clustered");
        }

        public SR(Proxy_SR proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public SR(string uuid, string name_label, string name_description, List<storage_operations> allowed_operations, Dictionary<string, storage_operations> current_operations, List<XenRef<VDI>> VDIs, List<XenRef<PBD>> PBDs, long virtual_allocation, long physical_utilisation, long physical_size, string type, string content_type, bool shared, Dictionary<string, string> other_config, string[] tags, Dictionary<string, string> sm_config, Dictionary<string, XenRef<Blob>> blobs, bool local_cache_enabled, XenRef<DR_task> introduced_by, bool clustered)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.VDIs = VDIs;
            this.PBDs = PBDs;
            this.virtual_allocation = virtual_allocation;
            this.physical_utilisation = physical_utilisation;
            this.physical_size = physical_size;
            this.type = type;
            this.content_type = content_type;
            this.shared = shared;
            this.other_config = other_config;
            this.tags = tags;
            this.sm_config = sm_config;
            this.blobs = blobs;
            this.local_cache_enabled = local_cache_enabled;
            this.introduced_by = introduced_by;
            this.clustered = clustered;
        }

        public static void add_tags(Session session, string _sr, string _value)
        {
            session.proxy.sr_add_tags(session.uuid, (_sr != null) ? _sr : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_other_config(Session session, string _sr, string _key, string _value)
        {
            session.proxy.sr_add_to_other_config(session.uuid, (_sr != null) ? _sr : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_sm_config(Session session, string _sr, string _key, string _value)
        {
            session.proxy.sr_add_to_sm_config(session.uuid, (_sr != null) ? _sr : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void assert_can_host_ha_statefile(Session session, string _sr)
        {
            session.proxy.sr_assert_can_host_ha_statefile(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void assert_supports_database_replication(Session session, string _sr)
        {
            session.proxy.sr_assert_supports_database_replication(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static XenRef<Task> async_assert_can_host_ha_statefile(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_assert_can_host_ha_statefile(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_assert_supports_database_replication(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_assert_supports_database_replication(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_create(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type, bool _shared)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_create(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared).parse());
        }

        public static XenRef<Task> async_create(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type, bool _shared, Dictionary<string, string> _sm_config)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_create(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared, Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<Task> async_create_new_blob(Session session, string _sr, string _name, string _mime_type)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_create_new_blob(session.uuid, (_sr != null) ? _sr : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        public static XenRef<Task> async_create_new_blob(Session session, string _sr, string _name, string _mime_type, bool _public)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_create_new_blob(session.uuid, (_sr != null) ? _sr : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_destroy(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_disable_database_replication(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_disable_database_replication(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_enable_database_replication(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_enable_database_replication(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_forget(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_forget(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_introduce(Session session, string _uuid, string _name_label, string _name_description, string _type, string _content_type, bool _shared)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared).parse());
        }

        public static XenRef<Task> async_introduce(Session session, string _uuid, string _name_label, string _name_description, string _type, string _content_type, bool _shared, Dictionary<string, string> _sm_config)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared, Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<Task> async_make(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_make(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "").parse());
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<Task> async_make(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type, Dictionary<string, string> _sm_config)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_make(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<Task> async_probe(Session session, string _host, Dictionary<string, string> _device_config, string _type, Dictionary<string, string> _sm_config)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_probe(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), (_type != null) ? _type : "", Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<Task> async_scan(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_scan(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_set_name_description(Session session, string _sr, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_set_name_description(session.uuid, (_sr != null) ? _sr : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_set_name_label(Session session, string _sr, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_set_name_label(session.uuid, (_sr != null) ? _sr : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_set_shared(Session session, string _sr, bool _value)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_set_shared(session.uuid, (_sr != null) ? _sr : "", _value).parse());
        }

        public static XenRef<Task> async_update(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_sr_update(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<WinAPI.SR> create(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type, bool _shared)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_create(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared).parse());
        }

        public static XenRef<WinAPI.SR> create(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type, bool _shared, Dictionary<string, string> _sm_config)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_create(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared, Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        public static XenRef<Blob> create_new_blob(Session session, string _sr, string _name, string _mime_type)
        {
            return XenRef<Blob>.Create(session.proxy.sr_create_new_blob(session.uuid, (_sr != null) ? _sr : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        public static XenRef<Blob> create_new_blob(Session session, string _sr, string _name, string _mime_type, bool _public)
        {
            return XenRef<Blob>.Create(session.proxy.sr_create_new_blob(session.uuid, (_sr != null) ? _sr : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public bool DeepEquals(WinAPI.SR other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, storage_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<List<storage_operations>>(this._allowed_operations, other._allowed_operations))) && ((Helper.AreEqual2<List<XenRef<VDI>>>(this._VDIs, other._VDIs) && Helper.AreEqual2<List<XenRef<PBD>>>(this._PBDs, other._PBDs)) && (Helper.AreEqual2<long>(this._virtual_allocation, other._virtual_allocation) && Helper.AreEqual2<long>(this._physical_utilisation, other._physical_utilisation)))) && (((Helper.AreEqual2<long>(this._physical_size, other._physical_size) && Helper.AreEqual2<string>(this._type, other._type)) && (Helper.AreEqual2<string>(this._content_type, other._content_type) && Helper.AreEqual2<bool>(this._shared, other._shared))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<string[]>(this._tags, other._tags)) && (Helper.AreEqual2<Dictionary<string, string>>(this._sm_config, other._sm_config) && Helper.AreEqual2<Dictionary<string, XenRef<Blob>>>(this._blobs, other._blobs))))) && (Helper.AreEqual2<bool>(this._local_cache_enabled, other._local_cache_enabled) && Helper.AreEqual2<XenRef<DR_task>>(this._introduced_by, other._introduced_by))) && Helper.AreEqual2<bool>(this._clustered, other._clustered));
        }

        public static void destroy(Session session, string _sr)
        {
            session.proxy.sr_destroy(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void disable_database_replication(Session session, string _sr)
        {
            session.proxy.sr_disable_database_replication(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void enable_database_replication(Session session, string _sr)
        {
            session.proxy.sr_enable_database_replication(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void forget(Session session, string _sr)
        {
            session.proxy.sr_forget(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void forget_data_source_archives(Session session, string _sr, string _data_source)
        {
            session.proxy.sr_forget_data_source_archives(session.uuid, (_sr != null) ? _sr : "", (_data_source != null) ? _data_source : "").parse();
        }

        public static List<XenRef<WinAPI.SR>> get_all(Session session)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<WinAPI.SR>, WinAPI.SR> get_all_records(Session session)
        {
            return XenRef<WinAPI.SR>.Create<Proxy_SR>(session.proxy.sr_get_all_records(session.uuid).parse());
        }

        public static List<storage_operations> get_allowed_operations(Session session, string _sr)
        {
            return Helper.StringArrayToEnumList<storage_operations>(session.proxy.sr_get_allowed_operations(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static Dictionary<string, XenRef<Blob>> get_blobs(Session session, string _sr)
        {
            return Maps.convert_from_proxy_string_XenRefBlob(session.proxy.sr_get_blobs(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static List<XenRef<WinAPI.SR>> get_by_name_label(Session session, string _label)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<WinAPI.SR> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static bool get_clustered(Session session, string _sr)
        {
            return session.proxy.sr_get_clustered(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static string get_content_type(Session session, string _sr)
        {
            return session.proxy.sr_get_content_type(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static Dictionary<string, storage_operations> get_current_operations(Session session, string _sr)
        {
            return Maps.convert_from_proxy_string_storage_operations(session.proxy.sr_get_current_operations(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static List<Data_source> get_data_sources(Session session, string _sr)
        {
            return Helper.Proxy_Data_sourceArrayToData_sourceList(session.proxy.sr_get_data_sources(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<DR_task> get_introduced_by(Session session, string _sr)
        {
            return XenRef<DR_task>.Create(session.proxy.sr_get_introduced_by(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static bool get_local_cache_enabled(Session session, string _sr)
        {
            return session.proxy.sr_get_local_cache_enabled(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static string get_name_description(Session session, string _sr)
        {
            return session.proxy.sr_get_name_description(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static string get_name_label(Session session, string _sr)
        {
            return session.proxy.sr_get_name_label(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _sr)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.sr_get_other_config(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static List<XenRef<PBD>> get_PBDs(Session session, string _sr)
        {
            return XenRef<PBD>.Create(session.proxy.sr_get_pbds(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static long get_physical_size(Session session, string _sr)
        {
            return long.Parse(session.proxy.sr_get_physical_size(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static long get_physical_utilisation(Session session, string _sr)
        {
            return long.Parse(session.proxy.sr_get_physical_utilisation(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static WinAPI.SR get_record(Session session, string _sr)
        {
            return new WinAPI.SR(session.proxy.sr_get_record(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static bool get_shared(Session session, string _sr)
        {
            return session.proxy.sr_get_shared(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static Dictionary<string, string> get_sm_config(Session session, string _sr)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.sr_get_sm_config(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static string[] get_supported_types(Session session)
        {
            return session.proxy.sr_get_supported_types(session.uuid).parse();
        }

        public static string[] get_tags(Session session, string _sr)
        {
            return session.proxy.sr_get_tags(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static string get_type(Session session, string _sr)
        {
            return session.proxy.sr_get_type(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static string get_uuid(Session session, string _sr)
        {
            return session.proxy.sr_get_uuid(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static List<XenRef<VDI>> get_VDIs(Session session, string _sr)
        {
            return XenRef<VDI>.Create(session.proxy.sr_get_vdis(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static long get_virtual_allocation(Session session, string _sr)
        {
            return long.Parse(session.proxy.sr_get_virtual_allocation(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<WinAPI.SR> introduce(Session session, string _uuid, string _name_label, string _name_description, string _type, string _content_type, bool _shared)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared).parse());
        }

        public static XenRef<WinAPI.SR> introduce(Session session, string _uuid, string _name_label, string _name_description, string _type, string _content_type, bool _shared, Dictionary<string, string> _sm_config)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.sr_introduce(session.uuid, (_uuid != null) ? _uuid : "", (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", _shared, Maps.convert_to_proxy_string_string(_sm_config)).parse());
        }

        [Deprecated("XenServer 4.1")]
        public static string make(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type)
        {
            return session.proxy.sr_make(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "").parse();
        }

        [Deprecated("XenServer 4.1")]
        public static string make(Session session, string _host, Dictionary<string, string> _device_config, long _physical_size, string _name_label, string _name_description, string _type, string _content_type, Dictionary<string, string> _sm_config)
        {
            return session.proxy.sr_make(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), _physical_size.ToString(), (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", (_type != null) ? _type : "", (_content_type != null) ? _content_type : "", Maps.convert_to_proxy_string_string(_sm_config)).parse();
        }

        public static string probe(Session session, string _host, Dictionary<string, string> _device_config, string _type, Dictionary<string, string> _sm_config)
        {
            return session.proxy.sr_probe(session.uuid, (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_device_config), (_type != null) ? _type : "", Maps.convert_to_proxy_string_string(_sm_config)).parse();
        }

        public static double query_data_source(Session session, string _sr, string _data_source)
        {
            return Convert.ToDouble(session.proxy.sr_query_data_source(session.uuid, (_sr != null) ? _sr : "", (_data_source != null) ? _data_source : "").parse());
        }

        public static void record_data_source(Session session, string _sr, string _data_source)
        {
            session.proxy.sr_record_data_source(session.uuid, (_sr != null) ? _sr : "", (_data_source != null) ? _data_source : "").parse();
        }

        public static void remove_from_other_config(Session session, string _sr, string _key)
        {
            session.proxy.sr_remove_from_other_config(session.uuid, (_sr != null) ? _sr : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_sm_config(Session session, string _sr, string _key)
        {
            session.proxy.sr_remove_from_sm_config(session.uuid, (_sr != null) ? _sr : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_tags(Session session, string _sr, string _value)
        {
            session.proxy.sr_remove_tags(session.uuid, (_sr != null) ? _sr : "", (_value != null) ? _value : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, WinAPI.SR server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<string[]>(this._tags, server._tags))
            {
                set_tags(session, opaqueRef, this._tags);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._sm_config, server._sm_config))
            {
                set_sm_config(session, opaqueRef, this._sm_config);
            }
            if (!Helper.AreEqual2<string>(this._name_label, server._name_label))
            {
                set_name_label(session, opaqueRef, this._name_label);
            }
            if (!Helper.AreEqual2<string>(this._name_description, server._name_description))
            {
                set_name_description(session, opaqueRef, this._name_description);
            }
            if (!Helper.AreEqual2<long>(this._physical_size, server._physical_size))
            {
                set_physical_size(session, opaqueRef, this._physical_size);
            }
            return null;
        }

        public static void scan(Session session, string _sr)
        {
            session.proxy.sr_scan(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void set_name_description(Session session, string _sr, string _value)
        {
            session.proxy.sr_set_name_description(session.uuid, (_sr != null) ? _sr : "", (_value != null) ? _value : "").parse();
        }

        public static void set_name_label(Session session, string _sr, string _value)
        {
            session.proxy.sr_set_name_label(session.uuid, (_sr != null) ? _sr : "", (_value != null) ? _value : "").parse();
        }

        public static void set_other_config(Session session, string _sr, Dictionary<string, string> _other_config)
        {
            session.proxy.sr_set_other_config(session.uuid, (_sr != null) ? _sr : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_physical_size(Session session, string _sr, long _value)
        {
            session.proxy.sr_set_physical_size(session.uuid, (_sr != null) ? _sr : "", _value.ToString()).parse();
        }

        public static void set_physical_utilisation(Session session, string _sr, long _value)
        {
            session.proxy.sr_set_physical_utilisation(session.uuid, (_sr != null) ? _sr : "", _value.ToString()).parse();
        }

        public static void set_shared(Session session, string _sr, bool _value)
        {
            session.proxy.sr_set_shared(session.uuid, (_sr != null) ? _sr : "", _value).parse();
        }

        public static void set_sm_config(Session session, string _sr, Dictionary<string, string> _sm_config)
        {
            session.proxy.sr_set_sm_config(session.uuid, (_sr != null) ? _sr : "", Maps.convert_to_proxy_string_string(_sm_config)).parse();
        }

        public static void set_tags(Session session, string _sr, string[] _tags)
        {
            session.proxy.sr_set_tags(session.uuid, (_sr != null) ? _sr : "", _tags).parse();
        }

        public static void set_virtual_allocation(Session session, string _sr, long _value)
        {
            session.proxy.sr_set_virtual_allocation(session.uuid, (_sr != null) ? _sr : "", _value.ToString()).parse();
        }

        public Proxy_SR ToProxy()
        {
            return new Proxy_SR { 
                uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<storage_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_storage_operations(this.current_operations), VDIs = (this.VDIs != null) ? Helper.RefListToStringArray<VDI>(this.VDIs) : new string[0], PBDs = (this.PBDs != null) ? Helper.RefListToStringArray<PBD>(this.PBDs) : new string[0], virtual_allocation = this.virtual_allocation.ToString(), physical_utilisation = this.physical_utilisation.ToString(), physical_size = this.physical_size.ToString(), type = (this.type != null) ? this.type : "", content_type = (this.content_type != null) ? this.content_type : "", shared = this.shared, other_config = Maps.convert_to_proxy_string_string(this.other_config), tags = this.tags, sm_config = Maps.convert_to_proxy_string_string(this.sm_config), 
                blobs = Maps.convert_to_proxy_string_XenRefBlob(this.blobs), local_cache_enabled = this.local_cache_enabled, introduced_by = (this.introduced_by != null) ? ((string) this.introduced_by) : "", clustered = this.clustered
             };
        }

        public static void update(Session session, string _sr)
        {
            session.proxy.sr_update(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public override void UpdateFrom(WinAPI.SR update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.VDIs = update.VDIs;
            this.PBDs = update.PBDs;
            this.virtual_allocation = update.virtual_allocation;
            this.physical_utilisation = update.physical_utilisation;
            this.physical_size = update.physical_size;
            this.type = update.type;
            this.content_type = update.content_type;
            this.shared = update.shared;
            this.other_config = update.other_config;
            this.tags = update.tags;
            this.sm_config = update.sm_config;
            this.blobs = update.blobs;
            this.local_cache_enabled = update.local_cache_enabled;
            this.introduced_by = update.introduced_by;
            this.clustered = update.clustered;
        }

        internal void UpdateFromProxy(Proxy_SR proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<storage_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_storage_operations(proxy.current_operations);
            this.VDIs = (proxy.VDIs == null) ? null : XenRef<VDI>.Create(proxy.VDIs);
            this.PBDs = (proxy.PBDs == null) ? null : XenRef<PBD>.Create(proxy.PBDs);
            this.virtual_allocation = (proxy.virtual_allocation == null) ? 0L : long.Parse(proxy.virtual_allocation);
            this.physical_utilisation = (proxy.physical_utilisation == null) ? 0L : long.Parse(proxy.physical_utilisation);
            this.physical_size = (proxy.physical_size == null) ? 0L : long.Parse(proxy.physical_size);
            this.type = (proxy.type == null) ? null : proxy.type;
            this.content_type = (proxy.content_type == null) ? null : proxy.content_type;
            this.shared = proxy.shared;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.tags = (proxy.tags == null) ? new string[0] : proxy.tags;
            this.sm_config = (proxy.sm_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.sm_config);
            this.blobs = (proxy.blobs == null) ? null : Maps.convert_from_proxy_string_XenRefBlob(proxy.blobs);
            this.local_cache_enabled = proxy.local_cache_enabled;
            this.introduced_by = (proxy.introduced_by == null) ? null : XenRef<DR_task>.Create(proxy.introduced_by);
            this.clustered = proxy.clustered;
        }

        public virtual List<storage_operations> allowed_operations
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

        public virtual Dictionary<string, XenRef<Blob>> blobs
        {
            get
            {
                return this._blobs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._blobs))
                {
                    this._blobs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("blobs");
                }
            }
        }

        public virtual bool clustered
        {
            get
            {
                return this._clustered;
            }
            set
            {
                if (!Helper.AreEqual(value, this._clustered))
                {
                    this._clustered = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("clustered");
                }
            }
        }

        public virtual string content_type
        {
            get
            {
                return this._content_type;
            }
            set
            {
                if (!Helper.AreEqual(value, this._content_type))
                {
                    this._content_type = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("content_type");
                }
            }
        }

        public virtual Dictionary<string, storage_operations> current_operations
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

        public virtual XenRef<DR_task> introduced_by
        {
            get
            {
                return this._introduced_by;
            }
            set
            {
                if (!Helper.AreEqual(value, this._introduced_by))
                {
                    this._introduced_by = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("introduced_by");
                }
            }
        }

        public virtual bool local_cache_enabled
        {
            get
            {
                return this._local_cache_enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._local_cache_enabled))
                {
                    this._local_cache_enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("local_cache_enabled");
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

        public virtual List<XenRef<PBD>> PBDs
        {
            get
            {
                return this._PBDs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._PBDs))
                {
                    this._PBDs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("PBDs");
                }
            }
        }

        public virtual long physical_size
        {
            get
            {
                return this._physical_size;
            }
            set
            {
                if (!Helper.AreEqual(value, this._physical_size))
                {
                    this._physical_size = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("physical_size");
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

        public virtual bool shared
        {
            get
            {
                return this._shared;
            }
            set
            {
                if (!Helper.AreEqual(value, this._shared))
                {
                    this._shared = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("shared");
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

        public virtual string type
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

        public virtual List<XenRef<VDI>> VDIs
        {
            get
            {
                return this._VDIs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VDIs))
                {
                    this._VDIs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VDIs");
                }
            }
        }

        public virtual long virtual_allocation
        {
            get
            {
                return this._virtual_allocation;
            }
            set
            {
                if (!Helper.AreEqual(value, this._virtual_allocation))
                {
                    this._virtual_allocation = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("virtual_allocation");
                }
            }
        }
    }
}

