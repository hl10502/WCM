namespace WinAPI
{
    using System;

    public static class task_allowed_operations_helper
    {
        public static string ToString(task_allowed_operations x)
        {
            switch (x)
            {
                case task_allowed_operations.cancel:
                    return "cancel";

                case task_allowed_operations.destroy:
                    return "destroy";
            }
            return "unknown";
        }
    }
}

