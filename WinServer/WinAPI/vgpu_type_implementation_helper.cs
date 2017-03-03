namespace WinAPI
{
    using System;

    public static class vgpu_type_implementation_helper
    {
        public static string ToString(vgpu_type_implementation x)
        {
            switch (x)
            {
                case vgpu_type_implementation.passthrough:
                    return "passthrough";

                case vgpu_type_implementation.nvidia:
                    return "nvidia";

                case vgpu_type_implementation.gvt_g:
                    return "gvt_g";
            }
            return "unknown";
        }
    }
}

