namespace WinAPI
{
    using System;

    public static class vmpp_backup_frequency_helper
    {
        public static string ToString(vmpp_backup_frequency x)
        {
            switch (x)
            {
                case vmpp_backup_frequency.hourly:
                    return "hourly";

                case vmpp_backup_frequency.daily:
                    return "daily";

                case vmpp_backup_frequency.weekly:
                    return "weekly";
            }
            return "unknown";
        }
    }
}

