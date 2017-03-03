namespace WinAPI
{
    using System;

    public enum host_allowed_operations
    {
        provision,
        evacuate,
        shutdown,
        reboot,
        power_on,
        vm_start,
        vm_resume,
        vm_migrate,
        unknown
    }
}

