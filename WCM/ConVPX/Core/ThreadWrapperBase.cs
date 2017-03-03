namespace WCM.ConVPX.Core
{
    using System;
    using System.Threading;

    public abstract class ThreadWrapperBase
    {
        private int cancelCheckInterval = 5;
        private TimeSpan cancelWaitTime = TimeSpan.Zero;
        private Guid id = Guid.NewGuid();
        protected int progress;
        private bool requestCancel = false;
        private StatusState status;
        private bool supportsProgress;
        private Thread thread;

        protected ThreadWrapperBase()
        {
        }

        protected abstract void DoTask();
        protected abstract void OnCompleted();
        public void Start()
        {
            if (this.status == StatusState.InProgress)
            {
                throw new InvalidOperationException("Already in progress.");
            }
            this.status = StatusState.InProgress;
            this.thread = new Thread(new ThreadStart(this.StartTaskAsync));
            this.thread.IsBackground = true;
            this.thread.Start();
        }

        private void StartTaskAsync()
        {
            this.DoTask();
            this.status = StatusState.Completed;
            this.OnCompleted();
        }

        public void StopTask()
        {
            if (this.status == StatusState.InProgress)
            {
                if (this.cancelWaitTime != TimeSpan.Zero)
                {
                    DateTime now = DateTime.Now;
                    while (DateTime.Now.Subtract(now).TotalSeconds > 0.0)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds((double) this.cancelCheckInterval));
                    }
                }
                this.thread.Abort();
            }
        }

        protected int CancelCheckInterval
        {
            get
            {
                return this.cancelCheckInterval;
            }
            set
            {
                this.cancelCheckInterval = value;
            }
        }

        protected TimeSpan CancelWaitTime
        {
            get
            {
                return this.cancelWaitTime;
            }
            set
            {
                this.cancelWaitTime = value;
            }
        }

        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

        public int Progress
        {
            get
            {
                if (!this.supportsProgress)
                {
                    throw new InvalidOperationException("This worker does not report progess.");
                }
                return this.progress;
            }
        }

        protected bool RequestCancel
        {
            get
            {
                return this.requestCancel;
            }
        }

        public StatusState Status
        {
            get
            {
                return this.status;
            }
        }

        protected bool SupportsProgress
        {
            get
            {
                return this.supportsProgress;
            }
            set
            {
                this.supportsProgress = value;
            }
        }
    }
}

