namespace WCM.ConVPX
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), CompilerGenerated]
    internal class InvisibleMessages
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal InvisibleMessages()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string JOB_DESTINATION_FORMAT
        {
            get
            {
                return ResourceManager.GetString("JOB_DESTINATION_FORMAT", resourceCulture);
            }
        }

        internal static string JOB_SOURCE_FORMAT
        {
            get
            {
                return ResourceManager.GetString("JOB_SOURCE_FORMAT", resourceCulture);
            }
        }

        internal static string JOB_STATUS_FORMAT
        {
            get
            {
                return ResourceManager.GetString("JOB_STATUS_FORMAT", resourceCulture);
            }
        }

        internal static string MAINWINDOW_HELP_PATH
        {
            get
            {
                return ResourceManager.GetString("MAINWINDOW_HELP_PATH", resourceCulture);
            }
        }

        internal static string REMOTE_CONVERTING_STATUS_MESSAGE
        {
            get
            {
                return ResourceManager.GetString("REMOTE_CONVERTING_STATUS_MESSAGE", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("WCM.ConVPX.InvisibleMessages", typeof(InvisibleMessages).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static string VMWARE_SDK_URL
        {
            get
            {
                return ResourceManager.GetString("VMWARE_SDK_URL", resourceCulture);
            }
        }

        internal static string XCM_APPLIANCE_LOG_NAME
        {
            get
            {
                return ResourceManager.GetString("XCM_APPLIANCE_LOG_NAME", resourceCulture);
            }
        }

        internal static string XCM_SCRATCH_LOG_DIR
        {
            get
            {
                return ResourceManager.GetString("XCM_SCRATCH_LOG_DIR", resourceCulture);
            }
        }

        internal static string XCM_SUPPORT_ZIP_LOG_NAME
        {
            get
            {
                return ResourceManager.GetString("XCM_SUPPORT_ZIP_LOG_NAME", resourceCulture);
            }
        }

        internal static string XEN_DEFAULT_NETWORK
        {
            get
            {
                return ResourceManager.GetString("XEN_DEFAULT_NETWORK", resourceCulture);
            }
        }

        internal static string XENSERVER_URL
        {
            get
            {
                return ResourceManager.GetString("XENSERVER_URL", resourceCulture);
            }
        }

        internal static string XENSERVER_VERSION_NOT_SUPPORTED
        {
            get
            {
                return ResourceManager.GetString("XENSERVER_VERSION_NOT_SUPPORTED", resourceCulture);
            }
        }
    }
}

