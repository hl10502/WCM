namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Pool : XenObject<Pool>
    {
        private List<pool_allowed_operations> _allowed_operations;
        private Dictionary<string, XenRef<Blob>> _blobs;
        private XenRef<WinAPI.SR> _crash_dump_SR;
        private Dictionary<string, pool_allowed_operations> _current_operations;
        private XenRef<WinAPI.SR> _default_SR;
        private Dictionary<string, string> _guest_agent_config;
        private Dictionary<string, string> _gui_config;
        private bool _ha_allow_overcommit;
        private string _ha_cluster_stack;
        private Dictionary<string, string> _ha_configuration;
        private bool _ha_enabled;
        private long _ha_host_failures_to_tolerate;
        private bool _ha_overcommitted;
        private long _ha_plan_exists_for;
        private string[] _ha_statefiles;
        private Dictionary<string, string> _health_check_config;
        private XenRef<Host> _master;
        private List<XenRef<VDI>> _metadata_VDIs;
        private string _name_description;
        private string _name_label;
        private Dictionary<string, string> _other_config;
        private bool _redo_log_enabled;
        private XenRef<VDI> _redo_log_vdi;
        private Dictionary<string, string> _restrictions;
        private XenRef<WinAPI.SR> _suspend_image_SR;
        private string[] _tags;
        private string _uuid;
        private string _vswitch_controller;
        private bool _wlb_enabled;
        private string _wlb_url;
        private string _wlb_username;
        private bool _wlb_verify_cert;

        public Pool()
        {
        }

        public Pool(Hashtable table)
        {
            this.uuid = Marshalling.ParseString(table, "uuid");
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.master = Marshalling.ParseRef<Host>(table, "master");
            this.default_SR = Marshalling.ParseRef<WinAPI.SR>(table, "default_SR");
            this.suspend_image_SR = Marshalling.ParseRef<WinAPI.SR>(table, "suspend_image_SR");
            this.crash_dump_SR = Marshalling.ParseRef<WinAPI.SR>(table, "crash_dump_SR");
            this.other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            this.ha_enabled = Marshalling.ParseBool(table, "ha_enabled");
            this.ha_configuration = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "ha_configuration"));
            this.ha_statefiles = Marshalling.ParseStringArray(table, "ha_statefiles");
            this.ha_host_failures_to_tolerate = Marshalling.ParseLong(table, "ha_host_failures_to_tolerate");
            this.ha_plan_exists_for = Marshalling.ParseLong(table, "ha_plan_exists_for");
            this.ha_allow_overcommit = Marshalling.ParseBool(table, "ha_allow_overcommit");
            this.ha_overcommitted = Marshalling.ParseBool(table, "ha_overcommitted");
            this.blobs = Maps.convert_from_proxy_string_XenRefBlob(Marshalling.ParseHashTable(table, "blobs"));
            this.tags = Marshalling.ParseStringArray(table, "tags");
            this.gui_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "gui_config"));
            this.health_check_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "health_check_config"));
            this.wlb_url = Marshalling.ParseString(table, "wlb_url");
            this.wlb_username = Marshalling.ParseString(table, "wlb_username");
            this.wlb_enabled = Marshalling.ParseBool(table, "wlb_enabled");
            this.wlb_verify_cert = Marshalling.ParseBool(table, "wlb_verify_cert");
            this.redo_log_enabled = Marshalling.ParseBool(table, "redo_log_enabled");
            this.redo_log_vdi = Marshalling.ParseRef<VDI>(table, "redo_log_vdi");
            this.vswitch_controller = Marshalling.ParseString(table, "vswitch_controller");
            this.restrictions = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "restrictions"));
            this.metadata_VDIs = Marshalling.ParseSetRef<VDI>(table, "metadata_VDIs");
            this.ha_cluster_stack = Marshalling.ParseString(table, "ha_cluster_stack");
            this.allowed_operations = Helper.StringArrayToEnumList<pool_allowed_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            this.current_operations = Maps.convert_from_proxy_string_pool_allowed_operations(Marshalling.ParseHashTable(table, "current_operations"));
            this.guest_agent_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "guest_agent_config"));
        }

        public Pool(Proxy_Pool proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Pool(string uuid, string name_label, string name_description, XenRef<Host> master, XenRef<WinAPI.SR> default_SR, XenRef<WinAPI.SR> suspend_image_SR, XenRef<WinAPI.SR> crash_dump_SR, Dictionary<string, string> other_config, bool ha_enabled, Dictionary<string, string> ha_configuration, string[] ha_statefiles, long ha_host_failures_to_tolerate, long ha_plan_exists_for, bool ha_allow_overcommit, bool ha_overcommitted, Dictionary<string, XenRef<Blob>> blobs, string[] tags, Dictionary<string, string> gui_config, Dictionary<string, string> health_check_config, string wlb_url, string wlb_username, bool wlb_enabled, bool wlb_verify_cert, bool redo_log_enabled, XenRef<VDI> redo_log_vdi, string vswitch_controller, Dictionary<string, string> restrictions, List<XenRef<VDI>> metadata_VDIs, string ha_cluster_stack, List<pool_allowed_operations> allowed_operations, Dictionary<string, pool_allowed_operations> current_operations, Dictionary<string, string> guest_agent_config)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.master = master;
            this.default_SR = default_SR;
            this.suspend_image_SR = suspend_image_SR;
            this.crash_dump_SR = crash_dump_SR;
            this.other_config = other_config;
            this.ha_enabled = ha_enabled;
            this.ha_configuration = ha_configuration;
            this.ha_statefiles = ha_statefiles;
            this.ha_host_failures_to_tolerate = ha_host_failures_to_tolerate;
            this.ha_plan_exists_for = ha_plan_exists_for;
            this.ha_allow_overcommit = ha_allow_overcommit;
            this.ha_overcommitted = ha_overcommitted;
            this.blobs = blobs;
            this.tags = tags;
            this.gui_config = gui_config;
            this.health_check_config = health_check_config;
            this.wlb_url = wlb_url;
            this.wlb_username = wlb_username;
            this.wlb_enabled = wlb_enabled;
            this.wlb_verify_cert = wlb_verify_cert;
            this.redo_log_enabled = redo_log_enabled;
            this.redo_log_vdi = redo_log_vdi;
            this.vswitch_controller = vswitch_controller;
            this.restrictions = restrictions;
            this.metadata_VDIs = metadata_VDIs;
            this.ha_cluster_stack = ha_cluster_stack;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.guest_agent_config = guest_agent_config;
        }

        public static void add_tags(Session session, string _pool, string _value)
        {
            session.proxy.pool_add_tags(session.uuid, (_pool != null) ? _pool : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_guest_agent_config(Session session, string _pool, string _key, string _value)
        {
            session.proxy.pool_add_to_guest_agent_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_gui_config(Session session, string _pool, string _key, string _value)
        {
            session.proxy.pool_add_to_gui_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_health_check_config(Session session, string _pool, string _key, string _value)
        {
            session.proxy.pool_add_to_health_check_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void add_to_other_config(Session session, string _pool, string _key, string _value)
        {
            session.proxy.pool_add_to_other_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void apply_edition(Session session, string _pool, string _edition)
        {
            session.proxy.pool_apply_edition(session.uuid, (_pool != null) ? _pool : "", (_edition != null) ? _edition : "").parse();
        }

        public static XenRef<Task> async_add_to_guest_agent_config(Session session, string _pool, string _key, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_add_to_guest_agent_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse());
        }

        public static XenRef<Task> async_apply_edition(Session session, string _pool, string _edition)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_apply_edition(session.uuid, (_pool != null) ? _pool : "", (_edition != null) ? _edition : "").parse());
        }

        public static XenRef<Task> async_certificate_install(Session session, string _name, string _cert)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_certificate_install(session.uuid, (_name != null) ? _name : "", (_cert != null) ? _cert : "").parse());
        }

        public static XenRef<Task> async_certificate_list(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_certificate_list(session.uuid).parse());
        }

        public static XenRef<Task> async_certificate_sync(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_certificate_sync(session.uuid).parse());
        }

        public static XenRef<Task> async_certificate_uninstall(Session session, string _name)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_certificate_uninstall(session.uuid, (_name != null) ? _name : "").parse());
        }

        public static XenRef<Task> async_create_new_blob(Session session, string _pool, string _name, string _mime_type)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_create_new_blob(session.uuid, (_pool != null) ? _pool : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        public static XenRef<Task> async_create_new_blob(Session session, string _pool, string _name, string _mime_type, bool _public)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_create_new_blob(session.uuid, (_pool != null) ? _pool : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public static XenRef<Task> async_create_VLAN(Session session, string _device, string _network, long _vlan)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_create_vlan(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", _vlan.ToString()).parse());
        }

        public static XenRef<Task> async_create_VLAN_from_PIF(Session session, string _pif, string _network, long _vlan)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_create_vlan_from_pif(session.uuid, (_pif != null) ? _pif : "", (_network != null) ? _network : "", _vlan.ToString()).parse());
        }

        public static XenRef<Task> async_crl_install(Session session, string _name, string _cert)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_crl_install(session.uuid, (_name != null) ? _name : "", (_cert != null) ? _cert : "").parse());
        }

        public static XenRef<Task> async_crl_list(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_crl_list(session.uuid).parse());
        }

        public static XenRef<Task> async_crl_uninstall(Session session, string _name)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_crl_uninstall(session.uuid, (_name != null) ? _name : "").parse());
        }

        public static XenRef<Task> async_deconfigure_wlb(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_deconfigure_wlb(session.uuid).parse());
        }

        public static XenRef<Task> async_designate_new_master(Session session, string _host)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_designate_new_master(session.uuid, (_host != null) ? _host : "").parse());
        }

        public static XenRef<Task> async_disable_ha(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_disable_ha(session.uuid).parse());
        }

        public static XenRef<Task> async_disable_local_storage_caching(Session session, string _pool)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_disable_local_storage_caching(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Task> async_disable_redo_log(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_disable_redo_log(session.uuid).parse());
        }

        public static XenRef<Task> async_disable_ssl_legacy(Session session, string _pool)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_disable_ssl_legacy(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Task> async_eject(Session session, string _host)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_eject(session.uuid, (_host != null) ? _host : "").parse());
        }

        public static XenRef<Task> async_enable_ha(Session session, List<XenRef<WinAPI.SR>> _heartbeat_srs, Dictionary<string, string> _configuration)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_enable_ha(session.uuid, (_heartbeat_srs != null) ? Helper.RefListToStringArray<WinAPI.SR>(_heartbeat_srs) : new string[0], Maps.convert_to_proxy_string_string(_configuration)).parse());
        }

        public static XenRef<Task> async_enable_local_storage_caching(Session session, string _pool)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_enable_local_storage_caching(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Task> async_enable_redo_log(Session session, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_enable_redo_log(session.uuid, (_sr != null) ? _sr : "").parse());
        }

        public static XenRef<Task> async_enable_ssl_legacy(Session session, string _pool)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_enable_ssl_legacy(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Task> async_get_license_state(Session session, string _pool)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_get_license_state(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Task> async_has_extension(Session session, string _pool, string _name)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_has_extension(session.uuid, (_pool != null) ? _pool : "", (_name != null) ? _name : "").parse());
        }

        public static XenRef<Task> async_initialize_wlb(Session session, string _wlb_url, string _wlb_username, string _wlb_password, string _xenserver_username, string _xenserver_password)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_initialize_wlb(session.uuid, (_wlb_url != null) ? _wlb_url : "", (_wlb_username != null) ? _wlb_username : "", (_wlb_password != null) ? _wlb_password : "", (_xenserver_username != null) ? _xenserver_username : "", (_xenserver_password != null) ? _xenserver_password : "").parse());
        }

        public static XenRef<Task> async_join(Session session, string _master_address, string _master_username, string _master_password)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_join(session.uuid, (_master_address != null) ? _master_address : "", (_master_username != null) ? _master_username : "", (_master_password != null) ? _master_password : "").parse());
        }

        public static XenRef<Task> async_join_force(Session session, string _master_address, string _master_username, string _master_password)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_join_force(session.uuid, (_master_address != null) ? _master_address : "", (_master_username != null) ? _master_username : "", (_master_password != null) ? _master_password : "").parse());
        }

        public static XenRef<Task> async_recover_slaves(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_recover_slaves(session.uuid).parse());
        }

        public static XenRef<Task> async_remove_from_guest_agent_config(Session session, string _pool, string _key)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_remove_from_guest_agent_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "").parse());
        }

        public static XenRef<Task> async_retrieve_wlb_configuration(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_retrieve_wlb_configuration(session.uuid).parse());
        }

        public static XenRef<Task> async_retrieve_wlb_recommendations(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_retrieve_wlb_recommendations(session.uuid).parse());
        }

        public static XenRef<Task> async_send_test_post(Session session, string _host, long _port, string _body)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_send_test_post(session.uuid, (_host != null) ? _host : "", _port.ToString(), (_body != null) ? _body : "").parse());
        }

        public static XenRef<Task> async_send_wlb_configuration(Session session, Dictionary<string, string> _config)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_send_wlb_configuration(session.uuid, Maps.convert_to_proxy_string_string(_config)).parse());
        }

        public static XenRef<Task> async_set_ha_host_failures_to_tolerate(Session session, string _pool, long _value)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_set_ha_host_failures_to_tolerate(session.uuid, (_pool != null) ? _pool : "", _value.ToString()).parse());
        }

        public static XenRef<Task> async_set_vswitch_controller(Session session, string _address)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_set_vswitch_controller(session.uuid, (_address != null) ? _address : "").parse());
        }

        public static XenRef<Task> async_sync_database(Session session)
        {
            return XenRef<Task>.Create(session.proxy.async_pool_sync_database(session.uuid).parse());
        }

        public static void certificate_install(Session session, string _name, string _cert)
        {
            session.proxy.pool_certificate_install(session.uuid, (_name != null) ? _name : "", (_cert != null) ? _cert : "").parse();
        }

        public static string[] certificate_list(Session session)
        {
            return session.proxy.pool_certificate_list(session.uuid).parse();
        }

        public static void certificate_sync(Session session)
        {
            session.proxy.pool_certificate_sync(session.uuid).parse();
        }

        public static void certificate_uninstall(Session session, string _name)
        {
            session.proxy.pool_certificate_uninstall(session.uuid, (_name != null) ? _name : "").parse();
        }

        public static XenRef<Blob> create_new_blob(Session session, string _pool, string _name, string _mime_type)
        {
            return XenRef<Blob>.Create(session.proxy.pool_create_new_blob(session.uuid, (_pool != null) ? _pool : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        public static XenRef<Blob> create_new_blob(Session session, string _pool, string _name, string _mime_type, bool _public)
        {
            return XenRef<Blob>.Create(session.proxy.pool_create_new_blob(session.uuid, (_pool != null) ? _pool : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public static List<XenRef<PIF>> create_VLAN(Session session, string _device, string _network, long _vlan)
        {
            return XenRef<PIF>.Create(session.proxy.pool_create_vlan(session.uuid, (_device != null) ? _device : "", (_network != null) ? _network : "", _vlan.ToString()).parse());
        }

        public static List<XenRef<PIF>> create_VLAN_from_PIF(Session session, string _pif, string _network, long _vlan)
        {
            return XenRef<PIF>.Create(session.proxy.pool_create_vlan_from_pif(session.uuid, (_pif != null) ? _pif : "", (_network != null) ? _network : "", _vlan.ToString()).parse());
        }

        public static void crl_install(Session session, string _name, string _cert)
        {
            session.proxy.pool_crl_install(session.uuid, (_name != null) ? _name : "", (_cert != null) ? _cert : "").parse();
        }

        public static string[] crl_list(Session session)
        {
            return session.proxy.pool_crl_list(session.uuid).parse();
        }

        public static void crl_uninstall(Session session, string _name)
        {
            session.proxy.pool_crl_uninstall(session.uuid, (_name != null) ? _name : "").parse();
        }

        public static void deconfigure_wlb(Session session)
        {
            session.proxy.pool_deconfigure_wlb(session.uuid).parse();
        }

        public bool DeepEquals(Pool other, bool ignoreCurrentOperations)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!ignoreCurrentOperations && !Helper.AreEqual2<Dictionary<string, pool_allowed_operations>>(this.current_operations, other.current_operations))
            {
                return false;
            }
            return ((((((Helper.AreEqual2<string>(this._uuid, other._uuid) && Helper.AreEqual2<string>(this._name_label, other._name_label)) && (Helper.AreEqual2<string>(this._name_description, other._name_description) && Helper.AreEqual2<XenRef<Host>>(this._master, other._master))) && ((Helper.AreEqual2<XenRef<WinAPI.SR>>(this._default_SR, other._default_SR) && Helper.AreEqual2<XenRef<WinAPI.SR>>(this._suspend_image_SR, other._suspend_image_SR)) && (Helper.AreEqual2<XenRef<WinAPI.SR>>(this._crash_dump_SR, other._crash_dump_SR) && Helper.AreEqual2<Dictionary<string, string>>(this._other_config, other._other_config)))) && (((Helper.AreEqual2<bool>(this._ha_enabled, other._ha_enabled) && Helper.AreEqual2<Dictionary<string, string>>(this._ha_configuration, other._ha_configuration)) && (Helper.AreEqual2<string[]>(this._ha_statefiles, other._ha_statefiles) && Helper.AreEqual2<long>(this._ha_host_failures_to_tolerate, other._ha_host_failures_to_tolerate))) && ((Helper.AreEqual2<long>(this._ha_plan_exists_for, other._ha_plan_exists_for) && Helper.AreEqual2<bool>(this._ha_allow_overcommit, other._ha_allow_overcommit)) && (Helper.AreEqual2<bool>(this._ha_overcommitted, other._ha_overcommitted) && Helper.AreEqual2<Dictionary<string, XenRef<Blob>>>(this._blobs, other._blobs))))) && ((((Helper.AreEqual2<string[]>(this._tags, other._tags) && Helper.AreEqual2<Dictionary<string, string>>(this._gui_config, other._gui_config)) && (Helper.AreEqual2<Dictionary<string, string>>(this._health_check_config, other._health_check_config) && Helper.AreEqual2<string>(this._wlb_url, other._wlb_url))) && ((Helper.AreEqual2<string>(this._wlb_username, other._wlb_username) && Helper.AreEqual2<bool>(this._wlb_enabled, other._wlb_enabled)) && (Helper.AreEqual2<bool>(this._wlb_verify_cert, other._wlb_verify_cert) && Helper.AreEqual2<bool>(this._redo_log_enabled, other._redo_log_enabled)))) && (((Helper.AreEqual2<XenRef<VDI>>(this._redo_log_vdi, other._redo_log_vdi) && Helper.AreEqual2<string>(this._vswitch_controller, other._vswitch_controller)) && (Helper.AreEqual2<Dictionary<string, string>>(this._restrictions, other._restrictions) && Helper.AreEqual2<List<XenRef<VDI>>>(this._metadata_VDIs, other._metadata_VDIs))) && (Helper.AreEqual2<string>(this._ha_cluster_stack, other._ha_cluster_stack) && Helper.AreEqual2<List<pool_allowed_operations>>(this._allowed_operations, other._allowed_operations))))) && Helper.AreEqual2<Dictionary<string, string>>(this._guest_agent_config, other._guest_agent_config));
        }

        public static void designate_new_master(Session session, string _host)
        {
            session.proxy.pool_designate_new_master(session.uuid, (_host != null) ? _host : "").parse();
        }

        public static void detect_nonhomogeneous_external_auth(Session session, string _pool)
        {
            session.proxy.pool_detect_nonhomogeneous_external_auth(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static void disable_external_auth(Session session, string _pool, Dictionary<string, string> _config)
        {
            session.proxy.pool_disable_external_auth(session.uuid, (_pool != null) ? _pool : "", Maps.convert_to_proxy_string_string(_config)).parse();
        }

        public static void disable_ha(Session session)
        {
            session.proxy.pool_disable_ha(session.uuid).parse();
        }

        public static void disable_local_storage_caching(Session session, string _pool)
        {
            session.proxy.pool_disable_local_storage_caching(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static void disable_redo_log(Session session)
        {
            session.proxy.pool_disable_redo_log(session.uuid).parse();
        }

        public static void disable_ssl_legacy(Session session, string _pool)
        {
            session.proxy.pool_disable_ssl_legacy(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static void eject(Session session, string _host)
        {
            session.proxy.pool_eject(session.uuid, (_host != null) ? _host : "").parse();
        }

        public static void emergency_reset_master(Session session, string _master_address)
        {
            session.proxy.pool_emergency_reset_master(session.uuid, (_master_address != null) ? _master_address : "").parse();
        }

        public static void emergency_transition_to_master(Session session)
        {
            session.proxy.pool_emergency_transition_to_master(session.uuid).parse();
        }

        public static void enable_external_auth(Session session, string _pool, Dictionary<string, string> _config, string _service_name, string _auth_type)
        {
            session.proxy.pool_enable_external_auth(session.uuid, (_pool != null) ? _pool : "", Maps.convert_to_proxy_string_string(_config), (_service_name != null) ? _service_name : "", (_auth_type != null) ? _auth_type : "").parse();
        }

        public static void enable_ha(Session session, List<XenRef<WinAPI.SR>> _heartbeat_srs, Dictionary<string, string> _configuration)
        {
            session.proxy.pool_enable_ha(session.uuid, (_heartbeat_srs != null) ? Helper.RefListToStringArray<WinAPI.SR>(_heartbeat_srs) : new string[0], Maps.convert_to_proxy_string_string(_configuration)).parse();
        }

        public static void enable_local_storage_caching(Session session, string _pool)
        {
            session.proxy.pool_enable_local_storage_caching(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static void enable_redo_log(Session session, string _sr)
        {
            session.proxy.pool_enable_redo_log(session.uuid, (_sr != null) ? _sr : "").parse();
        }

        public static void enable_ssl_legacy(Session session, string _pool)
        {
            session.proxy.pool_enable_ssl_legacy(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static List<XenRef<Pool>> get_all(Session session)
        {
            return XenRef<Pool>.Create(session.proxy.pool_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Pool>, Pool> get_all_records(Session session)
        {
            return XenRef<Pool>.Create<Proxy_Pool>(session.proxy.pool_get_all_records(session.uuid).parse());
        }

        public static List<pool_allowed_operations> get_allowed_operations(Session session, string _pool)
        {
            return Helper.StringArrayToEnumList<pool_allowed_operations>(session.proxy.pool_get_allowed_operations(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Dictionary<string, XenRef<Blob>> get_blobs(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_XenRefBlob(session.proxy.pool_get_blobs(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Pool> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Pool>.Create(session.proxy.pool_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static XenRef<WinAPI.SR> get_crash_dump_SR(Session session, string _pool)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.pool_get_crash_dump_sr(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Dictionary<string, pool_allowed_operations> get_current_operations(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_pool_allowed_operations(session.proxy.pool_get_current_operations(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<WinAPI.SR> get_default_SR(Session session, string _pool)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.pool_get_default_sr(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Dictionary<string, string> get_guest_agent_config(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_guest_agent_config(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Dictionary<string, string> get_gui_config(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_gui_config(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static bool get_ha_allow_overcommit(Session session, string _pool)
        {
            return session.proxy.pool_get_ha_allow_overcommit(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static string get_ha_cluster_stack(Session session, string _pool)
        {
            return session.proxy.pool_get_ha_cluster_stack(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static Dictionary<string, string> get_ha_configuration(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_ha_configuration(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static bool get_ha_enabled(Session session, string _pool)
        {
            return session.proxy.pool_get_ha_enabled(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static long get_ha_host_failures_to_tolerate(Session session, string _pool)
        {
            return long.Parse(session.proxy.pool_get_ha_host_failures_to_tolerate(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static bool get_ha_overcommitted(Session session, string _pool)
        {
            return session.proxy.pool_get_ha_overcommitted(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static long get_ha_plan_exists_for(Session session, string _pool)
        {
            return long.Parse(session.proxy.pool_get_ha_plan_exists_for(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static string[] get_ha_statefiles(Session session, string _pool)
        {
            return session.proxy.pool_get_ha_statefiles(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static Dictionary<string, string> get_health_check_config(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_health_check_config(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Dictionary<string, string> get_license_state(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_license_state(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<Host> get_master(Session session, string _pool)
        {
            return XenRef<Host>.Create(session.proxy.pool_get_master(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static List<XenRef<VDI>> get_metadata_VDIs(Session session, string _pool)
        {
            return XenRef<VDI>.Create(session.proxy.pool_get_metadata_vdis(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static string get_name_description(Session session, string _pool)
        {
            return session.proxy.pool_get_name_description(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static string get_name_label(Session session, string _pool)
        {
            return session.proxy.pool_get_name_label(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_other_config(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Pool get_record(Session session, string _pool)
        {
            return new Pool(session.proxy.pool_get_record(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static bool get_redo_log_enabled(Session session, string _pool)
        {
            return session.proxy.pool_get_redo_log_enabled(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static XenRef<VDI> get_redo_log_vdi(Session session, string _pool)
        {
            return XenRef<VDI>.Create(session.proxy.pool_get_redo_log_vdi(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static Dictionary<string, string> get_restrictions(Session session, string _pool)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_get_restrictions(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static XenRef<WinAPI.SR> get_suspend_image_SR(Session session, string _pool)
        {
            return XenRef<WinAPI.SR>.Create(session.proxy.pool_get_suspend_image_sr(session.uuid, (_pool != null) ? _pool : "").parse());
        }

        public static string[] get_tags(Session session, string _pool)
        {
            return session.proxy.pool_get_tags(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static string get_uuid(Session session, string _pool)
        {
            return session.proxy.pool_get_uuid(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static string get_vswitch_controller(Session session, string _pool)
        {
            return session.proxy.pool_get_vswitch_controller(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static bool get_wlb_enabled(Session session, string _pool)
        {
            return session.proxy.pool_get_wlb_enabled(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static string get_wlb_url(Session session, string _pool)
        {
            return session.proxy.pool_get_wlb_url(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static string get_wlb_username(Session session, string _pool)
        {
            return session.proxy.pool_get_wlb_username(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static bool get_wlb_verify_cert(Session session, string _pool)
        {
            return session.proxy.pool_get_wlb_verify_cert(session.uuid, (_pool != null) ? _pool : "").parse();
        }

        public static long ha_compute_hypothetical_max_host_failures_to_tolerate(Session session, Dictionary<XenRef<VM>, string> _configuration)
        {
            return long.Parse(session.proxy.pool_ha_compute_hypothetical_max_host_failures_to_tolerate(session.uuid, Maps.convert_to_proxy_XenRefVM_string(_configuration)).parse());
        }

        public static long ha_compute_max_host_failures_to_tolerate(Session session)
        {
            return long.Parse(session.proxy.pool_ha_compute_max_host_failures_to_tolerate(session.uuid).parse());
        }

        public static Dictionary<XenRef<VM>, Dictionary<string, string>> ha_compute_vm_failover_plan(Session session, List<XenRef<Host>> _failed_hosts, List<XenRef<VM>> _failed_vms)
        {
            return Maps.convert_from_proxy_XenRefVM_Dictionary_string_string(session.proxy.pool_ha_compute_vm_failover_plan(session.uuid, (_failed_hosts != null) ? Helper.RefListToStringArray<Host>(_failed_hosts) : new string[0], (_failed_vms != null) ? Helper.RefListToStringArray<VM>(_failed_vms) : new string[0]).parse());
        }

        public static bool ha_failover_plan_exists(Session session, long _n)
        {
            return session.proxy.pool_ha_failover_plan_exists(session.uuid, _n.ToString()).parse();
        }

        public static void ha_prevent_restarts_for(Session session, long _seconds)
        {
            session.proxy.pool_ha_prevent_restarts_for(session.uuid, _seconds.ToString()).parse();
        }

        public static bool has_extension(Session session, string _pool, string _name)
        {
            return session.proxy.pool_has_extension(session.uuid, (_pool != null) ? _pool : "", (_name != null) ? _name : "").parse();
        }

        public static void initialize_wlb(Session session, string _wlb_url, string _wlb_username, string _wlb_password, string _xenserver_username, string _xenserver_password)
        {
            session.proxy.pool_initialize_wlb(session.uuid, (_wlb_url != null) ? _wlb_url : "", (_wlb_username != null) ? _wlb_username : "", (_wlb_password != null) ? _wlb_password : "", (_xenserver_username != null) ? _xenserver_username : "", (_xenserver_password != null) ? _xenserver_password : "").parse();
        }

        public static void join(Session session, string _master_address, string _master_username, string _master_password)
        {
            session.proxy.pool_join(session.uuid, (_master_address != null) ? _master_address : "", (_master_username != null) ? _master_username : "", (_master_password != null) ? _master_password : "").parse();
        }

        public static void join_force(Session session, string _master_address, string _master_username, string _master_password)
        {
            session.proxy.pool_join_force(session.uuid, (_master_address != null) ? _master_address : "", (_master_username != null) ? _master_username : "", (_master_password != null) ? _master_password : "").parse();
        }

        public static List<XenRef<Host>> recover_slaves(Session session)
        {
            return XenRef<Host>.Create(session.proxy.pool_recover_slaves(session.uuid).parse());
        }

        public static void remove_from_guest_agent_config(Session session, string _pool, string _key)
        {
            session.proxy.pool_remove_from_guest_agent_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_gui_config(Session session, string _pool, string _key)
        {
            session.proxy.pool_remove_from_gui_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_health_check_config(Session session, string _pool, string _key)
        {
            session.proxy.pool_remove_from_health_check_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_from_other_config(Session session, string _pool, string _key)
        {
            session.proxy.pool_remove_from_other_config(session.uuid, (_pool != null) ? _pool : "", (_key != null) ? _key : "").parse();
        }

        public static void remove_tags(Session session, string _pool, string _value)
        {
            session.proxy.pool_remove_tags(session.uuid, (_pool != null) ? _pool : "", (_value != null) ? _value : "").parse();
        }

        public static Dictionary<string, string> retrieve_wlb_configuration(Session session)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.pool_retrieve_wlb_configuration(session.uuid).parse());
        }

        public static Dictionary<XenRef<VM>, string[]> retrieve_wlb_recommendations(Session session)
        {
            return Maps.convert_from_proxy_XenRefVM_string_array(session.proxy.pool_retrieve_wlb_recommendations(session.uuid).parse());
        }

        public override string SaveChanges(Session session, string opaqueRef, Pool server)
        {
            if (opaqueRef == null)
            {
                return "";
            }
            if (!Helper.AreEqual2<string>(this._name_label, server._name_label))
            {
                set_name_label(session, opaqueRef, this._name_label);
            }
            if (!Helper.AreEqual2<string>(this._name_description, server._name_description))
            {
                set_name_description(session, opaqueRef, this._name_description);
            }
            if (!Helper.AreEqual2<XenRef<WinAPI.SR>>(this._default_SR, server._default_SR))
            {
                set_default_SR(session, opaqueRef, (string) this._default_SR);
            }
            if (!Helper.AreEqual2<XenRef<WinAPI.SR>>(this._suspend_image_SR, server._suspend_image_SR))
            {
                set_suspend_image_SR(session, opaqueRef, (string) this._suspend_image_SR);
            }
            if (!Helper.AreEqual2<XenRef<WinAPI.SR>>(this._crash_dump_SR, server._crash_dump_SR))
            {
                set_crash_dump_SR(session, opaqueRef, (string) this._crash_dump_SR);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._other_config, server._other_config))
            {
                set_other_config(session, opaqueRef, this._other_config);
            }
            if (!Helper.AreEqual2<bool>(this._ha_allow_overcommit, server._ha_allow_overcommit))
            {
                set_ha_allow_overcommit(session, opaqueRef, this._ha_allow_overcommit);
            }
            if (!Helper.AreEqual2<string[]>(this._tags, server._tags))
            {
                set_tags(session, opaqueRef, this._tags);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._gui_config, server._gui_config))
            {
                set_gui_config(session, opaqueRef, this._gui_config);
            }
            if (!Helper.AreEqual2<Dictionary<string, string>>(this._health_check_config, server._health_check_config))
            {
                set_health_check_config(session, opaqueRef, this._health_check_config);
            }
            if (!Helper.AreEqual2<bool>(this._wlb_enabled, server._wlb_enabled))
            {
                set_wlb_enabled(session, opaqueRef, this._wlb_enabled);
            }
            if (!Helper.AreEqual2<bool>(this._wlb_verify_cert, server._wlb_verify_cert))
            {
                set_wlb_verify_cert(session, opaqueRef, this._wlb_verify_cert);
            }
            return null;
        }

        public static string send_test_post(Session session, string _host, long _port, string _body)
        {
            return session.proxy.pool_send_test_post(session.uuid, (_host != null) ? _host : "", _port.ToString(), (_body != null) ? _body : "").parse();
        }

        public static void send_wlb_configuration(Session session, Dictionary<string, string> _config)
        {
            session.proxy.pool_send_wlb_configuration(session.uuid, Maps.convert_to_proxy_string_string(_config)).parse();
        }

        public static void set_crash_dump_SR(Session session, string _pool, string _crash_dump_sr)
        {
            session.proxy.pool_set_crash_dump_sr(session.uuid, (_pool != null) ? _pool : "", (_crash_dump_sr != null) ? _crash_dump_sr : "").parse();
        }

        public static void set_default_SR(Session session, string _pool, string _default_sr)
        {
            session.proxy.pool_set_default_sr(session.uuid, (_pool != null) ? _pool : "", (_default_sr != null) ? _default_sr : "").parse();
        }

        public static void set_gui_config(Session session, string _pool, Dictionary<string, string> _gui_config)
        {
            session.proxy.pool_set_gui_config(session.uuid, (_pool != null) ? _pool : "", Maps.convert_to_proxy_string_string(_gui_config)).parse();
        }

        public static void set_ha_allow_overcommit(Session session, string _pool, bool _ha_allow_overcommit)
        {
            session.proxy.pool_set_ha_allow_overcommit(session.uuid, (_pool != null) ? _pool : "", _ha_allow_overcommit).parse();
        }

        public static void set_ha_host_failures_to_tolerate(Session session, string _pool, long _value)
        {
            session.proxy.pool_set_ha_host_failures_to_tolerate(session.uuid, (_pool != null) ? _pool : "", _value.ToString()).parse();
        }

        public static void set_health_check_config(Session session, string _pool, Dictionary<string, string> _health_check_config)
        {
            session.proxy.pool_set_health_check_config(session.uuid, (_pool != null) ? _pool : "", Maps.convert_to_proxy_string_string(_health_check_config)).parse();
        }

        public static void set_name_description(Session session, string _pool, string _name_description)
        {
            session.proxy.pool_set_name_description(session.uuid, (_pool != null) ? _pool : "", (_name_description != null) ? _name_description : "").parse();
        }

        public static void set_name_label(Session session, string _pool, string _name_label)
        {
            session.proxy.pool_set_name_label(session.uuid, (_pool != null) ? _pool : "", (_name_label != null) ? _name_label : "").parse();
        }

        public static void set_other_config(Session session, string _pool, Dictionary<string, string> _other_config)
        {
            session.proxy.pool_set_other_config(session.uuid, (_pool != null) ? _pool : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void set_suspend_image_SR(Session session, string _pool, string _suspend_image_sr)
        {
            session.proxy.pool_set_suspend_image_sr(session.uuid, (_pool != null) ? _pool : "", (_suspend_image_sr != null) ? _suspend_image_sr : "").parse();
        }

        public static void set_tags(Session session, string _pool, string[] _tags)
        {
            session.proxy.pool_set_tags(session.uuid, (_pool != null) ? _pool : "", _tags).parse();
        }

        public static void set_vswitch_controller(Session session, string _address)
        {
            session.proxy.pool_set_vswitch_controller(session.uuid, (_address != null) ? _address : "").parse();
        }

        public static void set_wlb_enabled(Session session, string _pool, bool _wlb_enabled)
        {
            session.proxy.pool_set_wlb_enabled(session.uuid, (_pool != null) ? _pool : "", _wlb_enabled).parse();
        }

        public static void set_wlb_verify_cert(Session session, string _pool, bool _wlb_verify_cert)
        {
            session.proxy.pool_set_wlb_verify_cert(session.uuid, (_pool != null) ? _pool : "", _wlb_verify_cert).parse();
        }

        public static void sync_database(Session session)
        {
            session.proxy.pool_sync_database(session.uuid).parse();
        }

        public static string test_archive_target(Session session, string _pool, Dictionary<string, string> _config)
        {
            return session.proxy.pool_test_archive_target(session.uuid, (_pool != null) ? _pool : "", Maps.convert_to_proxy_string_string(_config)).parse();
        }

        public Proxy_Pool ToProxy()
        {
            return new Proxy_Pool { 
                uuid = (this.uuid != null) ? this.uuid : "", name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", master = (this.master != null) ? ((string) this.master) : "", default_SR = (this.default_SR != null) ? ((string) this.default_SR) : "", suspend_image_SR = (this.suspend_image_SR != null) ? ((string) this.suspend_image_SR) : "", crash_dump_SR = (this.crash_dump_SR != null) ? ((string) this.crash_dump_SR) : "", other_config = Maps.convert_to_proxy_string_string(this.other_config), ha_enabled = this.ha_enabled, ha_configuration = Maps.convert_to_proxy_string_string(this.ha_configuration), ha_statefiles = this.ha_statefiles, ha_host_failures_to_tolerate = this.ha_host_failures_to_tolerate.ToString(), ha_plan_exists_for = this.ha_plan_exists_for.ToString(), ha_allow_overcommit = this.ha_allow_overcommit, ha_overcommitted = this.ha_overcommitted, blobs = Maps.convert_to_proxy_string_XenRefBlob(this.blobs), 
                tags = this.tags, gui_config = Maps.convert_to_proxy_string_string(this.gui_config), health_check_config = Maps.convert_to_proxy_string_string(this.health_check_config), wlb_url = (this.wlb_url != null) ? this.wlb_url : "", wlb_username = (this.wlb_username != null) ? this.wlb_username : "", wlb_enabled = this.wlb_enabled, wlb_verify_cert = this.wlb_verify_cert, redo_log_enabled = this.redo_log_enabled, redo_log_vdi = (this.redo_log_vdi != null) ? ((string) this.redo_log_vdi) : "", vswitch_controller = (this.vswitch_controller != null) ? this.vswitch_controller : "", restrictions = Maps.convert_to_proxy_string_string(this.restrictions), metadata_VDIs = (this.metadata_VDIs != null) ? Helper.RefListToStringArray<VDI>(this.metadata_VDIs) : new string[0], ha_cluster_stack = (this.ha_cluster_stack != null) ? this.ha_cluster_stack : "", allowed_operations = (this.allowed_operations != null) ? Helper.ObjectListToStringArray<pool_allowed_operations>(this.allowed_operations) : new string[0], current_operations = Maps.convert_to_proxy_string_pool_allowed_operations(this.current_operations), guest_agent_config = Maps.convert_to_proxy_string_string(this.guest_agent_config)
             };
        }

        public override void UpdateFrom(Pool update)
        {
            this.uuid = update.uuid;
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.master = update.master;
            this.default_SR = update.default_SR;
            this.suspend_image_SR = update.suspend_image_SR;
            this.crash_dump_SR = update.crash_dump_SR;
            this.other_config = update.other_config;
            this.ha_enabled = update.ha_enabled;
            this.ha_configuration = update.ha_configuration;
            this.ha_statefiles = update.ha_statefiles;
            this.ha_host_failures_to_tolerate = update.ha_host_failures_to_tolerate;
            this.ha_plan_exists_for = update.ha_plan_exists_for;
            this.ha_allow_overcommit = update.ha_allow_overcommit;
            this.ha_overcommitted = update.ha_overcommitted;
            this.blobs = update.blobs;
            this.tags = update.tags;
            this.gui_config = update.gui_config;
            this.health_check_config = update.health_check_config;
            this.wlb_url = update.wlb_url;
            this.wlb_username = update.wlb_username;
            this.wlb_enabled = update.wlb_enabled;
            this.wlb_verify_cert = update.wlb_verify_cert;
            this.redo_log_enabled = update.redo_log_enabled;
            this.redo_log_vdi = update.redo_log_vdi;
            this.vswitch_controller = update.vswitch_controller;
            this.restrictions = update.restrictions;
            this.metadata_VDIs = update.metadata_VDIs;
            this.ha_cluster_stack = update.ha_cluster_stack;
            this.allowed_operations = update.allowed_operations;
            this.current_operations = update.current_operations;
            this.guest_agent_config = update.guest_agent_config;
        }

        internal void UpdateFromProxy(Proxy_Pool proxy)
        {
            this.uuid = (proxy.uuid == null) ? null : proxy.uuid;
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.master = (proxy.master == null) ? null : XenRef<Host>.Create(proxy.master);
            this.default_SR = (proxy.default_SR == null) ? null : XenRef<WinAPI.SR>.Create(proxy.default_SR);
            this.suspend_image_SR = (proxy.suspend_image_SR == null) ? null : XenRef<WinAPI.SR>.Create(proxy.suspend_image_SR);
            this.crash_dump_SR = (proxy.crash_dump_SR == null) ? null : XenRef<WinAPI.SR>.Create(proxy.crash_dump_SR);
            this.other_config = (proxy.other_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            this.ha_enabled = proxy.ha_enabled;
            this.ha_configuration = (proxy.ha_configuration == null) ? null : Maps.convert_from_proxy_string_string(proxy.ha_configuration);
            this.ha_statefiles = (proxy.ha_statefiles == null) ? new string[0] : proxy.ha_statefiles;
            this.ha_host_failures_to_tolerate = (proxy.ha_host_failures_to_tolerate == null) ? 0L : long.Parse(proxy.ha_host_failures_to_tolerate);
            this.ha_plan_exists_for = (proxy.ha_plan_exists_for == null) ? 0L : long.Parse(proxy.ha_plan_exists_for);
            this.ha_allow_overcommit = proxy.ha_allow_overcommit;
            this.ha_overcommitted = proxy.ha_overcommitted;
            this.blobs = (proxy.blobs == null) ? null : Maps.convert_from_proxy_string_XenRefBlob(proxy.blobs);
            this.tags = (proxy.tags == null) ? new string[0] : proxy.tags;
            this.gui_config = (proxy.gui_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.gui_config);
            this.health_check_config = (proxy.health_check_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.health_check_config);
            this.wlb_url = (proxy.wlb_url == null) ? null : proxy.wlb_url;
            this.wlb_username = (proxy.wlb_username == null) ? null : proxy.wlb_username;
            this.wlb_enabled = proxy.wlb_enabled;
            this.wlb_verify_cert = proxy.wlb_verify_cert;
            this.redo_log_enabled = proxy.redo_log_enabled;
            this.redo_log_vdi = (proxy.redo_log_vdi == null) ? null : XenRef<VDI>.Create(proxy.redo_log_vdi);
            this.vswitch_controller = (proxy.vswitch_controller == null) ? null : proxy.vswitch_controller;
            this.restrictions = (proxy.restrictions == null) ? null : Maps.convert_from_proxy_string_string(proxy.restrictions);
            this.metadata_VDIs = (proxy.metadata_VDIs == null) ? null : XenRef<VDI>.Create(proxy.metadata_VDIs);
            this.ha_cluster_stack = (proxy.ha_cluster_stack == null) ? null : proxy.ha_cluster_stack;
            this.allowed_operations = (proxy.allowed_operations == null) ? null : Helper.StringArrayToEnumList<pool_allowed_operations>(proxy.allowed_operations);
            this.current_operations = (proxy.current_operations == null) ? null : Maps.convert_from_proxy_string_pool_allowed_operations(proxy.current_operations);
            this.guest_agent_config = (proxy.guest_agent_config == null) ? null : Maps.convert_from_proxy_string_string(proxy.guest_agent_config);
        }

        public virtual List<pool_allowed_operations> allowed_operations
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

        public virtual Dictionary<string, XenRef<Blob>> blobs
        {
            get
            {
                return this._blobs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._blobs))
                {
                    this._blobs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("blobs");
                }
            }
        }

        public virtual XenRef<WinAPI.SR> crash_dump_SR
        {
            get
            {
                return this._crash_dump_SR;
            }
            set
            {
                if (!Helper.AreEqual(value, this._crash_dump_SR))
                {
                    this._crash_dump_SR = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("crash_dump_SR");
                }
            }
        }

        public virtual Dictionary<string, pool_allowed_operations> current_operations
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

        public virtual XenRef<WinAPI.SR> default_SR
        {
            get
            {
                return this._default_SR;
            }
            set
            {
                if (!Helper.AreEqual(value, this._default_SR))
                {
                    this._default_SR = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("default_SR");
                }
            }
        }

        public virtual Dictionary<string, string> guest_agent_config
        {
            get
            {
                return this._guest_agent_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._guest_agent_config))
                {
                    this._guest_agent_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("guest_agent_config");
                }
            }
        }

        public virtual Dictionary<string, string> gui_config
        {
            get
            {
                return this._gui_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._gui_config))
                {
                    this._gui_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("gui_config");
                }
            }
        }

        public virtual bool ha_allow_overcommit
        {
            get
            {
                return this._ha_allow_overcommit;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_allow_overcommit))
                {
                    this._ha_allow_overcommit = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_allow_overcommit");
                }
            }
        }

        public virtual string ha_cluster_stack
        {
            get
            {
                return this._ha_cluster_stack;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_cluster_stack))
                {
                    this._ha_cluster_stack = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_cluster_stack");
                }
            }
        }

        public virtual Dictionary<string, string> ha_configuration
        {
            get
            {
                return this._ha_configuration;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_configuration))
                {
                    this._ha_configuration = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_configuration");
                }
            }
        }

        public virtual bool ha_enabled
        {
            get
            {
                return this._ha_enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_enabled))
                {
                    this._ha_enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_enabled");
                }
            }
        }

        public virtual long ha_host_failures_to_tolerate
        {
            get
            {
                return this._ha_host_failures_to_tolerate;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_host_failures_to_tolerate))
                {
                    this._ha_host_failures_to_tolerate = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_host_failures_to_tolerate");
                }
            }
        }

        public virtual bool ha_overcommitted
        {
            get
            {
                return this._ha_overcommitted;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_overcommitted))
                {
                    this._ha_overcommitted = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_overcommitted");
                }
            }
        }

        public virtual long ha_plan_exists_for
        {
            get
            {
                return this._ha_plan_exists_for;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_plan_exists_for))
                {
                    this._ha_plan_exists_for = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_plan_exists_for");
                }
            }
        }

        public virtual string[] ha_statefiles
        {
            get
            {
                return this._ha_statefiles;
            }
            set
            {
                if (!Helper.AreEqual(value, this._ha_statefiles))
                {
                    this._ha_statefiles = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("ha_statefiles");
                }
            }
        }

        public virtual Dictionary<string, string> health_check_config
        {
            get
            {
                return this._health_check_config;
            }
            set
            {
                if (!Helper.AreEqual(value, this._health_check_config))
                {
                    this._health_check_config = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("health_check_config");
                }
            }
        }

        public virtual XenRef<Host> master
        {
            get
            {
                return this._master;
            }
            set
            {
                if (!Helper.AreEqual(value, this._master))
                {
                    this._master = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("master");
                }
            }
        }

        public virtual List<XenRef<VDI>> metadata_VDIs
        {
            get
            {
                return this._metadata_VDIs;
            }
            set
            {
                if (!Helper.AreEqual(value, this._metadata_VDIs))
                {
                    this._metadata_VDIs = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("metadata_VDIs");
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

        public virtual bool redo_log_enabled
        {
            get
            {
                return this._redo_log_enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._redo_log_enabled))
                {
                    this._redo_log_enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("redo_log_enabled");
                }
            }
        }

        public virtual XenRef<VDI> redo_log_vdi
        {
            get
            {
                return this._redo_log_vdi;
            }
            set
            {
                if (!Helper.AreEqual(value, this._redo_log_vdi))
                {
                    this._redo_log_vdi = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("redo_log_vdi");
                }
            }
        }

        public virtual Dictionary<string, string> restrictions
        {
            get
            {
                return this._restrictions;
            }
            set
            {
                if (!Helper.AreEqual(value, this._restrictions))
                {
                    this._restrictions = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("restrictions");
                }
            }
        }

        public virtual XenRef<WinAPI.SR> suspend_image_SR
        {
            get
            {
                return this._suspend_image_SR;
            }
            set
            {
                if (!Helper.AreEqual(value, this._suspend_image_SR))
                {
                    this._suspend_image_SR = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("suspend_image_SR");
                }
            }
        }

        public virtual string[] tags
        {
            get
            {
                return this._tags;
            }
            set
            {
                if (!Helper.AreEqual(value, this._tags))
                {
                    this._tags = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("tags");
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

        public virtual string vswitch_controller
        {
            get
            {
                return this._vswitch_controller;
            }
            set
            {
                if (!Helper.AreEqual(value, this._vswitch_controller))
                {
                    this._vswitch_controller = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("vswitch_controller");
                }
            }
        }

        public virtual bool wlb_enabled
        {
            get
            {
                return this._wlb_enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._wlb_enabled))
                {
                    this._wlb_enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("wlb_enabled");
                }
            }
        }

        public virtual string wlb_url
        {
            get
            {
                return this._wlb_url;
            }
            set
            {
                if (!Helper.AreEqual(value, this._wlb_url))
                {
                    this._wlb_url = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("wlb_url");
                }
            }
        }

        public virtual string wlb_username
        {
            get
            {
                return this._wlb_username;
            }
            set
            {
                if (!Helper.AreEqual(value, this._wlb_username))
                {
                    this._wlb_username = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("wlb_username");
                }
            }
        }

        public virtual bool wlb_verify_cert
        {
            get
            {
                return this._wlb_verify_cert;
            }
            set
            {
                if (!Helper.AreEqual(value, this._wlb_verify_cert))
                {
                    this._wlb_verify_cert = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("wlb_verify_cert");
                }
            }
        }
    }
}

