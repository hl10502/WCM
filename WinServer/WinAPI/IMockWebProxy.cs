namespace WinAPI
{
    using System;
    using System.IO;
    using System.Net;

    public interface IMockWebProxy : IWebProxy
    {
        Stream GetStream(Uri uri);
    }
}

