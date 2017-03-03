namespace WinAPI
{
    using System;

    public static class host_display_helper
    {
        public static string ToString(host_display x)
        {
            switch (x)
            {
                case host_display.enabled:
                    return "enabled";

                case host_display.disable_on_reboot:
                    return "disable_on_reboot";

                case host_display.disabled:
                    return "disabled";

                case host_display.enable_on_reboot:
                    return "enable_on_reboot";
            }
            return "unknown";
        }
    }
}

