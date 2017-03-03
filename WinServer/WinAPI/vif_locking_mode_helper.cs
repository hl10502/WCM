namespace WinAPI
{
    using System;

    public static class vif_locking_mode_helper
    {
        public static string ToString(vif_locking_mode x)
        {
            switch (x)
            {
                case vif_locking_mode.network_default:
                    return "network_default";

                case vif_locking_mode.locked:
                    return "locked";

                case vif_locking_mode.unlocked:
                    return "unlocked";

                case vif_locking_mode.disabled:
                    return "disabled";
            }
            return "unknown";
        }
    }
}

