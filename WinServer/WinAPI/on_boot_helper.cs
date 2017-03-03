namespace WinAPI
{
    using System;

    public static class on_boot_helper
    {
        public static string ToString(on_boot x)
        {
            switch (x)
            {
                case on_boot.reset:
                    return "reset";

                case on_boot.persist:
                    return "persist";
            }
            return "unknown";
        }
    }
}

