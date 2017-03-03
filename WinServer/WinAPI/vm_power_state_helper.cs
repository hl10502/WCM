namespace WinAPI
{
    using System;

    public static class vm_power_state_helper
    {
        public static string ToString(vm_power_state x)
        {
            switch (x)
            {
                case vm_power_state.Halted:
                    return "Halted";

                case vm_power_state.Paused:
                    return "Paused";

                case vm_power_state.Running:
                    return "Running";

                case vm_power_state.Suspended:
                    return "Suspended";
            }
            return "unknown";
        }
    }
}

