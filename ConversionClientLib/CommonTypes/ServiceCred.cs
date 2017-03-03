namespace ExportImport.CommonTypes
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceCred
    {
        public string Username;
        public string Password;
        public ServiceCred(string user, string pwd)
        {
            this.Username = user;
            this.Password = pwd;
        }
    }
}

