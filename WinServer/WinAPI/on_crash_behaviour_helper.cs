namespace WinAPI
{
    using System;

    public static class on_crash_behaviour_helper
    {
        public static string ToString(on_crash_behaviour x)
        {
            switch (x)
            {
                case on_crash_behaviour.destroy:
                    return "destroy";

                case on_crash_behaviour.coredump_and_destroy:
                    return "coredump_and_destroy";

                case on_crash_behaviour.restart:
                    return "restart";

                case on_crash_behaviour.coredump_and_restart:
                    return "coredump_and_restart";

                case on_crash_behaviour.preserve:
                    return "preserve";

                case on_crash_behaviour.rename_restart:
                    return "rename_restart";
            }
            return "unknown";
        }
    }
}

