namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class GPU_group : XenObject<GPU_group>
    {
        private WinAPI.allocation_algorithm _allocation_algorithm;
        private List<XenRef<VGPU_type>> _enabled_VGPU_types;
        private string[] _GPU_types;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private List<XenRef<PGPU>> _PGPUs;
        private List<XenRef<VGPU_type>> _supported_VGPU_types;
        private string _uuid;
        private List<XenRef<VGPU>> _VGPUs;

        public GPU_group()
        {
        }

        public GPU_group(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.PGPUs = Marshalling.ParseSetRef<PGPU>(table, "PGPUs");
            this.VGPUs = Marshalling.ParseSetRef<VGPU>(table, "VGPUs");
            this.GPU_types = Marshalling.ParseStringArray(table, "GPU_types");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.allocation_algorithm = (WinAPI.allocation_algorithm) Helper.EnumParseDefault(typeof(WinAPI.allocation_algorithm), Marshalling.ParseString(table, "allocation_algorithm"));
            this.supported_VGPU_types = Marshalling.ParseSetRef<VGPU_type>(table, "supported_VGPU_types");
            this.enabled_VGPU_types = Marshalling.ParseSetRef<VGPU_type>(table, "enabled_VGPU_types");
        }

        public GPU_group(Proxy_GPU_group proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public GPU_group(string uuid, string name_label, string name_description, List<XenRef<PGPU>> PGPUs, List<XenRef<VGPU>> VGPUs, string[] GPU_types, Dictionary<string, string> other_config, WinAPI.allocation_algorithm allocation_algorithm, List<XenRef<VGPU_type>> supported_VGPU_types, List<XenRef<VGPU_type>> enabled_VGPU_types)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.PGPUs = PGPUs;
            this.VGPUs = VGPUs;
            this.GPU_types = GPU_types;
            this.other_config = other_config;
            this.allocation_algorithm = allocation_algorithm;
            this.supported_VGPU_types = supported_VGPU_types;
            this.enabled_VGPU_types = enabled_VGPU_types;
        }

        public static void add_to_other_config(Session session, string _gpu_group, string _key, string _value)
        {
            session.proxy.gpu_group_add_to_other_config(session.uuid, (_gpu_group != null) ? _gpu_group : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, string _name_label, string _name_description, Dictionary<string, string> _other_config)
        {
            return XenRef<Task>.Create(session.proxy.async_gpu_group_create(session.uuid, (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", Maps.convert_to_proxy_string_string(_other_config)).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _gpu_group)
        {
            return XenRef<Task>.Create(session.proxy.async_gpu_group_destroy(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static XenRef<Task> async_get_remaining_capacity(Session session, string _gpu_group, string _vgpu_type)
        {
            return XenRef<Task>.Create(session.proxy.async_gpu_group_get_remaining_capacity(session.uuid, (_gpu_group != null) ? _gpu_group : "", (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static XenRef<GPU_group> create(Session session, string _name_label, string _name_description, Dictionary<string, string> _other_config)
        {
            return XenRef<GPU_group>.Create(session.proxy.gpu_group_create(session.uuid, (_name_label != null) ? _name_label : "", (_name_description != null) ? _name_description : "", Maps.convert_to_proxy_string_string(_other_config)).parse());
        }

        public bool DeepEquals(GPU_group other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<List<XenRef<PGPU>>>(this._PGPUs, other._PGPUs))) && ((Helper.AreEqual2<List<XenRef<VGPU>>>(this._VGPUs, other._VGPUs) && Helper.AreEqual2<string[]>(this._GPU_types, other._GPU_types)) && (Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<WinAPI.allocation_algorithm>(this._allocation_algorithm, other._allocation_algorithm)))) && Helper.AreEqual2<List<XenRef<VGPU_type>>>(this._supported_VGPU_types, other._supported_VGPU_types)) && Helper.AreEqual2<List<XenRef<VGPU_type>>>(this._enabled_VGPU_types, other._enabled_VGPU_types)));
        }

        public static void destroy(Session session, string _gpu_group)
        {
            session.proxy.gpu_group_destroy(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse();
        }

        public static List<XenRef<GPU_group>> get_all(Session session)
        {
            return XenRef<GPU_group>.Create(session.proxy.gpu_group_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<GPU_group>, GPU_group> get_all_records(Session session)
        {
            return XenRef<GPU_group>.Create<Proxy_GPU_group>(session.proxy.gpu_group_get_all_records(session.uuid).parse());
        }

        public static WinAPI.allocation_algorithm get_allocation_algorithm(Session session, string _gpu_group)
        {
            return (WinAPI.allocation_algorithm) Helper.EnumParseDefault(typeof(WinAPI.allocation_algorithm), session.proxy.gpu_group_get_allocation_algorithm(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static List<XenRef<GPU_group>> get_by_name_label(Session session, string _label)
        {
            return XenRef<GPU_group>.Create(session.proxy.gpu_group_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<GPU_group> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<GPU_group>.Create(session.proxy.gpu_group_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static List<XenRef<VGPU_type>> get_enabled_VGPU_types(Session session, string _gpu_group)
        {
            return XenRef<VGPU_type>.Create(session.proxy.gpu_group_get_enabled_vgpu_types(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static string[] get_GPU_types(Session session, string _gpu_group)
        {
            return session.proxy.gpu_group_get_gpu_types(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse();
        }

        public static string get_name_description(Session session, string _gpu_group)
        {
            return session.proxy.gpu_group_get_name_description(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse();
        }

        public static string get_name_label(Session session, string _gpu_group)
        {
            return session.proxy.gpu_group_get_name_label(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _gpu_group)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.gpu_group_get_other_config(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static List<XenRef<PGPU>> get_PGPUs(Session session, string _gpu_group)
        {
            return XenRef<PGPU>.Create(session.proxy.gpu_group_get_pgpus(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static GPU_group get_record(Session session, string _gpu_group)
        {
            return new GPU_group(session.proxy.gpu_group_get_record(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static long get_remaining_capacity(Session session, string _gpu_group, string _vgpu_type)
        {
            return long.Parse(session.proxy.gpu_group_get_remaining_capacity(session.uuid, (_gpu_group != null) ? _gpu_group : "", (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static List<XenRef<VGPU_type>> get_supported_VGPU_types(Session session, string _gpu_group)
        {
            return XenRef<VGPU_type>.Create(session.proxy.gpu_group_get_supported_vgpu_types(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static string get_uuid(Session session, string _gpu_group)
        {
            return session.proxy.gpu_group_get_uuid(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse();
        }

        public static List<XenRef<VGPU>> get_VGPUs(Session session, string _gpu_group)
        {
            return XenRef<VGPU>.Create(session.proxy.gpu_group_get_vgpus(session.uuid, (_gpu_group != null) ? _gpu_group : "").parse());
        }

        public static void remove_from_other_config(Session session, string _gpu_group, string _key)
        {
            session.proxy.gpu_group_remove_from_other_config(session.uuid, (_gpu_group != null) ? _gpu_group : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, GPU_group server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<string>(this._name_label, server._name_label))
            {
                set_name_label(session, opaqueRef, this._name_label);
            }
            if (!Helper.AreEqual2<string>(this._name_description, server._name_description))
            {
                set_name_description(session, opaqueRef, this._name_description);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<WinAPI.allocation_algorithm>(this._allocation_algorithm, server._allocation_algorithm))
            {
                set_allocation_algorithm(session, opaqueRef, this._allocation_algorithm);
            }
            return null;
        }

        public static void set_allocation_algorithm(Session session, string _gpu_group, WinAPI.allocation_algorithm _allocation_algorithm)
        {
            session.proxy.gpu_group_set_allocation_algorithm(session.uuid, (_gpu_group != null) ? _gpu_group : "", allocation_algorithm_helper.ToString(_allocation_algorithm)).parse();
        }

        public static void set_name_description(Session session, string _gpu_group, string _description)
        {
            session.proxy.gpu_group_set_name_description(session.uuid, (_gpu_group != null) ? _gpu_group : "", (_description != null) ? _description : "").parse();
        }

        public static void set_name_label(Session session, string _gpu_group, string _label)
        {
            session.proxy.gpu_group_set_name_label(session.uuid, (_gpu_group != null) ? _gpu_group : "", (_label != null) ? _label : "").parse();
        }

        public static void set_other_config(Session session, string _gpu_group, Dictionary<string, string> _other_config)
        {
            session.proxy.gpu_group_set_other_config(session.uuid, (_gpu_group != null) ? _gpu_group : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_GPU_group ToProxy()
        {
            return new Proxy_GPU_group { uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", PGPUs = (this.PGPUs != null) ? Helper.RefListToStringArray<PGPU>(this.PGPUs) : new string[0], VGPUs = (this.VGPUs != null) ? Helper.RefListToStringArray<VGPU>(this.VGPUs) : new string[0], GPU_types = this.GPU_types, other_config = Maps.convert_to_proxy_string_string(this.other_config), allocation_algorithm = allocation_algorithm_helper.ToString(this.allocation_algorithm), supported_VGPU_types = (this.supported_VGPU_types != null) ? Helper.RefListToStringArray<VGPU_type>(this.supported_VGPU_types) : new string[0], enabled_VGPU_types = (this.enabled_VGPU_types != null) ? Helper.RefListToStringArray<VGPU_type>(this.enabled_VGPU_types) : new string[0] };
        }

        public override void UpdateFrom(GPU_group update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.PGPUs = update.PGPUs;
            this.VGPUs = update.VGPUs;
            this.GPU_types = update.GPU_types;
            this.other_config = update.other_config;
            this.allocation_algorithm = update.allocation_algorithm;
            this.supported_VGPU_types = update.supported_VGPU_types;
            this.enabled_VGPU_types = update.enabled_VGPU_types;
        }

        internal void UpdateFromProxy(Proxy_GPU_group proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.PGPUs = (proxy.PGPUs == null) ? null : XenRef<PGPU>.Create(proxy.PGPUs);
            this.VGPUs = (proxy.VGPUs == null) ? null : XenRef<VGPU>.Create(proxy.VGPUs);
            this.GPU_types = (proxy.GPU_types == null) ? new string[0] : proxy.GPU_types;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.allocation_algorithm = (proxy.allocation_algorithm == null) ? WinAPI.allocation_algorithm.breadth_first : ((WinAPI.allocation_algorithm) Helper.EnumParseDefault(typeof(WinAPI.allocation_algorithm), proxy.allocation_algorithm));
            this.supported_VGPU_types = (proxy.supported_VGPU_types == null) ? null : XenRef<VGPU_type>.Create(proxy.supported_VGPU_types);
            this.enabled_VGPU_types = (proxy.enabled_VGPU_types == null) ? null : XenRef<VGPU_type>.Create(proxy.enabled_VGPU_types);
        }

        public virtual WinAPI.allocation_algorithm allocation_algorithm
        {
            get
            {
                return this._allocation_algorithm;
            }
            set
            {
                if (!Helper.AreEqual(value, this._allocation_algorithm))
                {
                    this._allocation_algorithm = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("allocation_algorithm");
                }
            }
        }

        public virtual List<XenRef<VGPU_type>> enabled_VGPU_types
        {
            get
            {
                return this._enabled_VGPU_types;
            }
            set
            {
                if (!Helper.AreEqual(value, this._enabled_VGPU_types))
                {
                    this._enabled_VGPU_types = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("enabled_VGPU_types");
                }
            }
        }

        public virtual string[] GPU_types
        {
            get
            {
                return this._GPU_types;
            }
            set
            {
                if (!Helper.AreEqual(value, this._GPU_types))
                {
                    this._GPU_types = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("GPU_types");
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

        public virtual List<XenRef<PGPU>> PGPUs
        {
            get
            {
                return this._PGPUs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._PGPUs))
                {
                    this._PGPUs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("PGPUs");
                }
            }
        }

        public virtual List<XenRef<VGPU_type>> supported_VGPU_types
        {
            get
            {
                return this._supported_VGPU_types;
            }
            set
            {
                if (!Helper.AreEqual(value, this._supported_VGPU_types))
                {
                    this._supported_VGPU_types = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("supported_VGPU_types");
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

        public virtual List<XenRef<VGPU>> VGPUs
        {
            get
            {
                return this._VGPUs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VGPUs))
                {
                    this._VGPUs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VGPUs");
                }
            }
        }
    }
}

