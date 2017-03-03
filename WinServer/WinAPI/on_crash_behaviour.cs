namespace WinAPI
{
    using System;

    public enum on_crash_behaviour
    {
        destroy,
        coredump_and_destroy,
        restart,
        coredump_and_restart,
        preserve,
        rename_restart,
        unknown
    }
}

