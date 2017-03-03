namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VGPU_type : XenObject<VGPU_type>
    {
        private List<XenRef<GPU_group>> _enabled_on_GPU_groups;
        private List<XenRef<PGPU>> _enabled_on_PGPUs;
        private bool _experimental;
        private long _framebuffer_size;
        private string _identifier;
        private vgpu_type_implementation _implementation;
        private long _max_heads;
        private long _max_resolution_x;
        private long _max_resolution_y;
        private string _model_name;
        private List<XenRef<GPU_group>> _supported_on_GPU_groups;
        private List<XenRef<PGPU>> _supported_on_PGPUs;
        private string _uuid;
        private string _vendor_name;
        private List<XenRef<VGPU>> _VGPUs;

        public VGPU_type()
        {
        }

        public VGPU_type(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.vendor_name = Marshalling.ParseString(table, "vendor_name");
            this.model_name = Marshalling.ParseString(table, "model_name");
            this.framebuffer_size = Marshalling.ParseLong(table, "framebuffer_size");
            this.max_heads = Marshalling.ParseLong(table, "max_heads");
            this.max_resolution_x = Marshalling.ParseLong(table, "max_resolution_x");
            this.max_resolution_y = Marshalling.ParseLong(table, "max_resolution_y");
            this.supported_on_PGPUs = Marshalling.ParseSetRef<PGPU>(table, "supported_on_PGPUs");
            this.enabled_on_PGPUs = Marshalling.ParseSetRef<PGPU>(table, "enabled_on_PGPUs");
            this.VGPUs = Marshalling.ParseSetRef<VGPU>(table, "VGPUs");
            this.supported_on_GPU_groups = Marshalling.ParseSetRef<GPU_group>(table, "supported_on_GPU_groups");
            this.enabled_on_GPU_groups = Marshalling.ParseSetRef<GPU_group>(table, "enabled_on_GPU_groups");
            this.implementation = (vgpu_type_implementation) Helper.EnumParseDefault(typeof(vgpu_type_implementation), Marshalling.ParseString(table, "implementation"));
            this.identifier = Marshalling.ParseString(table, "identifier");
            this.experimental = Marshalling.ParseBool(table, "experimental");
        }

        public VGPU_type(Proxy_VGPU_type proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VGPU_type(string uuid, string vendor_name, string model_name, long framebuffer_size, long max_heads, long max_resolution_x, long max_resolution_y, List<XenRef<PGPU>> supported_on_PGPUs, List<XenRef<PGPU>> enabled_on_PGPUs, List<XenRef<VGPU>> VGPUs, List<XenRef<GPU_group>> supported_on_GPU_groups, List<XenRef<GPU_group>> enabled_on_GPU_groups, vgpu_type_implementation implementation, string identifier, bool experimental)
        {
            this.uuid = uuid;
            this.vendor_name = vendor_name;
            this.model_name = model_name;
            this.framebuffer_size = framebuffer_size;
            this.max_heads = max_heads;
            this.max_resolution_x = max_resolution_x;
            this.max_resolution_y = max_resolution_y;
            this.supported_on_PGPUs = supported_on_PGPUs;
            this.enabled_on_PGPUs = enabled_on_PGPUs;
            this.VGPUs = VGPUs;
            this.supported_on_GPU_groups = supported_on_GPU_groups;
            this.enabled_on_GPU_groups = enabled_on_GPU_groups;
            this.implementation = implementation;
            this.identifier = identifier;
            this.experimental = experimental;
        }

        public bool DeepEquals(VGPU_type other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._vendor_name, other._vendor_name)) && (Helper.AreEqual2<string>(this._model_name, other._model_name) && Helper.AreEqual2<long>(this._framebuffer_size, other._framebuffer_size))) && ((Helper.AreEqual2<long>(this._max_heads, other._max_heads) && Helper.AreEqual2<long>(this._max_resolution_x, other._max_resolution_x)) && (Helper.AreEqual2<long>(this._max_resolution_y, other._max_resolution_y) && Helper.AreEqual2<List<XenRef<PGPU>>>(this._supported_on_PGPUs, other._supported_on_PGPUs)))) && (((Helper.AreEqual2<List<XenRef<PGPU>>>(this._enabled_on_PGPUs, other._enabled_on_PGPUs) && Helper.AreEqual2<List<XenRef<VGPU>>>(this._VGPUs, other._VGPUs)) && (Helper.AreEqual2<List<XenRef<GPU_group>>>(this._supported_on_GPU_groups, other._supported_on_GPU_groups) && Helper.AreEqual2<List<XenRef<GPU_group>>>(this._enabled_on_GPU_groups, other._enabled_on_GPU_groups))) && (Helper.AreEqual2<vgpu_type_implementation>(this._implementation, other._implementation) && Helper.AreEqual2<string>(this._identifier, other._identifier)))) && Helper.AreEqual2<bool>(this._experimental, other._experimental)));
        }

        public static List<XenRef<VGPU_type>> get_all(Session session)
        {
            return XenRef<VGPU_type>.Create(session.proxy.vgpu_type_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VGPU_type>, VGPU_type> get_all_records(Session session)
        {
            return XenRef<VGPU_type>.Create<Proxy_VGPU_type>(session.proxy.vgpu_type_get_all_records(session.uuid).parse());
        }

        public static XenRef<VGPU_type> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VGPU_type>.Create(session.proxy.vgpu_type_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static List<XenRef<GPU_group>> get_enabled_on_GPU_groups(Session session, string _vgpu_type)
        {
            return XenRef<GPU_group>.Create(session.proxy.vgpu_type_get_enabled_on_gpu_groups(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static List<XenRef<PGPU>> get_enabled_on_PGPUs(Session session, string _vgpu_type)
        {
            return XenRef<PGPU>.Create(session.proxy.vgpu_type_get_enabled_on_pgpus(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static bool get_experimental(Session session, string _vgpu_type)
        {
            return session.proxy.vgpu_type_get_experimental(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse();
        }

        public static long get_framebuffer_size(Session session, string _vgpu_type)
        {
            return long.Parse(session.proxy.vgpu_type_get_framebuffer_size(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static string get_identifier(Session session, string _vgpu_type)
        {
            return session.proxy.vgpu_type_get_identifier(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse();
        }

        public static vgpu_type_implementation get_implementation(Session session, string _vgpu_type)
        {
            return (vgpu_type_implementation) Helper.EnumParseDefault(typeof(vgpu_type_implementation), session.proxy.vgpu_type_get_implementation(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static long get_max_heads(Session session, string _vgpu_type)
        {
            return long.Parse(session.proxy.vgpu_type_get_max_heads(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static long get_max_resolution_x(Session session, string _vgpu_type)
        {
            return long.Parse(session.proxy.vgpu_type_get_max_resolution_x(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static long get_max_resolution_y(Session session, string _vgpu_type)
        {
            return long.Parse(session.proxy.vgpu_type_get_max_resolution_y(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static string get_model_name(Session session, string _vgpu_type)
        {
            return session.proxy.vgpu_type_get_model_name(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse();
        }

        public static VGPU_type get_record(Session session, string _vgpu_type)
        {
            return new VGPU_type(session.proxy.vgpu_type_get_record(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static List<XenRef<GPU_group>> get_supported_on_GPU_groups(Session session, string _vgpu_type)
        {
            return XenRef<GPU_group>.Create(session.proxy.vgpu_type_get_supported_on_gpu_groups(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static List<XenRef<PGPU>> get_supported_on_PGPUs(Session session, string _vgpu_type)
        {
            return XenRef<PGPU>.Create(session.proxy.vgpu_type_get_supported_on_pgpus(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public static string get_uuid(Session session, string _vgpu_type)
        {
            return session.proxy.vgpu_type_get_uuid(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse();
        }

        public static string get_vendor_name(Session session, string _vgpu_type)
        {
            return session.proxy.vgpu_type_get_vendor_name(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse();
        }

        public static List<XenRef<VGPU>> get_VGPUs(Session session, string _vgpu_type)
        {
            return XenRef<VGPU>.Create(session.proxy.vgpu_type_get_vgpus(session.uuid, (_vgpu_type != null) ? _vgpu_type : "").parse());
        }

        public override string SaveChanges(Session session, string opaqueRef, VGPU_type server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            return "";
        }

        public Proxy_VGPU_type ToProxy()
        {
            return new Proxy_VGPU_type { uuid = (this.uuid != null) ? this.uuid : "", vendor_name = (this.vendor_name != null) ? this.vendor_name : "", model_name = (this.model_name != null) ? this.model_name : "", framebuffer_size = this.framebuffer_size.ToString(), max_heads = this.max_heads.ToString(), max_resolution_x = this.max_resolution_x.ToString(), max_resolution_y = this.max_resolution_y.ToString(), supported_on_PGPUs = (this.supported_on_PGPUs != null) ? Helper.RefListToStringArray<PGPU>(this.supported_on_PGPUs) : new string[0], enabled_on_PGPUs = (this.enabled_on_PGPUs != null) ? Helper.RefListToStringArray<PGPU>(this.enabled_on_PGPUs) : new string[0], VGPUs = (this.VGPUs != null) ? Helper.RefListToStringArray<VGPU>(this.VGPUs) : new string[0], supported_on_GPU_groups = (this.supported_on_GPU_groups != null) ? Helper.RefListToStringArray<GPU_group>(this.supported_on_GPU_groups) : new string[0], enabled_on_GPU_groups = (this.enabled_on_GPU_groups != null) ? Helper.RefListToStringArray<GPU_group>(this.enabled_on_GPU_groups) : new string[0], implementation = vgpu_type_implementation_helper.ToString(this.implementation), identifier = (this.identifier != null) ? this.identifier : "", experimental = this.experimental };
        }

        public override void UpdateFrom(VGPU_type update)
        {
            this.uuid = update.uuid;
            this.vendor_name = update.vendor_name;
            this.model_name = update.model_name;
            this.framebuffer_size = update.framebuffer_size;
            this.max_heads = update.max_heads;
            this.max_resolution_x = update.max_resolution_x;
            this.max_resolution_y = update.max_resolution_y;
            this.supported_on_PGPUs = update.supported_on_PGPUs;
            this.enabled_on_PGPUs = update.enabled_on_PGPUs;
            this.VGPUs = update.VGPUs;
            this.supported_on_GPU_groups = update.supported_on_GPU_groups;
            this.enabled_on_GPU_groups = update.enabled_on_GPU_groups;
            this.implementation = update.implementation;
            this.identifier = update.identifier;
            this.experimental = update.experimental;
        }

        internal void UpdateFromProxy(Proxy_VGPU_type proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.vendor_name = (proxy.vendor_name == null) ? null : proxy.vendor_name;
            this.model_name = (proxy.model_name == null) ? null : proxy.model_name;
            this.framebuffer_size = (proxy.framebuffer_size == null) ? 0L : long.Parse(proxy.framebuffer_size);
            this.max_heads = (proxy.max_heads == null) ? 0L : long.Parse(proxy.max_heads);
            this.max_resolution_x = (proxy.max_resolution_x == null) ? 0L : long.Parse(proxy.max_resolution_x);
            this.max_resolution_y = (proxy.max_resolution_y == null) ? 0L : long.Parse(proxy.max_resolution_y);
            this.supported_on_PGPUs = (proxy.supported_on_PGPUs == null) ? null : XenRef<PGPU>.Create(proxy.supported_on_PGPUs);
            this.enabled_on_PGPUs = (proxy.enabled_on_PGPUs == null) ? null : XenRef<PGPU>.Create(proxy.enabled_on_PGPUs);
            this.VGPUs = (proxy.VGPUs == null) ? null : XenRef<VGPU>.Create(proxy.VGPUs);
            this.supported_on_GPU_groups = (proxy.supported_on_GPU_groups == null) ? null : XenRef<GPU_group>.Create(proxy.supported_on_GPU_groups);
            this.enabled_on_GPU_groups = (proxy.enabled_on_GPU_groups == null) ? null : XenRef<GPU_group>.Create(proxy.enabled_on_GPU_groups);
            this.implementation = (proxy.implementation == null) ? vgpu_type_implementation.passthrough : ((vgpu_type_implementation) Helper.EnumParseDefault(typeof(vgpu_type_implementation), proxy.implementation));
            this.identifier = (proxy.identifier == null) ? null : proxy.identifier;
            this.experimental = proxy.experimental;
        }

        public virtual List<XenRef<GPU_group>> enabled_on_GPU_groups
        {
            get
            {
                return this._enabled_on_GPU_groups;
            }
            set
            {
                if (!Helper.AreEqual(value, this._enabled_on_GPU_groups))
                {
                    this._enabled_on_GPU_groups = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("enabled_on_GPU_groups");
                }
            }
        }

        public virtual List<XenRef<PGPU>> enabled_on_PGPUs
        {
            get
            {
                return this._enabled_on_PGPUs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._enabled_on_PGPUs))
                {
                    this._enabled_on_PGPUs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("enabled_on_PGPUs");
                }
            }
        }

        public virtual bool experimental
        {
            get
            {
                return this._experimental;
            }
            set
            {
                if (!Helper.AreEqual(value, this._experimental))
                {
                    this._experimental = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("experimental");
                }
            }
        }

        public virtual long framebuffer_size
        {
            get
            {
                return this._framebuffer_size;
            }
            set
            {
                if (!Helper.AreEqual(value, this._framebuffer_size))
                {
                    this._framebuffer_size = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("framebuffer_size");
                }
            }
        }

        public virtual string identifier
        {
            get
            {
                return this._identifier;
            }
            set
            {
                if (!Helper.AreEqual(value, this._identifier))
                {
                    this._identifier = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("identifier");
                }
            }
        }

        public virtual vgpu_type_implementation implementation
        {
            get
            {
                return this._implementation;
            }
            set
            {
                if (!Helper.AreEqual(value, this._implementation))
                {
                    this._implementation = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("implementation");
                }
            }
        }

        public virtual long max_heads
        {
            get
            {
                return this._max_heads;
            }
            set
            {
                if (!Helper.AreEqual(value, this._max_heads))
                {
                    this._max_heads = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("max_heads");
                }
            }
        }

        public virtual long max_resolution_x
        {
            get
            {
                return this._max_resolution_x;
            }
            set
            {
                if (!Helper.AreEqual(value, this._max_resolution_x))
                {
                    this._max_resolution_x = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("max_resolution_x");
                }
            }
        }

        public virtual long max_resolution_y
        {
            get
            {
                return this._max_resolution_y;
            }
            set
            {
                if (!Helper.AreEqual(value, this._max_resolution_y))
                {
                    this._max_resolution_y = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("max_resolution_y");
                }
            }
        }

        public virtual string model_name
        {
            get
            {
                return this._model_name;
            }
            set
            {
                if (!Helper.AreEqual(value, this._model_name))
                {
                    this._model_name = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("model_name");
                }
            }
        }

        public virtual List<XenRef<GPU_group>> supported_on_GPU_groups
        {
            get
            {
                return this._supported_on_GPU_groups;
            }
            set
            {
                if (!Helper.AreEqual(value, this._supported_on_GPU_groups))
                {
                    this._supported_on_GPU_groups = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("supported_on_GPU_groups");
                }
            }
        }

        public virtual List<XenRef<PGPU>> supported_on_PGPUs
        {
            get
            {
                return this._supported_on_PGPUs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._supported_on_PGPUs))
                {
                    this._supported_on_PGPUs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("supported_on_PGPUs");
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

        public virtual string vendor_name
        {
            get
            {
                return this._vendor_name;
            }
            set
            {
                if (!Helper.AreEqual(value, this._vendor_name))
                {
                    this._vendor_name = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("vendor_name");
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

