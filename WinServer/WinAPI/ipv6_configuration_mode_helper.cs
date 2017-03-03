namespace WinAPI
{
    using System;

    public static class ipv6_configuration_mode_helper
    {
        public static string ToString(ipv6_configuration_mode x)
        {
            switch (x)
            {
                case ipv6_configuration_mode.None:
                    return "None";

                case ipv6_configuration_mode.DHCP:
                    return "DHCP";

                case ipv6_configuration_mode.Static:
                    return "Static";

                case ipv6_configuration_mode.Autoconf:
                    return "Autoconf";
            }
            return "unknown";
        }
    }
}

