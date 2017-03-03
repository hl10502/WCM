namespace WinAPI
{
    using System;

    public static class network_operations_helper
    {
        public static string ToString(network_operations x)
        {
            if (x == network_operations.attaching)
            {
                return "attaching";
            }
            return "unknown";
        }
    }
}

