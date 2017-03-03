namespace WinAPI
{
    using System;

    public static class task_status_type_helper
    {
        public static string ToString(task_status_type x)
        {
            switch (x)
            {
                case task_status_type.pending:
                    return "pending";

                case task_status_type.success:
                    return "success";

                case task_status_type.failure:
                    return "failure";

                case task_status_type.cancelling:
                    return "cancelling";

                case task_status_type.cancelled:
                    return "cancelled";
            }
            return "unknown";
        }
    }
}

