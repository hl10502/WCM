namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PGPU : XenObject<PGPU>
    {
        private pgpu_dom0_access _dom0_access;
        private List<XenRef<VGPU_type>> _enabled_VGPU_types;
        private XenRef<WinAPI.GPU_group> _GPU_group;
        private XenRef<Host> _host;
        private bool _is_system_display_device;
        private Dictionary<string, string> _other_config;
        private XenRef<WinAPI.PCI> _PCI;
        private List<XenRef<VGPU>> _resident_VGPUs;
        private Dictionary<XenRef<VGPU_type>, long> _supported_VGPU_max_capacities;
        private List<XenRef<VGPU_type>> _supported_VGPU_types;
        private string _uuid;

        public PGPU()
        {
        }

        public PGPU(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.PCI = Marshalling.ParseRef<WinAPI.PCI>(table, "PCI");
            this.GPU_group = Marshalling.ParseRef<WinAPI.GPU_group>(table, "GPU_group");
            this.host = Marshalling.ParseRef<Host>(table, "host");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.supported_VGPU_types = Marshalling.ParseSetRef<VGPU_type>(table, "supported_VGPU_types");
            this.enabled_VGPU_types = Marshalling.ParseSetRef<VGPU_type>(table, "enabled_VGPU_types");
            this.resident_VGPUs = Marshalling.ParseSetRef<VGPU>(table, "resident_VGPUs");
            this.supported_VGPU_max_capacities = Maps.convert_from_proxy_XenRefVGPU_type_long(Marshalling.ParseHashTable(table, "supported_VGPU_max_capacities"));
            this.dom0_access = (pgpu_dom0_access) Helper.EnumParseDefault(typeof(pgpu_dom0_access), Marshalling.ParseString(table, "dom0_access"));
            this.is_system_display_device = Marshalling.ParseBool(table, "is_system_display_device");
        }

        public PGPU(Proxy_PGPU proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public PGPU(string uuid, XenRef<WinAPI.PCI> PCI, XenRef<WinAPI.GPU_group> GPU_group, XenRef<Host> host, Dictionary<string, string> other_config, List<XenRef<VGPU_type>> supported_VGPU_types, List<XenRef<VGPU_type>> enabled_VGPU_types, List<XenRef<VGPU>> resident_VGPUs, Dictionary<XenRef<VGPU_type>, long> supported_VGPU_max_capacities, pgpu_dom0_access dom0_access, bool is_system_display_device)
        {
            this.uuid = uuid;
            this.PCI = PCI;
            this.GPU_group = GPU_group;
            this.host = host;
            this.other_config = other_config;
            this.supported_VGPU_types = supported_VGPU_types;
            this.enabled_VGPU_types = enabled_VGPU_types;
            this.resident_VGPUs = resident_VGPUs;
            this.supported_VGPU_max_capacities = supported_VGPU_max_capacities;
            this.dom0_access = dom0_access;
            this.is_system_display_device = is_system_display_device;
        }

        public static void add_enabled_VGPU_types(Session session, string _pgpu, string _value)
        {
            session.proxy.pgpu_add_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_other_config(Session session, string _pgpu, string _key, string _value)
        {
            session.proxy.pgpu_add_to_other_config(session.uuid, (_pgpu != null) ? _pgpu : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_add_enabled_VGPU_types(Session session, string _pgpu, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_add_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_disable_dom0_access(Session session, string _pgpu)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_disable_dom0_access(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static XenRef<Task> async_enable_dom0_access(Session session, string _pgpu)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_enable_dom0_access(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static XenRef<Task> async_get_remaining_capacity(Session session, string _pgpu, string _vgpu_type)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_get_remaining_capacity(session.uuid, (_pgpu != null) ? _pgpu : "", (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static XenRef<Task> async_remove_enabled_VGPU_types(Session session, string _pgpu, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_remove_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_set_enabled_VGPU_types(Session session, string _pgpu, List<XenRef<VGPU_type>> _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_set_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? Helper.RefListToStringArray<VGPU_type>(_value) : new string[0]).parse());
        }

        public static XenRef<Task> async_set_GPU_group(Session session, string _pgpu, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pgpu_set_gpu_group(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? _value : "").parse());
        }

        public bool DeepEquals(PGPU other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<WinAPI.PCI>>(this._PCI, other._PCI)) && (Helper.AreEqual2<XenRef<WinAPI.GPU_group>>(this._GPU_group, other._GPU_group) && Helper.AreEqual2<XenRef<Host>>(this._host, other._host))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<List<XenRef<VGPU_type>>>(this._supported_VGPU_types, other._supported_VGPU_types)) && (Helper.AreEqual2<List<XenRef<VGPU_type>>>(this._enabled_VGPU_types, other._enabled_VGPU_types) && Helper.AreEqual2<List<XenRef<VGPU>>>(this._resident_VGPUs, other._resident_VGPUs)))) && (Helper.AreEqual2<Dictionary<XenRef<VGPU_type>, long>>(this._supported_VGPU_max_capacities, other._supported_VGPU_max_capacities) && Helper.AreEqual2<pgpu_dom0_access>(this._dom0_access, other._dom0_access))) && Helper.AreEqual2<bool>(this._is_system_display_device, other._is_system_display_device)));
        }

        public static pgpu_dom0_access disable_dom0_access(Session session, string _pgpu)
        {
            return (pgpu_dom0_access) Helper.EnumParseDefault(typeof(pgpu_dom0_access), session.proxy.pgpu_disable_dom0_access(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static pgpu_dom0_access enable_dom0_access(Session session, string _pgpu)
        {
            return (pgpu_dom0_access) Helper.EnumParseDefault(typeof(pgpu_dom0_access), session.proxy.pgpu_enable_dom0_access(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static List<XenRef<PGPU>> get_all(Session session)
        {
            return XenRef<PGPU>.Create(session.proxy.pgpu_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<PGPU>, PGPU> get_all_records(Session session)
        {
            return XenRef<PGPU>.Create<Proxy_PGPU>(session.proxy.pgpu_get_all_records(session.uuid).parse());
        }

        public static XenRef<PGPU> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<PGPU>.Create(session.proxy.pgpu_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static pgpu_dom0_access get_dom0_access(Session session, string _pgpu)
        {
            return (pgpu_dom0_access) Helper.EnumParseDefault(typeof(pgpu_dom0_access), session.proxy.pgpu_get_dom0_access(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static List<XenRef<VGPU_type>> get_enabled_VGPU_types(Session session, string _pgpu)
        {
            return XenRef<VGPU_type>.Create(session.proxy.pgpu_get_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static XenRef<WinAPI.GPU_group> get_GPU_group(Session session, string _pgpu)
        {
            return XenRef<WinAPI.GPU_group>.Create(session.proxy.pgpu_get_gpu_group(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static XenRef<Host> get_host(Session session, string _pgpu)
        {
            return XenRef<Host>.Create(session.proxy.pgpu_get_host(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static bool get_is_system_display_device(Session session, string _pgpu)
        {
            return session.proxy.pgpu_get_is_system_display_device(session.uuid, (_pgpu != null) ? _pgpu : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _pgpu)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pgpu_get_other_config(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static XenRef<WinAPI.PCI> get_PCI(Session session, string _pgpu)
        {
            return XenRef<WinAPI.PCI>.Create(session.proxy.pgpu_get_pci(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static PGPU get_record(Session session, string _pgpu)
        {
            return new PGPU(session.proxy.pgpu_get_record(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static long get_remaining_capacity(Session session, string _pgpu, string _vgpu_type)
        {
            return long.Parse(session.proxy.pgpu_get_remaining_capacity(session.uuid, (_pgpu != null) ? _pgpu : "", (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static List<XenRef<VGPU>> get_resident_VGPUs(Session session, string _pgpu)
        {
            return XenRef<VGPU>.Create(session.proxy.pgpu_get_resident_vgpus(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static Dictionary<XenRef<VGPU_type>, long> get_supported_VGPU_max_capacities(Session session, string _pgpu)
        {
            return Maps.convert_from_proxy_XenRefVGPU_type_long(session.proxy.pgpu_get_supported_vgpu_max_capacities(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static List<XenRef<VGPU_type>> get_supported_VGPU_types(Session session, string _pgpu)
        {
            return XenRef<VGPU_type>.Create(session.proxy.pgpu_get_supported_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "").parse());
        }

        public static string get_uuid(Session session, string _pgpu)
        {
            return session.proxy.pgpu_get_uuid(session.uuid, (_pgpu != null) ? _pgpu : "").parse();
        }

        public static void remove_enabled_VGPU_types(Session session, string _pgpu, string _value)
        {
            session.proxy.pgpu_remove_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? _value : "").parse();
        }

        public static void remove_from_other_config(Session session, string _pgpu, string _key)
        {
            session.proxy.pgpu_remove_from_other_config(session.uuid, (_pgpu != null) ? _pgpu : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, PGPU server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<XenRef<WinAPI.GPU_group>>(this._GPU_group, server._GPU_group))
            {
                set_GPU_group(session, opaqueRef, (string) this._GPU_group);
            }
            return null;
        }

        public static void set_enabled_VGPU_types(Session session, string _pgpu, List<XenRef<VGPU_type>> _value)
        {
            session.proxy.pgpu_set_enabled_vgpu_types(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? Helper.RefListToStringArray<VGPU_type>(_value) : new string[0]).parse();
        }

        public static void set_GPU_group(Session session, string _pgpu, string _value)
        {
            session.proxy.pgpu_set_gpu_group(session.uuid, (_pgpu != null) ? _pgpu : "", (_value != null) ? _value : "").parse();
        }

        public static void set_other_config(Session session, string _pgpu, Dictionary<string, string> _other_config)
        {
            session.proxy.pgpu_set_other_config(session.uuid, (_pgpu != null) ? _pgpu : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_PGPU ToProxy()
        {
            return new Proxy_PGPU { uuid = (this.uuid != null) ? this.uuid : "", PCI = (this.PCI != null) ? ((string) this.PCI) : "", GPU_group = (this.GPU_group != null) ? ((string) this.GPU_group) : "", host = (this.host != null) ? ((string) this.host) : "", other_config = Maps.convert_to_proxy_string_string(this.other_config), supported_VGPU_types = (this.supported_VGPU_types != null) ? Helper.RefListToStringArray<VGPU_type>(this.supported_VGPU_types) : new string[0], enabled_VGPU_types = (this.enabled_VGPU_types != null) ? Helper.RefListToStringArray<VGPU_type>(this.enabled_VGPU_types) : new string[0], resident_VGPUs = (this.resident_VGPUs != null) ? Helper.RefListToStringArray<VGPU>(this.resident_VGPUs) : new string[0], supported_VGPU_max_capacities = Maps.convert_to_proxy_XenRefVGPU_type_long(this.supported_VGPU_max_capacities), dom0_access = pgpu_dom0_access_helper.ToString(this.dom0_access), is_system_display_device = this.is_system_display_device };
        }

        public override void UpdateFrom(PGPU update)
        {
            this.uuid = update.uuid;
            this.PCI = update.PCI;
            this.GPU_group = update.GPU_group;
            this.host = update.host;
            this.other_config = update.other_config;
            this.supported_VGPU_types = update.supported_VGPU_types;
            this.enabled_VGPU_types = update.enabled_VGPU_types;
            this.resident_VGPUs = update.resident_VGPUs;
            this.supported_VGPU_max_capacities = update.supported_VGPU_max_capacities;
            this.dom0_access = update.dom0_access;
            this.is_system_display_device = update.is_system_display_device;
        }

        internal void UpdateFromProxy(Proxy_PGPU proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.PCI = (proxy.PCI == null) ? null : XenRef<WinAPI.PCI>.Create(proxy.PCI);
            this.GPU_group = (proxy.GPU_group == null) ? null : XenRef<WinAPI.GPU_group>.Create(proxy.GPU_group);
            this.host = (proxy.host == null) ? null : XenRef<Host>.Create(proxy.host);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.supported_VGPU_types = (proxy.supported_VGPU_types == null) ? null : XenRef<VGPU_type>.Create(proxy.supported_VGPU_types);
            this.enabled_VGPU_types = (proxy.enabled_VGPU_types == null) ? null : XenRef<VGPU_type>.Create(proxy.enabled_VGPU_types);
            this.resident_VGPUs = (proxy.resident_VGPUs == null) ? null : XenRef<VGPU>.Create(proxy.resident_VGPUs);
            this.supported_VGPU_max_capacities = (proxy.supported_VGPU_max_capacities == null) ? null : Maps.convert_from_proxy_XenRefVGPU_type_long(proxy.supported_VGPU_max_capacities);
            this.dom0_access = (proxy.dom0_access == null) ? pgpu_dom0_access.enabled : ((pgpu_dom0_access) Helper.EnumParseDefault(typeof(pgpu_dom0_access), proxy.dom0_access));
            this.is_system_display_device = proxy.is_system_display_device;
        }

        public virtual pgpu_dom0_access dom0_access
        {
            get
            {
                return this._dom0_access;
            }
            set
            {
                if (!Helper.AreEqual(value, this._dom0_access))
                {
                    this._dom0_access = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("dom0_access");
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

        public virtual XenRef<WinAPI.GPU_group> GPU_group
        {
            get
            {
                return this._GPU_group;
            }
            set
            {
                if (!Helper.AreEqual(value, this._GPU_group))
                {
                    this._GPU_group = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("GPU_group");
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

        public virtual bool is_system_display_device
        {
            get
            {
                return this._is_system_display_device;
            }
            set
            {
                if (!Helper.AreEqual(value, this._is_system_display_device))
                {
                    this._is_system_display_device = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("is_system_display_device");
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

        public virtual XenRef<WinAPI.PCI> PCI
        {
            get
            {
                return this._PCI;
            }
            set
            {
                if (!Helper.AreEqual(value, this._PCI))
                {
                    this._PCI = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("PCI");
                }
            }
        }

        public virtual List<XenRef<VGPU>> resident_VGPUs
        {
            get
            {
                return this._resident_VGPUs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._resident_VGPUs))
                {
                    this._resident_VGPUs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("resident_VGPUs");
                }
            }
        }

        public virtual Dictionary<XenRef<VGPU_type>, long> supported_VGPU_max_capacities
        {
            get
            {
                return this._supported_VGPU_max_capacities;
            }
            set
            {
                if (!Helper.AreEqual(value, this._supported_VGPU_max_capacities))
                {
                    this._supported_VGPU_max_capacities = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("supported_VGPU_max_capacities");
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
    }
}

