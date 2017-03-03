namespace WinAPI
{
    using System;

    public enum vdi_type
    {
        system,
        user,
        ephemeral,
        suspend,
        crashdump,
        ha_statefile,
        metadata,
        redo_log,
        rrd,
        unknown
    }
}

