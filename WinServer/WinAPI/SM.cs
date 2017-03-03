namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SM : XenObject<SM>
    {
        private string[] _capabilities;
        private Dictionary<string, string> _configuration;
        private string _copyright;
        private string _driver_filename;
        private Dictionary<string, long> _features;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private string _required_api_version;
        private string[] _required_cluster_stack;
        private string _type;
        private string _uuid;
        private string _vendor;
        private string _version;

        public SM()
        {
        }

        public SM(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.type = Marshalling.ParseString(table, "type");
            this.vendor = Marshalling.ParseString(table, "vendor");
            this.copyright = Marshalling.ParseString(table, "copyright");
            this.version = Marshalling.ParseString(table, "version");
            this.required_api_version = Marshalling.ParseString(table, "required_api_version");
            this.configuration = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "configuration"));
            this.capabilities = Marshalling.ParseStringArray(table, "capabilities");
            this.features = Maps.convert_from_proxy_string_long(Marshalling.ParseHashTable(table, "features"));
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.driver_filename = Marshalling.ParseString(table, "driver_filename");
            this.required_cluster_stack = Marshalling.ParseStringArray(table, "required_cluster_stack");
        }

        public SM(Proxy_SM proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public SM(string uuid, string name_label, string name_description, string type, string vendor, string copyright, string version, string required_api_version, Dictionary<string, string> configuration, string[] capabilities, Dictionary<string, long> features, Dictionary<string, string> other_config, string driver_filename, string[] required_cluster_stack)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.type = type;
            this.vendor = vendor;
            this.copyright = copyright;
            this.version = version;
            this.required_api_version = required_api_version;
            this.configuration = configuration;
            this.capabilities = capabilities;
            this.features = features;
            this.other_config = other_config;
            this.driver_filename = driver_filename;
            this.required_cluster_stack = required_cluster_stack;
        }

        public static void add_to_other_config(Session session, string _sm, string _key, string _value)
        {
            session.proxy.sm_add_to_other_config(session.uuid, (_sm != null) ? _sm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public bool DeepEquals(SM other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<string>(this._type, other._type))) && ((Helper.AreEqual2<string>(this._vendor, other._vendor) && Helper.AreEqual2<string>(this._copyright, other._copyright)) && (Helper.AreEqual2<string>(this._version, other._version) && Helper.AreEqual2<string>(this._required_api_version, other._required_api_version)))) && (((Helper.AreEqual2<Dictionary<string, string>>(this._configuration, other._configuration) && Helper.AreEqual2<string[]>(this._capabilities, other._capabilities)) && (Helper.AreEqual2<Dictionary<string, long>>(this._features, other._features) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config))) && Helper.AreEqual2<string>(this._driver_filename, other._driver_filename))) && Helper.AreEqual2<string[]>(this._required_cluster_stack, other._required_cluster_stack)));
        }

        public static List<XenRef<SM>> get_all(Session session)
        {
            return XenRef<SM>.Create(session.proxy.sm_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<SM>, SM> get_all_records(Session session)
        {
            return XenRef<SM>.Create<Proxy_SM>(session.proxy.sm_get_all_records(session.uuid).parse());
        }

        public static List<XenRef<SM>> get_by_name_label(Session session, string _label)
        {
            return XenRef<SM>.Create(session.proxy.sm_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<SM> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<SM>.Create(session.proxy.sm_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        [Deprecated("XenServer 6.2")]
        public static string[] get_capabilities(Session session, string _sm)
        {
            return session.proxy.sm_get_capabilities(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static Dictionary<string, string> get_configuration(Session session, string _sm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.sm_get_configuration(session.uuid, (_sm != null) ? _sm : "").parse());
        }

        public static string get_copyright(Session session, string _sm)
        {
            return session.proxy.sm_get_copyright(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string get_driver_filename(Session session, string _sm)
        {
            return session.proxy.sm_get_driver_filename(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static Dictionary<string, long> get_features(Session session, string _sm)
        {
            return Maps.convert_from_proxy_string_long(session.proxy.sm_get_features(session.uuid, (_sm != null) ? _sm : "").parse());
        }

        public static string get_name_description(Session session, string _sm)
        {
            return session.proxy.sm_get_name_description(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string get_name_label(Session session, string _sm)
        {
            return session.proxy.sm_get_name_label(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _sm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.sm_get_other_config(session.uuid, (_sm != null) ? _sm : "").parse());
        }

        public static SM get_record(Session session, string _sm)
        {
            return new SM(session.proxy.sm_get_record(session.uuid, (_sm != null) ? _sm : "").parse());
        }

        public static string get_required_api_version(Session session, string _sm)
        {
            return session.proxy.sm_get_required_api_version(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string[] get_required_cluster_stack(Session session, string _sm)
        {
            return session.proxy.sm_get_required_cluster_stack(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string get_type(Session session, string _sm)
        {
            return session.proxy.sm_get_type(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string get_uuid(Session session, string _sm)
        {
            return session.proxy.sm_get_uuid(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string get_vendor(Session session, string _sm)
        {
            return session.proxy.sm_get_vendor(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static string get_version(Session session, string _sm)
        {
            return session.proxy.sm_get_version(session.uuid, (_sm != null) ? _sm : "").parse();
        }

        public static void remove_from_other_config(Session session, string _sm, string _key)
        {
            session.proxy.sm_remove_from_other_config(session.uuid, (_sm != null) ? _sm : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, SM server)
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

        public static void set_other_config(Session session, string _sm, Dictionary<string, string> _other_config)
        {
            session.proxy.sm_set_other_config(session.uuid, (_sm != null) ? _sm : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_SM ToProxy()
        {
            return new Proxy_SM { uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", type = (this.type != null) ? this.type : "", vendor = (this.vendor != null) ? this.vendor : "", copyright = (this.copyright != null) ? this.copyright : "", version = (this.version != null) ? this.version : "", required_api_version = (this.required_api_version != null) ? this.required_api_version : "", configuration = Maps.convert_to_proxy_string_string(this.configuration), capabilities = this.capabilities, features = Maps.convert_to_proxy_string_long(this.features), other_config = Maps.convert_to_proxy_string_string(this.other_config), driver_filename = (this.driver_filename != null) ? this.driver_filename : "", required_cluster_stack = this.required_cluster_stack };
        }

        public override void UpdateFrom(SM update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.type = update.type;
            this.vendor = update.vendor;
            this.copyright = update.copyright;
            this.version = update.version;
            this.required_api_version = update.required_api_version;
            this.configuration = update.configuration;
            this.capabilities = update.capabilities;
            this.features = update.features;
            this.other_config = update.other_config;
            this.driver_filename = update.driver_filename;
            this.required_cluster_stack = update.required_cluster_stack;
        }

        internal void UpdateFromProxy(Proxy_SM proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.type = (proxy.type == null) ? null : proxy.type;
            this.vendor = (proxy.vendor == null) ? null : proxy.vendor;
            this.copyright = (proxy.copyright == null) ? null : proxy.copyright;
            this.version = (proxy.version == null) ? null : proxy.version;
            this.required_api_version = (proxy.required_api_version == null) ? null : proxy.required_api_version;
            this.configuration = (proxy.configuration == null) ? null : Maps.convert_from_proxy_string_string(proxy.configuration);
            this.capabilities = (proxy.capabilities == null) ? new string[0] : proxy.capabilities;
            this.features = (proxy.features == null) ? null : Maps.convert_from_proxy_string_long(proxy.features);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.driver_filename = (proxy.driver_filename == null) ? null : proxy.driver_filename;
            this.required_cluster_stack = (proxy.required_cluster_stack == null) ? new string[0] : proxy.required_cluster_stack;
        }

        public virtual string[] capabilities
        {
            get
            {
                return this._capabilities;
            }
            set
            {
                if (!Helper.AreEqual(value, this._capabilities))
                {
                    this._capabilities = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("capabilities");
                }
            }
        }

        public virtual Dictionary<string, string> configuration
        {
            get
            {
                return this._configuration;
            }
            set
            {
                if (!Helper.AreEqual(value, this._configuration))
                {
                    this._configuration = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("configuration");
                }
            }
        }

        public virtual string copyright
        {
            get
            {
                return this._copyright;
            }
            set
            {
                if (!Helper.AreEqual(value, this._copyright))
                {
                    this._copyright = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("copyright");
                }
            }
        }

        public virtual string driver_filename
        {
            get
            {
                return this._driver_filename;
            }
            set
            {
                if (!Helper.AreEqual(value, this._driver_filename))
                {
                    this._driver_filename = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("driver_filename");
                }
            }
        }

        public virtual Dictionary<string, long> features
        {
            get
            {
                return this._features;
            }
            set
            {
                if (!Helper.AreEqual(value, this._features))
                {
                    this._features = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("features");
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

        public virtual string required_api_version
        {
            get
            {
                return this._required_api_version;
            }
            set
            {
                if (!Helper.AreEqual(value, this._required_api_version))
                {
                    this._required_api_version = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("required_api_version");
                }
            }
        }

        public virtual string[] required_cluster_stack
        {
            get
            {
                return this._required_cluster_stack;
            }
            set
            {
                if (!Helper.AreEqual(value, this._required_cluster_stack))
                {
                    this._required_cluster_stack = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("required_cluster_stack");
                }
            }
        }

        public virtual string type
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

        public virtual string vendor
        {
            get
            {
                return this._vendor;
            }
            set
            {
                if (!Helper.AreEqual(value, this._vendor))
                {
                    this._vendor = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("vendor");
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

