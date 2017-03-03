namespace WinAPI
{
    using System;

    public static class allocation_algorithm_helper
    {
        public static string ToString(allocation_algorithm x)
        {
            switch (x)
            {
                case allocation_algorithm.breadth_first:
                    return "breadth_first";

                case allocation_algorithm.depth_first:
                    return "depth_first";
            }
            return "unknown";
        }
    }
}

