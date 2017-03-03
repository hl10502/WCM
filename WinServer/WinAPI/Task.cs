namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Task : XenObject<Task>
    {
        private List<task_allowed_operations> _allowed_operations;
        private string _backtrace;
        private DateTime _created;
        private Dictionary<string, task_allowed_operations> _current_operations;
        private string[] _error_info;
        private DateTime _finished;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private double _progress;
        private XenRef<Host> _resident_on;
        private string _result;
        private task_status_type _status;
        private XenRef<Task> _subtask_of;
        private List<XenRef<Task>> _subtasks;
        private string _type;
        private string _uuid;

        public Task()
        {
        }

        public Task(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.allowed_operations = Helper.StringArrayToEnumList<task_allowed_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_task_allowed_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.created = Marshalling.ParseDateTime(table, "created");
            this.finished = Marshalling.ParseDateTime(table, "finished");
            this.status = (task_status_type) Helper.EnumParseDefault(typeof(task_status_type), Marshalling.ParseString(table, "status"));
            this.resident_on = Marshalling.ParseRef<Host>(table, "resident_on");
            this.progress = Marshalling.ParseDouble(table, "progress");
            this.type = Marshalling.ParseString(table, "type");
            this.result = Marshalling.ParseString(table, "result");
            this.error_info = Marshalling.ParseStringArray(table, "error_info");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.subtask_of = Marshalling.ParseRef<Task>(table, "subtask_of");
            this.subtasks = Marshalling.ParseSetRef<Task>(table, "subtasks");
            this.backtrace = Marshalling.ParseString(table, "backtrace");
        }

        public Task(Proxy_Task proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Task(string uuid, string name_label, string name_description, List<task_allowed_operations> allowed_operations, Dictionary<string, task_allowed_operations> current_operations, DateTime created, DateTime finished, task_status_type status, XenRef<Host> resident_on, double progress, string type, string result, string[] error_info, Dictionary<string, string> other_config, XenRef<Task> subtask_of, List<XenRef<Task>> subtasks, string backtrace)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.created = created;
            this.finished = finished;
            this.status = status;
            this.resident_on = resident_on;
            this.progress = progress;
            this.type = type;
            this.result = result;
            this.error_info = error_info;
            this.other_config = other_config;
            this.subtask_of = subtask_of;
            this.subtasks = subtasks;
            this.backtrace = backtrace;
        }

        public static void add_to_other_config(Session session, string _task, string _key, string _value)
        {
            session.proxy.task_add_to_other_config(session.uuid, (_task != null) ? _task : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static XenRef<Task> async_cancel(Session session, string _task)
        {
            return XenRef<Task>.Create(session.proxy.async_task_cancel(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static void cancel(Session session, string _task)
        {
            session.proxy.task_cancel(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static XenRef<Task> create(Session session, string _label, string _description)
        {
            return XenRef<Task>.Create(session.proxy.task_create(session.uuid, (_label != null) ? _label : "", (_description != null) ? _description : "").parse());
        }

        public bool DeepEquals(Task other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, task_allowed_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return (((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<List<task_allowed_operations>>(this._allowed_operations, other._allowed_operations))) && ((Helper.AreEqual2<DateTime>(this._created, other._created) && Helper.AreEqual2<DateTime>(this._finished, other._finished)) && (Helper.AreEqual2<task_status_type>(this._status, other._status) && Helper.AreEqual2<XenRef<Host>>(this._resident_on, other._resident_on)))) && (((Helper.AreEqual2<double>(this._progress, other._progress) && Helper.AreEqual2<string>(this._type, other._type)) && (Helper.AreEqual2<string>(this._result, other._result) && Helper.AreEqual2<string[]>(this._error_info, other._error_info))) && ((Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config) && Helper.AreEqual2<XenRef<Task>>(this._subtask_of, other._subtask_of)) && Helper.AreEqual2<List<XenRef<Task>>>(this._subtasks, other._subtasks)))) && Helper.AreEqual2<string>(this._backtrace, other._backtrace));
        }

        public static void destroy(Session session, string _task)
        {
            session.proxy.task_destroy(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static List<XenRef<Task>> get_all(Session session)
        {
            return XenRef<Task>.Create(session.proxy.task_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Task>, Task> get_all_records(Session session)
        {
            return XenRef<Task>.Create<Proxy_Task>(session.proxy.task_get_all_records(session.uuid).parse());
        }

        public static List<task_allowed_operations> get_allowed_operations(Session session, string _task)
        {
            return Helper.StringArrayToEnumList<task_allowed_operations>(session.proxy.task_get_allowed_operations(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static string get_backtrace(Session session, string _task)
        {
            return session.proxy.task_get_backtrace(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static List<XenRef<Task>> get_by_name_label(Session session, string _label)
        {
            return XenRef<Task>.Create(session.proxy.task_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static XenRef<Task> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Task>.Create(session.proxy.task_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static DateTime get_created(Session session, string _task)
        {
            return session.proxy.task_get_created(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static Dictionary<string, task_allowed_operations> get_current_operations(Session session, string _task)
        {
            return Maps.convert_from_proxy_string_task_allowed_operations(session.proxy.task_get_current_operations(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static string[] get_error_info(Session session, string _task)
        {
            return session.proxy.task_get_error_info(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static DateTime get_finished(Session session, string _task)
        {
            return session.proxy.task_get_finished(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static string get_name_description(Session session, string _task)
        {
            return session.proxy.task_get_name_description(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static string get_name_label(Session session, string _task)
        {
            return session.proxy.task_get_name_label(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _task)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.task_get_other_config(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static double get_progress(Session session, string _task)
        {
            return Convert.ToDouble(session.proxy.task_get_progress(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static Task get_record(Session session, string _task)
        {
            return new Task(session.proxy.task_get_record(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static XenRef<Host> get_resident_on(Session session, string _task)
        {
            return XenRef<Host>.Create(session.proxy.task_get_resident_on(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static string get_result(Session session, string _task)
        {
            return session.proxy.task_get_result(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static task_status_type get_status(Session session, string _task)
        {
            return (task_status_type) Helper.EnumParseDefault(typeof(task_status_type), session.proxy.task_get_status(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static XenRef<Task> get_subtask_of(Session session, string _task)
        {
            return XenRef<Task>.Create(session.proxy.task_get_subtask_of(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static List<XenRef<Task>> get_subtasks(Session session, string _task)
        {
            return XenRef<Task>.Create(session.proxy.task_get_subtasks(session.uuid, (_task != null) ? _task : "").parse());
        }

        public static string get_type(Session session, string _task)
        {
            return session.proxy.task_get_type(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static string get_uuid(Session session, string _task)
        {
            return session.proxy.task_get_uuid(session.uuid, (_task != null) ? _task : "").parse();
        }

        public static void remove_from_other_config(Session session, string _task, string _key)
        {
            session.proxy.task_remove_from_other_config(session.uuid, (_task != null) ? _task : "", (_key != null) ? _key : "").parse();
        }

        public override string SaveChanges(Session session, string opaqueRef, Task server)
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

        public static void set_other_config(Session session, string _task, Dictionary<string, string> _other_config)
        {
            session.proxy.task_set_other_config(session.uuid, (_task != null) ? _task : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public Proxy_Task ToProxy()
        {
            return new Proxy_Task { 
                uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<task_allowed_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_task_allowed_operations(this.current_operations), created = this.created, finished = this.finished, status = task_status_type_helper.ToString(this.status), resident_on = (this.resident_on != null) ? ((string) this.resident_on) : "", progress = this.progress, type = (this.type != null) ? this.type : "", result = (this.result != null) ? this.result : "", error_info = this.error_info, other_config = Maps.convert_to_proxy_string_string(this.other_config), subtask_of = (this.subtask_of != null) ? ((string) this.subtask_of) : "", subtasks = (this.subtasks != null) ? Helper.RefListToStringArray<Task>(this.subtasks) : new string[0], 
                backtrace = (this.backtrace != null) ? this.backtrace : ""
             };
        }

        public override void UpdateFrom(Task update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.created = update.created;
            this.finished = update.finished;
            this.status = update.status;
            this.resident_on = update.resident_on;
            this.progress = update.progress;
            this.type = update.type;
            this.result = update.result;
            this.error_info = update.error_info;
            this.other_config = update.other_config;
            this.subtask_of = update.subtask_of;
            this.subtasks = update.subtasks;
            this.backtrace = update.backtrace;
        }

        internal void UpdateFromProxy(Proxy_Task proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<task_allowed_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_task_allowed_operations(proxy.current_operations);
            this.created = proxy.created;
            this.finished = proxy.finished;
            this.status = (proxy.status == null) ? task_status_type.pending : ((task_status_type) Helper.EnumParseDefault(typeof(task_status_type), proxy.status));
            this.resident_on = (proxy.resident_on == null) ? null : XenRef<Host>.Create(proxy.resident_on);
            this.progress = Convert.ToDouble(proxy.progress);
            this.type = (proxy.type == null) ? null : proxy.type;
            this.result = (proxy.result == null) ? null : proxy.result;
            this.error_info = (proxy.error_info == null) ? new string[0] : proxy.error_info;
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.subtask_of = (proxy.subtask_of == null) ? null : XenRef<Task>.Create(proxy.subtask_of);
            this.subtasks = (proxy.subtasks == null) ? null : XenRef<Task>.Create(proxy.subtasks);
            this.backtrace = (proxy.backtrace == null) ? null : proxy.backtrace;
        }

        public virtual List<task_allowed_operations> allowed_operations
        {
            get
            {
                return this._allowed_operations;
            }
            set
            {
                if (!Helper.AreEqual(value, this._allowed_operations))
                {
                    this._allowed_operations = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("allowed_operations");
                }
            }
        }

        public virtual string backtrace
        {
            get
            {
                return this._backtrace;
            }
            set
            {
                if (!Helper.AreEqual(value, this._backtrace))
                {
                    this._backtrace = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("backtrace");
                }
            }
        }

        public virtual DateTime created
        {
            get
            {
                return this._created;
            }
            set
            {
                if (!Helper.AreEqual(value, this._created))
                {
                    this._created = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("created");
                }
            }
        }

        public virtual Dictionary<string, task_allowed_operations> current_operations
        {
            get
            {
                return this._current_operations;
            }
            set
            {
                if (!Helper.AreEqual(value, this._current_operations))
                {
                    this._current_operations = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("current_operations");
                }
            }
        }

        public virtual string[] error_info
        {
            get
            {
                return this._error_info;
            }
            set
            {
                if (!Helper.AreEqual(value, this._error_info))
                {
                    this._error_info = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("error_info");
                }
            }
        }

        public virtual DateTime finished
        {
            get
            {
                return this._finished;
            }
            set
            {
                if (!Helper.AreEqual(value, this._finished))
                {
                    this._finished = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("finished");
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

        public virtual double progress
        {
            get
            {
                return this._progress;
            }
            set
            {
                if (!Helper.AreEqual(value, this._progress))
                {
                    this._progress = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("progress");
                }
            }
        }

        public virtual XenRef<Host> resident_on
        {
            get
            {
                return this._resident_on;
            }
            set
            {
                if (!Helper.AreEqual(value, this._resident_on))
                {
                    this._resident_on = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("resident_on");
                }
            }
        }

        public virtual string result
        {
            get
            {
                return this._result;
            }
            set
            {
                if (!Helper.AreEqual(value, this._result))
                {
                    this._result = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("result");
                }
            }
        }

        public virtual task_status_type status
        {
            get
            {
                return this._status;
            }
            set
            {
                if (!Helper.AreEqual(value, this._status))
                {
                    this._status = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("status");
                }
            }
        }

        public virtual XenRef<Task> subtask_of
        {
            get
            {
                return this._subtask_of;
            }
            set
            {
                if (!Helper.AreEqual(value, this._subtask_of))
                {
                    this._subtask_of = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("subtask_of");
                }
            }
        }

        public virtual List<XenRef<Task>> subtasks
        {
            get
            {
                return this._subtasks;
            }
            set
            {
                if (!Helper.AreEqual(value, this._subtasks))
                {
                    this._subtasks = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("subtasks");
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
    }
}

