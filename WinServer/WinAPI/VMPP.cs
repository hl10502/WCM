namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class VMPP : XenObject<VMPP>
    {
        private Dictionary<string, string> _alarm_config;
        private vmpp_archive_frequency _archive_frequency;
        private DateTime _archive_last_run_time;
        private Dictionary<string, string> _archive_schedule;
        private Dictionary<string, string> _archive_target_config;
        private vmpp_archive_target_type _archive_target_type;
        private vmpp_backup_frequency _backup_frequency;
        private DateTime _backup_last_run_time;
        private long _backup_retention_value;
        private Dictionary<string, string> _backup_schedule;
        private vmpp_backup_type _backup_type;
        private bool _is_alarm_enabled;
        private bool _is_archive_running;
        private bool _is_backup_running;
        private bool _is_policy_enabled;
        private string _name_description;
        private string _name_label;
        private string[] _recent_alerts;
        private string _uuid;
        private List<XenRef<VM>> _VMs;

        public VMPP()
        {
        }

        public VMPP(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.is_policy_enabled = Marshalling.ParseBool(table, "is_policy_enabled");
            this.backup_type = (vmpp_backup_type) Helper.EnumParseDefault(typeof(vmpp_backup_type), Marshalling.ParseString(table, "backup_type"));
            this.backup_retention_value = Marshalling.ParseLong(table, "backup_retention_value");
            this.backup_frequency = (vmpp_backup_frequency) Helper.EnumParseDefault(typeof(vmpp_backup_frequency), Marshalling.ParseString(table, "backup_frequency"));
            this.backup_schedule = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "backup_schedule"));
            this.is_backup_running = Marshalling.ParseBool(table, "is_backup_running");
            this.backup_last_run_time = Marshalling.ParseDateTime(table, "backup_last_run_time");
            this.archive_target_type = (vmpp_archive_target_type) Helper.EnumParseDefault(typeof(vmpp_archive_target_type), Marshalling.ParseString(table, "archive_target_type"));
            this.archive_target_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "archive_target_config"));
            this.archive_frequency = (vmpp_archive_frequency) Helper.EnumParseDefault(typeof(vmpp_archive_frequency), Marshalling.ParseString(table, "archive_frequency"));
            this.archive_schedule = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "archive_schedule"));
            this.is_archive_running = Marshalling.ParseBool(table, "is_archive_running");
            this.archive_last_run_time = Marshalling.ParseDateTime(table, "archive_last_run_time");
            this.VMs = Marshalling.ParseSetRef<VM>(table, "VMs");
            this.is_alarm_enabled = Marshalling.ParseBool(table, "is_alarm_enabled");
            this.alarm_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "alarm_config"));
            this.recent_alerts = Marshalling.ParseStringArray(table, "recent_alerts");
        }

        public VMPP(Proxy_VMPP proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public VMPP(string uuid, string name_label, string name_description, bool is_policy_enabled, vmpp_backup_type backup_type, long backup_retention_value, vmpp_backup_frequency backup_frequency, Dictionary<string, string> backup_schedule, bool is_backup_running, DateTime backup_last_run_time, vmpp_archive_target_type archive_target_type, Dictionary<string, string> archive_target_config, vmpp_archive_frequency archive_frequency, Dictionary<string, string> archive_schedule, bool is_archive_running, DateTime archive_last_run_time, List<XenRef<VM>> VMs, bool is_alarm_enabled, Dictionary<string, string> alarm_config, string[] recent_alerts)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.is_policy_enabled = is_policy_enabled;
            this.backup_type = backup_type;
            this.backup_retention_value = backup_retention_value;
            this.backup_frequency = backup_frequency;
            this.backup_schedule = backup_schedule;
            this.is_backup_running = is_backup_running;
            this.backup_last_run_time = backup_last_run_time;
            this.archive_target_type = archive_target_type;
            this.archive_target_config = archive_target_config;
            this.archive_frequency = archive_frequency;
            this.archive_schedule = archive_schedule;
            this.is_archive_running = is_archive_running;
            this.archive_last_run_time = archive_last_run_time;
            this.VMs = VMs;
            this.is_alarm_enabled = is_alarm_enabled;
            this.alarm_config = alarm_config;
            this.recent_alerts = recent_alerts;
        }

        public static void add_to_alarm_config(Session session, string _vmpp, string _key, string _value)
        {
            session.proxy.vmpp_add_to_alarm_config(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_archive_schedule(Session session, string _vmpp, string _key, string _value)
        {
            session.proxy.vmpp_add_to_archive_schedule(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_archive_target_config(Session session, string _vmpp, string _key, string _value)
        {
            session.proxy.vmpp_add_to_archive_target_config(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_backup_schedule(Session session, string _vmpp, string _key, string _value)
        {
            session.proxy.vmpp_add_to_backup_schedule(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static string archive_now(Session session, string _snapshot)
        {
            return session.proxy.vmpp_archive_now(session.uuid, (_snapshot != null) ? _snapshot : "").parse();
        }

        public static XenRef<Task> async_create(Session session, VMPP _record)
        {
            return XenRef<Task>.Create(session.proxy.async_vmpp_create(session.uuid, _record.ToProxy()).parse());
        }

        public static XenRef<Task> async_destroy(Session session, string _vmpp)
        {
            return XenRef<Task>.Create(session.proxy.async_vmpp_destroy(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static XenRef<VMPP> create(Session session, VMPP _record)
        {
            return XenRef<VMPP>.Create(session.proxy.vmpp_create(session.uuid, _record.ToProxy()).parse());
        }

        public bool DeepEquals(VMPP other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<bool>(this._is_policy_enabled, other._is_policy_enabled))) && ((Helper.AreEqual2<vmpp_backup_type>(this._backup_type, other._backup_type) && Helper.AreEqual2<long>(this._backup_retention_value, other._backup_retention_value)) && (Helper.AreEqual2<vmpp_backup_frequency>(this._backup_frequency, other._backup_frequency) && Helper.AreEqual2<Dictionary<string, string>>(this._backup_schedule, other._backup_schedule)))) && (((Helper.AreEqual2<bool>(this._is_backup_running, other._is_backup_running) && Helper.AreEqual2<DateTime>(this._backup_last_run_time, other._backup_last_run_time)) && (Helper.AreEqual2<vmpp_archive_target_type>(this._archive_target_type, other._archive_target_type) && Helper.AreEqual2<Dictionary<string, string>>(this._archive_target_config, other._archive_target_config))) && ((Helper.AreEqual2<vmpp_archive_frequency>(this._archive_frequency, other._archive_frequency) && Helper.AreEqual2<Dictionary<string, string>>(this._archive_schedule, other._archive_schedule)) && (Helper.AreEqual2<bool>(this._is_archive_running, other._is_archive_running) && Helper.AreEqual2<DateTime>(this._archive_last_run_time, other._archive_last_run_time))))) && ((Helper.AreEqual2<List<XenRef<VM>>>(this._VMs, other._VMs) && Helper.AreEqual2<bool>(this._is_alarm_enabled, other._is_alarm_enabled)) && Helper.AreEqual2<Dictionary<string, string>>(this._alarm_config, other._alarm_config))) && Helper.AreEqual2<string[]>(this._recent_alerts, other._recent_alerts)));
        }

        public static void destroy(Session session, string _vmpp)
        {
            session.proxy.vmpp_destroy(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static Dictionary<string, string> get_alarm_config(Session session, string _vmpp)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vmpp_get_alarm_config(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static string[] get_alerts(Session session, string _vmpp, long _hours_from_now)
        {
            return session.proxy.vmpp_get_alerts(session.uuid, (_vmpp != null) ? _vmpp : "", _hours_from_now.ToString()).parse();
        }

        public static List<XenRef<VMPP>> get_all(Session session)
        {
            return XenRef<VMPP>.Create(session.proxy.vmpp_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VMPP>, VMPP> get_all_records(Session session)
        {
            return XenRef<VMPP>.Create<Proxy_VMPP>(session.proxy.vmpp_get_all_records(session.uuid).parse());
        }

        public static vmpp_archive_frequency get_archive_frequency(Session session, string _vmpp)
        {
            return (vmpp_archive_frequency) Helper.EnumParseDefault(typeof(vmpp_archive_frequency), session.proxy.vmpp_get_archive_frequency(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static DateTime get_archive_last_run_time(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_archive_last_run_time(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static Dictionary<string, string> get_archive_schedule(Session session, string _vmpp)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vmpp_get_archive_schedule(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static Dictionary<string, string> get_archive_target_config(Session session, string _vmpp)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vmpp_get_archive_target_config(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static vmpp_archive_target_type get_archive_target_type(Session session, string _vmpp)
        {
            return (vmpp_archive_target_type) Helper.EnumParseDefault(typeof(vmpp_archive_target_type), session.proxy.vmpp_get_archive_target_type(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static vmpp_backup_frequency get_backup_frequency(Session session, string _vmpp)
        {
            return (vmpp_backup_frequency) Helper.EnumParseDefault(typeof(vmpp_backup_frequency), session.proxy.vmpp_get_backup_frequency(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static DateTime get_backup_last_run_time(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_backup_last_run_time(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static long get_backup_retention_value(Session session, string _vmpp)
        {
            return long.Parse(session.proxy.vmpp_get_backup_retention_value(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static Dictionary<string, string> get_backup_schedule(Session session, string _vmpp)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vmpp_get_backup_schedule(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static vmpp_backup_type get_backup_type(Session session, string _vmpp)
        {
            return (vmpp_backup_type) Helper.EnumParseDefault(typeof(vmpp_backup_type), session.proxy.vmpp_get_backup_type(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static List<XenRef<VMPP>> get_by_name_label(Session session, string _label)
        {
            return XenRef<VMPP>.Create(session.proxy.vmpp_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<VMPP> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VMPP>.Create(session.proxy.vmpp_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static bool get_is_alarm_enabled(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_is_alarm_enabled(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static bool get_is_archive_running(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_is_archive_running(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static bool get_is_backup_running(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_is_backup_running(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static bool get_is_policy_enabled(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_is_policy_enabled(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static string get_name_description(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_name_description(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static string get_name_label(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_name_label(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static string[] get_recent_alerts(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_recent_alerts(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static VMPP get_record(Session session, string _vmpp)
        {
            return new VMPP(session.proxy.vmpp_get_record(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static string get_uuid(Session session, string _vmpp)
        {
            return session.proxy.vmpp_get_uuid(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static List<XenRef<VM>> get_VMs(Session session, string _vmpp)
        {
            return XenRef<VM>.Create(session.proxy.vmpp_get_vms(session.uuid, (_vmpp != null) ? _vmpp : "").parse());
        }

        public static string protect_now(Session session, string _vmpp)
        {
            return session.proxy.vmpp_protect_now(session.uuid, (_vmpp != null) ? _vmpp : "").parse();
        }

        public static void remove_from_alarm_config(Session session, string _vmpp, string _key)
        {
            session.proxy.vmpp_remove_from_alarm_config(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_archive_schedule(Session session, string _vmpp, string _key)
        {
            session.proxy.vmpp_remove_from_archive_schedule(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_archive_target_config(Session session, string _vmpp, string _key)
        {
            session.proxy.vmpp_remove_from_archive_target_config(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_backup_schedule(Session session, string _vmpp, string _key)
        {
            session.proxy.vmpp_remove_from_backup_schedule(session.uuid, (_vmpp != null) ? _vmpp : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, VMPP server)
        {
            if (opaqueRef == null)
            {
                Proxy_VMPP y_vmpp = this.ToProxy();
                return session.proxy.vmpp_create(session.uuid, y_vmpp).parse();
            }
            if (!Helper.AreEqual2<string>(this._name_label, server._name_label))
            {
                set_name_label(session, opaqueRef, this._name_label);
            }
            if (!Helper.AreEqual2<string>(this._name_description, server._name_description))
            {
                set_name_description(session, opaqueRef, this._name_description);
            }
            if (!Helper.AreEqual2<bool>(this._is_policy_enabled, server._is_policy_enabled))
            {
                set_is_policy_enabled(session, opaqueRef, this._is_policy_enabled);
            }
            if (!Helper.AreEqual2<vmpp_backup_type>(this._backup_type, server._backup_type))
            {
                set_backup_type(session, opaqueRef, this._backup_type);
            }
            if (!Helper.AreEqual2<long>(this._backup_retention_value, server._backup_retention_value))
            {
                set_backup_retention_value(session, opaqueRef, this._backup_retention_value);
            }
            if (!Helper.AreEqual2<vmpp_backup_frequency>(this._backup_frequency, server._backup_frequency))
            {
                set_backup_frequency(session, opaqueRef, this._backup_frequency);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._backup_schedule, server._backup_schedule))
            {
                set_backup_schedule(session, opaqueRef, this._backup_schedule);
            }
            if (!Helper.AreEqual2<vmpp_archive_target_type>(this._archive_target_type, server._archive_target_type))
            {
                set_archive_target_type(session, opaqueRef, this._archive_target_type);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._archive_target_config, server._archive_target_config))
            {
                set_archive_target_config(session, opaqueRef, this._archive_target_config);
            }
            if (!Helper.AreEqual2<vmpp_archive_frequency>(this._archive_frequency, server._archive_frequency))
            {
                set_archive_frequency(session, opaqueRef, this._archive_frequency);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._archive_schedule, server._archive_schedule))
            {
                set_archive_schedule(session, opaqueRef, this._archive_schedule);
            }
            if (!Helper.AreEqual2<bool>(this._is_alarm_enabled, server._is_alarm_enabled))
            {
                set_is_alarm_enabled(session, opaqueRef, this._is_alarm_enabled);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._alarm_config, server._alarm_config))
            {
                set_alarm_config(session, opaqueRef, this._alarm_config);
            }
            return null;
        }

        public static void set_alarm_config(Session session, string _vmpp, Dictionary<string, string> _value)
        {
            session.proxy.vmpp_set_alarm_config(session.uuid, (_vmpp != null) ? _vmpp : "", Maps.convert_to_proxy_string_string(_value)).parse();
        }

        public static void set_archive_frequency(Session session, string _vmpp, vmpp_archive_frequency _value)
        {
            session.proxy.vmpp_set_archive_frequency(session.uuid, (_vmpp != null) ? _vmpp : "", vmpp_archive_frequency_helper.ToString(_value)).parse();
        }

        public static void set_archive_last_run_time(Session session, string _vmpp, DateTime _value)
        {
            session.proxy.vmpp_set_archive_last_run_time(session.uuid, (_vmpp != null) ? _vmpp : "", _value).parse();
        }

        public static void set_archive_schedule(Session session, string _vmpp, Dictionary<string, string> _value)
        {
            session.proxy.vmpp_set_archive_schedule(session.uuid, (_vmpp != null) ? _vmpp : "", Maps.convert_to_proxy_string_string(_value)).parse();
        }

        public static void set_archive_target_config(Session session, string _vmpp, Dictionary<string, string> _value)
        {
            session.proxy.vmpp_set_archive_target_config(session.uuid, (_vmpp != null) ? _vmpp : "", Maps.convert_to_proxy_string_string(_value)).parse();
        }

        public static void set_archive_target_type(Session session, string _vmpp, vmpp_archive_target_type _value)
        {
            session.proxy.vmpp_set_archive_target_type(session.uuid, (_vmpp != null) ? _vmpp : "", vmpp_archive_target_type_helper.ToString(_value)).parse();
        }

        public static void set_backup_frequency(Session session, string _vmpp, vmpp_backup_frequency _value)
        {
            session.proxy.vmpp_set_backup_frequency(session.uuid, (_vmpp != null) ? _vmpp : "", vmpp_backup_frequency_helper.ToString(_value)).parse();
        }

        public static void set_backup_last_run_time(Session session, string _vmpp, DateTime _value)
        {
            session.proxy.vmpp_set_backup_last_run_time(session.uuid, (_vmpp != null) ? _vmpp : "", _value).parse();
        }

        public static void set_backup_retention_value(Session session, string _vmpp, long _value)
        {
            session.proxy.vmpp_set_backup_retention_value(session.uuid, (_vmpp != null) ? _vmpp : "", _value.ToString()).parse();
        }

        public static void set_backup_schedule(Session session, string _vmpp, Dictionary<string, string> _value)
        {
            session.proxy.vmpp_set_backup_schedule(session.uuid, (_vmpp != null) ? _vmpp : "", Maps.convert_to_proxy_string_string(_value)).parse();
        }

        public static void set_backup_type(Session session, string _vmpp, vmpp_backup_type _backup_type)
        {
            session.proxy.vmpp_set_backup_type(session.uuid, (_vmpp != null) ? _vmpp : "", vmpp_backup_type_helper.ToString(_backup_type)).parse();
        }

        public static void set_is_alarm_enabled(Session session, string _vmpp, bool _value)
        {
            session.proxy.vmpp_set_is_alarm_enabled(session.uuid, (_vmpp != null) ? _vmpp : "", _value).parse();
        }

        public static void set_is_policy_enabled(Session session, string _vmpp, bool _is_policy_enabled)
        {
            session.proxy.vmpp_set_is_policy_enabled(session.uuid, (_vmpp != null) ? _vmpp : "", _is_policy_enabled).parse();
        }

        public static void set_name_description(Session session, string _vmpp, string _description)
        {
            session.proxy.vmpp_set_name_description(session.uuid, (_vmpp != null) ? _vmpp : "", (_description != null) ? _description : "").parse();
        }

        public static void set_name_label(Session session, string _vmpp, string _label)
        {
            session.proxy.vmpp_set_name_label(session.uuid, (_vmpp != null) ? _vmpp : "", (_label != null) ? _label : "").parse();
        }

        public Proxy_VMPP ToProxy()
        {
            return new Proxy_VMPP { 
                uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", is_policy_enabled = this.is_policy_enabled, backup_type = vmpp_backup_type_helper.ToString(this.backup_type), backup_retention_value = this.backup_retention_value.ToString(), backup_frequency = vmpp_backup_frequency_helper.ToString(this.backup_frequency), backup_schedule = Maps.convert_to_proxy_string_string(this.backup_schedule), is_backup_running = this.is_backup_running, backup_last_run_time = this.backup_last_run_time, archive_target_type = vmpp_archive_target_type_helper.ToString(this.archive_target_type), archive_target_config = Maps.convert_to_proxy_string_string(this.archive_target_config), archive_frequency = vmpp_archive_frequency_helper.ToString(this.archive_frequency), archive_schedule = Maps.convert_to_proxy_string_string(this.archive_schedule), is_archive_running = this.is_archive_running, archive_last_run_time = this.archive_last_run_time, 
                VMs = (this.VMs != null) ? Helper.RefListToStringArray<VM>(this.VMs) : new string[0], is_alarm_enabled = this.is_alarm_enabled, alarm_config = Maps.convert_to_proxy_string_string(this.alarm_config), recent_alerts = this.recent_alerts
             };
        }

        public override void UpdateFrom(VMPP update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.is_policy_enabled = update.is_policy_enabled;
            this.backup_type = update.backup_type;
            this.backup_retention_value = update.backup_retention_value;
            this.backup_frequency = update.backup_frequency;
            this.backup_schedule = update.backup_schedule;
            this.is_backup_running = update.is_backup_running;
            this.backup_last_run_time = update.backup_last_run_time;
            this.archive_target_type = update.archive_target_type;
            this.archive_target_config = update.archive_target_config;
            this.archive_frequency = update.archive_frequency;
            this.archive_schedule = update.archive_schedule;
            this.is_archive_running = update.is_archive_running;
            this.archive_last_run_time = update.archive_last_run_time;
            this.VMs = update.VMs;
            this.is_alarm_enabled = update.is_alarm_enabled;
            this.alarm_config = update.alarm_config;
            this.recent_alerts = update.recent_alerts;
        }

        internal void UpdateFromProxy(Proxy_VMPP proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.is_policy_enabled = proxy.is_policy_enabled;
            this.backup_type = (proxy.backup_type == null) ? vmpp_backup_type.snapshot : ((vmpp_backup_type) Helper.EnumParseDefault(typeof(vmpp_backup_type), proxy.backup_type));
            this.backup_retention_value = (proxy.backup_retention_value == null) ? 0L : long.Parse(proxy.backup_retention_value);
            this.backup_frequency = (proxy.backup_frequency == null) ? vmpp_backup_frequency.hourly : ((vmpp_backup_frequency) Helper.EnumParseDefault(typeof(vmpp_backup_frequency), proxy.backup_frequency));
            this.backup_schedule = (proxy.backup_schedule == null) ? null : Maps.convert_from_proxy_string_string(proxy.backup_schedule);
            this.is_backup_running = proxy.is_backup_running;
            this.backup_last_run_time = proxy.backup_last_run_time;
            this.archive_target_type = (proxy.archive_target_type == null) ? vmpp_archive_target_type.none : ((vmpp_archive_target_type) Helper.EnumParseDefault(typeof(vmpp_archive_target_type), proxy.archive_target_type));
            this.archive_target_config = (proxy.archive_target_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.archive_target_config);
            this.archive_frequency = (proxy.archive_frequency == null) ? vmpp_archive_frequency.never : ((vmpp_archive_frequency) Helper.EnumParseDefault(typeof(vmpp_archive_frequency), proxy.archive_frequency));
            this.archive_schedule = (proxy.archive_schedule == null) ? null : Maps.convert_from_proxy_string_string(proxy.archive_schedule);
            this.is_archive_running = proxy.is_archive_running;
            this.archive_last_run_time = proxy.archive_last_run_time;
            this.VMs = (proxy.VMs == null) ? null : XenRef<VM>.Create(proxy.VMs);
            this.is_alarm_enabled = proxy.is_alarm_enabled;
            this.alarm_config = (proxy.alarm_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.alarm_config);
            this.recent_alerts = (proxy.recent_alerts == null) ? new string[0] : proxy.recent_alerts;
        }

        public virtual Dictionary<string, string> alarm_config
        {
            get
            {
                return this._alarm_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._alarm_config))
                {
                    this._alarm_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("alarm_config");
                }
            }
        }

        public virtual vmpp_archive_frequency archive_frequency
        {
            get
            {
                return this._archive_frequency;
            }
            set
            {
                if (!Helper.AreEqual(value, this._archive_frequency))
                {
                    this._archive_frequency = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("archive_frequency");
                }
            }
        }

        public virtual DateTime archive_last_run_time
        {
            get
            {
                return this._archive_last_run_time;
            }
            set
            {
                if (!Helper.AreEqual(value, this._archive_last_run_time))
                {
                    this._archive_last_run_time = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("archive_last_run_time");
                }
            }
        }

        public virtual Dictionary<string, string> archive_schedule
        {
            get
            {
                return this._archive_schedule;
            }
            set
            {
                if (!Helper.AreEqual(value, this._archive_schedule))
                {
                    this._archive_schedule = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("archive_schedule");
                }
            }
        }

        public virtual Dictionary<string, string> archive_target_config
        {
            get
            {
                return this._archive_target_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._archive_target_config))
                {
                    this._archive_target_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("archive_target_config");
                }
            }
        }

        public virtual vmpp_archive_target_type archive_target_type
        {
            get
            {
                return this._archive_target_type;
            }
            set
            {
                if (!Helper.AreEqual(value, this._archive_target_type))
                {
                    this._archive_target_type = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("archive_target_type");
                }
            }
        }

        public virtual vmpp_backup_frequency backup_frequency
        {
            get
            {
                return this._backup_frequency;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backup_frequency))
                {
                    this._backup_frequency = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backup_frequency");
                }
            }
        }

        public virtual DateTime backup_last_run_time
        {
            get
            {
                return this._backup_last_run_time;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backup_last_run_time))
                {
                    this._backup_last_run_time = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backup_last_run_time");
                }
            }
        }

        public virtual long backup_retention_value
        {
            get
            {
                return this._backup_retention_value;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backup_retention_value))
                {
                    this._backup_retention_value = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backup_retention_value");
                }
            }
        }

        public virtual Dictionary<string, string> backup_schedule
        {
            get
            {
                return this._backup_schedule;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backup_schedule))
                {
                    this._backup_schedule = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backup_schedule");
                }
            }
        }

        public virtual vmpp_backup_type backup_type
        {
            get
            {
                return this._backup_type;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backup_type))
                {
                    this._backup_type = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backup_type");
                }
            }
        }

        public virtual bool is_alarm_enabled
        {
            get
            {
                return this._is_alarm_enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._is_alarm_enabled))
                {
                    this._is_alarm_enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("is_alarm_enabled");
                }
            }
        }

        public virtual bool is_archive_running
        {
            get
            {
                return this._is_archive_running;
            }
            set
            {
                if (!Helper.AreEqual(value, this._is_archive_running))
                {
                    this._is_archive_running = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("is_archive_running");
                }
            }
        }

        public virtual bool is_backup_running
        {
            get
            {
                return this._is_backup_running;
            }
            set
            {
                if (!Helper.AreEqual(value, this._is_backup_running))
                {
                    this._is_backup_running = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("is_backup_running");
                }
            }
        }

        public virtual bool is_policy_enabled
        {
            get
            {
                return this._is_policy_enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._is_policy_enabled))
                {
                    this._is_policy_enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("is_policy_enabled");
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

        public virtual string[] recent_alerts
        {
            get
            {
                return this._recent_alerts;
            }
            set
            {
                if (!Helper.AreEqual(value, this._recent_alerts))
                {
                    this._recent_alerts = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("recent_alerts");
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

        public virtual List<XenRef<VM>> VMs
        {
            get
            {
                return this._VMs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._VMs))
                {
                    this._VMs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("VMs");
                }
            }
        }
    }
}

