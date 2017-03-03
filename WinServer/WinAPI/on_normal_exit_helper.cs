namespace WinAPI
{
    using System;

    public static class on_normal_exit_helper
    {
        public static string ToString(on_normal_exit x)
        {
            switch (x)
            {
                case on_normal_exit.destroy:
                    return "destroy";

                case on_normal_exit.restart:
                    return "restart";
            }
            return "unknown";
        }
    }
}

