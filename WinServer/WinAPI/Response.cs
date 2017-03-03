namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Response<ValType>
    {
        public string Status;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public ValType Value;
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] ErrorDescription;
        public Response(ValType Value)
        {
            this.Status = "Success";
            this.Value = Value;
            this.ErrorDescription = new string[0];
        }

        public Response(bool Failure, string[] error)
        {
            this.Status = Failure ? "Failure" : "Success";
            this.Value = default(ValType);
            this.ErrorDescription = error;
        }

        internal ValType parse()
        {
            if ("Success".Equals(this.Status))
            {
                Trace.Assert(this.Value != null, "Value must not be null");
                return this.Value;
            }
            if (this.ErrorDescription == null)
            {
                throw new Failure(new List<string> { "INTERNAL_ERROR", "Null ErrorDescription in response" });
            }
            throw new Failure(new List<string>(this.ErrorDescription));
        }
    }
}

