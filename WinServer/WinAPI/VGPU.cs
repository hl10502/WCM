namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VGPU : XenObject<VGPU>
    {
        private bool _currently_attached;
        private string _device;
        private XenRef<WinAPI.GPU_group> _GPU_group;
        private Dictionary<string, string> _other_config;
        private XenRef<PGPU> _resident_on;
        private XenRef<VGPU_type> _type;
        private string _uuid;
        private XenRef<WinAPI.VM> _VM;

        public VGPU()
        {
        }

        public VGPU(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.VM = Marshalling.ParseRef<WinAPI.VM>(table, "VM");
            this.GPU_group = Marshalling.ParseRef<WinAPI.GPU_group>(table, "GPU_group");
            this.device = Marshalling.ParseString(table, "device");
            this.currently_attached = Marshalling.ParseBool(table, "currently_attached");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.type = Marshalling.ParseRef<VGPU_type>(table, "type");
            this.resident_on = Marshalling.ParseRef<PGPU>(table, "resident_on");
        }

        public VGPU(Proxy_VGPU proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VGPU(string uuid, XenRef<WinAPI.VM> VM, XenRef<WinAPI.GPU_group> GPU_group, string device, bool currently_attached, Dictionary<string, string> other_config, XenRef<VGPU_type> type, XenRef<PGPU> resident_on)
        {
            this.uuid = uuid;
            this.VM = VM;
            this.GPU_group = GPU_group;
            this.device = device;
            this.currently_attached = currently_attached;
            this.other_config = other_config;
            this.type = type;
            this.resident_on = resident_on;
        }

        public static void add_to_other_config(Session session, string _vgpu, string _key, string _value)
        {
            session.proxy.vgpu_add_to_other_config(session.uuid, (_vgpu != null) ? _vgpu : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, string _vm, string _gpu_group, string _device, Dictionary<string, string> _other_config)
        {
            return XenRef<Task>.Create(session.proxy.async_vgpu_create(session.uuid, (_vm != null) ? _vm : "", (_gpu_group != null) ? _gpu_group : "", (_device != null) ? _device : "", Maps.convert_to_proxy_string_string(_other_config)).parse());
        }

        public static XenRef<Task> async_create(Session session, string _vm, string _gpu_group, string _device, Dictionary<string, string> _other_config, string _type)
        {
            return XenRef<Task>.Create(session.proxy.async_vgpu_create(session.uuid, (_vm != null) ? _vm : "", (_gpu_group != null) ? _gpu_group : "", (_device != null) ? _device : "", Maps.convert_to_proxy_string_string(_other_config), (_type != null) ? _type : "").parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _vgpu)
        {
            return XenRef<Task>.Create(session.proxy.async_vgpu_destroy(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static XenRef<VGPU> create(Session session, string _vm, string _gpu_group, string _device, Dictionary<string, string> _other_config)
        {
            return XenRef<VGPU>.Create(session.proxy.vgpu_create(session.uuid, (_vm != null) ? _vm : "", (_gpu_group != null) ? _gpu_group : "", (_device != null) ? _device : "", Maps.convert_to_proxy_string_string(_other_config)).parse());
        }

        public static XenRef<VGPU> create(Session session, string _vm, string _gpu_group, string _device, Dictionary<string, string> _other_config, string _type)
        {
            return XenRef<VGPU>.Create(session.proxy.vgpu_create(session.uuid, (_vm != null) ? _vm : "", (_gpu_group != null) ? _gpu_group : "", (_device != null) ? _device : "", Maps.convert_to_proxy_string_string(_other_config), (_type != null) ? _type : "").parse());
        }

        public bool DeepEquals(VGPU other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<WinAPI.VM>>(this._VM, other._VM)) && (Helper.AreEqual2<XenRef<WinAPI.GPU_group>>(this._GPU_group, other._GPU_group) && Helper.AreEqual2<string>(this._device, other._device))) && ((Helper.AreEqual2<bool>(this._currently_attached, other._currently_attached) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)) && Helper.AreEqual2<XenRef<VGPU_type>>(this._type, other._type))) && Helper.AreEqual2<XenRef<PGPU>>(this._resident_on, other._resident_on)));
        }

        public static void destroy(Session session, string _vgpu)
        {
            session.proxy.vgpu_destroy(session.uuid, (_vgpu != null) ? _vgpu : "").parse();
        }

        public static List<XenRef<VGPU>> get_all(Session session)
        {
            return XenRef<VGPU>.Create(session.proxy.vgpu_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VGPU>, VGPU> get_all_records(Session session)
        {
            return XenRef<VGPU>.Create<Proxy_VGPU>(session.proxy.vgpu_get_all_records(session.uuid).parse());
        }

        public static XenRef<VGPU> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VGPU>.Create(session.proxy.vgpu_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static bool get_currently_attached(Session session, string _vgpu)
        {
            return session.proxy.vgpu_get_currently_attached(session.uuid, (_vgpu != null) ? _vgpu : "").parse();
        }

        public static string get_device(Session session, string _vgpu)
        {
            return session.proxy.vgpu_get_device(session.uuid, (_vgpu != null) ? _vgpu : "").parse();
        }

        public static XenRef<WinAPI.GPU_group> get_GPU_group(Session session, string _vgpu)
        {
            return XenRef<WinAPI.GPU_group>.Create(session.proxy.vgpu_get_gpu_group(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _vgpu)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vgpu_get_other_config(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static VGPU get_record(Session session, string _vgpu)
        {
            return new VGPU(session.proxy.vgpu_get_record(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static XenRef<PGPU> get_resident_on(Session session, string _vgpu)
        {
            return XenRef<PGPU>.Create(session.proxy.vgpu_get_resident_on(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static XenRef<VGPU_type> get_type(Session session, string _vgpu)
        {
            return XenRef<VGPU_type>.Create(session.proxy.vgpu_get_type(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static string get_uuid(Session session, string _vgpu)
        {
            return session.proxy.vgpu_get_uuid(session.uuid, (_vgpu != null) ? _vgpu : "").parse();
        }

        public static XenRef<WinAPI.VM> get_VM(Session session, string _vgpu)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.vgpu_get_vm(session.uuid, (_vgpu != null) ? _vgpu : "").parse());
        }

        public static void remove_from_other_config(Session session, string _vgpu, string _key)
        {
            session.proxy.vgpu_remove_from_other_config(session.uuid, (_vgpu != null) ? _vgpu : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, VGPU server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            return null;
        }

        public static void set_other_config(Session session, string _vgpu, Dictionary<string, string> _other_config)
        {
            session.proxy.vgpu_set_other_config(session.uuid, (_vgpu != null) ? _vgpu : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_VGPU ToProxy()
        {
            return new Proxy_VGPU { uuid = (this.uuid != null) ? this.uuid : "", VM = (this.VM != null) ? ((string) this.VM) : "", GPU_group = (this.GPU_group != null) ? ((string) this.GPU_group) : "", device = (this.device != null) ? this.device : "", currently_attached = this.currently_attached, other_config = Maps.convert_to_proxy_string_string(this.other_config), type = (this.type != null) ? ((string) this.type) : "", resident_on = (this.resident_on != null) ? ((string) this.resident_on) : "" };
        }

        public override void UpdateFrom(VGPU update)
        {
            this.uuid = update.uuid;
            this.VM = update.VM;
            this.GPU_group = update.GPU_group;
            this.device = update.device;
            this.currently_attached = update.currently_attached;
            this.other_config = update.other_config;
            this.type = update.type;
            this.resident_on = update.resident_on;
        }

        internal void UpdateFromProxy(Proxy_VGPU proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.VM = (proxy.VM == null) ? null : XenRef<WinAPI.VM>.Create(proxy.VM);
            this.GPU_group = (proxy.GPU_group == null) ? null : XenRef<WinAPI.GPU_group>.Create(proxy.GPU_group);
            this.device = (proxy.device == null) ? null : proxy.device;
            this.currently_attached = proxy.currently_attached;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.type = (proxy.type == null) ? null : XenRef<VGPU_type>.Create(proxy.type);
            this.resident_on = (proxy.resident_on == null) ? null : XenRef<PGPU>.Create(proxy.resident_on);
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

        public virtual XenRef<PGPU> resident_on
        {
            get
            {
                return this._resident_on;
            }
            set
            {
                if (!Helper.AreEqual(value, this._resident_on))
                {
                    this._resident_on = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("resident_on");
                }
            }
        }

        public virtual XenRef<VGPU_type> type
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

