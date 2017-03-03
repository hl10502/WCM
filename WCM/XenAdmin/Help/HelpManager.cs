namespace WCM.XenAdmin.Help
{
    using WCM.ConVPX;
    using WCM.ConVPX.Properties;
    using log4net;
    using System;
    using System.Drawing;
    using System.Resources;
    using WCM.XenAdmin.Dialogs;
	using System.Reflection;

    internal class HelpManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ResourceManager resources = new ResourceManager("XenAdmin.Help.HelpManager", typeof(HelpManager).Assembly);

        internal static string GetID(string pageref)
        {
            int num;
            string s = resources.GetString(pageref);
            if ((s != null) && int.TryParse(s, out num))
            {
                return s;
            }
            return null;
        }

        public static bool HasHelpFor(string pageref)
        {
            return (((pageref != null) && (pageref != "TabPageUnknown")) && (GetID(pageref) != null));
        }

        public static void Launch(string pageref)
        {
            MainWindow mainWindow = Program.MainWindow;
            if (pageref != null)
            {
                log.DebugFormat("User Request Help ID for {0}", pageref);
                string iD = GetID(pageref);
                if (iD != null)
                {
                    log.DebugFormat("Help ID for {0} is {1}", pageref, iD);
                    if (ConVPX.Properties.Settings.Default.DebugHelp && !Program.RunInAutomatedTestMode)
                    {
                        new ThreeButtonDialog(new ThreeButtonDialog.Details(SystemIcons.Information, string.Format(Messages.MESSAGEBOX_HELP_TOPICS, iD, pageref), Messages.APPLICATION_NAME)).ShowDialog(mainWindow);
                    }
                    mainWindow.ShowHelpTopic(iD);
                }
                else
                {
                    log.WarnFormat("Failed to find Help ID for {0}", pageref);
                    if (!Program.RunInAutomatedTestMode)
                    {
                        if (ConVPX.Properties.Settings.Default.DebugHelp)
                        {
                            new ThreeButtonDialog(new ThreeButtonDialog.Details(SystemIcons.Error, string.Format(Messages.MESSAGEBOX_HELP_TOPIC_NOT_FOUND, pageref), Messages.MESSAGEBOX_HELP_TOPIC_NOT_FOUND)).ShowDialog(mainWindow);
                        }
                        mainWindow.ShowHelpTOC();
                    }
                }
            }
            else
            {
                log.WarnFormat("Null help ID passed to Help Manager", new object[0]);
                if (!Program.RunInAutomatedTestMode)
                {
                    if (ConVPX.Properties.Settings.Default.DebugHelp)
                    {
                        new ThreeButtonDialog(new ThreeButtonDialog.Details(SystemIcons.Error, string.Format(Messages.MESSAGEBOX_HELP_TOPIC_NOT_FOUND, pageref), Messages.MESSAGEBOX_HELP_TOPIC_NOT_FOUND)).ShowDialog(mainWindow);
                    }
                    mainWindow.ShowHelpTOC();
                }
            }
        }
    }
}

