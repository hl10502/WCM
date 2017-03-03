namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Bond : XenObject<Bond>
    {
        private long _links_up;
        private XenRef<PIF> _master;
        private bond_mode _mode;
        private Dictionary<string, string> _other_config;
        private XenRef<PIF> _primary_slave;
        private Dictionary<string, string> _properties;
        private List<XenRef<PIF>> _slaves;
        private string _uuid;

        public Bond()
        {
        }

        public Bond(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.master = Marshalling.ParseRef<PIF>(table, "master");
            this.slaves = Marshalling.ParseSetRef<PIF>(table, "slaves");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.primary_slave = Marshalling.ParseRef<PIF>(table, "primary_slave");
            this.mode = (bond_mode) Helper.EnumParseDefault(typeof(bond_mode), Marshalling.ParseString(table, "mode"));
            this.properties = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "properties"));
            this.links_up = Marshalling.ParseLong(table, "links_up");
        }

        public Bond(Proxy_Bond proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Bond(string uuid, XenRef<PIF> master, List<XenRef<PIF>> slaves, Dictionary<string, string> other_config, XenRef<PIF> primary_slave, bond_mode mode, Dictionary<string, string> properties, long links_up)
        {
            this.uuid = uuid;
            this.master = master;
            this.slaves = slaves;
            this.other_config = other_config;
            this.primary_slave = primary_slave;
            this.mode = mode;
            this.properties = properties;
            this.links_up = links_up;
        }

        public static void add_to_other_config(Session session, string _bond, string _key, string _value)
        {
            session.proxy.bond_add_to_other_config(session.uuid, (_bond != null) ? _bond : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, string _network, List<XenRef<PIF>> _members, string _mac)
        {
            return XenRef<Task>.Create(session.proxy.async_bond_create(session.uuid, (_network != null) ? _network : "", (_members != null) ? Helper.RefListToStringArray<PIF>(_members) : new string[0], (_mac != null) ? _mac : "").parse());
        }

        public static XenRef<Task> async_create(Session session, string _network, List<XenRef<PIF>> _members, string _mac, bond_mode _mode)
        {
            return XenRef<Task>.Create(session.proxy.async_bond_create(session.uuid, (_network != null) ? _network : "", (_members != null) ? Helper.RefListToStringArray<PIF>(_members) : new string[0], (_mac != null) ? _mac : "", bond_mode_helper.ToString(_mode)).parse());
        }

        public static XenRef<Task> async_create(Session session, string _network, List<XenRef<PIF>> _members, string _mac, bond_mode _mode, Dictionary<string, string> _properties)
        {
            return XenRef<Task>.Create(session.proxy.async_bond_create(session.uuid, (_network != null) ? _network : "", (_members != null) ? Helper.RefListToStringArray<PIF>(_members) : new string[0], (_mac != null) ? _mac : "", bond_mode_helper.ToString(_mode), Maps.convert_to_proxy_string_string(_properties)).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _bond)
        {
            return XenRef<Task>.Create(session.proxy.async_bond_destroy(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static XenRef<Task> async_set_mode(Session session, string _bond, bond_mode _value)
        {
            return XenRef<Task>.Create(session.proxy.async_bond_set_mode(session.uuid, (_bond != null) ? _bond : "", bond_mode_helper.ToString(_value)).parse());
        }

        public static XenRef<Task> async_set_property(Session session, string _bond, string _name, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_bond_set_property(session.uuid, (_bond != null) ? _bond : "", (_name != null) ? _name : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Bond> create(Session session, string _network, List<XenRef<PIF>> _members, string _mac)
        {
            return XenRef<Bond>.Create(session.proxy.bond_create(session.uuid, (_network != null) ? _network : "", (_members != null) ? Helper.RefListToStringArray<PIF>(_members) : new string[0], (_mac != null) ? _mac : "").parse());
        }

        public static XenRef<Bond> create(Session session, string _network, List<XenRef<PIF>> _members, string _mac, bond_mode _mode)
        {
            return XenRef<Bond>.Create(session.proxy.bond_create(session.uuid, (_network != null) ? _network : "", (_members != null) ? Helper.RefListToStringArray<PIF>(_members) : new string[0], (_mac != null) ? _mac : "", bond_mode_helper.ToString(_mode)).parse());
        }

        public static XenRef<Bond> create(Session session, string _network, List<XenRef<PIF>> _members, string _mac, bond_mode _mode, Dictionary<string, string> _properties)
        {
            return XenRef<Bond>.Create(session.proxy.bond_create(session.uuid, (_network != null) ? _network : "", (_members != null) ? Helper.RefListToStringArray<PIF>(_members) : new string[0], (_mac != null) ? _mac : "", bond_mode_helper.ToString(_mode), Maps.convert_to_proxy_string_string(_properties)).parse());
        }

        public bool DeepEquals(Bond other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<XenRef<PIF>>(this._master, other._master)) && (Helper.AreEqual2<List<XenRef<PIF>>>(this._slaves, other._slaves) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config))) && ((Helper.AreEqual2<XenRef<PIF>>(this._primary_slave, other._primary_slave) && Helper.AreEqual2<bond_mode>(this._mode, other._mode)) && Helper.AreEqual2<Dictionary<string, string>>(this._properties, other._properties))) && Helper.AreEqual2<long>(this._links_up, other._links_up)));
        }

        public static void destroy(Session session, string _bond)
        {
            session.proxy.bond_destroy(session.uuid, (_bond != null) ? _bond : "").parse();
        }

        public static List<XenRef<Bond>> get_all(Session session)
        {
            return XenRef<Bond>.Create(session.proxy.bond_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Bond>, Bond> get_all_records(Session session)
        {
            return XenRef<Bond>.Create<Proxy_Bond>(session.proxy.bond_get_all_records(session.uuid).parse());
        }

        public static XenRef<Bond> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Bond>.Create(session.proxy.bond_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static long get_links_up(Session session, string _bond)
        {
            return long.Parse(session.proxy.bond_get_links_up(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static XenRef<PIF> get_master(Session session, string _bond)
        {
            return XenRef<PIF>.Create(session.proxy.bond_get_master(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static bond_mode get_mode(Session session, string _bond)
        {
            return (bond_mode) Helper.EnumParseDefault(typeof(bond_mode), session.proxy.bond_get_mode(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _bond)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.bond_get_other_config(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static XenRef<PIF> get_primary_slave(Session session, string _bond)
        {
            return XenRef<PIF>.Create(session.proxy.bond_get_primary_slave(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static Dictionary<string, string> get_properties(Session session, string _bond)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.bond_get_properties(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static Bond get_record(Session session, string _bond)
        {
            return new Bond(session.proxy.bond_get_record(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static List<XenRef<PIF>> get_slaves(Session session, string _bond)
        {
            return XenRef<PIF>.Create(session.proxy.bond_get_slaves(session.uuid, (_bond != null) ? _bond : "").parse());
        }

        public static string get_uuid(Session session, string _bond)
        {
            return session.proxy.bond_get_uuid(session.uuid, (_bond != null) ? _bond : "").parse();
        }

        public static void remove_from_other_config(Session session, string _bond, string _key)
        {
            session.proxy.bond_remove_from_other_config(session.uuid, (_bond != null) ? _bond : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Bond server)
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

        public static void set_mode(Session session, string _bond, bond_mode _value)
        {
            session.proxy.bond_set_mode(session.uuid, (_bond != null) ? _bond : "", bond_mode_helper.ToString(_value)).parse();
        }

        public static void set_other_config(Session session, string _bond, Dictionary<string, string> _other_config)
        {
            session.proxy.bond_set_other_config(session.uuid, (_bond != null) ? _bond : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_property(Session session, string _bond, string _name, string _value)
        {
            session.proxy.bond_set_property(session.uuid, (_bond != null) ? _bond : "", (_name != null) ? _name : "", (_value != null) ? _value : "").parse();
        }

        public Proxy_Bond ToProxy()
        {
            return new Proxy_Bond { uuid = (this.uuid != null) ? this.uuid : "", master = (this.master != null) ? ((string) this.master) : "", slaves = (this.slaves != null) ? Helper.RefListToStringArray<PIF>(this.slaves) : new string[0], other_config = Maps.convert_to_proxy_string_string(this.other_config), primary_slave = (this.primary_slave != null) ? ((string) this.primary_slave) : "", mode = bond_mode_helper.ToString(this.mode), properties = Maps.convert_to_proxy_string_string(this.properties), links_up = this.links_up.ToString() };
        }

        public override void UpdateFrom(Bond update)
        {
            this.uuid = update.uuid;
            this.master = update.master;
            this.slaves = update.slaves;
            this.other_config = update.other_config;
            this.primary_slave = update.primary_slave;
            this.mode = update.mode;
            this.properties = update.properties;
            this.links_up = update.links_up;
        }

        internal void UpdateFromProxy(Proxy_Bond proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.master = (proxy.master == null) ? null : XenRef<PIF>.Create(proxy.master);
            this.slaves = (proxy.slaves == null) ? null : XenRef<PIF>.Create(proxy.slaves);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.primary_slave = (proxy.primary_slave == null) ? null : XenRef<PIF>.Create(proxy.primary_slave);
            this.mode = (proxy.mode == null) ? bond_mode.balance_slb : ((bond_mode) Helper.EnumParseDefault(typeof(bond_mode), proxy.mode));
            this.properties = (proxy.properties == null) ? null : Maps.convert_from_proxy_string_string(proxy.properties);
            this.links_up = (proxy.links_up == null) ? 0L : long.Parse(proxy.links_up);
        }

        public virtual long links_up
        {
            get
            {
                return this._links_up;
            }
            set
            {
                if (!Helper.AreEqual(value, this._links_up))
                {
                    this._links_up = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("links_up");
                }
            }
        }

        public virtual XenRef<PIF> master
        {
            get
            {
                return this._master;
            }
            set
            {
                if (!Helper.AreEqual(value, this._master))
                {
                    this._master = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("master");
                }
            }
        }

        public virtual bond_mode mode
        {
            get
            {
                return this._mode;
            }
            set
            {
                if (!Helper.AreEqual(value, this._mode))
                {
                    this._mode = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("mode");
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

        public virtual XenRef<PIF> primary_slave
        {
            get
            {
                return this._primary_slave;
            }
            set
            {
                if (!Helper.AreEqual(value, this._primary_slave))
                {
                    this._primary_slave = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("primary_slave");
                }
            }
        }

        public virtual Dictionary<string, string> properties
        {
            get
            {
                return this._properties;
            }
            set
            {
                if (!Helper.AreEqual(value, this._properties))
                {
                    this._properties = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("properties");
                }
            }
        }

        public virtual List<XenRef<PIF>> slaves
        {
            get
            {
                return this._slaves;
            }
            set
            {
                if (!Helper.AreEqual(value, this._slaves))
                {
                    this._slaves = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("slaves");
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

