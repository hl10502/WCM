namespace WinAPI
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class XenObject<S> : IXenObject, INotifyPropertyChanged where S: XenObject<S>
    {
        private bool _changed;
        private string _opaque_ref;

        public event PropertyChangedEventHandler PropertyChanged;

        protected XenObject()
        {
        }

        public void ClearEventListeners()
        {
            this.PropertyChanged = null;
        }

        public void NotifyPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public abstract string SaveChanges(Session session, string serverOpaqueRef, S serverObject);
        public abstract void UpdateFrom(S update);

        public bool Changed
        {
            get
            {
                return this._changed;
            }
            set
            {
                this._changed = value;
            }
        }

        public string opaque_ref
        {
            get
            {
                return this._opaque_ref;
            }
            set
            {
                this._opaque_ref = value;
            }
        }
    }
}

