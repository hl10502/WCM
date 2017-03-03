namespace WinAPI
{
    using System;

    public static class vm_appliance_operation_helper
    {
        public static string ToString(vm_appliance_operation x)
        {
            switch (x)
            {
                case vm_appliance_operation.start:
                    return "start";

                case vm_appliance_operation.clean_shutdown:
                    return "clean_shutdown";

                case vm_appliance_operation.hard_shutdown:
                    return "hard_shutdown";

                case vm_appliance_operation.shutdown:
                    return "shutdown";
            }
            return "unknown";
        }
    }
}

