namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Subject : XenObject<Subject>
    {
        private Dictionary<string, string> _other_config;
        private List<XenRef<Role>> _roles;
        private string _subject_identifier;
        private string _uuid;
        public static readonly string SUBJECT_DISPLAYNAME_KEY = "subject-displayname";
        public static readonly string SUBJECT_IS_GROUP_KEY = "subject-is-group";
        public static readonly string SUBJECT_NAME_KEY = "subject-name";

        public Subject()
        {
        }

        public Subject(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.subject_identifier = Marshalling.ParseString(table, "subject_identifier");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.roles = Marshalling.ParseSetRef<Role>(table, "roles");
        }

        public Subject(Proxy_Subject proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Subject(string uuid, string subject_identifier, Dictionary<string, string> other_config, List<XenRef<Role>> roles)
        {
            this.uuid = uuid;
            this.subject_identifier = subject_identifier;
            this.other_config = other_config;
            this.roles = roles;
        }

        public static void add_to_roles(Session session, string _subject, string _role)
        {
            session.proxy.subject_add_to_roles(session.uuid, (_subject != null) ? _subject : "", (_role != null) ? _role : "").parse();
        }

        public static XenRef<Task> async_create(Session session, Subject _record)
        {
            return XenRef<Task>.Create(session.proxy.async_subject_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _subject)
        {
            return XenRef<Task>.Create(session.proxy.async_subject_destroy(session.uuid, (_subject != null) ? _subject : "").parse());
        }

        public static XenRef<Subject> create(Session session, Subject _record)
        {
            return XenRef<Subject>.Create(session.proxy.subject_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(Subject other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._subject_identifier, other._subject_identifier)) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)) && Helper.AreEqual2<List<XenRef<Role>>>(this._roles, other._roles)));
        }

        public static void destroy(Session session, string _subject)
        {
            session.proxy.subject_destroy(session.uuid, (_subject != null) ? _subject : "").parse();
        }

        public static List<XenRef<Subject>> get_all(Session session)
        {
            return XenRef<Subject>.Create(session.proxy.subject_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Subject>, Subject> get_all_records(Session session)
        {
            return XenRef<Subject>.Create<Proxy_Subject>(session.proxy.subject_get_all_records(session.uuid).parse());
        }

        public static XenRef<Subject> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Subject>.Create(session.proxy.subject_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Dictionary<string, string> get_other_config(Session session, string _subject)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.subject_get_other_config(session.uuid, (_subject != null) ? _subject : "").parse());
        }

        public static string[] get_permissions_name_label(Session session, string _subject)
        {
            return session.proxy.subject_get_permissions_name_label(session.uuid, (_subject != null) ? _subject : "").parse();
        }

        public static Subject get_record(Session session, string _subject)
        {
            return new Subject(session.proxy.subject_get_record(session.uuid, (_subject != null) ? _subject : "").parse());
        }

        public static List<XenRef<Role>> get_roles(Session session, string _subject)
        {
            return XenRef<Role>.Create(session.proxy.subject_get_roles(session.uuid, (_subject != null) ? _subject : "").parse());
        }

        public static string get_subject_identifier(Session session, string _subject)
        {
            return session.proxy.subject_get_subject_identifier(session.uuid, (_subject != null) ? _subject : "").parse();
        }

        public static string get_uuid(Session session, string _subject)
        {
            return session.proxy.subject_get_uuid(session.uuid, (_subject != null) ? _subject : "").parse();
        }

        public static void remove_from_roles(Session session, string _subject, string _role)
        {
            session.proxy.subject_remove_from_roles(session.uuid, (_subject != null) ? _subject : "", (_role != null) ? _role : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Subject server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            Proxy_Subject subject = this.ToProxy();
            return session.proxy.subject_create(session.uuid, subject).parse();
        }

        public Proxy_Subject ToProxy()
        {
            return new Proxy_Subject { uuid = (this.uuid != null) ? this.uuid : "", subject_identifier = (this.subject_identifier != null) ? this.subject_identifier : "", other_config = Maps.convert_to_proxy_string_string(this.other_config), roles = (this.roles != null) ? Helper.RefListToStringArray<Role>(this.roles) : new string[0] };
        }

        public override void UpdateFrom(Subject update)
        {
            this.uuid = update.uuid;
            this.subject_identifier = update.subject_identifier;
            this.other_config = update.other_config;
            this.roles = update.roles;
        }

        internal void UpdateFromProxy(Proxy_Subject proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.subject_identifier = (proxy.subject_identifier == null) ? null : proxy.subject_identifier;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.roles = (proxy.roles == null) ? null : XenRef<Role>.Create(proxy.roles);
        }

        public string DisplayName
        {
            get
            {
                string str;
                if (this.other_config.TryGetValue(SUBJECT_DISPLAYNAME_KEY, out str))
                {
                    return str;
                }
                return null;
            }
        }

        public bool IsGroup
        {
            get
            {
                string str;
                bool flag;
                return ((this.other_config.TryGetValue(SUBJECT_IS_GROUP_KEY, out str) && bool.TryParse(str, out flag)) && flag);
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

        public virtual List<XenRef<Role>> roles
        {
            get
            {
                return this._roles;
            }
            set
            {
                if (!Helper.AreEqual(value, this._roles))
                {
                    this._roles = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("roles");
                }
            }
        }

        public virtual string subject_identifier
        {
            get
            {
                return this._subject_identifier;
            }
            set
            {
                if (!Helper.AreEqual(value, this._subject_identifier))
                {
                    this._subject_identifier = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("subject_identifier");
                }
            }
        }

        public string SubjectName
        {
            get
            {
                string str;
                if (this.other_config.TryGetValue(SUBJECT_NAME_KEY, out str))
                {
                    return str;
                }
                return null;
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

