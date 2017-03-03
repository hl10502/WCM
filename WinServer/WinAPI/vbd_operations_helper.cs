namespace WinAPI
{
    using System;

    public static class vbd_operations_helper
    {
        public static string ToString(vbd_operations x)
        {
            switch (x)
            {
                case vbd_operations.attach:
                    return "attach";

                case vbd_operations.eject:
                    return "eject";

                case vbd_operations.insert:
                    return "insert";

                case vbd_operations.plug:
                    return "plug";

                case vbd_operations.unplug:
                    return "unplug";

                case vbd_operations.unplug_force:
                    return "unplug_force";

                case vbd_operations.pause:
                    return "pause";

                case vbd_operations.unpause:
                    return "unpause";
            }
            return "unknown";
        }
    }
}

