namespace WinAPI
{
    using System;

    public static class ip_configuration_mode_helper
    {
        public static string ToString(ip_configuration_mode x)
        {
            switch (x)
            {
                case ip_configuration_mode.None:
                    return "None";

                case ip_configuration_mode.DHCP:
                    return "DHCP";

                case ip_configuration_mode.Static:
                    return "Static";
            }
            return "unknown";
        }
    }
}

