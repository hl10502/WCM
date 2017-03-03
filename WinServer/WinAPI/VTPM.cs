namespace WinAPI
{
    using System;
    using System.Collections;

    public class VTPM : XenObject<VTPM>
    {
        private XenRef<WinAPI.VM> _backend;
        private string _uuid;
        private XenRef<WinAPI.VM> _VM;

        public VTPM()
        {
        }

        public VTPM(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.VM = Marshalling.ParseRef<WinAPI.VM>(table, "VM");
            this.backend = Marshalling.ParseRef<WinAPI.VM>(table, "backend");
        }

        public VTPM(Proxy_VTPM proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VTPM(string uuid, XenRef<WinAPI.VM> VM, XenRef<WinAPI.VM> backend)
        {
            this.uuid = uuid;
            this.VM = VM;
            this.backend = backend;
        }

        public static XenRef<Task> async_create(Session session, VTPM _record)
        {
            return XenRef<Task>.Create(session.proxy.async_vtpm_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _vtpm)
        {
            return XenRef<Task>.Create(session.proxy.async_vtpm_destroy(session.uuid, (_vtpm != null) ? _vtpm : "").parse());
        }

        public static XenRef<VTPM> create(Session session, VTPM _record)
        {
            return XenRef<VTPM>.Create(session.proxy.vtpm_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(VTPM other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<WinAPI.VM>>(this._VM, other._VM)) && Helper.AreEqual2<XenRef<WinAPI.VM>>(this._backend, other._backend)));
        }

        public static void destroy(Session session, string _vtpm)
        {
            session.proxy.vtpm_destroy(session.uuid, (_vtpm != null) ? _vtpm : "").parse();
        }

        public static XenRef<WinAPI.VM> get_backend(Session session, string _vtpm)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.vtpm_get_backend(session.uuid, (_vtpm != null) ? _vtpm : "").parse());
        }

        public static XenRef<VTPM> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VTPM>.Create(session.proxy.vtpm_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static VTPM get_record(Session session, string _vtpm)
        {
            return new VTPM(session.proxy.vtpm_get_record(session.uuid, (_vtpm != null) ? _vtpm : "").parse());
        }

        public static string get_uuid(Session session, string _vtpm)
        {
            return session.proxy.vtpm_get_uuid(session.uuid, (_vtpm != null) ? _vtpm : "").parse();
        }

        public static XenRef<WinAPI.VM> get_VM(Session session, string _vtpm)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.vtpm_get_vm(session.uuid, (_vtpm != null) ? _vtpm : "").parse());
        }

        public override string SaveChanges(Session session, string opaqueRef, VTPM server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            Proxy_VTPM y_vtpm = this.ToProxy();
            return session.proxy.vtpm_create(session.uuid, y_vtpm).parse();
        }

        public Proxy_VTPM ToProxy()
        {
            return new Proxy_VTPM { uuid = (this.uuid != null) ? this.uuid : "", VM = (this.VM != null) ? ((string) this.VM) : "", backend = (this.backend != null) ? ((string) this.backend) : "" };
        }

        public override void UpdateFrom(VTPM update)
        {
            this.uuid = update.uuid;
            this.VM = update.VM;
            this.backend = update.backend;
        }

        internal void UpdateFromProxy(Proxy_VTPM proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.VM = (proxy.VM == null) ? null : XenRef<WinAPI.VM>.Create(proxy.VM);
            this.backend = (proxy.backend == null) ? null : XenRef<WinAPI.VM>.Create(proxy.backend);
        }

        public virtual XenRef<WinAPI.VM> backend
        {
            get
            {
                return this._backend;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backend))
                {
                    this._backend = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backend");
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

