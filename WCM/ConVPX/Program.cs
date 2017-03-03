namespace WCM.ConVPX
{
    using WCM.ConVPX.Core;
    using WCM.ConVPX.Model;
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Windows.Forms;
    using WCM.XenAdmin.Core;

    public static class Program
    {
        public static string ApplianceVersion = "";
        public static readonly string AssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static ConversionClient ClientConnection = null;
        public const int DEFAULT_XEN_PORT = 0x1bb;
        public static Font DefaultFont = FormFontFixer.DefaultFont;
        public static Font DefaultFontBold;
        public static Font DefaultFontBoldUnderline;
        public static Font DefaultFontHeader;
        public static Font DefaultFontItalic;
        public static Font DefaultFontUnderline;
        public static readonly Color ErrorBackColor = Color.Firebrick;
        public static readonly Color ErrorForeColor = Color.White;
        public static volatile bool Exiting = false;
        public static Color HeaderGradientEndColor = Color.FromArgb(0x3f, 0x8b, 0x89);
        public static Font HeaderGradientFont = new Font(DefaultFont.FontFamily, 11.25f);
        public static Font HeaderGradientFontSmall = DefaultFont;
        public static Color HeaderGradientForeColor = Color.White;
        public static Color HeaderGradientStartColor = Color.FromArgb(0x39, 0x6d, 140);
        public static bool IsApplianceAlive = false;
        public static ConVpxJobInfoList JobList = null;
        public static readonly object JobListLock = new object();
        public static JobPollThread JobPollManager = new JobPollThread();
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static ConVPX.MainWindow MainWindow = null;
        public static readonly Color PieChartFreeSpaceColor = Color.FromArgb(0xb9, 0xdb, 0xff);
        public static readonly Color PieChartUsedSpaceColor = Color.FromArgb(0x57, 120, 0xb2);
        public static bool RunInAutomatedTestMode = false;
        public static Font TabbedDialogHeaderFont = HeaderGradientFont;
        public static Color TabPageRowBorder = Color.DarkGray;
        public static Color TabPageRowHeader = Color.Silver;
        public static Color TitleBarBorderColor = TitleBarEndColor;
        public static Color TitleBarEndColor = ProfessionalColors.OverflowButtonGradientEnd;
        public static Color TitleBarForeColor = Color.White;
        public static Color TitleBarStartColor = ProfessionalColors.OverflowButtonGradientBegin;
        public static Color TransparentUsually = Color.Transparent;
        public static bool UpdateJobList = false;
        public static ServerInfo XenServerHostInfo;
        public static Dictionary<string, string> XenServerVersionInfoDict = new Dictionary<string, string>();

        static Program()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Assembly.GetCallingAssembly().Location + ".config"));
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Exiting = true;
            if (JobPollManager != null)
            {
                JobPollManager.RequestStop();
            }
        }

        internal static void AssertOffEventThread()
        {
            if (MainWindow.Visible && !MainWindow.InvokeRequired)
            {
                FatalError();
            }
        }

        internal static void AssertOnEventThread()
        {
            if (((MainWindow != null) && MainWindow.Visible) && MainWindow.InvokeRequired)
            {
                FatalError();
            }
        }

        private static void FatalError()
        {
            log.Fatal(string.Format(Messages.MESSAGEBOX_PROGRAM_UNEXPECTED, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), GetLogFile_()) + "\n" + Environment.StackTrace);
            ConVPX.MainWindow mainWindow = MainWindow;
            if (mainWindow == null)
            {
                log.Fatal("Program.MainWindow is null");
            }
            else
            {
                log.FatalFormat("Program.MainWindow.Visible == {0}", mainWindow.Visible);
                log.FatalFormat("Program.MainWindow.InvokeRequired == {0}", mainWindow.InvokeRequired);
                log.FatalFormat("CurrentThread.Name == {0}", Thread.CurrentThread.Name);
            }
        }

        public static string GetLogFile_()
        {
            foreach (IAppender appender in log.Logger.Repository.GetAppenders())
            {
                if (appender is FileAppender)
                {
                    return ((FileAppender) appender).File;
                }
            }
            return null;
        }

        public static string GetLogFileBaseName()
        {
            string path = GetLogFile_();
            if (path == null)
            {
                return "";
            }
            Path.GetDirectoryName(path);
            string str2 = path.Substring(path.LastIndexOf('\\') + 1);
            string str3 = str2.Substring(str2.LastIndexOf('.') + 1);
            return str2.Substring(0, (str2.Length - str3.Length) - 1);
        }

        public static string GetLogFileFullName()
        {
            string path = GetLogFile_();
            if (path == null)
            {
                return "";
            }
            Path.GetDirectoryName(path);
            return path.Substring(path.LastIndexOf('\\') + 1);
        }

        public static string GetLogFilePath()
        {
            string path = GetLogFile_();
            if (path == null)
            {
                return "";
            }
            return Path.GetDirectoryName(path);
        }

        public static object Invoke(Control c, Delegate f, params object[] p)
        {
            try
            {
                if ((Exiting || c.Disposing) || (c.IsDisposed || !c.IsHandleCreated))
                {
                    return null;
                }
                return (c.InvokeRequired ? c.Invoke(new InvokeDelegate(Program.Invoke_), new object[] { c, f, p }) : f.DynamicInvoke(p));
            }
            catch (ObjectDisposedException)
            {
                if ((!Exiting && !c.Disposing) && !c.IsDisposed)
                {
                    throw;
                }
                return null;
            }
        }

        private static object Invoke_(Control c, Delegate f, params object[] p)
        {
            object obj2;
            try
            {
                if ((Exiting || c.Disposing) || c.IsDisposed)
                {
                    return null;
                }
                obj2 = f.DynamicInvoke(p);
            }
            catch (Exception)
            {
                throw;
            }
            return obj2;
        }

        private static void logSystemDetails()
        {
            log.Info("Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            log.Info(".NET runtime version: " + Environment.Version.ToString(4));
            log.Info("OS version: " + Environment.OSVersion.ToString());
            log.Info("UI Culture: " + Thread.CurrentThread.CurrentUICulture.EnglishName);
        }

        [STAThread]
        private static void Main()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(Program.Validator);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            logSystemDetails();
            MainWindow = new ConVPX.MainWindow();
            Application.Run(MainWindow);
            log.Info("Application main thread exited");
        }

        public static bool Validator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static void ViewLogFiles()
        {
            string path = GetLogFile_();
            if (path != null)
            {
                Process.Start(Path.GetDirectoryName(path));
            }
        }

        public static System.Version Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        private delegate object InvokeDelegate(Control c, Delegate f, params object[] p);
    }
}

