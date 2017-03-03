namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Role : XenObject<Role>
    {
        private string _name_description;
        private string _name_label;
        private List<XenRef<Role>> _subroles;
        private string _uuid;

        public Role()
        {
        }

        public Role(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.subroles = Marshalling.ParseSetRef<Role>(table, "subroles");
        }

        public Role(Proxy_Role proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Role(string uuid, string name_label, string name_description, List<XenRef<Role>> subroles)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.subroles = subroles;
        }

        public bool DeepEquals(Role other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && Helper.AreEqual2<string>(this._name_description, other._name_description)) && Helper.AreEqual2<List<XenRef<Role>>>(this._subroles, other._subroles)));
        }

        public static List<XenRef<Role>> get_all(Session session)
        {
            return XenRef<Role>.Create(session.proxy.role_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Role>, Role> get_all_records(Session session)
        {
            return XenRef<Role>.Create<Proxy_Role>(session.proxy.role_get_all_records(session.uuid).parse());
        }

        public static List<XenRef<Role>> get_by_name_label(Session session, string _label)
        {
            return XenRef<Role>.Create(session.proxy.role_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static List<XenRef<Role>> get_by_permission(Session session, string _role)
        {
            return XenRef<Role>.Create(session.proxy.role_get_by_permission(session.uuid, (_role != null) ? _role : "").parse());
        }

        public static List<XenRef<Role>> get_by_permission_name_label(Session session, string _label)
        {
            return XenRef<Role>.Create(session.proxy.role_get_by_permission_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<Role> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Role>.Create(session.proxy.role_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static string get_name_description(Session session, string _role)
        {
            return session.proxy.role_get_name_description(session.uuid, (_role != null) ? _role : "").parse();
        }

        public static string get_name_label(Session session, string _role)
        {
            return session.proxy.role_get_name_label(session.uuid, (_role != null) ? _role : "").parse();
        }

        public static List<XenRef<Role>> get_permissions(Session session, string _role)
        {
            return XenRef<Role>.Create(session.proxy.role_get_permissions(session.uuid, (_role != null) ? _role : "").parse());
        }

        public static string[] get_permissions_name_label(Session session, string _role)
        {
            return session.proxy.role_get_permissions_name_label(session.uuid, (_role != null) ? _role : "").parse();
        }

        public static Role get_record(Session session, string _role)
        {
            return new Role(session.proxy.role_get_record(session.uuid, (_role != null) ? _role : "").parse());
        }

        public static List<XenRef<Role>> get_subroles(Session session, string _role)
        {
            return XenRef<Role>.Create(session.proxy.role_get_subroles(session.uuid, (_role != null) ? _role : "").parse());
        }

        public static string get_uuid(Session session, string _role)
        {
            return session.proxy.role_get_uuid(session.uuid, (_role != null) ? _role : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Role server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            return "";
        }

        public Proxy_Role ToProxy()
        {
            return new Proxy_Role { uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", subroles = (this.subroles != null) ? Helper.RefListToStringArray<Role>(this.subroles) : new string[0] };
        }

        public override void UpdateFrom(Role update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.subroles = update.subroles;
        }

        internal void UpdateFromProxy(Proxy_Role proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.subroles = (proxy.subroles == null) ? null : XenRef<Role>.Create(proxy.subroles);
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

        public virtual List<XenRef<Role>> subroles
        {
            get
            {
                return this._subroles;
            }
            set
            {
                if (!Helper.AreEqual(value, this._subroles))
                {
                    this._subroles = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("subroles");
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

