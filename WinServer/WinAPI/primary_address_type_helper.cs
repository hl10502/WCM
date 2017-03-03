namespace WinAPI
{
    using System;

    public static class primary_address_type_helper
    {
        public static string ToString(primary_address_type x)
        {
            switch (x)
            {
                case primary_address_type.IPv4:
                    return "IPv4";

                case primary_address_type.IPv6:
                    return "IPv6";
            }
            return "unknown";
        }
    }
}

