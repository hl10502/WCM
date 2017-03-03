namespace WinAPI
{
    using System;

    public static class vif_operations_helper
    {
        public static string ToString(vif_operations x)
        {
            switch (x)
            {
                case vif_operations.attach:
                    return "attach";

                case vif_operations.plug:
                    return "plug";

                case vif_operations.unplug:
                    return "unplug";
            }
            return "unknown";
        }
    }
}

