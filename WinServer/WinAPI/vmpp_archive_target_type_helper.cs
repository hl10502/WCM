namespace WinAPI
{
    using System;

    public static class vmpp_archive_target_type_helper
    {
        public static string ToString(vmpp_archive_target_type x)
        {
            switch (x)
            {
                case vmpp_archive_target_type.none:
                    return "none";

                case vmpp_archive_target_type.cifs:
                    return "cifs";

                case vmpp_archive_target_type.nfs:
                    return "nfs";
            }
            return "unknown";
        }
    }
}

