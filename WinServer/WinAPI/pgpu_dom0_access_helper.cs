namespace WinAPI
{
    using System;

    public static class pgpu_dom0_access_helper
    {
        public static string ToString(pgpu_dom0_access x)
        {
            switch (x)
            {
                case pgpu_dom0_access.enabled:
                    return "enabled";

                case pgpu_dom0_access.disable_on_reboot:
                    return "disable_on_reboot";

                case pgpu_dom0_access.disabled:
                    return "disabled";

                case pgpu_dom0_access.enable_on_reboot:
                    return "enable_on_reboot";
            }
            return "unknown";
        }
    }
}

