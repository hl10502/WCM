namespace WinAPI
{
    using System;

    public static class vbd_type_helper
    {
        public static string ToString(vbd_type x)
        {
            switch (x)
            {
                case vbd_type.CD:
                    return "CD";

                case vbd_type.Disk:
                    return "Disk";

                case vbd_type.Floppy:
                    return "Floppy";
            }
            return "unknown";
        }
    }
}

