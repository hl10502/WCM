namespace ExportImport.CommonTypes
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct XenServerInfo
    {
        public int ServerType;
        public string Url;
        public string Username;
        public string Password;
    }
}

