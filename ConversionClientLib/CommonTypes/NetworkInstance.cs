namespace ExportImport.CommonTypes
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct NetworkInstance
    {
        public string Name;
        public string Id;
    }
}

