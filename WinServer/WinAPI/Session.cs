namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;

    public class Session : XenObject<Session>
    {
        private bool _isLocalSuperuser;
        private WinAPI.Proxy _proxy;
        private XenRef<WinAPI.Subject> _subject;
        private string _userSid;
        private string _uuid;
        public API_Version APIVersion;
        private string[] permissions;
        public static IWebProxy Proxy = null;
        private List<Role> roles;
        public const int STANDARD_TIMEOUT = 0x5265c00;
        public object Tag;
        public static string UserAgent = string.Format("WinAPI/{0}", Helper.APIVersionString(API_Version.API_2_5));

        public Session(string url) : this(0x5265c00, url)
        {
        }

        public Session(int timeout, string url)
        {
            this.APIVersion = API_Version.API_1_1;
            this._isLocalSuperuser = true;
            this.roles = new List<Role>();
            this._proxy = XmlRpcProxyGen.Create<WinAPI.Proxy>();
            this._proxy.Url = url;
            this._proxy.NonStandard = XmlRpcNonStandard.All;
            this._proxy.Timeout = timeout;
            this._proxy.UseIndentation = false;
            this._proxy.UserAgent = UserAgent;
            this._proxy.KeepAlive = true;
            this._proxy.Proxy = Proxy;
        }

        public Session(string host, int port) : this(0x5265c00, host, port)
        {
        }

        public Session(string url, string opaque_ref) : this(0x5265c00, url)
        {
            this._uuid = opaque_ref;
            this.SetAPIVersion();
            if (this.APIVersion >= API_Version.API_1_6)
            {
                this.SetADDetails();
            }
        }

        public Session(Session session, int timeout) : this(timeout, session.Url)
        {
            this._uuid = session.uuid;
            this.APIVersion = session.APIVersion;
            this._isLocalSuperuser = session._isLocalSuperuser;
            this._subject = session._subject;
            this._userSid = session._userSid;
        }

        public Session(int timeout, string host, int port) : this(timeout, GetUrl(host, port))
        {
        }

        public void add_to_other_config(string _key, string _value)
        {
            add_to_other_config(this, this.uuid, _key, _value);
        }

        public static void add_to_other_config(Session session, string _self, string _key, string _value)
        {
            session.proxy.session_add_to_other_config(session.uuid, (_self != null) ? _self : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public XenRef<Task> async_get_all_subject_identifiers()
        {
            return async_get_all_subject_identifiers(this);
        }

        public static XenRef<Task> async_get_all_subject_identifiers(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_session_get_all_subject_identifiers(session.uuid).parse());
        }

        public XenRef<Task> async_logout_subject_identifier(string subject_identifier)
        {
            return async_logout_subject_identifier(this, subject_identifier);
        }

        public static XenRef<Task> async_logout_subject_identifier(Session session, string subject_identifier)
        {
            return XenRef<Task>.Create(session.proxy.async_session_logout_subject_identifier(session.uuid, subject_identifier).parse());
        }

        public void change_password(string oldPassword, string newPassword)
        {
            this.change_password(this, oldPassword, newPassword);
        }

        public void change_password(Session session2, string oldPassword, string newPassword)
        {
            this.proxy.session_change_password(session2.uuid, oldPassword, newPassword).parse();
        }

        public string[] get_all_subject_identifiers()
        {
            return get_all_subject_identifiers(this);
        }

        public static string[] get_all_subject_identifiers(Session session)
        {
            return session.proxy.session_get_all_subject_identifiers(session.uuid).parse();
        }

        public string get_auth_user_sid()
        {
            return get_auth_user_sid(this, this.uuid);
        }

        public static string get_auth_user_sid(Session session, string _self)
        {
            return session.proxy.session_get_auth_user_sid(session.uuid, (_self != null) ? _self : "").parse();
        }

        public bool get_is_local_superuser()
        {
            return get_is_local_superuser(this, this.uuid);
        }

        public static bool get_is_local_superuser(Session session, string _self)
        {
            return session.proxy.session_get_is_local_superuser(session.uuid, (_self != null) ? _self : "").parse();
        }

        public DateTime get_last_active()
        {
            return get_last_active(this, this.uuid);
        }

        public static DateTime get_last_active(Session session, string _self)
        {
            return session.proxy.session_get_last_active(session.uuid, (_self != null) ? _self : "").parse();
        }

        public Dictionary<string, string> get_other_config()
        {
            return get_other_config(this, this.uuid);
        }

        public static Dictionary<string, string> get_other_config(Session session, string _self)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.session_get_other_config(session.uuid, (_self != null) ? _self : "").parse());
        }

        public bool get_pool()
        {
            return get_pool(this, this.uuid);
        }

        public static bool get_pool(Session session, string _self)
        {
            return session.proxy.session_get_pool(session.uuid, (_self != null) ? _self : "").parse();
        }

        public static string[] get_rbac_permissions(Session session, string _self)
        {
            return session.proxy.session_get_rbac_permissions(session.uuid, (_self != null) ? _self : "").parse();
        }

        public static Session get_record(Session session, string _session)
        {
            Session session2 = new Session(0x5265c00, session.proxy.Url) {
                _uuid = _session
            };
            session2.SetAPIVersion();
            return session2;
        }

        public XenRef<WinAPI.Subject> get_subject()
        {
            return get_subject(this, this.uuid);
        }

        public static XenRef<WinAPI.Subject> get_subject(Session session, string _self)
        {
            return new XenRef<WinAPI.Subject>(session.proxy.session_get_subject(session.uuid, (_self != null) ? _self : "").parse());
        }

        public string get_this_host()
        {
            return get_this_host(this, this.uuid);
        }

        public static string get_this_host(Session session, string _self)
        {
            return session.proxy.session_get_this_host(session.uuid, (_self != null) ? _self : "").parse();
        }

        public string get_this_user()
        {
            return get_this_user(this, this.uuid);
        }

        public static string get_this_user(Session session, string _self)
        {
            return session.proxy.session_get_this_user(session.uuid, (_self != null) ? _self : "").parse();
        }

        private static string GetUrl(string hostname, int port)
        {
            return string.Format("{0}://{1}:{2}", ((port == 0x1f90) || (port == 80)) ? "http" : "https", hostname, port);
        }

        public void local_logout()
        {
            this.local_logout(this);
        }

        public void local_logout(string session_uuid)
        {
            if (session_uuid != null)
            {
                this.proxy.session_local_logout(session_uuid).parse();
            }
        }

        public void local_logout(Session session2)
        {
            this.local_logout(session2._uuid);
            session2._uuid = null;
        }

        public void login_with_password(string username, string password)
        {
            this._uuid = this.proxy.session_login_with_password(username, password).parse();
            this.SetAPIVersion();
        }

        public void login_with_password(string username, string password, string version)
        {
            try
            {
                this._uuid = this.proxy.session_login_with_password(username, password, version).parse();
                this.SetAPIVersion();
                if (this.APIVersion >= API_Version.API_1_6)
                {
                    this.SetADDetails();
                }
            }
            catch (Failure failure)
            {
                if (failure.ErrorDescription[0] != "MESSAGE_PARAMETER_COUNT_MISMATCH")
                {
                    throw;
                }
                this.login_with_password(username, password);
            }
        }

        public void login_with_password(string username, string password, API_Version version)
        {
            this.login_with_password(username, password, Helper.APIVersionString(version));
        }

        public void login_with_password(string username, string password, string version, string originator)
        {
            try
            {
                this._uuid = this.proxy.session_login_with_password(username, password, version, originator).parse();
                this.SetAPIVersion();
                if (this.APIVersion >= API_Version.API_1_6)
                {
                    this.SetADDetails();
                }
            }
            catch (Failure failure)
            {
                if (failure.ErrorDescription[0] != "MESSAGE_PARAMETER_COUNT_MISMATCH")
                {
                    throw;
                }
                this.login_with_password(username, password, version);
            }
        }

        public void logout()
        {
            this.logout(this);
        }

        public void logout(string _self)
        {
            if (_self != null)
            {
                this.proxy.session_logout(_self).parse();
            }
        }

        public void logout(Session session2)
        {
            this.logout(session2._uuid);
            session2._uuid = null;
        }

        public string logout_subject_identifier(string subject_identifier)
        {
            return logout_subject_identifier(this, subject_identifier);
        }

        public static string logout_subject_identifier(Session session, string subject_identifier)
        {
            return session.proxy.session_logout_subject_identifier(session.uuid, subject_identifier).parse();
        }

        public void remove_from_other_config(string _key)
        {
            remove_from_other_config(this, this.uuid, _key);
        }

        public static void remove_from_other_config(Session session, string _self, string _key)
        {
            session.proxy.session_remove_from_other_config(session.uuid, (_self != null) ? _self : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string _serverOpaqueRef, Session serverObject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void set_other_config(Dictionary<string, string> _other_config)
        {
            set_other_config(this, this.uuid, _other_config);
        }

        public static void set_other_config(Session session, string _self, Dictionary<string, string> _other_config)
        {
            session.proxy.session_set_other_config(session.uuid, (_self != null) ? _self : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        private void SetADDetails()
        {
            this._isLocalSuperuser = this.get_is_local_superuser();
            if (!this.IsLocalSuperuser)
            {
                this._subject = this.get_subject();
                this._userSid = this.get_auth_user_sid();
                UserDetails.UpdateDetails(this._userSid, this);
                if (this.APIVersion > API_Version.API_1_6)
                {
                    this.permissions = get_rbac_permissions(this, this.uuid);
                    Dictionary<XenRef<Role>, Role> dictionary = Role.get_all_records(this);
                    foreach (string str in this.permissions)
                    {
                        foreach (XenRef<Role> ref2 in dictionary.Keys)
                        {
                            Role item = dictionary[ref2];
                            if ((item.subroles.Count > 0) && (item.name_label == str))
                            {
                                item.opaque_ref = ref2.opaque_ref;
                                this.roles.Add(item);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SetAPIVersion()
        {
            foreach (Pool pool in Pool.get_all_records(this).Values)
            {
                Host host = Host.get_record(this, (string) pool.master);
                this.APIVersion = Helper.GetAPIVersion(host.API_version_major, host.API_version_minor);
                break;
            }
        }

        public void slave_local_login_with_password(string username, string password)
        {
            this._uuid = this.proxy.session_slave_local_login_with_password(username, password).parse();
            this.APIVersion = API_Version.API_2_5;
        }

        public override void UpdateFrom(Session update)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public virtual UserDetails CurrentUserDetails
        {
            get
            {
                if (this._userSid != null)
                {
                    return UserDetails.Sid_To_UserDetails[this._userSid];
                }
                return null;
            }
        }

        public virtual bool IsLocalSuperuser
        {
            get
            {
                return this._isLocalSuperuser;
            }
        }

        public string[] Permissions
        {
            get
            {
                return this.permissions;
            }
        }

        public WinAPI.Proxy proxy
        {
            get
            {
                return this._proxy;
            }
        }

        public List<Role> Roles
        {
            get
            {
                return this.roles;
            }
        }

        public XenRef<WinAPI.Subject> Subject
        {
            get
            {
                return this._subject;
            }
        }

        public string Url
        {
            get
            {
                return this._proxy.Url;
            }
        }

        public string UserSid
        {
            get
            {
                return this._userSid;
            }
        }

        public string uuid
        {
            get
            {
                return this._uuid;
            }
        }
    }
}

