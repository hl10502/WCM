namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Console : XenObject<WinAPI.Console>
    {
        private string _location;
        private Dictionary<string, string> _other_config;
        private console_protocol _protocol;
        private string _uuid;
        private XenRef<WinAPI.VM> _VM;

        public Console()
        {
        }

        public Console(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.protocol = (console_protocol) Helper.EnumParseDefault(typeof(console_protocol), Marshalling.ParseString(table, "protocol"));
            this.location = Marshalling.ParseString(table, "location");
            this.VM = Marshalling.ParseRef<WinAPI.VM>(table, "VM");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public Console(Proxy_Console proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Console(string uuid, console_protocol protocol, string location, XenRef<WinAPI.VM> VM, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.protocol = protocol;
            this.location = location;
            this.VM = VM;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _console, string _key, string _value)
        {
            session.proxy.console_add_to_other_config(session.uuid, (_console != null) ? _console : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_create(Session session, WinAPI.Console _record)
        {
            return XenRef<Task>.Create(session.proxy.async_console_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _console)
        {
            return XenRef<Task>.Create(session.proxy.async_console_destroy(session.uuid, (_console != null) ? _console : "").parse());
        }

        public static XenRef<WinAPI.Console> create(Session session, WinAPI.Console _record)
        {
            return XenRef<WinAPI.Console>.Create(session.proxy.console_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(WinAPI.Console other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<console_protocol>(this._protocol, other._protocol)) && (Helper.AreEqual2<string>(this._location, other._location) && Helper.AreEqual2<XenRef<WinAPI.VM>>(this._VM, other._VM))) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        public static void destroy(Session session, string _console)
        {
            session.proxy.console_destroy(session.uuid, (_console != null) ? _console : "").parse();
        }

        public static List<XenRef<WinAPI.Console>> get_all(Session session)
        {
            return XenRef<WinAPI.Console>.Create(session.proxy.console_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<WinAPI.Console>, WinAPI.Console> get_all_records(Session session)
        {
            return XenRef<WinAPI.Console>.Create<Proxy_Console>(session.proxy.console_get_all_records(session.uuid).parse());
        }

        public static XenRef<WinAPI.Console> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<WinAPI.Console>.Create(session.proxy.console_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static string get_location(Session session, string _console)
        {
            return session.proxy.console_get_location(session.uuid, (_console != null) ? _console : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _console)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.console_get_other_config(session.uuid, (_console != null) ? _console : "").parse());
        }

        public static console_protocol get_protocol(Session session, string _console)
        {
            return (console_protocol) Helper.EnumParseDefault(typeof(console_protocol), session.proxy.console_get_protocol(session.uuid, (_console != null) ? _console : "").parse());
        }

        public static WinAPI.Console get_record(Session session, string _console)
        {
            return new WinAPI.Console(session.proxy.console_get_record(session.uuid, (_console != null) ? _console : "").parse());
        }

        public static string get_uuid(Session session, string _console)
        {
            return session.proxy.console_get_uuid(session.uuid, (_console != null) ? _console : "").parse();
        }

        public static XenRef<WinAPI.VM> get_VM(Session session, string _console)
        {
            return XenRef<WinAPI.VM>.Create(session.proxy.console_get_vm(session.uuid, (_console != null) ? _console : "").parse());
        }

        public static void remove_from_other_config(Session session, string _console, string _key)
        {
            session.proxy.console_remove_from_other_config(session.uuid, (_console != null) ? _console : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, WinAPI.Console server)
        {
            if (opaqueRef == null)
            {
                Proxy_Console console = this.ToProxy();
                return session.proxy.console_create(session.uuid, console).parse();
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            return null;
        }

        public static void set_other_config(Session session, string _console, Dictionary<string, string> _other_config)
        {
            session.proxy.console_set_other_config(session.uuid, (_console != null) ? _console : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_Console ToProxy()
        {
            return new Proxy_Console { uuid = (this.uuid != null) ? this.uuid : "", protocol = console_protocol_helper.ToString(this.protocol), location = (this.location != null) ? this.location : "", VM = (this.VM != null) ? ((string) this.VM) : "", other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(WinAPI.Console update)
        {
            this.uuid = update.uuid;
            this.protocol = update.protocol;
            this.location = update.location;
            this.VM = update.VM;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Console proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.protocol = (proxy.protocol == null) ? console_protocol.vt100 : ((console_protocol) Helper.EnumParseDefault(typeof(console_protocol), proxy.protocol));
            this.location = (proxy.location == null) ? null : proxy.location;
            this.VM = (proxy.VM == null) ? null : XenRef<WinAPI.VM>.Create(proxy.VM);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public virtual string location
        {
            get
            {
                return this._location;
            }
            set
            {
                if (!Helper.AreEqual(value, this._location))
                {
                    this._location = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("location");
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

        public virtual console_protocol protocol
        {
            get
            {
                return this._protocol;
            }
            set
            {
                if (!Helper.AreEqual(value, this._protocol))
                {
                    this._protocol = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("protocol");
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

