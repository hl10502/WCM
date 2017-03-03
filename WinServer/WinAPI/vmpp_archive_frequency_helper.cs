namespace WinAPI
{
    using System;

    public static class vmpp_archive_frequency_helper
    {
        public static string ToString(vmpp_archive_frequency x)
        {
            switch (x)
            {
                case vmpp_archive_frequency.never:
                    return "never";

                case vmpp_archive_frequency.always_after_backup:
                    return "always_after_backup";

                case vmpp_archive_frequency.daily:
                    return "daily";

                case vmpp_archive_frequency.weekly:
                    return "weekly";
            }
            return "unknown";
        }
    }
}

