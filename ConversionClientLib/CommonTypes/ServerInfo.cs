namespace ExportImport.CommonTypes
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ServerInfo
    {
        public int ServerType;
        public string Hostname;
        public string Username;
        public string Password;
    }
}

