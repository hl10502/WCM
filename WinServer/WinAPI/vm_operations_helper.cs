namespace WinAPI
{
    using System;

    public static class vm_operations_helper
    {
        public static string ToString(vm_operations x)
        {
            switch (x)
            {
                case vm_operations.snapshot:
                    return "snapshot";

                case vm_operations.clone:
                    return "clone";

                case vm_operations.copy:
                    return "copy";

                case vm_operations.create_template:
                    return "create_template";

                case vm_operations.revert:
                    return "revert";

                case vm_operations.checkpoint:
                    return "checkpoint";

                case vm_operations.snapshot_with_quiesce:
                    return "snapshot_with_quiesce";

                case vm_operations.provision:
                    return "provision";

                case vm_operations.start:
                    return "start";

                case vm_operations.start_on:
                    return "start_on";

                case vm_operations.pause:
                    return "pause";

                case vm_operations.unpause:
                    return "unpause";

                case vm_operations.clean_shutdown:
                    return "clean_shutdown";

                case vm_operations.clean_reboot:
                    return "clean_reboot";

                case vm_operations.hard_shutdown:
                    return "hard_shutdown";

                case vm_operations.power_state_reset:
                    return "power_state_reset";

                case vm_operations.hard_reboot:
                    return "hard_reboot";

                case vm_operations.suspend:
                    return "suspend";

                case vm_operations.csvm:
                    return "csvm";

                case vm_operations.resume:
                    return "resume";

                case vm_operations.resume_on:
                    return "resume_on";

                case vm_operations.pool_migrate:
                    return "pool_migrate";

                case vm_operations.migrate_send:
                    return "migrate_send";

                case vm_operations.get_boot_record:
                    return "get_boot_record";

                case vm_operations.send_sysrq:
                    return "send_sysrq";

                case vm_operations.send_trigger:
                    return "send_trigger";

                case vm_operations.query_services:
                    return "query_services";

                case vm_operations.shutdown:
                    return "shutdown";

                case vm_operations.call_plugin:
                    return "call_plugin";

                case vm_operations.changing_memory_live:
                    return "changing_memory_live";

                case vm_operations.awaiting_memory_live:
                    return "awaiting_memory_live";

                case vm_operations.changing_dynamic_range:
                    return "changing_dynamic_range";

                case vm_operations.changing_static_range:
                    return "changing_static_range";

                case vm_operations.changing_memory_limits:
                    return "changing_memory_limits";

                case vm_operations.changing_shadow_memory:
                    return "changing_shadow_memory";

                case vm_operations.changing_shadow_memory_live:
                    return "changing_shadow_memory_live";

                case vm_operations.changing_VCPUs:
                    return "changing_VCPUs";

                case vm_operations.changing_VCPUs_live:
                    return "changing_VCPUs_live";

                case vm_operations.assert_operation_valid:
                    return "assert_operation_valid";

                case vm_operations.data_source_op:
                    return "data_source_op";

                case vm_operations.update_allowed_operations:
                    return "update_allowed_operations";

                case vm_operations.make_into_template:
                    return "make_into_template";

                case vm_operations.import:
                    return "import";

                case vm_operations.export:
                    return "export";

                case vm_operations.metadata_export:
                    return "metadata_export";

                case vm_operations.reverting:
                    return "reverting";

                case vm_operations.destroy:
                    return "destroy";

                case vm_operations.xenprep:
                    return "xenprep";
            }
            return "unknown";
        }
    }
}

