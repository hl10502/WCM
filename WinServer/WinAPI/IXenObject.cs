namespace WinAPI
{
    using System;
    using System.ComponentModel;

    public interface IXenObject : INotifyPropertyChanged
    {
        void ClearEventListeners();

        string opaque_ref { get; set; }
    }
}

