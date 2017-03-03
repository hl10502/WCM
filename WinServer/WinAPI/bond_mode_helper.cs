namespace WinAPI
{
    using System;

    public static class bond_mode_helper
    {
        public static string ToString(bond_mode x)
        {
            switch (x)
            {
                case bond_mode.balance_slb:
                    return "balance-slb";

                case bond_mode.active_backup:
                    return "active-backup";

                case bond_mode.lacp:
                    return "lacp";
            }
            return "unknown";
        }
    }
}

