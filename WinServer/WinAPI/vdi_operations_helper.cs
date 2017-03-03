namespace WinAPI
{
    using System;

    public static class vdi_operations_helper
    {
        public static string ToString(vdi_operations x)
        {
            switch (x)
            {
                case vdi_operations.scan:
                    return "scan";

                case vdi_operations.clone:
                    return "clone";

                case vdi_operations.copy:
                    return "copy";

                case vdi_operations.resize:
                    return "resize";

                case vdi_operations.resize_online:
                    return "resize_online";

                case vdi_operations.snapshot:
                    return "snapshot";

                case vdi_operations.destroy:
                    return "destroy";

                case vdi_operations.forget:
                    return "forget";

                case vdi_operations.update:
                    return "update";

                case vdi_operations.force_unlock:
                    return "force_unlock";

                case vdi_operations.generate_config:
                    return "generate_config";

                case vdi_operations.blocked:
                    return "blocked";
            }
            return "unknown";
        }
    }
}

