namespace ExportImport.CommonTypes
{
    using CookComputing.XmlRpc;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct JobProgressData
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public long BytesRead;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public long BytesWritten;
        public JobProgressData(long bytesRead, long bytesWritten)
        {
            this.BytesRead = bytesRead;
            this.BytesWritten = bytesWritten;
        }
    }
}

