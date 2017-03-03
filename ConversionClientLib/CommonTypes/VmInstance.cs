namespace ExportImport.CommonTypes
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct VmInstance
    {
        public string UUID;
        public string Name;
        public int PowerState;
        public string OSType;
        public long CommittedStorage;
        public long UncommittedStorage;
        public bool Template;
    }
}

