namespace WinAPI
{
    using System;

    public static class network_default_locking_mode_helper
    {
        public static string ToString(network_default_locking_mode x)
        {
            switch (x)
            {
                case network_default_locking_mode.unlocked:
                    return "unlocked";

                case network_default_locking_mode.disabled:
                    return "disabled";
            }
            return "unknown";
        }
    }
}

