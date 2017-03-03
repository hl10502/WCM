namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Auth : XenObject<Auth>
    {
        public Auth()
        {
        }

        public Auth(Hashtable table)
        {
        }

        public Auth(Proxy_Auth proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public bool DeepEquals(Auth other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return object.ReferenceEquals(this, other);
        }

        public static string[] get_group_membership(Session session, string _subject_identifier)
        {
            return session.proxy.auth_get_group_membership(session.uuid, (_subject_identifier != null) ? _subject_identifier : "").parse();
        }

        public static string get_subject_identifier(Session session, string _subject_name)
        {
            return session.proxy.auth_get_subject_identifier(session.uuid, (_subject_name != null) ? _subject_name : "").parse();
        }

        public static Dictionary<string, string> get_subject_information_from_identifier(Session session, string _subject_identifier)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.auth_get_subject_information_from_identifier(session.uuid, (_subject_identifier != null) ? _subject_identifier : "").parse());
        }

        public override string SaveChanges(Session session, string opaqueRef, Auth server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            return "";
        }

        public Proxy_Auth ToProxy()
        {
            return new Proxy_Auth();
        }

        public override void UpdateFrom(Auth update)
        {
        }

        internal void UpdateFromProxy(Proxy_Auth proxy)
        {
        }
    }
}

