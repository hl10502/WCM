namespace WCM.ConVPX
{
    using WCM.ConVPX.Properties;
    using log4net;
    using System;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Reflection;
    using WCM.XenAdmin.Dialogs;

    public static class Settings
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetSelectedXenServerHost()
        {
            Program.AssertOnEventThread();
            string selectedXenServerHost = "";
            if (ConVPX.Properties.Settings.Default.SelectedXenServerHost != null)
            {
                selectedXenServerHost = ConVPX.Properties.Settings.Default.SelectedXenServerHost;
            }
            return selectedXenServerHost;
        }

        public static StringCollection GetVMwareHosts()
        {
            Program.AssertOnEventThread();
            StringCollection strings = new StringCollection();
            if (ConVPX.Properties.Settings.Default.VMwareHosts != null)
            {
                foreach (string str in ConVPX.Properties.Settings.Default.VMwareHosts)
                {
                    strings.Add(str);
                }
            }
            return strings;
        }

        public static StringCollection GetXenServerHosts()
        {
            Program.AssertOnEventThread();
            StringCollection strings = new StringCollection();
            if (ConVPX.Properties.Settings.Default.XenServerHosts != null)
            {
                foreach (string str in ConVPX.Properties.Settings.Default.XenServerHosts)
                {
                    strings.Add(str);
                }
            }
            return strings;
        }

        public static void SetSelectedXenServerHost(string toStoreStr)
        {
            Program.AssertOnEventThread();
            ConVPX.Properties.Settings.Default.SelectedXenServerHost = toStoreStr;
            TrySaveSettings();
        }

        public static void SetVMwareHosts(StringCollection toStoreList)
        {
            Program.AssertOnEventThread();
            ConVPX.Properties.Settings.Default.VMwareHosts = toStoreList;
            TrySaveSettings();
        }

        public static void SetXenServerHosts(StringCollection toStoreList)
        {
            Program.AssertOnEventThread();
            ConVPX.Properties.Settings.Default.XenServerHosts = toStoreList;
            TrySaveSettings();
        }

        public static void TrySaveSettings()
        {
            try
            {
                ConVPX.Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                new ThreeButtonDialog(new ThreeButtonDialog.Details(SystemIcons.Error, Messages.MESSAGEBOX_LOAD_CORRUPTED, Messages.MESSAGEBOX_LOAD_CORRUPTED_TITLE)).ShowDialog(Program.MainWindow);
                log.Error("Could not save settings. Exiting application.");
                log.Error(exception, exception);
            }
        }
    }
}

