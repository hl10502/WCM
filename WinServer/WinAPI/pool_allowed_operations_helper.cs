namespace WinAPI
{
    using System;

    public static class pool_allowed_operations_helper
    {
        public static string ToString(pool_allowed_operations x)
        {
            switch (x)
            {
                case pool_allowed_operations.ha_enable:
                    return "ha_enable";

                case pool_allowed_operations.ha_disable:
                    return "ha_disable";
            }
            return "unknown";
        }
    }
}

