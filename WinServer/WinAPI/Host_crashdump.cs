namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Host_crashdump : XenObject<Host_crashdump>
    {
        private XenRef<Host> _host;
        private Dictionary<string, string> _other_config;
        private long _size;
        private DateTime _timestamp;
        private string _uuid;

        public Host_crashdump()
        {
        }

        public Host_crashdump(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.host = Marshalling.ParseRef<Host>(table, "host");
            this.timestamp = Marshalling.ParseDateTime(table, "timestamp");
            this.size = Marshalling.ParseLong(table, "size");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public Host_crashdump(Proxy_Host_crashdump proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Host_crashdump(string uuid, XenRef<Host> host, DateTime timestamp, long size, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.host = host;
            this.timestamp = timestamp;
            this.size = size;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _host_crashdump, string _key, string _value)
        {
            session.proxy.host_crashdump_add_to_other_config(session.uuid, (_host_crashdump != null) ? _host_crashdump : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_destroy(Session session, string _host_crashdump)
        {
            return XenRef<Task>.Create(session.proxy.async_host_crashdump_destroy(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse());
        }

        public static XenRef<Task> async_upload(Session session, string _host_crashdump, string _url, Dictionary<string, string> _options)
        {
            return XenRef<Task>.Create(session.proxy.async_host_crashdump_upload(session.uuid, (_host_crashdump != null) ? _host_crashdump : "", (_url != null) ? _url : "", Maps.convert_to_proxy_string_string(_options)).parse());
        }

        public bool DeepEquals(Host_crashdump other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<Host>>(this._host, other._host)) && (Helper.AreEqual2<DateTime>(this._timestamp, other._timestamp) && Helper.AreEqual2<long>(this._size, other._size))) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        public static void destroy(Session session, string _host_crashdump)
        {
            session.proxy.host_crashdump_destroy(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse();
        }

        public static List<XenRef<Host_crashdump>> get_all(Session session)
        {
            return XenRef<Host_crashdump>.Create(session.proxy.host_crashdump_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Host_crashdump>, Host_crashdump> get_all_records(Session session)
        {
            return XenRef<Host_crashdump>.Create<Proxy_Host_crashdump>(session.proxy.host_crashdump_get_all_records(session.uuid).parse());
        }

        public static XenRef<Host_crashdump> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Host_crashdump>.Create(session.proxy.host_crashdump_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static XenRef<Host> get_host(Session session, string _host_crashdump)
        {
            return XenRef<Host>.Create(session.proxy.host_crashdump_get_host(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _host_crashdump)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.host_crashdump_get_other_config(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse());
        }

        public static Host_crashdump get_record(Session session, string _host_crashdump)
        {
            return new Host_crashdump(session.proxy.host_crashdump_get_record(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse());
        }

        public static long get_size(Session session, string _host_crashdump)
        {
            return long.Parse(session.proxy.host_crashdump_get_size(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse());
        }

        public static DateTime get_timestamp(Session session, string _host_crashdump)
        {
            return session.proxy.host_crashdump_get_timestamp(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse();
        }

        public static string get_uuid(Session session, string _host_crashdump)
        {
            return session.proxy.host_crashdump_get_uuid(session.uuid, (_host_crashdump != null) ? _host_crashdump : "").parse();
        }

        public static void remove_from_other_config(Session session, string _host_crashdump, string _key)
        {
            session.proxy.host_crashdump_remove_from_other_config(session.uuid, (_host_crashdump != null) ? _host_crashdump : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Host_crashdump server)
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

        public static void set_other_config(Session session, string _host_crashdump, Dictionary<string, string> _other_config)
        {
            session.proxy.host_crashdump_set_other_config(session.uuid, (_host_crashdump != null) ? _host_crashdump : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_Host_crashdump ToProxy()
        {
            return new Proxy_Host_crashdump { uuid = (this.uuid != null) ? this.uuid : "", host = (this.host != null) ? ((string) this.host) : "", timestamp = this.timestamp, size = this.size.ToString(), other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(Host_crashdump update)
        {
            this.uuid = update.uuid;
            this.host = update.host;
            this.timestamp = update.timestamp;
            this.size = update.size;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Host_crashdump proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.host = (proxy.host == null) ? null : XenRef<Host>.Create(proxy.host);
            this.timestamp = proxy.timestamp;
            this.size = (proxy.size == null) ? 0L : long.Parse(proxy.size);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public static void upload(Session session, string _host_crashdump, string _url, Dictionary<string, string> _options)
        {
            session.proxy.host_crashdump_upload(session.uuid, (_host_crashdump != null) ? _host_crashdump : "", (_url != null) ? _url : "", Maps.convert_to_proxy_string_string(_options)).parse();
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

        public virtual long size
        {
            get
            {
                return this._size;
            }
            set
            {
                if (!Helper.AreEqual(value, this._size))
                {
                    this._size = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("size");
                }
            }
        }

        public virtual DateTime timestamp
        {
            get
            {
                return this._timestamp;
            }
            set
            {
                if (!Helper.AreEqual(value, this._timestamp))
                {
                    this._timestamp = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("timestamp");
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

