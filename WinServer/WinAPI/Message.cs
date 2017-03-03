namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Message : XenObject<Message>
    {
        private string _body;
        private WinAPI.cls _cls;
        private string _name;
        private string _obj_uuid;
        private long _priority;
        private DateTime _timestamp;
        private string _uuid;

        public Message()
        {
        }

        public Message(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name = Marshalling.ParseString(table, "name");
            this.priority = Marshalling.ParseLong(table, "priority");
            this.cls = (WinAPI.cls) Helper.EnumParseDefault(typeof(WinAPI.cls), Marshalling.ParseString(table, "cls"));
            this.obj_uuid = Marshalling.ParseString(table, "obj_uuid");
            this.timestamp = Marshalling.ParseDateTime(table, "timestamp");
            this.body = Marshalling.ParseString(table, "body");
        }

        public Message(Proxy_Message proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Message(string uuid, string name, long priority, WinAPI.cls cls, string obj_uuid, DateTime timestamp, string body)
        {
            this.uuid = uuid;
            this.name = name;
            this.priority = priority;
            this.cls = cls;
            this.obj_uuid = obj_uuid;
            this.timestamp = timestamp;
            this.body = body;
        }

        public static XenRef<Message> create(Session session, string _name, long _priority, WinAPI.cls _cls, string _obj_uuid, string _body)
        {
            return XenRef<Message>.Create(session.proxy.message_create(session.uuid, (_name != null) ? _name : "", _priority.ToString(), cls_helper.ToString(_cls), (_obj_uuid != null) ? _obj_uuid : "", (_body != null) ? _body : "").parse());
        }

        public bool DeepEquals(Message other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name, other._name)) && (Helper.AreEqual2<long>(this._priority, other._priority) && Helper.AreEqual2<WinAPI.cls>(this._cls, other._cls))) && (Helper.AreEqual2<string>(this._obj_uuid, other._obj_uuid) && Helper.AreEqual2<DateTime>(this._timestamp, other._timestamp))) && Helper.AreEqual2<string>(this._body, other._body)));
        }

        public static void destroy(Session session, string _message)
        {
            session.proxy.message_destroy(session.uuid, (_message != null) ? _message : "").parse();
        }

        public static Dictionary<XenRef<Message>, Message> get(Session session, WinAPI.cls _cls, string _obj_uuid, DateTime _since)
        {
            return XenRef<Message>.Create<Proxy_Message>(session.proxy.message_get(session.uuid, cls_helper.ToString(_cls), (_obj_uuid != null) ? _obj_uuid : "", _since).parse());
        }

        public static List<XenRef<Message>> get_all(Session session)
        {
            return XenRef<Message>.Create(session.proxy.message_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Message>, Message> get_all_records(Session session)
        {
            return XenRef<Message>.Create<Proxy_Message>(session.proxy.message_get_all_records(session.uuid).parse());
        }

        public static XenRef<Message> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Message>.Create(session.proxy.message_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static Message get_record(Session session, string _message)
        {
            return new Message(session.proxy.message_get_record(session.uuid, (_message != null) ? _message : "").parse());
        }

        public static Dictionary<XenRef<Message>, Message> get_since(Session session, DateTime _since)
        {
            return XenRef<Message>.Create<Proxy_Message>(session.proxy.message_get_since(session.uuid, _since).parse());
        }

        public override string SaveChanges(Session session, string opaqueRef, Message server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            return "";
        }

        public Proxy_Message ToProxy()
        {
            return new Proxy_Message { uuid = (this.uuid != null) ? this.uuid : "", name = (this.name != null) ? this.name : "", priority = this.priority.ToString(), cls = cls_helper.ToString(this.cls), obj_uuid = (this.obj_uuid != null) ? this.obj_uuid : "", timestamp = this.timestamp, body = (this.body != null) ? this.body : "" };
        }

        public override void UpdateFrom(Message update)
        {
            this.uuid = update.uuid;
            this.name = update.name;
            this.priority = update.priority;
            this.cls = update.cls;
            this.obj_uuid = update.obj_uuid;
            this.timestamp = update.timestamp;
            this.body = update.body;
        }

        internal void UpdateFromProxy(Proxy_Message proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name = (proxy.name == null) ? null : proxy.name;
            this.priority = (proxy.priority == null) ? 0L : long.Parse(proxy.priority);
            this.cls = (proxy.cls == null) ? WinAPI.cls.VM : ((WinAPI.cls) Helper.EnumParseDefault(typeof(WinAPI.cls), proxy.cls));
            this.obj_uuid = (proxy.obj_uuid == null) ? null : proxy.obj_uuid;
            this.timestamp = proxy.timestamp;
            this.body = (proxy.body == null) ? null : proxy.body;
        }

        public virtual string body
        {
            get
            {
                return this._body;
            }
            set
            {
                if (!Helper.AreEqual(value, this._body))
                {
                    this._body = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("body");
                }
            }
        }

        public virtual WinAPI.cls cls
        {
            get
            {
                return this._cls;
            }
            set
            {
                if (!Helper.AreEqual(value, this._cls))
                {
                    this._cls = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("cls");
                }
            }
        }

        public virtual string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!Helper.AreEqual(value, this._name))
                {
                    this._name = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("name");
                }
            }
        }

        public virtual string obj_uuid
        {
            get
            {
                return this._obj_uuid;
            }
            set
            {
                if (!Helper.AreEqual(value, this._obj_uuid))
                {
                    this._obj_uuid = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("obj_uuid");
                }
            }
        }

        public virtual long priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                if (!Helper.AreEqual(value, this._priority))
                {
                    this._priority = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("priority");
                }
            }
        }

        public virtual DateTime timestamp
        {
            get
            {
                return this._timestamp;
            }
            set
            {
                if (!Helper.AreEqual(value, this._timestamp))
                {
                    this._timestamp = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("timestamp");
                }
            }
        }

        public MessageType Type
        {
            get
            {
                switch (this.name)
                {
                    case "BOND_STATUS_CHANGED":
                        return MessageType.BOND_STATUS_CHANGED;

                    case "VMPP_SNAPSHOT_ARCHIVE_ALREADY_EXISTS":
                        return MessageType.VMPP_SNAPSHOT_ARCHIVE_ALREADY_EXISTS;

                    case "VMPP_ARCHIVE_MISSED_EVENT":
                        return MessageType.VMPP_ARCHIVE_MISSED_EVENT;

                    case "VMPP_SNAPSHOT_MISSED_EVENT":
                        return MessageType.VMPP_SNAPSHOT_MISSED_EVENT;

                    case "VMPP_XAPI_LOGON_FAILURE":
                        return MessageType.VMPP_XAPI_LOGON_FAILURE;

                    case "VMPP_LICENSE_ERROR":
                        return MessageType.VMPP_LICENSE_ERROR;

                    case "VMPP_ARCHIVE_TARGET_UNMOUNT_FAILED":
                        return MessageType.VMPP_ARCHIVE_TARGET_UNMOUNT_FAILED;

                    case "VMPP_ARCHIVE_TARGET_MOUNT_FAILED":
                        return MessageType.VMPP_ARCHIVE_TARGET_MOUNT_FAILED;

                    case "VMPP_ARCHIVE_SUCCEEDED":
                        return MessageType.VMPP_ARCHIVE_SUCCEEDED;

                    case "VMPP_ARCHIVE_FAILED_0":
                        return MessageType.VMPP_ARCHIVE_FAILED_0;

                    case "VMPP_ARCHIVE_LOCK_FAILED":
                        return MessageType.VMPP_ARCHIVE_LOCK_FAILED;

                    case "VMPP_SNAPSHOT_FAILED":
                        return MessageType.VMPP_SNAPSHOT_FAILED;

                    case "VMPP_SNAPSHOT_SUCCEEDED":
                        return MessageType.VMPP_SNAPSHOT_SUCCEEDED;

                    case "VMPP_SNAPSHOT_LOCK_FAILED":
                        return MessageType.VMPP_SNAPSHOT_LOCK_FAILED;

                    case "LICENSE_SERVER_VERSION_OBSOLETE":
                        return MessageType.LICENSE_SERVER_VERSION_OBSOLETE;

                    case "LICENSE_SERVER_UNREACHABLE":
                        return MessageType.LICENSE_SERVER_UNREACHABLE;

                    case "LICENSE_NOT_AVAILABLE":
                        return MessageType.LICENSE_NOT_AVAILABLE;

                    case "GRACE_LICENSE":
                        return MessageType.GRACE_LICENSE;

                    case "LICENSE_EXPIRED":
                        return MessageType.LICENSE_EXPIRED;

                    case "LICENSE_SERVER_UNAVAILABLE":
                        return MessageType.LICENSE_SERVER_UNAVAILABLE;

                    case "LICENSE_SERVER_CONNECTED":
                        return MessageType.LICENSE_SERVER_CONNECTED;

                    case "MULTIPATH_PERIODIC_ALERT":
                        return MessageType.MULTIPATH_PERIODIC_ALERT;

                    case "EXTAUTH_IN_POOL_IS_NON_HOMOGENEOUS":
                        return MessageType.EXTAUTH_IN_POOL_IS_NON_HOMOGENEOUS;

                    case "EXTAUTH_INIT_IN_HOST_FAILED":
                        return MessageType.EXTAUTH_INIT_IN_HOST_FAILED;

                    case "WLB_OPTIMIZATION_ALERT":
                        return MessageType.WLB_OPTIMIZATION_ALERT;

                    case "WLB_CONSULTATION_FAILED":
                        return MessageType.WLB_CONSULTATION_FAILED;

                    case "ALARM":
                        return MessageType.ALARM;

                    case "PBD_PLUG_FAILED_ON_SERVER_START":
                        return MessageType.PBD_PLUG_FAILED_ON_SERVER_START;

                    case "POOL_MASTER_TRANSITION":
                        return MessageType.POOL_MASTER_TRANSITION;

                    case "HOST_CLOCK_WENT_BACKWARDS":
                        return MessageType.HOST_CLOCK_WENT_BACKWARDS;

                    case "HOST_CLOCK_SKEW_DETECTED":
                        return MessageType.HOST_CLOCK_SKEW_DETECTED;

                    case "HOST_SYNC_DATA_FAILED":
                        return MessageType.HOST_SYNC_DATA_FAILED;

                    case "VM_CLONED":
                        return MessageType.VM_CLONED;

                    case "VM_CRASHED":
                        return MessageType.VM_CRASHED;

                    case "VM_RESUMED":
                        return MessageType.VM_RESUMED;

                    case "VM_SUSPENDED":
                        return MessageType.VM_SUSPENDED;

                    case "VM_REBOOTED":
                        return MessageType.VM_REBOOTED;

                    case "VM_SHUTDOWN":
                        return MessageType.VM_SHUTDOWN;

                    case "VM_STARTED":
                        return MessageType.VM_STARTED;

                    case "VCPU_QOS_FAILED":
                        return MessageType.VCPU_QOS_FAILED;

                    case "VBD_QOS_FAILED":
                        return MessageType.VBD_QOS_FAILED;

                    case "VIF_QOS_FAILED":
                        return MessageType.VIF_QOS_FAILED;

                    case "IP_CONFIGURED_PIF_CAN_UNPLUG":
                        return MessageType.IP_CONFIGURED_PIF_CAN_UNPLUG;

                    case "METADATA_LUN_BROKEN":
                        return MessageType.METADATA_LUN_BROKEN;

                    case "METADATA_LUN_HEALTHY":
                        return MessageType.METADATA_LUN_HEALTHY;

                    case "HA_HOST_WAS_FENCED":
                        return MessageType.HA_HOST_WAS_FENCED;

                    case "HA_HOST_FAILED":
                        return MessageType.HA_HOST_FAILED;

                    case "HA_PROTECTED_VM_RESTART_FAILED":
                        return MessageType.HA_PROTECTED_VM_RESTART_FAILED;

                    case "HA_POOL_DROP_IN_PLAN_EXISTS_FOR":
                        return MessageType.HA_POOL_DROP_IN_PLAN_EXISTS_FOR;

                    case "HA_POOL_OVERCOMMITTED":
                        return MessageType.HA_POOL_OVERCOMMITTED;

                    case "HA_NETWORK_BONDING_ERROR":
                        return MessageType.HA_NETWORK_BONDING_ERROR;

                    case "HA_XAPI_HEALTHCHECK_APPROACHING_TIMEOUT":
                        return MessageType.HA_XAPI_HEALTHCHECK_APPROACHING_TIMEOUT;

                    case "HA_STATEFILE_APPROACHING_TIMEOUT":
                        return MessageType.HA_STATEFILE_APPROACHING_TIMEOUT;

                    case "HA_HEARTBEAT_APPROACHING_TIMEOUT":
                        return MessageType.HA_HEARTBEAT_APPROACHING_TIMEOUT;

                    case "HA_STATEFILE_LOST":
                        return MessageType.HA_STATEFILE_LOST;

                    case "LICENSE_EXPIRES_SOON":
                        return MessageType.LICENSE_EXPIRES_SOON;

                    case "LICENSE_DOES_NOT_SUPPORT_POOLING":
                        return MessageType.LICENSE_DOES_NOT_SUPPORT_POOLING;
                }
                return MessageType.unknown;
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

        public enum MessageType
        {
            BOND_STATUS_CHANGED,
            VMPP_SNAPSHOT_ARCHIVE_ALREADY_EXISTS,
            VMPP_ARCHIVE_MISSED_EVENT,
            VMPP_SNAPSHOT_MISSED_EVENT,
            VMPP_XAPI_LOGON_FAILURE,
            VMPP_LICENSE_ERROR,
            VMPP_ARCHIVE_TARGET_UNMOUNT_FAILED,
            VMPP_ARCHIVE_TARGET_MOUNT_FAILED,
            VMPP_ARCHIVE_SUCCEEDED,
            VMPP_ARCHIVE_FAILED_0,
            VMPP_ARCHIVE_LOCK_FAILED,
            VMPP_SNAPSHOT_FAILED,
            VMPP_SNAPSHOT_SUCCEEDED,
            VMPP_SNAPSHOT_LOCK_FAILED,
            LICENSE_SERVER_VERSION_OBSOLETE,
            LICENSE_SERVER_UNREACHABLE,
            LICENSE_NOT_AVAILABLE,
            GRACE_LICENSE,
            LICENSE_EXPIRED,
            LICENSE_SERVER_UNAVAILABLE,
            LICENSE_SERVER_CONNECTED,
            MULTIPATH_PERIODIC_ALERT,
            EXTAUTH_IN_POOL_IS_NON_HOMOGENEOUS,
            EXTAUTH_INIT_IN_HOST_FAILED,
            WLB_OPTIMIZATION_ALERT,
            WLB_CONSULTATION_FAILED,
            ALARM,
            PBD_PLUG_FAILED_ON_SERVER_START,
            POOL_MASTER_TRANSITION,
            HOST_CLOCK_WENT_BACKWARDS,
            HOST_CLOCK_SKEW_DETECTED,
            HOST_SYNC_DATA_FAILED,
            VM_CLONED,
            VM_CRASHED,
            VM_RESUMED,
            VM_SUSPENDED,
            VM_REBOOTED,
            VM_SHUTDOWN,
            VM_STARTED,
            VCPU_QOS_FAILED,
            VBD_QOS_FAILED,
            VIF_QOS_FAILED,
            IP_CONFIGURED_PIF_CAN_UNPLUG,
            METADATA_LUN_BROKEN,
            METADATA_LUN_HEALTHY,
            HA_HOST_WAS_FENCED,
            HA_HOST_FAILED,
            HA_PROTECTED_VM_RESTART_FAILED,
            HA_POOL_DROP_IN_PLAN_EXISTS_FOR,
            HA_POOL_OVERCOMMITTED,
            HA_NETWORK_BONDING_ERROR,
            HA_XAPI_HEALTHCHECK_APPROACHING_TIMEOUT,
            HA_STATEFILE_APPROACHING_TIMEOUT,
            HA_HEARTBEAT_APPROACHING_TIMEOUT,
            HA_STATEFILE_LOST,
            LICENSE_EXPIRES_SOON,
            LICENSE_DOES_NOT_SUPPORT_POOLING,
            unknown
        }
    }
}

