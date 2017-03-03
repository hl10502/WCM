namespace WinAPI
{
    using System;

    public enum vdi_operations
    {
        scan,
        clone,
        copy,
        resize,
        resize_online,
        snapshot,
        destroy,
        forget,
        update,
        force_unlock,
        generate_config,
        blocked,
        unknown
    }
}

