namespace WinAPI
{
    using System;

    public static class cls_helper
    {
        public static string ToString(cls x)
        {
            switch (x)
            {
                case cls.VM:
                    return "VM";

                case cls.Host:
                    return "Host";

                case cls.SR:
                    return "SR";

                case cls.Pool:
                    return "Pool";

                case cls.VMPP:
                    return "VMPP";
            }
            return "unknown";
        }
    }
}

