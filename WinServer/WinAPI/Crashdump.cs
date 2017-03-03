namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Crashdump : XenObject<Crashdump>
    {
        private Dictionary<string, string> _other_config;
        private string _uuid;
        private XenRef<WinAPI.VDI> _VDI;
        private XenRef<WinAPI.VM> _VM;

        public Crashdump()
        {
        }

        public Crashdump(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.VM = Marshalling.ParseRef<WinAPI.VM>(table, "VM");
            this.VDI = Marshalling.ParseRef<WinAPI.VDI>(table, "VDI");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public Crashdump(Proxy_Crashdump proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Crashdump(string uuid, XenRef<WinAPI.VM> VM, XenRef<WinAPI.VDI> VDI, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.VM = VM;
            this.VDI = VDI;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _crashdump, string _key, string _value)
        {
            session.proxy.crashdump_add_to_other_config(session.uuid, (_crashdump != null) ? _crashdump : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_destroy(Session session, string _crashdump)
        {
            return XenRef<Task>.Create(session.proxy.async_crashdump_destroy(session.uuid, (_crashdump != null) ? _crashdump : "").parse());
        }

        public bool DeepEquals(Crashdump other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<WinAPI.VM>>(this._VM, other._VM)) && Helper.AreEqual2<XenRef<WinAPI.VDI>>(this._VDI, other._VDI)) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        public static void destroy(Session session, string _crashdump)
        {
            session.proxy.crashdump_destroy(session.uuid, (_crashdump != null) ? _crashdump : "").parse();
        }

        public static List<XenRef<Crashdump>> get_all(Session session)
        {
            return XenRef<Crashdump>.Create(session.proxy.crashdump_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Crashdump>, Crashdump> get_all_records(Session session)
        {
            return XenRef<Crashdump>.Create<Proxy_Crashdump>(session.proxy.crashdump_get_all_records(session.uuid).parse());
        }

        public static XenRef<Crashdump> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Crashdump>.Create(session.proxy.crashdump_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _crashdump)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.crashdump_get_other_config(session.uuid, (_crashdump != null) ? _crashdump : "").parse());
        }

        public static Crashdump get_record(Session session, string _crashdump)
        {
            return new Crashdump(session.proxy.crashdump_get_record(session.uuid, (_crashdump != null) ? _crashdump : "").parse());
        }

        public static string get_uuid(Session session, string _crashdump)
        {
            return session.proxy.crashdump_get_uuid(session.uuid, (_crashdump != null) ? _crashdump : "").parse();
        }

        public static XenRef<WinAPI.VDI> get_VDI(Session session, string _crashdump)
        {
            return XenRef<WinAPI.VDI>.Create(session.proxy.crashdump_get_vdi(session.uuid, (_crashdump != null) ? _crashdump : "").parse());
        }

        public static XenRef<WinAPI.VM> get_VM(Session session, string _crashdump)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.crashdump_get_vm(session.uuid, (_crashdump != null) ? _crashdump : "").parse());
        }

        public static void remove_from_other_config(Session session, string _crashdump, string _key)
        {
            session.proxy.crashdump_remove_from_other_config(session.uuid, (_crashdump != null) ? _crashdump : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Crashdump server)
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

        public static void set_other_config(Session session, string _crashdump, Dictionary<string, string> _other_config)
        {
            session.proxy.crashdump_set_other_config(session.uuid, (_crashdump != null) ? _crashdump : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_Crashdump ToProxy()
        {
            return new Proxy_Crashdump { uuid = (this.uuid != null) ? this.uuid : "", VM = (this.VM != null) ? ((string) this.VM) : "", VDI = (this.VDI != null) ? ((string) this.VDI) : "", other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(Crashdump update)
        {
            this.uuid = update.uuid;
            this.VM = update.VM;
            this.VDI = update.VDI;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Crashdump proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.VM = (proxy.VM == null) ? null : XenRef<WinAPI.VM>.Create(proxy.VM);
            this.VDI = (proxy.VDI == null) ? null : XenRef<WinAPI.VDI>.Create(proxy.VDI);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
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

