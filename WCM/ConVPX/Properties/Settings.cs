namespace WCM.ConVPX.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        [DefaultSettingValue("False"), UserScopedSetting, DebuggerNonUserCode]
        public bool DebugHelp
        {
            get
            {
                return (bool) this["DebugHelp"];
            }
            set
            {
                this["DebugHelp"] = value;
            }
        }

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [DefaultSettingValue("3600000"), DebuggerNonUserCode, ApplicationScopedSetting]
        public int RequestCompositeTimeout
        {
            get
            {
                return (int) this["RequestCompositeTimeout"];
            }
        }

        [ApplicationScopedSetting, DebuggerNonUserCode, DefaultSettingValue("60000")]
        public int RequestRegularTimeout
        {
            get
            {
                return (int) this["RequestRegularTimeout"];
            }
        }

        [UserScopedSetting, DefaultSettingValue(""), DebuggerNonUserCode]
        public string SelectedXenServerHost
        {
            get
            {
                return (string) this["SelectedXenServerHost"];
            }
            set
            {
                this["SelectedXenServerHost"] = value;
            }
        }

        [UserScopedSetting, DebuggerNonUserCode]
        public StringCollection VMwareHosts
        {
            get
            {
                return (StringCollection) this["VMwareHosts"];
            }
            set
            {
                this["VMwareHosts"] = value;
            }
        }

        [DebuggerNonUserCode, UserScopedSetting]
        public StringCollection XenServerHosts
        {
            get
            {
                return (StringCollection) this["XenServerHosts"];
            }
            set
            {
                this["XenServerHosts"] = value;
            }
        }
    }
}

