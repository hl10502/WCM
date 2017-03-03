namespace WCM.ConVPX.Core
{
    using WCM.ConVPX;
    using WCM.ConVPX.Model;
    using log4net;
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class JobPollThread
    {
        private volatile bool forceJobUpdate = true;
        private volatile bool isPollingSuspended;
        private const int KEEP_ALIVE_RETRY_COUNT = 10;
        private const int KEEP_ALIVE_RETRY_WAIT = 0x7d0;
        private static ILog log;
        private int m_forceUpdateCounter;
        private const int MAX_QUICK_POLLS = 20;
        private const int POLL_TICK = 0x3e8;
        private volatile bool RunThread;
        private volatile bool ThreadRunning;
        private int totalWaitSeconds = 0x3e8;
        private Thread UpdaterThread;
        private const int WAIT_AFTER_POLL_TIME = 0x3a98;

        public event HeartbeatFailureEventHandler HeartbeatFailure;

        public JobPollThread()
        {
            this.InitializeThread();
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void HandleConnectionLoss()
        {
            log.Error("WCM job poll thread indicates appliance is unresponsive or connection has been lost.");
            this.OnHeartbeatFailure();
            this.RequestStop();
        }

        private void InitializeThread()
        {
            this.UpdaterThread = new Thread(new ThreadStart(this.Update));
            this.UpdaterThread.Name = string.Format(Messages.APPLICATION_NAME, "WinServer");
            this.UpdaterThread.IsBackground = true;
        }

        protected void OnHeartbeatFailure()
        {
            if (this.HeartbeatFailure != null)
            {
                this.HeartbeatFailure(this, new HeartbeatFailureEventArgs(false));
            }
        }

        public void RequestImmediateUpdate()
        {
            this.m_forceUpdateCounter = 0;
            this.forceJobUpdate = true;
        }

        public void RequestStop()
        {
            this.ThreadRunning = false;
            this.RunThread = false;
        }

        public void ResumeEventNotification(bool bClearEventStack)
        {
        }

        public void ResumeEventPolling()
        {
            this.isPollingSuspended = false;
        }

        public void Start()
        {
            this.isPollingSuspended = false;
            if (!this.ThreadRunning)
            {
                this.ThreadRunning = true;
                this.RunThread = true;
                if ((this.UpdaterThread.ThreadState & ThreadState.Unstarted) > ThreadState.Running)
                {
                    this.UpdaterThread.Start();
                }
            }
        }

        public void SuspendEventNotification()
        {
        }

        public void SuspendEventPolling()
        {
            this.isPollingSuspended = true;
        }

        public void Update()
        {
            while (this.RunThread)
            {
                try
                {
                    if ((Program.ClientConnection != null) && !this.isPollingSuspended)
                    {
                        try
                        {
                            ConVpxJobInfoList jobList = Commands.GetJobList(Program.ClientConnection);
                            if ((jobList != null) && !Helpers.AreEqual(Program.JobList, jobList))
                            {
                                lock (Program.JobListLock)
                                {
                                    Program.JobList = jobList;
                                    Program.UpdateJobList = true;
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            log.Error(exception.Message);
                        }
                    }
                    this.totalWaitSeconds = 0x3e8;
                    while (!this.forceJobUpdate)
                    {
                        Thread.Sleep(0x3e8);
                        this.totalWaitSeconds += 0x3e8;
                        if (this.totalWaitSeconds >= 0x3a98)
                        {
                            break;
                        }
                    }
                    if (this.forceJobUpdate && (this.m_forceUpdateCounter++ >= 20))
                    {
                        this.forceJobUpdate = false;
                    }
                    Program.IsApplianceAlive = Commands.IsApplianceAlive(Program.ClientConnection, 10, 0x7d0);
                    if (!Program.IsApplianceAlive)
                    {
                        this.HandleConnectionLoss();
                    }
                    continue;
                }
                catch (Exception exception2)
                {
                    log.Error(exception2, exception2);
                    continue;
                }
            }
        }
    }
}

