namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Secret : XenObject<Secret>
    {
        private Dictionary<string, string> _other_config;
        private string _uuid;
        private string _value;

        public Secret()
        {
        }

        public Secret(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.value = Marshalling.ParseString(table, "value");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public Secret(Proxy_Secret proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Secret(string uuid, string value, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.value = value;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _secret, string _key, string _value)
        {
            session.proxy.secret_add_to_other_config(session.uuid, (_secret != null) ? _secret : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, Secret _record)
        {
            return XenRef<Task>.Create(session.proxy.async_secret_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _secret)
        {
            return XenRef<Task>.Create(session.proxy.async_secret_destroy(session.uuid, (_secret != null) ? _secret : "").parse());
        }

        public static XenRef<Secret> create(Session session, Secret _record)
        {
            return XenRef<Secret>.Create(session.proxy.secret_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(Secret other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._value, other._value)) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        public static void destroy(Session session, string _secret)
        {
            session.proxy.secret_destroy(session.uuid, (_secret != null) ? _secret : "").parse();
        }

        public static List<XenRef<Secret>> get_all(Session session)
        {
            return XenRef<Secret>.Create(session.proxy.secret_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Secret>, Secret> get_all_records(Session session)
        {
            return XenRef<Secret>.Create<Proxy_Secret>(session.proxy.secret_get_all_records(session.uuid).parse());
        }

        public static XenRef<Secret> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Secret>.Create(session.proxy.secret_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _secret)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.secret_get_other_config(session.uuid, (_secret != null) ? _secret : "").parse());
        }

        public static Secret get_record(Session session, string _secret)
        {
            return new Secret(session.proxy.secret_get_record(session.uuid, (_secret != null) ? _secret : "").parse());
        }

        public static string get_uuid(Session session, string _secret)
        {
            return session.proxy.secret_get_uuid(session.uuid, (_secret != null) ? _secret : "").parse();
        }

        public static string get_value(Session session, string _secret)
        {
            return session.proxy.secret_get_value(session.uuid, (_secret != null) ? _secret : "").parse();
        }

        public static void remove_from_other_config(Session session, string _secret, string _key)
        {
            session.proxy.secret_remove_from_other_config(session.uuid, (_secret != null) ? _secret : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Secret server)
        {
            if (opaqueRef == null)
            {
                Proxy_Secret secret = this.ToProxy();
                return session.proxy.secret_create(session.uuid, secret).parse();
            }
            if (!Helper.AreEqual2<string>(this._value, server._value))
            {
                set_value(session, opaqueRef, this._value);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            return null;
        }

        public static void set_other_config(Session session, string _secret, Dictionary<string, string> _other_config)
        {
            session.proxy.secret_set_other_config(session.uuid, (_secret != null) ? _secret : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_value(Session session, string _secret, string _value)
        {
            session.proxy.secret_set_value(session.uuid, (_secret != null) ? _secret : "", (_value != null) ? _value : "").parse();
        }

        public Proxy_Secret ToProxy()
        {
            return new Proxy_Secret { uuid = (this.uuid != null) ? this.uuid : "", value = (this.value != null) ? this.value : "", other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(Secret update)
        {
            this.uuid = update.uuid;
            this.value = update.value;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Secret proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.value = (proxy.value == null) ? null : proxy.value;
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

        public virtual string value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (!Helper.AreEqual(value, this._value))
                {
                    this._value = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("value");
                }
            }
        }
    }
}

