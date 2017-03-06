namespace ExportImport.ConversionClientLib
{
    using ExportImport.CommonTypes;
    using CookComputing.XmlRpc;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Reflection;
    using WinAPI;

    public class ConversionClient
    {
        private const string BASE_TAMPA_VERSION = "6.0";
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ServerInfo m_hostInfo;
        private ExportImport.ConversionClientLib.Proxy m_proxy;
        private int m_requestCompositeTimeout;
        private int m_requestRegularTimeout;
        private string m_serviceUrl;
        public const string pluginMethod = "main";
        public const string pluginScript = "conversion";
        public static string UserAgent = "Winhong/ExportImportClientv0.1";

        public ConversionClient(int requestRegularTimeout, int requestCompositeTimeout)
        {
            this.m_requestRegularTimeout = requestRegularTimeout;
            this.m_requestCompositeTimeout = requestCompositeTimeout;
        }

        public void ClearJobs()
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            this.m_proxy.ClearJobs(cred);
        }

        public void Connect(ServerInfo hostInfo)
        {
            if (((hostInfo.Hostname.Length == 0) || (hostInfo.Username.Length == 0)) || (hostInfo.Password.Length == 0))
            {
                throw new ArgumentException("Host info is empty");
            }
            Dictionary<string, string> xenServerVersionInfo = this.GetXenServerVersionInfo(hostInfo);
            if ((xenServerVersionInfo != null) && (xenServerVersionInfo.Count == 3))
            {
                IsTampaOrGreater(xenServerVersionInfo);
            }
            this.m_hostInfo = hostInfo;
            this.m_serviceUrl = GetServiceUrl(hostInfo);
            LOG.Info(string.Format("Conversion info: service={0}", this.m_serviceUrl));
            this.m_proxy = this.CreateProxy(this.m_serviceUrl, this.m_requestRegularTimeout);
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            string msg = string.Format("ConversionClient version={0}, Application version={1}", Assembly.GetExecutingAssembly().GetName().Version.ToString(), Assembly.GetCallingAssembly().GetName().Version.ToString());
            this.m_proxy.LogMessage(cred, 6, msg);
        }

        public JobInstance CreateJob(JobInfo jobInfo)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            return this.m_proxy.CreateJob(cred, jobInfo);
        }

        private ExportImport.ConversionClientLib.Proxy CreateProxy(string url, int timeout)
        {
            ExportImport.ConversionClientLib.Proxy proxy = XmlRpcProxyGen.Create<ExportImport.ConversionClientLib.Proxy>();
            proxy.Url = url;
            proxy.NonStandard = XmlRpcNonStandard.All;
            proxy.Timeout = timeout;
            proxy.UseIndentation = false;
            proxy.UserAgent = UserAgent;
            proxy.KeepAlive = true;
            return proxy;
        }

        public void DeleteJob(string jobId)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            this.m_proxy.DeleteJob(cred, jobId);
        }

        public JobInstance[] GetAllJobs()
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            int timeout = this.m_proxy.Timeout;
            this.m_proxy.Timeout = this.m_requestCompositeTimeout;
            JobInstance[] allJobs = this.m_proxy.GetAllJobs(cred);
            this.m_proxy.Timeout = timeout;
            return allJobs;
        }

        public WinAPI.SR GetDefaultSR(ServerInfo hostInfo)
        {
            WinAPI.SR sr = null;
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);
                Dictionary<XenRef<Pool>, Pool> dictionary = Pool.get_all_records(session);
                if (dictionary != null)
                {
                    foreach (XenRef<Pool> ref2 in dictionary.Keys)
                    {
                        XenRef<WinAPI.SR> ref3 = Pool.get_default_SR(session, (string) ref2);
                        if (ref3 != null)
                        {
                            sr = WinAPI.SR.get_record(session, (string) ref3);
                        }
                        return sr;
                    }
                }
                return sr;
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get default SR from WinServer! Exception caught...", exception);
            }
            return sr;
        }

        public Network GetDefaultXenServerNetwork(ServerInfo hostInfo)
        {
            Network network = null;
            try
            {
                Dictionary<XenRef<Network>, Network> dictionary = Network.get_all_records(OpenSessionAndLogin(hostInfo));
                foreach (XenRef<Network> ref2 in dictionary.Keys)
                {
                    if (dictionary[ref2].bridge.ToLower().Contains("xenbr0"))
                    {
                        network = dictionary[ref2];
                    }
                }
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get default network from WinServer! Exception caught...", exception);
            }
            return network;
        }

        private Dictionary<string, string> GetHostLicense(ServerInfo hostInfo)
        {
            Dictionary<string, string> dictionary = null;
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);
                string str = session.get_this_host();
                dictionary = Host.get_license_params(session, str);
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get host license params from WinServer! Exception caught...", exception);
            }
            return dictionary;
        }

        public NetworkInstance[] GetHypervisorNetworks(ServerInfo source)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            int timeout = this.m_proxy.Timeout;
            this.m_proxy.Timeout = this.m_requestCompositeTimeout;
            NetworkInstance[] hypervisorNetworks = this.m_proxy.GetHypervisorNetworks(cred, source);
            this.m_proxy.Timeout = timeout;
            return hypervisorNetworks;
        }

        public JobInstance GetJob(string jobId)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            return this.m_proxy.GetJob(cred, jobId);
        }

        public string GetJobLog(string jobId)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            int timeout = this.m_proxy.Timeout;
            this.m_proxy.Timeout = this.m_requestCompositeTimeout;
            string jobLog = this.m_proxy.GetJobLog(cred, jobId);
            this.m_proxy.Timeout = timeout;
            return jobLog;
        }

        public string GetLog()
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            int timeout = this.m_proxy.Timeout;
            this.m_proxy.Timeout = this.m_requestCompositeTimeout;
            string log = this.m_proxy.GetLog(cred);
            this.m_proxy.Timeout = timeout;
            return log;
        }

        private Host GetMasterHost(ServerInfo hostInfo)
        {
            Host host = null;
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);
                Pool pool = null;
                List<XenRef<Pool>> list = Pool.get_all(session);
                if (list.Count > 0)
                {
                    pool = Pool.get_record(session, list[0]);
                }
                if (pool == null)
                {
                    string str = session.get_this_host();
                    return Host.get_record(session, str);
                }
                if (pool.master == null)
                {
                    string str2 = session.get_this_host();
                    return Host.get_record(session, str2);
                }
                host = Host.get_record(session, (string) pool.master);
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get master host object from WinServer! Exception caught...", exception);
            }
            return host;
        }

        public long GetReservedDiskSpace(string sruuid)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            return this.m_proxy.GetReservedDiskSpace(cred, sruuid);
        }

        public Dictionary<WinAPI.SR, long> GetReservedDiskSpaceDict(List<WinAPI.SR> list)
        {
            Dictionary<WinAPI.SR, long> dictionary = new Dictionary<WinAPI.SR, long>();
            try
            {
                new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
                foreach (WinAPI.SR sr in list)
                {
                    long reservedDiskSpace = this.GetReservedDiskSpace(sr.uuid);
                    dictionary.Add(sr, reservedDiskSpace);
                }
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get reserved disk space from WinServer! Exception caught...", exception);
            }
            return dictionary;
        }

        private static string GetServiceUrl(ServerInfo hostInfo)
        {
            string str;
            string str2;
            string str3;
            bool flag = true;
            try
            {
                str2 = ConfigurationManager.AppSettings["ConversionClient.PluginScript"].ToString();
            }
            catch
            {
                str2 = "conversion";
            }
            try
            {
                str3 = ConfigurationManager.AppSettings["ConversionClient.PluginScript"].ToString();
            }
            catch
            {
                str3 = "main";
            }
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);
                str = Host.call_plugin(session, session.get_this_host(), str2, str3, null);
                session.logout();
            }
            catch (Exception exception)
            {
                LOG.Warn("\n\n!!!Using the specified host as the service IP!!!\n\n");
                throw exception;
            }
            try
            {
                flag = bool.Parse(ConfigurationManager.AppSettings["ConversionClient.UseSSL"].ToString());
            }
            catch
            {
                flag = true;
            }
            if (flag)
            {
                return string.Format("https://{0}", str);
            }
            return string.Format("http://{0}", str);
        }

        public List<WinAPI.SR> GetSRList(ServerInfo hostInfo)
        {
            List<WinAPI.SR> list = new List<WinAPI.SR>();
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);

                Pool pool = null;
                string masterHostRef = null;
                List<XenRef<Pool>> poolList = Pool.get_all(session);
                if (list.Count > 0)
                {
                    pool = Pool.get_record(session, poolList[0]);
                }
                if (pool == null || pool.master == null)
                {
                    masterHostRef = session.get_this_host();
                }
                else
                {
                    masterHostRef = (string)pool.master;
                }


                List<XenRef<SR>> srRefs = SR.get_all(session);
                foreach (XenRef<SR> srRef in srRefs)
                {
                    SR sr = SR.get_record(session, (string)srRef);
                    bool allCurrentlyAttached = true;
                    bool isOtherLocalSr = false;
                    List<XenRef<PBD>> pbdRefs = SR.get_PBDs(session, (string)srRef);
                    foreach (XenRef<PBD> pbdRef in pbdRefs)
                    {
                        PBD pbd = PBD.get_record(session, (string)pbdRef);
                        bool currentlyAttached = pbd.currently_attached;
                        if (!currentlyAttached)
                        {
                            allCurrentlyAttached = false;
                            break;
                        }

                        string hostRef = (string)pbd.host;
                        if (!sr.shared && !hostRef.Equals(masterHostRef))
                        {
                            isOtherLocalSr = true; //非master主机的本地存储池
                            break;
                        }
                    }
                    if (!allCurrentlyAttached)
                    {
                        continue;
                    }

                    if (!isOtherLocalSr && this.IsValidSR(sr) && sr.physical_size > 0L && sr.physical_size - sr.physical_utilisation > 0L)
                    {
                        list.Add(sr);
                    }
                }

                //List<XenRef<Host>> list2 = Host.get_all(session);
                //foreach (XenRef<PBD> ref2 in Host.get_record(session, list2[0]).PBDs)
                //{
                //    XenRef<WinAPI.SR> ref3 = PBD.get_SR(session, (string) ref2);
                //    WinAPI.SR sr = WinAPI.SR.get_record(session, (string) ref3);
                //    if ((this.IsValidSR(sr) && ((list2.Count < 2) || this.IsSharedSR(sr))) && (sr.physical_size > 0L))
                //    {
                //        list.Add(sr);
                //    }
                //}
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get service SRs from WinServer! Exception caught...", exception);
            }
            return list;
        }

        public string GetVersion()
        {
            return this.m_proxy.GetVersion();
        }

        public VmInstance[] GetVirtualMachines(ServerInfo source)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            int timeout = this.m_proxy.Timeout;
            this.m_proxy.Timeout = this.m_requestCompositeTimeout;
            VmInstance[] virtualMachines = this.m_proxy.GetVirtualMachines(cred, source);
            this.m_proxy.Timeout = timeout;
            return virtualMachines;
        }

        public string GetXenServerFriendlyName(ServerInfo hostInfo)
        {
            string host;
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);
                List<XenRef<Pool>> list = Pool.get_all(session);
                host = Pool.get_record(session, list[0]).name_label;
                if (host.Length == 0)
                {
                    string str2 = session.get_this_host();
                    host = Host.get_name_label(session, str2);
                }
                session.logout();
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get WinServer friendlyName! Exception caught...", exception);
                Uri uri = new Uri(hostInfo.Hostname);
                host = uri.Host;
            }
            return host;
        }

        public Dictionary<string, string> GetXenServerLicenseInfo(ServerInfo hostInfo)
        {
            return this.GetHostLicense(hostInfo);
        }

        public Dictionary<XenRef<Network>, Network> GetXenServerNetworks(ServerInfo hostInfo)
        {
            Dictionary<XenRef<Network>, Network> dictionary = new Dictionary<XenRef<Network>, Network>();
            try
            {
                Session session = OpenSessionAndLogin(hostInfo);
                foreach (XenRef<Network> ref2 in Network.get_all(session))
                {
                    Network network = Network.get_record(session, (string) ref2);
                    if (string.Compare(network.name_label, "Host internal management network", true) != 0)
                    {
                        dictionary.Add(ref2, network);
                    }
                }
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get networks from WinServer! Exception caught...", exception);
            }
            return dictionary;
        }

        public Dictionary<string, string> GetXenServerVersionInfo(ServerInfo hostInfo)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                Host masterHost = this.GetMasterHost(hostInfo);
                if (masterHost != null)
                {
                    foreach (string str in new string[] { "date", "build_number", "product_version" })
                    {
                        if (masterHost.software_version.ContainsKey(str))
                        {
                            dictionary.Add(str, masterHost.software_version[str]);
                        }
                    }
                    return dictionary;
                }
                LOG.Error("Unable to get version information from WinServer!");
            }
            catch (Exception exception)
            {
                LOG.Error("Unable to get version information from WinServer! Exception caught...", exception);
            }
            return dictionary;
        }

        private bool IsSharedSR(WinAPI.SR sr)
        {
            return sr.shared;
        }

        public static bool IsTampaOrGreater(Dictionary<string, string> xenServerVersionInfoDict)
        {
            bool flag = false;
            Version version = new Version();
            Version version2 = new Version("6.0");
            try
            {
                if ((xenServerVersionInfoDict != null) && (xenServerVersionInfoDict.Count == 3))
                {
                    version = new Version(xenServerVersionInfoDict["product_version"]);
                }
                switch (version.CompareTo(version2))
                {
                    case -1:
                        return false;

                    case 0:
                        return true;

                    case 1:
                        return true;
                }
                return flag;
            }
            catch
            {
            }
            return flag;
        }

        private bool IsValidSR(WinAPI.SR sr)
        {
            //if (sr.content_type == "iso")
            //{
            //    return false;
            //}
            //return true;
            //五种类型 nfs ext lvm lvmhba lvmoiscsi
            if ("nfs".Equals(sr.type) || "ext".Equals(sr.type) || (!String.IsNullOrEmpty(sr.type) && sr.type.IndexOf("lvm") >= 0))
            {
                return true;
            }
            return false;
        }

        private static Session OpenSessionAndLogin(ServerInfo hostInfo)
        {
            //Session session = new Session(string.Format("https://{0}", hostInfo.Hostname));
            Session session = SessionFactory.CreateSession(hostInfo.Hostname);

            string version = Helper.APIVersionString(API_Version.API_2_5);
            string originator = "Conversion";
            try
            {
                session.login_with_password(hostInfo.Username, hostInfo.Password, version, originator);
            }
            catch (Failure failure)
            {
                if (failure.ErrorDescription[0] != "HOST_IS_SLAVE")
                {
                    throw;
                }
                //session = new Session(string.Format("https://{0}", failure.ErrorDescription[1]));
                session = SessionFactory.CreateSession(failure.ErrorDescription[1]);
                session.login_with_password(hostInfo.Username, hostInfo.Password, version, originator);
                return session;
            }
            return session;
        }

        public void RetryJob(string jobId)
        {
            ServiceCred cred = new ServiceCred(this.m_hostInfo.Username, this.m_hostInfo.Password);
            this.m_proxy.RetryJob(cred, jobId);
        }

        public ServerInfo HostInfo
        {
            get
            {
                return this.m_hostInfo;
            }
        }
    }
}

