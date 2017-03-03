namespace WCM.ConVPX.Core
{
    using WCM.ConVPX;
    using WCM.ConVPX.Dialogs;
    using CookComputing.XmlRpc;
    using ExportImport.CommonTypes;
    using ExportImport.ConversionClientLib;
    using log4net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Packaging;
    using System.Net;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WinAPI;

    internal static class Helpers
    {
        private static readonly ServiceCred _serviceCredentials = new ServiceCred("root", "xenroot");
        public static AboutDialog aboutDialog = null;
        public const long BINARY_GIGA = 0x40000000L;
        public const long BINARY_KILO = 0x400L;
        public const long BINARY_MEGA = 0x100000L;
        private const long BUFFER_SIZE = 0x1000L;
        public static CancelJobsDialog cancelJobsDialog = null;
        public static ConnectToXenServer connectionDialog = null;
        public static ConVPX.Wizards.ConversionWizard.ConversionWizard conVpxWizard = null;
        public static LegalNoticesDialog legalNoticesDialog = null;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Regex NaturalCompareRegex = new Regex(@"[\D]+|[\d]+");
        public static RetryJobsDialog retryJobsDialog = null;

        private static void AddFileToZip(string zipFilename, string fileToAdd)
        {
            using (Package package = Package.Open(zipFilename, FileMode.OpenOrCreate))
            {
                Uri partUri = PackUriHelper.CreatePartUri(new Uri(@".\" + Path.GetFileName(fileToAdd), UriKind.Relative));
                if (package.PartExists(partUri))
                {
                    package.DeletePart(partUri);
                }
                PackagePart part = package.CreatePart(partUri, "", CompressionOption.Normal);
                using (FileStream stream = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
                {
                    using (Stream stream2 = part.GetStream())
                    {
                        CopyStream(stream, stream2);
                    }
                }
            }
        }

        private static bool AreCollectionsEqual(ICollection c1, ICollection c2)
        {
            if (c1.Count != c2.Count)
            {
                return false;
            }
            IEnumerator enumerator = c1.GetEnumerator();
            IEnumerator enumerator2 = c2.GetEnumerator();
            while (enumerator.MoveNext() && enumerator2.MoveNext())
            {
                if (!AreEqual(enumerator.Current, enumerator2.Current))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool AreDictEqual(IDictionary d1, IDictionary d2)
        {
            if (d1.Count != d2.Count)
            {
                return false;
            }
            foreach (object obj2 in d1.Keys)
            {
                if (!d2.Contains(obj2) || !AreEqual(d2[obj2], d1[obj2]))
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool AreEqual(object o1, object o2)
        {
            if ((o1 == null) && (o2 == null))
            {
                return true;
            }
            if ((o1 == null) || (o2 == null))
            {
                return false;
            }
            if (o1 is IDictionary)
            {
                return AreDictEqual((IDictionary) o1, (IDictionary) o2);
            }
            if (o1 is ICollection)
            {
                return AreCollectionsEqual((ICollection) o1, (ICollection) o2);
            }
            return o1.Equals(o2);
        }

        internal static bool AreEqual2<T>(T o1, T o2)
        {
            if ((o1 == null) && (o2 == null))
            {
                return true;
            }
            if ((o1 == null) || (o2 == null))
            {
                return (((o1 == null) && IsEmptyCollection(o2)) || ((o2 == null) && IsEmptyCollection(o1)));
            }
            if (typeof(T) is IDictionary)
            {
                return AreDictEqual((IDictionary) o1, (IDictionary) o2);
            }
            if (typeof(T) is ICollection)
            {
                return AreCollectionsEqual((ICollection) o1, (ICollection) o2);
            }
            return o1.Equals(o2);
        }

        public static void BringFormToFront(Form f)
        {
            if (f.WindowState == FormWindowState.Minimized)
            {
                f.WindowState = FormWindowState.Normal;
            }
            f.BringToFront();
            f.Activate();
        }

        public static void CloseAll()
        {
            if (cancelJobsDialog != null)
            {
                cancelJobsDialog.Close();
            }
            if (retryJobsDialog != null)
            {
                retryJobsDialog.Close();
            }
            if (aboutDialog != null)
            {
                aboutDialog.Close();
            }
            if (legalNoticesDialog != null)
            {
                legalNoticesDialog.Close();
            }
            if (conVpxWizard != null)
            {
                conVpxWizard.Close();
            }
        }

        public static void CompressLogFilesAndSave(ConversionClient client, string sourcePath, string workingPath, string targetPath, string baseLogFileName, string zipFileName, string applianceLogFileName)
        {
            try
            {
                string zipFilename = Path.Combine(workingPath, zipFileName);
                string filePath = Path.Combine(workingPath, applianceLogFileName);
                if (!Directory.Exists(workingPath))
                {
                    Directory.CreateDirectory(workingPath);
                }
                else
                {
                    foreach (string str3 in Directory.GetFiles(sourcePath))
                    {
                        try
                        {
                            System.IO.File.Delete(str3);
                        }
                        catch
                        {
                        }
                    }
                }
                if (Directory.Exists(sourcePath))
                {
                    foreach (string str4 in Directory.GetFiles(sourcePath))
                    {
                        if (str4.IndexOf(baseLogFileName) != -1)
                        {
                            string fileName = Path.GetFileName(str4);
                            string str6 = Path.Combine(workingPath, fileName);
                            System.IO.File.Copy(str4, str6, true);
                            AddFileToZip(zipFilename, str6);
                        }
                    }
                    try
                    {
                        CopyStringToFile(client.GetLog(), filePath);
                        AddFileToZip(zipFilename, filePath);
                    }
                    catch (Exception exception)
                    {
                        LOG.Error(exception, exception);
                    }
                    string destFileName = Path.Combine(targetPath, zipFileName);
                    System.IO.File.Copy(zipFilename, destFileName, true);
                }
                else
                {
                    LOG.Error("Source path does not exist!");
                }
                try
                {
                    Directory.Delete(workingPath, true);
                }
                catch
                {
                }
            }
            catch (Exception exception2)
            {
                LOG.Error(exception2, exception2);
            }
        }

        public static bool Confirm(string msg, params object[] args)
        {
            return (DialogResult.OK == MessageBox.Show(string.Format(msg, args), Messages.MESSAGEBOX_CONFIRM, MessageBoxButtons.OKCancel, MessageBoxIcon.Question));
        }

        public static bool Confirm(Control parent, string msg, params object[] args)
        {
            return (DialogResult.OK == MessageBox.Show(parent, string.Format(msg, args), Messages.MESSAGEBOX_CONFIRM, MessageBoxButtons.OKCancel, MessageBoxIcon.Question));
        }

        private static void CopyStream(FileStream inputStream, Stream outputStream)
        {
            long num = (inputStream.Length < 0x1000L) ? inputStream.Length : 0x1000L;
            byte[] buffer = new byte[num];
            int count = 0;
            for (long i = 0L; (count = inputStream.Read(buffer, 0, buffer.Length)) != 0; i += num)
            {
                outputStream.Write(buffer, 0, count);
            }
        }

        public static void CopyStringToFile(string content, string filePath)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(content);
                writer.Close();
            }
            catch (Exception exception)
            {
                LOG.Error(exception.Message);
            }
        }

        internal static bool DictEquals<K, V>(Dictionary<K, V> d1, Dictionary<K, V> d2)
        {
            if ((d1 != null) || (d2 != null))
            {
                if ((d1 == null) || (d2 == null))
                {
                    return false;
                }
                if (d1.Count != d2.Count)
                {
                    return false;
                }
                foreach (K local in d1.Keys)
                {
                    if (!d2.ContainsKey(local) || !EqualOrEquallyNull(d2[local], d1[local]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string DiskSizeString(double bytes)
        {
            int digits = 2;
            return DiskSizeString(bytes, digits);
        }

		public static string DiskSizeString(double bytes, int digits) {
			if (bytes >= 1073741824.0) {
				string.Format("{0} GB", Math.Round((double)(bytes / 1073741824.0), digits).ToString());
				return string.Format("{0} GB", Math.Round((double)(bytes / 1073741824.0), digits).ToString());
			}
			if (bytes >= 1048576.0) {
				return string.Format("{0} MB", Math.Round((double)(bytes / 1048576.0), digits).ToString());
			}
			if (bytes > 1024.0) {
				return string.Format("{0} KB", Math.Round((double)(bytes / 1024.0), digits).ToString());
			}
			return string.Format("{0} B", bytes);
		}

        public static string DiskSizeString(long bytes, int dp)
        {
            if (bytes >= 0x40000000L)
            {
                return string.Format("{0} GB", Math.Round((double) (((double) bytes) / 1073741824.0), dp).ToString());
            }
            if (bytes >= 0x100000L)
            {
                return string.Format("{0} MB", Math.Round((double) (((double) bytes) / 1048576.0), dp).ToString());
            }
            if (bytes > 0x400L)
            {
                return string.Format("{0} KB", Math.Round((double) (((double) bytes) / 1024.0), dp).ToString());
            }
            return string.Format("{0} B", bytes);
        }

        internal static bool EqualOrEquallyNull(object o1, object o2)
        {
            if (o1 != null)
            {
                return o1.Equals(o2);
            }
            return (o2 == null);
        }

        public static string GetConnectionReason(Exception error, string Hostname)
        {
            if (error is XmlRpcServerException)
            {
                return string.Format(Messages.SERVER_FAILURE, error.Message);
            }
            if (error is NotSupportedException)
            {
                if (error.Message.Equals(InvisibleMessages.XENSERVER_VERSION_NOT_SUPPORTED))
                {
                    return Messages.XENSERVER_VERSION_NOT_SUPPORTED;
                }
                return error.Message;
            }
            if (error is ArgumentException)
            {
                return Messages.SERVER_API_INCOMPATIBLE;
            }
            if (error is WebException)
            {
                WebException exception = error as WebException;
                if (exception.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return string.Format(Messages.ERROR_NOT_FOUND, Hostname);
                }
                if (exception.Status == WebExceptionStatus.ConnectFailure)
                {
                    return string.Format(Messages.CONNECT_CONNECTION_FAILURE, Hostname);
                }
                if ((exception.Status != WebExceptionStatus.ReceiveFailure) && (exception.Status != WebExceptionStatus.SendFailure))
                {
                    return exception.Message;
                }
                return string.Format(Messages.ERROR_NO_XENSERVER, Hostname);
            }
            if (((error is Failure) && (error != null)) && !string.IsNullOrEmpty(error.Message))
            {
                Failure failure = error as Failure;
                if (failure.ErrorDescription[0] == "RBAC_PERMISSION_DENIED")
                {
                    return Messages.ERROR_NO_PERMISSION;
                }
                if (failure.ErrorDescription[0] == "SESSION_AUTHENTICATION_FAILED")
                {
                    return Messages.ADD_NEW_INCORRECT;
                }
                if (failure.ErrorDescription[0] == "HOST_STILL_BOOTING")
                {
                    return Messages.ERROR_HOST_STILL_BOOTING;
                }
                if (((failure.ErrorDescription.Count == 4) && (failure.ErrorDescription[0] == "XENAPI_PLUGIN_FAILURE")) && (failure.ErrorDescription[3] == "['NO_HOSTS_AVAILABLE']"))
                {
                    return Messages.ERROR_NO_HOSTS_AVAILABLE;
                }
                return error.Message.Replace("XENAPI_PLUGIN_FAILURE - main - Exception - ", "");
            }
            if ((error != null) && !string.IsNullOrEmpty(error.Message))
            {
				if (error.Message.IndexOf("HOST_IS_SLAVE") >= 0) {
					string[] arr = error.Message.Split(new char[1] { '-' });
					if (arr != null && arr.Length == 2) {
						Exception innerError = error.InnerException;
						if (innerError != null && innerError.ToString().IndexOf("SESSION_AUTHENTICATION_FAILED") >= 0) {
							return string.Format(Messages.MASTER_NEW_INCORRECT, arr[1]);
						}
						else {
							return string.Format(Messages.MASTER_NEW_CONNECT, arr[1]);
						}
					}
				}
				return Messages.UNKNOWN_CONNECTION_ERROR;
            }
            return Messages.ERROR_CONNECTING_BLURB;
        }

        public static string GetFreeSpaceString(WinAPI.SR theSR)
        {
            return DiskSizeString(theSR.physical_size - theSR.physical_utilisation, 2);
        }

        public static string GetFreeSpaceString(WinAPI.SR theSR, long otherUsedDiskSpace)
        {
            return DiskSizeString(theSR.physical_size - (theSR.physical_utilisation + otherUsedDiskSpace), 2);
        }

        public static string GetXSVerion()
        {
            string str = "";
            try
            {
                if ((Program.XenServerVersionInfoDict != null) && (Program.XenServerVersionInfoDict.Count == 3))
                {
                    str = Program.XenServerVersionInfoDict["product_version"];
                }
            }
            catch
            {
            }
            return str;
        }

        private static bool IsEmptyCollection(object obj)
        {
            ICollection is2 = obj as ICollection;
            return ((is2 != null) && (is2.Count == 0));
        }

        public static void LaunchAboutDialog()
        {
            try
            {
                if ((aboutDialog == null) || aboutDialog.IsDisposed)
                {
                    aboutDialog = new AboutDialog();
                    aboutDialog.ShowDialog();
                }
                else
                {
                    BringFormToFront(aboutDialog);
                }
            }
            catch
            {
            }
        }

        public static void LaunchCancelJobsDialog()
        {
            try
            {
                if ((cancelJobsDialog == null) || cancelJobsDialog.IsDisposed)
                {
                    cancelJobsDialog = new CancelJobsDialog(Commands.GetCancelableJobs());
                    cancelJobsDialog.ShowDialog();
                }
                else
                {
                    BringFormToFront(cancelJobsDialog);
                }
            }
            catch
            {
            }
        }

        public static void LaunchConversionWizard()
        {
            try
            {
                if ((conVpxWizard == null) || conVpxWizard.IsDisposed)
                {
                    conVpxWizard = new ConVPX.Wizards.ConversionWizard.ConversionWizard();
                    conVpxWizard.ShowDialog();
                }
                else
                {
                    BringFormToFront(conVpxWizard);
                }
            }
            catch (Exception exception)
            {
                LOG.Error(exception.Message);
            }
        }

        public static void LaunchLegalNoticesDialog()
        {
            try
            {
                if ((legalNoticesDialog == null) || legalNoticesDialog.IsDisposed)
                {
                    legalNoticesDialog = new LegalNoticesDialog();
                    legalNoticesDialog.ShowDialog();
                }
                else
                {
                    BringFormToFront(legalNoticesDialog);
                }
            }
            catch
            {
            }
        }

        public static void LaunchRetryJobsDialog()
        {
            try
            {
                if ((retryJobsDialog == null) || retryJobsDialog.IsDisposed)
                {
                    retryJobsDialog = new RetryJobsDialog(Commands.GetRetryableJobs());
                    retryJobsDialog.ShowDialog();
                }
                else
                {
                    BringFormToFront(retryJobsDialog);
                }
            }
            catch
            {
            }
        }

        public static DialogResult LaunchXSConnectDialog()
        {
            DialogResult none = DialogResult.None;
            try
            {
                if ((connectionDialog == null) || connectionDialog.IsDisposed)
                {
                    connectionDialog = new ConnectToXenServer();
                    return connectionDialog.ShowDialog();
                }
                BringFormToFront(connectionDialog);
            }
            catch
            {
            }
            return none;
        }

        public static int NaturalCompare(string s1, string s2)
        {
            Match match = NaturalCompareRegex.Match(s1);
            Match match2 = NaturalCompareRegex.Match(s2);
            while (match.Success)
            {
                if (!match2.Success)
                {
                    return 1;
                }
                string s = match.Value;
                string str2 = match2.Value;
                int result = 0;
                int num2 = 0;
                bool flag = int.TryParse(s, out result);
                bool flag2 = int.TryParse(str2, out num2);
                if (flag && flag2)
                {
                    if (result != num2)
                    {
                        if (result <= num2)
                        {
                            return -1;
                        }
                        return 1;
                    }
                }
                else
                {
                    if (flag)
                    {
                        return 1;
                    }
                    if (flag2)
                    {
                        return -1;
                    }
                    int num3 = s.CompareTo(str2);
                    if (num3 != 0)
                    {
                        return num3;
                    }
                }
                match2 = match2.NextMatch();
                match = match.NextMatch();
            }
            if (!match2.Success)
            {
                return 0;
            }
            return -1;
        }

        public static string SrToString(WinAPI.SR sr)
        {
            return string.Format(Messages.SR_SIZE_FREE, sr.name_label, GetFreeSpaceString(sr));
        }

        public static string SrToString(WinAPI.SR sr, long otherUsedDiskSpace)
        {
            return string.Format(Messages.SR_SIZE_FREE, sr.name_label, GetFreeSpaceString(sr, otherUsedDiskSpace));
        }
    }
}

