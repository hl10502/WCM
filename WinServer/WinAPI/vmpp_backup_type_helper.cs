namespace WinAPI
{
    using System;

    public static class vmpp_backup_type_helper
    {
        public static string ToString(vmpp_backup_type x)
        {
            switch (x)
            {
                case vmpp_backup_type.snapshot:
                    return "snapshot";

                case vmpp_backup_type.checkpoint:
                    return "checkpoint";
            }
            return "unknown";
        }
    }
}

