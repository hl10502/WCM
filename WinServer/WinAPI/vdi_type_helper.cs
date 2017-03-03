namespace WinAPI
{
    using System;

    public static class vdi_type_helper
    {
        public static string ToString(vdi_type x)
        {
            switch (x)
            {
                case vdi_type.system:
                    return "system";

                case vdi_type.user:
                    return "user";

                case vdi_type.ephemeral:
                    return "ephemeral";

                case vdi_type.suspend:
                    return "suspend";

                case vdi_type.crashdump:
                    return "crashdump";

                case vdi_type.ha_statefile:
                    return "ha_statefile";

                case vdi_type.metadata:
                    return "metadata";

                case vdi_type.redo_log:
                    return "redo_log";

                case vdi_type.rrd:
                    return "rrd";
            }
            return "unknown";
        }
    }
}

