namespace WinAPI
{
    using System;

    public static class console_protocol_helper
    {
        public static string ToString(console_protocol x)
        {
            switch (x)
            {
                case console_protocol.vt100:
                    return "vt100";

                case console_protocol.rfb:
                    return "rfb";

                case console_protocol.rdp:
                    return "rdp";
            }
            return "unknown";
        }
    }
}

