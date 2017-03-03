namespace WinAPI
{
    using System;

    [AttributeUsage(AttributeTargets.All)]
    public class DeprecatedAttribute : Attribute
    {
        private string version;

        public DeprecatedAttribute(string version)
        {
            this.version = version;
        }

        public override string ToString()
        {
            return ("Deprecated since " + this.Version);
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

