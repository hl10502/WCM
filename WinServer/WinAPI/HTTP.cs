namespace WinAPI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.RegularExpressions;

    public class HTTP
    {
        public const int BUFFER_SIZE = 0x8000;
        public const int DEFAULT_HTTPS_PORT = 0x1bb;
        public const int MAX_REDIRECTS = 10;

        public static Uri BuildUri(string hostname, string path, params object[] args)
        {
            List<object> list = new List<object>();
            foreach (object obj2 in args)
            {
                if (obj2 is IEnumerable<object>)
                {
                    list.AddRange((IEnumerable<object>) obj2);
                }
                else
                {
                    list.Add(obj2);
                }
            }
            UriBuilder builder = new UriBuilder {
                Scheme = "https",
                Port = 0x1bb,
                Host = hostname,
                Path = path
            };
            StringBuilder builder2 = new StringBuilder();
            for (int i = 0; i < (list.Count - 1); i += 2)
            {
                if (list[i + 1] != null)
                {
                    string str;
                    if (list[i + 1] is bool)
                    {
                        if (!((bool) list[i + 1]))
                        {
                            continue;
                        }
                        str = list[i] + "=true";
                    }
                    else
                    {
                        str = list[i] + "=" + Uri.EscapeDataString(list[i + 1].ToString());
                    }
                    if (builder2.Length != 0)
                    {
                        builder2.Append('&');
                    }
                    builder2.Append(str);
                }
            }
            builder.Query = builder2.ToString();
            return builder.Uri;
        }

        public static Stream CONNECT(Uri uri, IWebProxy proxy, string session, int timeout_ms)
        {
            return DO_HTTP(uri, proxy, true, timeout_ms, new string[] { string.Format("CONNECT {0} HTTP/1.0", uri.PathAndQuery), string.Format("Host: {0}", uri.Host), string.Format("Cookie: session_id={0}", session) });
        }

        private static NetworkStream ConnectSocket(Uri uri, bool nodelay, int timeout_ms)
        {
            AddressFamily addressFamily = (uri.HostNameType == UriHostNameType.IPv6) ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork;
            Socket socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp) {
                NoDelay = nodelay,
                ReceiveTimeout = timeout_ms,
                SendTimeout = timeout_ms
            };
            socket.Connect(uri.Host, uri.Port);
            return new NetworkStream(socket, true);
        }

        public static Stream ConnectStream(Uri uri, IWebProxy proxy, bool nodelay, int timeout_ms)
        {
            Stream stream;
            Stream stream3;
            IMockWebProxy proxy2 = (proxy != null) ? (proxy as IMockWebProxy) : null;
            if (proxy2 != null)
            {
                return proxy2.GetStream(uri);
            }
            bool flag = (proxy != null) && !proxy.IsBypassed(uri);
            if (flag)
            {
                stream = ConnectSocket(proxy.GetProxy(uri), nodelay, timeout_ms);
            }
            else
            {
                stream = ConnectSocket(uri, nodelay, timeout_ms);
            }
            try
            {
                if (flag)
                {
                    WriteLine(string.Format("CONNECT {0}:{1} HTTP/1.0", uri.Host, uri.Port), stream);
                    WriteLine(stream);
                    ReadHttpHeaders(ref stream, proxy, nodelay, timeout_ms);
                }
                if (UseSSL(uri))
                {
                    SslStream stream2 = new SslStream(stream, false, new RemoteCertificateValidationCallback(HTTP.ValidateServerCertificate), null);
                    stream2.AuthenticateAsClient("");
                    stream = stream2;
                }
                stream3 = stream;
            }
            catch
            {
                stream.Close();
                throw;
            }
            return stream3;
        }

        public static long CopyStream(Stream inStream, Stream outStream, DataCopiedDelegate progressDelegate, FuncBool cancellingDelegate)
        {
            long bytes = 0L;
            byte[] buffer = new byte[0x8000];
            DateTime now = DateTime.Now;
            while ((cancellingDelegate == null) || !cancellingDelegate())
            {
                int count = inStream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }
                outStream.Write(buffer, 0, count);
                bytes += count;
                if ((progressDelegate != null) && ((DateTime.Now - now) > TimeSpan.FromMilliseconds(500.0)))
                {
                    progressDelegate(bytes);
                    now = DateTime.Now;
                }
            }
            if ((cancellingDelegate != null) && cancellingDelegate())
            {
                throw new CancelledException();
            }
            if (progressDelegate != null)
            {
                progressDelegate(bytes);
            }
            return bytes;
        }

        private static Stream DO_HTTP(Uri uri, IWebProxy proxy, bool nodelay, int timeout_ms, params string[] headers)
        {
            Stream stream = ConnectStream(uri, proxy, nodelay, timeout_ms);
            int redirect = 0;
            do
            {
                if (redirect > 10)
                {
                    throw new TooManyRedirectsException(redirect, uri);
                }
                redirect++;
                foreach (string str in headers)
                {
                    WriteLine(str, stream);
                }
                WriteLine(stream);
                stream.Flush();
            }
            while (ReadHttpHeaders(ref stream, proxy, nodelay, timeout_ms));
            return stream;
        }

        public static void Get(DataCopiedDelegate dataCopiedDelegate, FuncBool cancellingDelegate, Uri uri, IWebProxy proxy, string path, int timeout_ms)
        {
            string tempFileName = Path.GetTempFileName();
            try
            {
                using (Stream stream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Stream stream2 = GET(uri, proxy, timeout_ms))
                    {
                        CopyStream(stream2, stream, dataCopiedDelegate, cancellingDelegate);
                        stream.Flush();
                    }
                }
                System.IO.File.Delete(path);
                System.IO.File.Move(tempFileName, path);
            }
            finally
            {
                System.IO.File.Delete(tempFileName);
            }
        }

        public static Stream GET(Uri uri, IWebProxy proxy, int timeout_ms)
        {
            return DO_HTTP(uri, proxy, false, timeout_ms, new string[] { string.Format("GET {0} HTTP/1.0", uri.PathAndQuery) });
        }

        public static int getResultCode(string line)
        {
            string[] strArray = line.Split(new char[] { ' ' });
            if (strArray.Length >= 2)
            {
                return int.Parse(strArray[1]);
            }
            return 0;
        }

        public static void Put(UpdateProgressDelegate progressDelegate, FuncBool cancellingDelegate, Uri uri, IWebProxy proxy, string path, int timeout_ms)
        {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (Stream stream2 = PUT(uri, proxy, stream.Length, timeout_ms))
                {
                    long len = stream.Length;
                    DataCopiedDelegate delegate2 = delegate (long bytes) {
                        if ((progressDelegate != null) && (len > 0L))
                        {
                            progressDelegate((int) ((bytes * 100L) / len));
                        }
                    };
                    CopyStream(stream, stream2, delegate2, cancellingDelegate);
                }
            }
        }

        public static Stream PUT(Uri uri, IWebProxy proxy, long ContentLength, int timeout_ms)
        {
            return DO_HTTP(uri, proxy, false, timeout_ms, new string[] { string.Format("PUT {0} HTTP/1.0", uri.PathAndQuery), string.Format("Content-Length: {0}", ContentLength) });
        }

        private static bool ReadHttpHeaders(ref Stream stream, IWebProxy proxy, bool nodelay, int timeout_ms)
        {
            string line = ReadLine(stream);
            switch (getResultCode(line))
            {
                case 200:
                    while (!Regex.Match(ReadLine(stream), @"^\s*$").Success)
                    {
                    }
                    return false;

                case 0x12e:
                {
                    string str2 = "";
                    do
                    {
                        line = ReadLine(stream);
                        if (line.StartsWith("Location: "))
                        {
                            str2 = line.Substring(10);
                        }
                    }
                    while ((!line.Equals("\r\n") && !line.Equals("\n")) && !line.Equals(""));
                    Uri uri = new Uri(str2.Trim());
                    stream.Close();
                    stream = ConnectStream(uri, proxy, nodelay, timeout_ms);
                    return true;
                }
            }
            if (line.EndsWith("\r\n"))
            {
                line = line.Substring(0, line.Length - 2);
            }
            else if (line.EndsWith("\n"))
            {
                line = line.Substring(0, line.Length - 1);
            }
            stream.Close();
            throw new BadServerResponseException(string.Format("Received error code {0} from the server", line));
        }

        private static string ReadLine(Stream stream)
        {
            char ch;
            StringBuilder builder = new StringBuilder();
            do
            {
                int num = stream.ReadByte();
                if (num == -1)
                {
                    throw new EndOfStreamException();
                }
                ch = Convert.ToChar(num);
                builder.Append(ch);
            }
            while (ch != '\n');
            return builder.ToString();
        }

        public static bool UseSSL(Uri uri)
        {
            if (!(uri.Scheme == "https"))
            {
                return (uri.Port == 0x1bb);
            }
            return true;
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private static void WriteLine(Stream stream)
        {
            WriteLine("", stream);
        }

        private static void WriteLine(string txt, Stream stream)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string.Format("{0}\r\n", txt));
            stream.Write(bytes, 0, bytes.Length);
        }

        [Serializable]
        public class BadServerResponseException : Exception
        {
            public BadServerResponseException()
            {
            }

            public BadServerResponseException(string message) : base(message)
            {
            }

            protected BadServerResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BadServerResponseException(string message, Exception exception) : base(message, exception)
            {
            }
        }

        [Serializable]
        public class CancelledException : Exception
        {
            public CancelledException()
            {
            }

            public CancelledException(string message) : base(message)
            {
            }

            protected CancelledException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public CancelledException(string message, Exception exception) : base(message, exception)
            {
            }
        }

        public delegate void DataCopiedDelegate(long bytes);

        public delegate bool FuncBool();

        [Serializable]
        public class TooManyRedirectsException : Exception
        {
            private readonly int redirect;
            private readonly Uri uri;

            public TooManyRedirectsException()
            {
            }

            public TooManyRedirectsException(string message) : base(message)
            {
            }

            public TooManyRedirectsException(int redirect, Uri uri)
            {
                this.redirect = redirect;
                this.uri = uri;
            }

            protected TooManyRedirectsException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.redirect = info.GetInt32("redirect");
                this.uri = (Uri) info.GetValue("uri", typeof(Uri));
            }

            public TooManyRedirectsException(string message, Exception exception) : base(message, exception)
            {
            }

            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                {
                    throw new ArgumentNullException("info");
                }
                info.AddValue("redirect", this.redirect);
                info.AddValue("uri", this.uri, typeof(Uri));
                base.GetObjectData(info, context);
            }
        }

        public delegate void UpdateProgressDelegate(int percent);
    }
}

