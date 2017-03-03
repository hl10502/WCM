namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VIF_metrics : XenObject<VIF_metrics>
    {
        private double _io_read_kbs;
        private double _io_write_kbs;
        private DateTime _last_updated;
        private Dictionary<string, string> _other_config;
        private string _uuid;

        public VIF_metrics()
        {
        }

        public VIF_metrics(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.io_read_kbs = Marshalling.ParseDouble(table, "io_read_kbs");
            this.io_write_kbs = Marshalling.ParseDouble(table, "io_write_kbs");
            this.last_updated = Marshalling.ParseDateTime(table, "last_updated");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public VIF_metrics(Proxy_VIF_metrics proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VIF_metrics(string uuid, double io_read_kbs, double io_write_kbs, DateTime last_updated, Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.io_read_kbs = io_read_kbs;
            this.io_write_kbs = io_write_kbs;
            this.last_updated = last_updated;
            this.other_config = other_config;
        }

        public static void add_to_other_config(Session session, string _vif_metrics, string _key, string _value)
        {
            session.proxy.vif_metrics_add_to_other_config(session.uuid, (_vif_metrics != null) ? _vif_metrics : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public bool DeepEquals(VIF_metrics other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<double>(this._io_read_kbs, other._io_read_kbs)) && (Helper.AreEqual2<double>(this._io_write_kbs, other._io_write_kbs) && Helper.AreEqual2<DateTime>(this._last_updated, other._last_updated))) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)));
        }

        public static List<XenRef<VIF_metrics>> get_all(Session session)
        {
            return XenRef<VIF_metrics>.Create(session.proxy.vif_metrics_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VIF_metrics>, VIF_metrics> get_all_records(Session session)
        {
            return XenRef<VIF_metrics>.Create<Proxy_VIF_metrics>(session.proxy.vif_metrics_get_all_records(session.uuid).parse());
        }

        public static XenRef<VIF_metrics> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VIF_metrics>.Create(session.proxy.vif_metrics_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static double get_io_read_kbs(Session session, string _vif_metrics)
        {
            return Convert.ToDouble(session.proxy.vif_metrics_get_io_read_kbs(session.uuid, (_vif_metrics != null) ? _vif_metrics : "").parse());
        }

        public static double get_io_write_kbs(Session session, string _vif_metrics)
        {
            return Convert.ToDouble(session.proxy.vif_metrics_get_io_write_kbs(session.uuid, (_vif_metrics != null) ? _vif_metrics : "").parse());
        }

        public static DateTime get_last_updated(Session session, string _vif_metrics)
        {
            return session.proxy.vif_metrics_get_last_updated(session.uuid, (_vif_metrics != null) ? _vif_metrics : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _vif_metrics)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vif_metrics_get_other_config(session.uuid, (_vif_metrics != null) ? _vif_metrics : "").parse());
        }

        public static VIF_metrics get_record(Session session, string _vif_metrics)
        {
            return new VIF_metrics(session.proxy.vif_metrics_get_record(session.uuid, (_vif_metrics != null) ? _vif_metrics : "").parse());
        }

        public static string get_uuid(Session session, string _vif_metrics)
        {
            return session.proxy.vif_metrics_get_uuid(session.uuid, (_vif_metrics != null) ? _vif_metrics : "").parse();
        }

        public static void remove_from_other_config(Session session, string _vif_metrics, string _key)
        {
            session.proxy.vif_metrics_remove_from_other_config(session.uuid, (_vif_metrics != null) ? _vif_metrics : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, VIF_metrics server)
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

        public static void set_other_config(Session session, string _vif_metrics, Dictionary<string, string> _other_config)
        {
            session.proxy.vif_metrics_set_other_config(session.uuid, (_vif_metrics != null) ? _vif_metrics : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_VIF_metrics ToProxy()
        {
            return new Proxy_VIF_metrics { uuid = (this.uuid != null) ? this.uuid : "", io_read_kbs = this.io_read_kbs, io_write_kbs = this.io_write_kbs, last_updated = this.last_updated, other_config = Maps.convert_to_proxy_string_string(this.other_config) };
        }

        public override void UpdateFrom(VIF_metrics update)
        {
            this.uuid = update.uuid;
            this.io_read_kbs = update.io_read_kbs;
            this.io_write_kbs = update.io_write_kbs;
            this.last_updated = update.last_updated;
            this.other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_VIF_metrics proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.io_read_kbs = Convert.ToDouble(proxy.io_read_kbs);
            this.io_write_kbs = Convert.ToDouble(proxy.io_write_kbs);
            this.last_updated = proxy.last_updated;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public virtual double io_read_kbs
        {
            get
            {
                return this._io_read_kbs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._io_read_kbs))
                {
                    this._io_read_kbs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("io_read_kbs");
                }
            }
        }

        public virtual double io_write_kbs
        {
            get
            {
                return this._io_write_kbs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._io_write_kbs))
                {
                    this._io_write_kbs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("io_write_kbs");
                }
            }
        }

        public virtual DateTime last_updated
        {
            get
            {
                return this._last_updated;
            }
            set
            {
                if (!Helper.AreEqual(value, this._last_updated))
                {
                    this._last_updated = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("last_updated");
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

