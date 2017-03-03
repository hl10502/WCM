namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tunnel : XenObject<Tunnel>
    {
        private XenRef<PIF> _access_PIF;
        private Dictionary<string, string> _other_config;
        private Dictionary<string, string> _status;
        private XenRef<PIF> _transport_PIF;
        private string _uuid;

        public Tunnel()
        {
        }

        public Tunnel(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.access_PIF = Marshalling.ParseRef<PIF>(table, "access_PIF");
            this.transport_PIF = Marshalling.ParseRef<PIF>(table, "transport_PIF");
            this.status = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "status"));
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public Tunnel(Proxy_Tunnel proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Tunnel(string uuid, XenRef<PIF> access_PIF, XenRef<PIF> transport_PIF, Dictionary<string, string> status, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.access_PIF = access_PIF;
            this.transport_PIF = transport_PIF;
            this.status = status;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _tunnel, string _key, string _value)
        {
            session.proxy.tunnel_add_to_other_config(session.uuid, (_tunnel != null) ? _tunnel : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_status(Session session, string _tunnel, string _key, string _value)
        {
            session.proxy.tunnel_add_to_status(session.uuid, (_tunnel != null) ? _tunnel : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, string _transport_pif, string _network)
        {
            return XenRef<Task>.Create(session.proxy.async_tunnel_create(session.uuid, (_transport_pif != null) ? _transport_pif : "", (_network != null) ? _network : "").parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _tunnel)
        {
            return XenRef<Task>.Create(session.proxy.async_tunnel_destroy(session.uuid, (_tunnel != null) ? _tunnel : "").parse());
        }

        public static XenRef<Tunnel> create(Session session, string _transport_pif, string _network)
        {
            return XenRef<Tunnel>.Create(session.proxy.tunnel_create(session.uuid, (_transport_pif != null) ? _transport_pif : "", (_network != null) ? _network : "").parse());
        }

        public bool DeepEquals(Tunnel other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<PIF>>(this._access_PIF, other._access_PIF)) && (Helper.AreEqual2<XenRef<PIF>>(this._transport_PIF, other._transport_PIF) && Helper.AreEqual2<Dictionary<string, string>>(this._status, other._status))) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        public static void destroy(Session session, string _tunnel)
        {
            session.proxy.tunnel_destroy(session.uuid, (_tunnel != null) ? _tunnel : "").parse();
        }

        public static XenRef<PIF> get_access_PIF(Session session, string _tunnel)
        {
            return XenRef<PIF>.Create(session.proxy.tunnel_get_access_pif(session.uuid, (_tunnel != null) ? _tunnel : "").parse());
        }

        public static List<XenRef<Tunnel>> get_all(Session session)
        {
            return XenRef<Tunnel>.Create(session.proxy.tunnel_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Tunnel>, Tunnel> get_all_records(Session session)
        {
            return XenRef<Tunnel>.Create<Proxy_Tunnel>(session.proxy.tunnel_get_all_records(session.uuid).parse());
        }

        public static XenRef<Tunnel> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Tunnel>.Create(session.proxy.tunnel_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _tunnel)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.tunnel_get_other_config(session.uuid, (_tunnel != null) ? _tunnel : "").parse());
        }

        public static Tunnel get_record(Session session, string _tunnel)
        {
            return new Tunnel(session.proxy.tunnel_get_record(session.uuid, (_tunnel != null) ? _tunnel : "").parse());
        }

        public static Dictionary<string, string> get_status(Session session, string _tunnel)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.tunnel_get_status(session.uuid, (_tunnel != null) ? _tunnel : "").parse());
        }

        public static XenRef<PIF> get_transport_PIF(Session session, string _tunnel)
        {
            return XenRef<PIF>.Create(session.proxy.tunnel_get_transport_pif(session.uuid, (_tunnel != null) ? _tunnel : "").parse());
        }

        public static string get_uuid(Session session, string _tunnel)
        {
            return session.proxy.tunnel_get_uuid(session.uuid, (_tunnel != null) ? _tunnel : "").parse();
        }

        public static void remove_from_other_config(Session session, string _tunnel, string _key)
        {
            session.proxy.tunnel_remove_from_other_config(session.uuid, (_tunnel != null) ? _tunnel : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_status(Session session, string _tunnel, string _key)
        {
            session.proxy.tunnel_remove_from_status(session.uuid, (_tunnel != null) ? _tunnel : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Tunnel server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._status, server._status))
            {
                set_status(session, opaqueRef, this._status);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            return null;
        }

        public static void set_other_config(Session session, string _tunnel, Dictionary<string, string> _other_config)
        {
            session.proxy.tunnel_set_other_config(session.uuid, (_tunnel != null) ? _tunnel : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_status(Session session, string _tunnel, Dictionary<string, string> _status)
        {
            session.proxy.tunnel_set_status(session.uuid, (_tunnel != null) ? _tunnel : "", Maps.convert_to_proxy_string_string(_status)).parse();
        }

        public Proxy_Tunnel ToProxy()
        {
            return new Proxy_Tunnel { uuid = (this.uuid != null) ? this.uuid : "", access_PIF = (this.access_PIF != null) ? ((string) this.access_PIF) : "", transport_PIF = (this.transport_PIF != null) ? ((string) this.transport_PIF) : "", status = Maps.convert_to_proxy_string_string(this.status), other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(Tunnel update)
        {
            this.uuid = update.uuid;
            this.access_PIF = update.access_PIF;
            this.transport_PIF = update.transport_PIF;
            this.status = update.status;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Tunnel proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.access_PIF = (proxy.access_PIF == null) ? null : XenRef<PIF>.Create(proxy.access_PIF);
            this.transport_PIF = (proxy.transport_PIF == null) ? null : XenRef<PIF>.Create(proxy.transport_PIF);
            this.status = (proxy.status == null) ? null : Maps.convert_from_proxy_string_string(proxy.status);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public virtual XenRef<PIF> access_PIF
        {
            get
            {
                return this._access_PIF;
            }
            set
            {
                if (!Helper.AreEqual(value, this._access_PIF))
                {
                    this._access_PIF = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("access_PIF");
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

        public virtual Dictionary<string, string> status
        {
            get
            {
                return this._status;
            }
            set
            {
                if (!Helper.AreEqual(value, this._status))
                {
                    this._status = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("status");
                }
            }
        }

        public virtual XenRef<PIF> transport_PIF
        {
            get
            {
                return this._transport_PIF;
            }
            set
            {
                if (!Helper.AreEqual(value, this._transport_PIF))
                {
                    this._transport_PIF = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("transport_PIF");
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

