namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Network : XenObject<Network>
    {
        private List<network_operations> _allowed_operations;
        private Dictionary<XenRef<VIF>, string> _assigned_ips;
        private Dictionary<string, XenRef<Blob>> _blobs;
        private string _bridge;
        private Dictionary<string, network_operations> _current_operations;
        private network_default_locking_mode _default_locking_mode;
        private long _MTU;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private List<XenRef<PIF>> _PIFs;
        private string[] _tags;
        private string _uuid;
        private List<XenRef<VIF>> _VIFs;

        public Network()
        {
        }

        public Network(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.allowed_operations = Helper.StringArrayToEnumList<network_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_network_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.VIFs = Marshalling.ParseSetRef<VIF>(table, "VIFs");
            this.PIFs = Marshalling.ParseSetRef<PIF>(table, "PIFs");
            this.MTU = Marshalling.ParseLong(table, "MTU");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.bridge = Marshalling.ParseString(table, "bridge");
            this.blobs = Maps.convert_from_proxy_string_XenRefBlob(Marshalling.ParseHashTable(table, "blobs"));
            this.tags = Marshalling.ParseStringArray(table, "tags");
            this.default_locking_mode = (network_default_locking_mode) Helper.EnumParseDefault(typeof(network_default_locking_mode), Marshalling.ParseString(table, "default_locking_mode"));
            this.assigned_ips = Maps.convert_from_proxy_XenRefVIF_string(Marshalling.ParseHashTable(table, "assigned_ips"));
        }

        public Network(Proxy_Network proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Network(string uuid, string name_label, string name_description, List<network_operations> allowed_operations, Dictionary<string, network_operations> current_operations, List<XenRef<VIF>> VIFs, List<XenRef<PIF>> PIFs, long MTU, Dictionary<string, string> other_config, string bridge, Dictionary<string, XenRef<Blob>> blobs, string[] tags, network_default_locking_mode default_locking_mode, Dictionary<XenRef<VIF>, string> assigned_ips)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.VIFs = VIFs;
            this.PIFs = PIFs;
            this.MTU = MTU;
            this.other_config = other_config;
            this.bridge = bridge;
            this.blobs = blobs;
            this.tags = tags;
            this.default_locking_mode = default_locking_mode;
            this.assigned_ips = assigned_ips;
        }

        public static void add_tags(Session session, string _network, string _value)
        {
            session.proxy.network_add_tags(session.uuid, (_network != null) ? _network : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_other_config(Session session, string _network, string _key, string _value)
        {
            session.proxy.network_add_to_other_config(session.uuid, (_network != null) ? _network : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, Network _record)
        {
            return XenRef<Task>.Create(session.proxy.async_network_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_create_new_blob(Session session, string _network, string _name, string _mime_type)
        {
            return XenRef<Task>.Create(session.proxy.async_network_create_new_blob(session.uuid, (_network != null) ? _network : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        public static XenRef<Task> async_create_new_blob(Session session, string _network, string _name, string _mime_type, bool _public)
        {
            return XenRef<Task>.Create(session.proxy.async_network_create_new_blob(session.uuid, (_network != null) ? _network : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _network)
        {
            return XenRef<Task>.Create(session.proxy.async_network_destroy(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static XenRef<Task> async_set_default_locking_mode(Session session, string _network, network_default_locking_mode _value)
        {
            return XenRef<Task>.Create(session.proxy.async_network_set_default_locking_mode(session.uuid, (_network != null) ? _network : "", network_default_locking_mode_helper.ToString(_value)).parse());
        }

        public static XenRef<Network> create(Session session, Network _record)
        {
            return XenRef<Network>.Create(session.proxy.network_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Blob> create_new_blob(Session session, string _network, string _name, string _mime_type)
        {
            return XenRef<Blob>.Create(session.proxy.network_create_new_blob(session.uuid, (_network != null) ? _network : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        public static XenRef<Blob> create_new_blob(Session session, string _network, string _name, string _mime_type, bool _public)
        {
            return XenRef<Blob>.Create(session.proxy.network_create_new_blob(session.uuid, (_network != null) ? _network : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public bool DeepEquals(Network other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, network_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<List<network_operations>>(this._allowed_operations, other._allowed_operations))) && ((Helper.AreEqual2<List<XenRef<VIF>>>(this._VIFs, other._VIFs) && Helper.AreEqual2<List<XenRef<PIF>>>(this._PIFs, other._PIFs)) && (Helper.AreEqual2<long>(this._MTU, other._MTU) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)))) && ((Helper.AreEqual2<string>(this._bridge, other._bridge) && Helper.AreEqual2<Dictionary<string, XenRef<Blob>>>(this._blobs, other._blobs)) && (Helper.AreEqual2<string[]>(this._tags, other._tags) && Helper.AreEqual2<network_default_locking_mode>(this._default_locking_mode, other._default_locking_mode)))) && Helper.AreEqual2<Dictionary<XenRef<VIF>, string>>(this._assigned_ips, other._assigned_ips));
        }

        public static void destroy(Session session, string _network)
        {
            session.proxy.network_destroy(session.uuid, (_network != null) ? _network : "").parse();
        }

        public static List<XenRef<Network>> get_all(Session session)
        {
            return XenRef<Network>.Create(session.proxy.network_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Network>, Network> get_all_records(Session session)
        {
            return XenRef<Network>.Create<Proxy_Network>(session.proxy.network_get_all_records(session.uuid).parse());
        }

        public static List<network_operations> get_allowed_operations(Session session, string _network)
        {
            return Helper.StringArrayToEnumList<network_operations>(session.proxy.network_get_allowed_operations(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static Dictionary<XenRef<VIF>, string> get_assigned_ips(Session session, string _network)
        {
            return Maps.convert_from_proxy_XenRefVIF_string(session.proxy.network_get_assigned_ips(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static Dictionary<string, XenRef<Blob>> get_blobs(Session session, string _network)
        {
            return Maps.convert_from_proxy_string_XenRefBlob(session.proxy.network_get_blobs(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static string get_bridge(Session session, string _network)
        {
            return session.proxy.network_get_bridge(session.uuid, (_network != null) ? _network : "").parse();
        }

        public static List<XenRef<Network>> get_by_name_label(Session session, string _label)
        {
            return XenRef<Network>.Create(session.proxy.network_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<Network> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Network>.Create(session.proxy.network_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, network_operations> get_current_operations(Session session, string _network)
        {
            return Maps.convert_from_proxy_string_network_operations(session.proxy.network_get_current_operations(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static network_default_locking_mode get_default_locking_mode(Session session, string _network)
        {
            return (network_default_locking_mode) Helper.EnumParseDefault(typeof(network_default_locking_mode), session.proxy.network_get_default_locking_mode(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static long get_MTU(Session session, string _network)
        {
            return long.Parse(session.proxy.network_get_mtu(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static string get_name_description(Session session, string _network)
        {
            return session.proxy.network_get_name_description(session.uuid, (_network != null) ? _network : "").parse();
        }

        public static string get_name_label(Session session, string _network)
        {
            return session.proxy.network_get_name_label(session.uuid, (_network != null) ? _network : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _network)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.network_get_other_config(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static List<XenRef<PIF>> get_PIFs(Session session, string _network)
        {
            return XenRef<PIF>.Create(session.proxy.network_get_pifs(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static Network get_record(Session session, string _network)
        {
            return new Network(session.proxy.network_get_record(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static string[] get_tags(Session session, string _network)
        {
            return session.proxy.network_get_tags(session.uuid, (_network != null) ? _network : "").parse();
        }

        public static string get_uuid(Session session, string _network)
        {
            return session.proxy.network_get_uuid(session.uuid, (_network != null) ? _network : "").parse();
        }

        public static List<XenRef<VIF>> get_VIFs(Session session, string _network)
        {
            return XenRef<VIF>.Create(session.proxy.network_get_vifs(session.uuid, (_network != null) ? _network : "").parse());
        }

        public static void remove_from_other_config(Session session, string _network, string _key)
        {
            session.proxy.network_remove_from_other_config(session.uuid, (_network != null) ? _network : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_tags(Session session, string _network, string _value)
        {
            session.proxy.network_remove_tags(session.uuid, (_network != null) ? _network : "", (_value != null) ? _value : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Network server)
        {
            if (opaqueRef == null)
            {
                Proxy_Network network = this.ToProxy();
                return session.proxy.network_create(session.uuid, network).parse();
            }
            if (!Helper.AreEqual2<string>(this._name_label, server._name_label))
            {
                set_name_label(session, opaqueRef, this._name_label);
            }
            if (!Helper.AreEqual2<string>(this._name_description, server._name_description))
            {
                set_name_description(session, opaqueRef, this._name_description);
            }
            if (!Helper.AreEqual2<long>(this._MTU, server._MTU))
            {
                set_MTU(session, opaqueRef, this._MTU);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<string[]>(this._tags, server._tags))
            {
                set_tags(session, opaqueRef, this._tags);
            }
            return null;
        }

        public static void set_default_locking_mode(Session session, string _network, network_default_locking_mode _value)
        {
            session.proxy.network_set_default_locking_mode(session.uuid, (_network != null) ? _network : "", network_default_locking_mode_helper.ToString(_value)).parse();
        }

        public static void set_MTU(Session session, string _network, long _mtu)
        {
            session.proxy.network_set_mtu(session.uuid, (_network != null) ? _network : "", _mtu.ToString()).parse();
        }

        public static void set_name_description(Session session, string _network, string _description)
        {
            session.proxy.network_set_name_description(session.uuid, (_network != null) ? _network : "", (_description != null) ? _description : "").parse();
        }

        public static void set_name_label(Session session, string _network, string _label)
        {
            session.proxy.network_set_name_label(session.uuid, (_network != null) ? _network : "", (_label != null) ? _label : "").parse();
        }

        public static void set_other_config(Session session, string _network, Dictionary<string, string> _other_config)
        {
            session.proxy.network_set_other_config(session.uuid, (_network != null) ? _network : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_tags(Session session, string _network, string[] _tags)
        {
            session.proxy.network_set_tags(session.uuid, (_network != null) ? _network : "", _tags).parse();
        }

        public Proxy_Network ToProxy()
        {
            return new Proxy_Network { uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<network_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_network_operations(this.current_operations), VIFs = (this.VIFs != null) ? Helper.RefListToStringArray<VIF>(this.VIFs) : new string[0], PIFs = (this.PIFs != null) ? Helper.RefListToStringArray<PIF>(this.PIFs) : new string[0], MTU = this.MTU.ToString(), other_config = Maps.convert_to_proxy_string_string(this.other_config), bridge = (this.bridge != null) ? this.bridge : "", blobs = Maps.convert_to_proxy_string_XenRefBlob(this.blobs), tags = this.tags, default_locking_mode = network_default_locking_mode_helper.ToString(this.default_locking_mode), assigned_ips = Maps.convert_to_proxy_XenRefVIF_string(this.assigned_ips) };
        }

        public override void UpdateFrom(Network update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.VIFs = update.VIFs;
            this.PIFs = update.PIFs;
            this.MTU = update.MTU;
            this.other_config = update.other_config;
            this.bridge = update.bridge;
            this.blobs = update.blobs;
            this.tags = update.tags;
            this.default_locking_mode = update.default_locking_mode;
            this.assigned_ips = update.assigned_ips;
        }

        internal void UpdateFromProxy(Proxy_Network proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<network_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_network_operations(proxy.current_operations);
            this.VIFs = (proxy.VIFs == null) ? null : XenRef<VIF>.Create(proxy.VIFs);
            this.PIFs = (proxy.PIFs == null) ? null : XenRef<PIF>.Create(proxy.PIFs);
            this.MTU = (proxy.MTU == null) ? 0L : long.Parse(proxy.MTU);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.bridge = (proxy.bridge == null) ? null : proxy.bridge;
            this.blobs = (proxy.blobs == null) ? null : Maps.convert_from_proxy_string_XenRefBlob(proxy.blobs);
            this.tags = (proxy.tags == null) ? new string[0] : proxy.tags;
            this.default_locking_mode = (proxy.default_locking_mode == null) ? network_default_locking_mode.unlocked : ((network_default_locking_mode) Helper.EnumParseDefault(typeof(network_default_locking_mode), proxy.default_locking_mode));
            this.assigned_ips = (proxy.assigned_ips == null) ? null : Maps.convert_from_proxy_XenRefVIF_string(proxy.assigned_ips);
        }

        public virtual List<network_operations> allowed_operations
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

        public virtual Dictionary<XenRef<VIF>, string> assigned_ips
        {
            get
            {
                return this._assigned_ips;
            }
            set
            {
                if (!Helper.AreEqual(value, this._assigned_ips))
                {
                    this._assigned_ips = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("assigned_ips");
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

        public virtual string bridge
        {
            get
            {
                return this._bridge;
            }
            set
            {
                if (!Helper.AreEqual(value, this._bridge))
                {
                    this._bridge = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("bridge");
                }
            }
        }

        public virtual Dictionary<string, network_operations> current_operations
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

        public virtual network_default_locking_mode default_locking_mode
        {
            get
            {
                return this._default_locking_mode;
            }
            set
            {
                if (!Helper.AreEqual(value, this._default_locking_mode))
                {
                    this._default_locking_mode = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("default_locking_mode");
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

        public virtual List<XenRef<PIF>> PIFs
        {
            get
            {
                return this._PIFs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._PIFs))
                {
                    this._PIFs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("PIFs");
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

        public virtual List<XenRef<VIF>> VIFs
        {
            get
            {
                return this._VIFs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VIFs))
                {
                    this._VIFs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VIFs");
                }
            }
        }
    }
}

