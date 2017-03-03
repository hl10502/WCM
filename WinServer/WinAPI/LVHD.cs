namespace WinAPI
{
    using System;
    using System.Collections;

    public class LVHD : XenObject<LVHD>
    {
        private string _uuid;

        public LVHD()
        {
        }

        public LVHD(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
        }

        public LVHD(string uuid)
        {
            this.uuid = uuid;
        }

        public LVHD(Proxy_LVHD proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public static XenRef<Task> async_enable_thin_provisioning(Session session, string _sr, long _initial_allocation, long _allocation_quantum)
        {
            return XenRef<Task>.Create(session.proxy.async_lvhd_enable_thin_provisioning(session.uuid, (_sr != null) ? _sr : "", _initial_allocation.ToString(), _allocation_quantum.ToString()).parse());
        }

        public bool DeepEquals(LVHD other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || Helper.AreEqual2<string>(this._uuid, other._uuid));
        }

        public static void enable_thin_provisioning(Session session, string _sr, long _initial_allocation, long _allocation_quantum)
        {
            session.proxy.lvhd_enable_thin_provisioning(session.uuid, (_sr != null) ? _sr : "", _initial_allocation.ToString(), _allocation_quantum.ToString()).parse();
        }

        public static XenRef<LVHD> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<LVHD>.Create(session.proxy.lvhd_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static LVHD get_record(Session session, string _lvhd)
        {
            return new LVHD(session.proxy.lvhd_get_record(session.uuid, (_lvhd != null) ? _lvhd : "").parse());
        }

        public static string get_uuid(Session session, string _lvhd)
        {
            return session.proxy.lvhd_get_uuid(session.uuid, (_lvhd != null) ? _lvhd : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, LVHD server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            return "";
        }

        public Proxy_LVHD ToProxy()
        {
            return new Proxy_LVHD { uuid = (this.uuid != null) ? this.uuid : "" };
        }

        public override void UpdateFrom(LVHD update)
        {
            this.uuid = update.uuid;
        }

        internal void UpdateFromProxy(Proxy_LVHD proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
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

