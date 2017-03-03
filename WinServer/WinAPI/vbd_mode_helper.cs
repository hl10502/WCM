namespace WinAPI
{
    using System;

    public static class vbd_mode_helper
    {
        public static string ToString(vbd_mode x)
        {
            switch (x)
            {
                case vbd_mode.RO:
                    return "RO";

                case vbd_mode.RW:
                    return "RW";
            }
            return "unknown";
        }
    }
}

