namespace WinAPI
{
    using System;

    public static class host_allowed_operations_helper
    {
        public static string ToString(host_allowed_operations x)
        {
            switch (x)
            {
                case host_allowed_operations.provision:
                    return "provision";

                case host_allowed_operations.evacuate:
                    return "evacuate";

                case host_allowed_operations.shutdown:
                    return "shutdown";

                case host_allowed_operations.reboot:
                    return "reboot";

                case host_allowed_operations.power_on:
                    return "power_on";

                case host_allowed_operations.vm_start:
                    return "vm_start";

                case host_allowed_operations.vm_resume:
                    return "vm_resume";

                case host_allowed_operations.vm_migrate:
                    return "vm_migrate";
            }
            return "unknown";
        }
    }
}

