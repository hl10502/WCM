namespace WinAPI
{
    using System;

    public class Event : XenObject<Event>
    {
        private long _id;

        public Event()
        {
        }

        internal Event(Proxy_Event proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public static Events from(Session session, string[] _classes, string _token, double _timeout)
        {
            return session.proxy.event_from(session.uuid, _classes, _token, _timeout).parse();
        }

        public static string get_by_uuid(Session session, string _uuid)
        {
            return session.proxy.event_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse();
        }

        public static long get_id(Session session, string _event)
        {
            return long.Parse(session.proxy.event_get_id(session.uuid, (_event != null) ? _event : "").parse());
        }

        public static Event get_record(Session session, string _event)
        {
            return new Event(session.proxy.event_get_record(session.uuid, (_event != null) ? _event : "").parse());
        }

        public static Proxy_Event[] next(Session session)
        {
            return session.proxy.event_next(session.uuid).parse();
        }

        public static void register(Session session, string[] _classes)
        {
            session.proxy.event_register(session.uuid, _classes).parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Event serverObject)
        {
            Event event2 = serverObject;
            if (opaqueRef == null)
            {
                this.ToProxy();
                throw new InvalidOperationException("There is no constructor available for this type; you cannot directly create one on the server.");
            }
            if (!this._id.Equals(event2._id))
            {
                set_id(session, opaqueRef, this._id);
            }
            return null;
        }

        public static void set_id(Session session, string _event, long _id)
        {
            session.proxy.event_set_id(session.uuid, (_event != null) ? _event : "", _id.ToString()).parse();
        }

        internal Proxy_Event ToProxy()
        {
            return new Proxy_Event { id = this.id.ToString() };
        }

        public static void unregister(Session session, string[] _classes)
        {
            session.proxy.event_unregister(session.uuid, _classes).parse();
        }

        public override void UpdateFrom(Event update)
        {
            this.id = update.id;
        }

        internal void UpdateFromProxy(Proxy_Event proxy)
        {
            this.id = long.Parse(proxy.id);
        }

        public long id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (value != this._id)
                {
                    this._id = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("id");
                }
            }
        }
    }
}

