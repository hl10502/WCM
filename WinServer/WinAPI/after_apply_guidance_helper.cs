namespace WinAPI
{
    using System;

    public static class after_apply_guidance_helper
    {
        public static string ToString(after_apply_guidance x)
        {
            switch (x)
            {
                case after_apply_guidance.restartHVM:
                    return "restartHVM";

                case after_apply_guidance.restartPV:
                    return "restartPV";

                case after_apply_guidance.restartHost:
                    return "restartHost";

                case after_apply_guidance.restartXAPI:
                    return "restartXAPI";
            }
            return "unknown";
        }
    }
}

