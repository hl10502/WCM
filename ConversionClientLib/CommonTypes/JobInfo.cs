namespace ExportImport.CommonTypes
{
    using CookComputing.XmlRpc;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct JobInfo
    {
        public ServerInfo Source;
        public string SourceVmUUID;
        public string SourceVmName;
        public ExportImport.CommonTypes.ImportInfo ImportInfo;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public XmlRpcStruct NetworkMappings;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public bool? PreserveMAC;
    }
}

