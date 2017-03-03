namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Host_patch : XenObject<Host_patch>
    {
        private bool _applied;
        private XenRef<Host> _host;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private XenRef<Pool_patch> _pool_patch;
        private long _size;
        private DateTime _timestamp_applied;
        private string _uuid;
        private string _version;

        public Host_patch()
        {
        }

        public Host_patch(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.version = Marshalling.ParseString(table, "version");
            this.host = Marshalling.ParseRef<Host>(table, "host");
            this.applied = Marshalling.ParseBool(table, "applied");
            this.timestamp_applied = Marshalling.ParseDateTime(table, "timestamp_applied");
            this.size = Marshalling.ParseLong(table, "size");
            this.pool_patch = Marshalling.ParseRef<Pool_patch>(table, "pool_patch");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public Host_patch(Proxy_Host_patch proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Host_patch(string uuid, string name_label, string name_description, string version, XenRef<Host> host, bool applied, DateTime timestamp_applied, long size, XenRef<Pool_patch> pool_patch, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.version = version;
            this.host = host;
            this.applied = applied;
            this.timestamp_applied = timestamp_applied;
            this.size = size;
            this.pool_patch = pool_patch;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _host_patch, string _key, string _value)
        {
            session.proxy.host_patch_add_to_other_config(session.uuid, (_host_patch != null) ? _host_patch : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        [Deprecated("XenServer 4.1")]
        public static string apply(Session session, string _host_patch)
        {
            return session.proxy.host_patch_apply(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<Task> async_apply(Session session, string _host_patch)
        {
            return XenRef<Task>.Create(session.proxy.async_host_patch_apply(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        [Deprecated("XenServer 4.1")]
        public static XenRef<Task> async_destroy(Session session, string _host_patch)
        {
            return XenRef<Task>.Create(session.proxy.async_host_patch_destroy(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        public bool DeepEquals(Host_patch other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<string>(this._version, other._version))) && ((Helper.AreEqual2<XenRef<Host>>(this._host, other._host) && Helper.AreEqual2<bool>(this._applied, other._applied)) && (Helper.AreEqual2<DateTime>(this._timestamp_applied, other._timestamp_applied) && Helper.AreEqual2<long>(this._size, other._size)))) && Helper.AreEqual2<XenRef<Pool_patch>>(this._pool_patch, other._pool_patch)) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        [Deprecated("XenServer 4.1")]
        public static void destroy(Session session, string _host_patch)
        {
            session.proxy.host_patch_destroy(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static List<XenRef<Host_patch>> get_all(Session session)
        {
            return XenRef<Host_patch>.Create(session.proxy.host_patch_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Host_patch>, Host_patch> get_all_records(Session session)
        {
            return XenRef<Host_patch>.Create<Proxy_Host_patch>(session.proxy.host_patch_get_all_records(session.uuid).parse());
        }

        public static bool get_applied(Session session, string _host_patch)
        {
            return session.proxy.host_patch_get_applied(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static List<XenRef<Host_patch>> get_by_name_label(Session session, string _label)
        {
            return XenRef<Host_patch>.Create(session.proxy.host_patch_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<Host_patch> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Host_patch>.Create(session.proxy.host_patch_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static XenRef<Host> get_host(Session session, string _host_patch)
        {
            return XenRef<Host>.Create(session.proxy.host_patch_get_host(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        public static string get_name_description(Session session, string _host_patch)
        {
            return session.proxy.host_patch_get_name_description(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static string get_name_label(Session session, string _host_patch)
        {
            return session.proxy.host_patch_get_name_label(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _host_patch)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.host_patch_get_other_config(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        public static XenRef<Pool_patch> get_pool_patch(Session session, string _host_patch)
        {
            return XenRef<Pool_patch>.Create(session.proxy.host_patch_get_pool_patch(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        public static Host_patch get_record(Session session, string _host_patch)
        {
            return new Host_patch(session.proxy.host_patch_get_record(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        public static long get_size(Session session, string _host_patch)
        {
            return long.Parse(session.proxy.host_patch_get_size(session.uuid, (_host_patch != null) ? _host_patch : "").parse());
        }

        public static DateTime get_timestamp_applied(Session session, string _host_patch)
        {
            return session.proxy.host_patch_get_timestamp_applied(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static string get_uuid(Session session, string _host_patch)
        {
            return session.proxy.host_patch_get_uuid(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static string get_version(Session session, string _host_patch)
        {
            return session.proxy.host_patch_get_version(session.uuid, (_host_patch != null) ? _host_patch : "").parse();
        }

        public static void remove_from_other_config(Session session, string _host_patch, string _key)
        {
            session.proxy.host_patch_remove_from_other_config(session.uuid, (_host_patch != null) ? _host_patch : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Host_patch server)
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

        public static void set_other_config(Session session, string _host_patch, Dictionary<string, string> _other_config)
        {
            session.proxy.host_patch_set_other_config(session.uuid, (_host_patch != null) ? _host_patch : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_Host_patch ToProxy()
        {
            return new Proxy_Host_patch { uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", version = (this.version != null) ? this.version : "", host = (this.host != null) ? ((string) this.host) : "", applied = this.applied, timestamp_applied = this.timestamp_applied, size = this.size.ToString(), pool_patch = (this.pool_patch != null) ? ((string) this.pool_patch) : "", other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(Host_patch update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.version = update.version;
            this.host = update.host;
            this.applied = update.applied;
            this.timestamp_applied = update.timestamp_applied;
            this.size = update.size;
            this.pool_patch = update.pool_patch;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Host_patch proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.version = (proxy.version == null) ? null : proxy.version;
            this.host = (proxy.host == null) ? null : XenRef<Host>.Create(proxy.host);
            this.applied = proxy.applied;
            this.timestamp_applied = proxy.timestamp_applied;
            this.size = (proxy.size == null) ? 0L : long.Parse(proxy.size);
            this.pool_patch = (proxy.pool_patch == null) ? null : XenRef<Pool_patch>.Create(proxy.pool_patch);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public virtual bool applied
        {
            get
            {
                return this._applied;
            }
            set
            {
                if (!Helper.AreEqual(value, this._applied))
                {
                    this._applied = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("applied");
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

        public virtual XenRef<Pool_patch> pool_patch
        {
            get
            {
                return this._pool_patch;
            }
            set
            {
                if (!Helper.AreEqual(value, this._pool_patch))
                {
                    this._pool_patch = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("pool_patch");
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

        public virtual DateTime timestamp_applied
        {
            get
            {
                return this._timestamp_applied;
            }
            set
            {
                if (!Helper.AreEqual(value, this._timestamp_applied))
                {
                    this._timestamp_applied = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("timestamp_applied");
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

        public virtual string version
        {
            get
            {
                return this._version;
            }
            set
            {
                if (!Helper.AreEqual(value, this._version))
                {
                    this._version = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("version");
                }
            }
        }
    }
}

