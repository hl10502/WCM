namespace WCM.ConVPX.Model
{
    using ExportImport.CommonTypes;
    using WCM.ConVPX;
    using WCM.ConVPX.Core;
    using System;
    using System.ComponentModel;
    using System.Threading;

    public class ConVpxJobInfo : INotifyPropertyChanged
    {
        private DateTime _completedDateTime;
        private long _compressedBytesRead;
        private DateTime _createdDateTime;
        private string _description;
        private string _destServer;
        private string _errorMessage;
        private string _jobId;
        private JobInstance _jobInstance;
        private long _percentComplete;
        private ServerInfo _source;
        private string _sourceVMName;
        private DateTime _startDateTime;
        private int _state;
        private string _stateDescription;
        private string _stateString;
        private string _targetSR;
        private string _title;
        private long _uncompressedBytesWritten;

        public event PropertyChangedEventHandler PropertyChanged;

        public ConVpxJobInfo()
        {
        }

        public ConVpxJobInfo(JobInstance jobInstance)
        {
            this._jobInstance = jobInstance;
            this._jobId = jobInstance.Id;
            this._title = jobInstance.JobName;
            string str = this._title.Replace(InvisibleMessages.REMOTE_CONVERTING_STATUS_MESSAGE, Messages.CONVERTING_STATUS);
            this._title = str;
            this._description = jobInstance.JobDesc;
            this._createdDateTime = jobInstance.CreatedTime.ToLocalTime();
            this._startDateTime = jobInstance.StartTime.ToLocalTime();
            this._completedDateTime = jobInstance.CompletedTime.ToLocalTime();
            this._stateString = ConVpxEnums.GetDisplayText<ConVpxEnums.JobState>((ConVpxEnums.JobState) jobInstance.State);
            this._state = jobInstance.State;
            this._stateDescription = jobInstance.StateDesc;
            this._sourceVMName = jobInstance.JobInfo.SourceVmName;
            this._targetSR = jobInstance.SRName;
            this._destServer = jobInstance.XenServerName;
            this._compressedBytesRead = jobInstance.CompressedBytesRead;
            this._uncompressedBytesWritten = jobInstance.UncompressedBytesWritten;
            this._percentComplete = jobInstance.PercentComplete;
            this._errorMessage = jobInstance.ErrorString;
            this._source = jobInstance.JobInfo.Source;
        }

        public bool DeepEquals(ConVpxJobInfo other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (((((Helpers.AreEqual2<string>(this.JobId, other.JobId) && Helpers.AreEqual2<string>(this.Title, other.Title)) && (Helpers.AreEqual2<string>(this.Description, other.Description) && Helpers.AreEqual2<DateTime>(this.CreatedDateTime, other.CreatedDateTime))) && ((Helpers.AreEqual2<DateTime>(this.StartDateTime, other.StartDateTime) && Helpers.AreEqual2<DateTime>(this.CompletedDateTime, other.CompletedDateTime)) && (Helpers.AreEqual2<string>(this.StateDescription, other.StateDescription) && Helpers.AreEqual2<string>(this.StateDisplay, other.StateDisplay)))) && (((Helpers.AreEqual2<string>(this.SourceVMName, other.SourceVMName) && Helpers.AreEqual2<string>(this.Destination, other.Destination)) && (Helpers.AreEqual2<string>(this.TargetSR, other.TargetSR) && Helpers.AreEqual2<long>(this.CompressedBytesRead, other.CompressedBytesRead))) && ((Helpers.AreEqual2<long>(this.UncompressedBytesWritten, other.UncompressedBytesWritten) && Helpers.AreEqual2<long>(this.PercentComplete, other.PercentComplete)) && Helpers.AreEqual2<string>(this.ErrorMessage, other.ErrorMessage)))) && Helpers.AreEqual2<string>(this.Source, other.Source)));
        }

        public override bool Equals(object other)
        {
            ConVpxJobInfo info = other as ConVpxJobInfo;
            return this.DeepEquals(info);
        }

        public override int GetHashCode()
        {
            return this.JobId.GetHashCode();
        }

        private void NotifyPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public DateTime CompletedDateTime
        {
            get
            {
                return this._completedDateTime;
            }
            set
            {
                this._completedDateTime = value;
                this.NotifyPropertyChanged("CompletedDateTime");
            }
        }

        public long CompressedBytesRead
        {
            get
            {
                return this._compressedBytesRead;
            }
            set
            {
                this._compressedBytesRead = value;
                this.NotifyPropertyChanged("CompressedBytesRead");
            }
        }

        public DateTime CreatedDateTime
        {
            get
            {
                return this._createdDateTime;
            }
            set
            {
                this._createdDateTime = value;
                this.NotifyPropertyChanged("CreatedDateTime");
            }
        }

        private string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
                this.NotifyPropertyChanged("Description");
            }
        }

        public string Destination
        {
            get
            {
                if (this._destServer != null)
                {
                    return string.Format(InvisibleMessages.JOB_DESTINATION_FORMAT, this._destServer, this.SourceVMName);
                }
                return this.SourceVMName;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                this._errorMessage = value;
                this.NotifyPropertyChanged("ErrorMessage");
            }
        }

        public string JobId
        {
            get
            {
                return this._jobId;
            }
            set
            {
                this._jobId = value;
                this.NotifyPropertyChanged("JobId");
            }
        }

        public long PercentComplete
        {
            get
            {
                return this._percentComplete;
            }
            set
            {
                this._percentComplete = value;
                this.NotifyPropertyChanged("PercentComplete");
            }
        }

        public string Source
        {
            get
            {
                try
                {
                    return string.Format(InvisibleMessages.JOB_SOURCE_FORMAT, this._source.Hostname, this.SourceVMName);
                }
                catch
                {
                    return this._source.Hostname;
                }
            }
        }

        public string SourceVMName
        {
            get
            {
                return this._sourceVMName;
            }
            set
            {
                this._sourceVMName = value;
                this.NotifyPropertyChanged("SourceVMName");
            }
        }

        public DateTime StartDateTime
        {
            get
            {
                return this._startDateTime;
            }
            set
            {
                this._startDateTime = value;
                this.NotifyPropertyChanged("StartDateTime");
            }
        }

        public int State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
                this.NotifyPropertyChanged("State");
            }
        }

        public string StateDescription
        {
            get
            {
                return this._stateDescription;
            }
            set
            {
                this._stateDescription = value;
                this.NotifyPropertyChanged("StateDescription");
            }
        }

        public string StateDisplay
        {
            get
            {
                return this._stateString;
            }
            set
            {
                this._stateString = value;
                this.NotifyPropertyChanged("StateDisplay");
            }
        }

        public string Status
        {
            get
            {
                return this.StateDisplay;
            }
        }

        public string StatusVerbose
        {
            get
            {
                return string.Format(InvisibleMessages.JOB_STATUS_FORMAT, this.StateDisplay, this.StateDescription);
            }
        }

        public string TargetSR
        {
            get
            {
                return this._targetSR;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
                this.NotifyPropertyChanged("Title");
            }
        }

        public long UncompressedBytesWritten
        {
            get
            {
                return this._uncompressedBytesWritten;
            }
            set
            {
                this._uncompressedBytesWritten = value;
                this.NotifyPropertyChanged("UncompressedBytesWritten");
            }
        }
    }
}

