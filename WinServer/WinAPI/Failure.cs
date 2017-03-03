namespace WinAPI
{
    using System;
    using System.Collections.Generic;
    using System.Resources;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using System.Xml;

    [Serializable]
    public class Failure : Exception
    {
        private readonly List<string> errorDescription;
        private static ResourceManager errorDescriptions = FriendlyErrorNames.ResourceManager;
        private string errorText;
        public const string INTERNAL_ERROR = "INTERNAL_ERROR";
        public const string MESSAGE_PARAMETER_COUNT_MISMATCH = "MESSAGE_PARAMETER_COUNT_MISMATCH";
        private string shortError;

        public Failure()
        {
        }

        public Failure(params string[] err) : this(new List<string>(err))
        {
        }

        public Failure(List<string> errDescription)
        {
            this.errorDescription = errDescription;
            this.Setup();
        }

        protected Failure(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.errorDescription = (List<string>) info.GetValue("errorDescription", typeof(List<string>));
            this.errorText = info.GetString("errorText");
            this.shortError = info.GetString("shortError");
        }

        public Failure(string message, Exception exception) : base(message, exception)
        {
            this.errorDescription = new List<string> { message };
            this.Setup();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("errorDescription", this.errorDescription, typeof(List<string>));
            info.AddValue("errorText", this.errorText);
            info.AddValue("shortError", this.shortError);
            base.GetObjectData(info, context);
        }

        public void Setup()
        {
            if (this.ErrorDescription.Count > 0)
            {
                try
                {
                    string str;
                    try
                    {
                        str = errorDescriptions.GetString(this.ErrorDescription[0]);
                    }
                    catch
                    {
                        str = null;
                    }
                    if (str == null)
                    {
                        List<string> list = new List<string>();
                        foreach (string str2 in this.ErrorDescription)
                        {
                            if (str2.Trim().Length > 0)
                            {
                                list.Add(str2.Trim());
                            }
                        }
                        this.errorText = string.Join(" - ", list.ToArray());
                    }
                    else
                    {
                        string[] strArray = new string[this.ErrorDescription.Count - 1];
                        for (int i = 1; i < this.ErrorDescription.Count; i++)
                        {
                            strArray[i - 1] = this.ErrorDescription[i];
                        }
                        this.errorText = string.Format(str, (object[]) strArray);
                    }
                }
                catch (Exception)
                {
                    this.errorText = this.ErrorDescription[0];
                }
                try
                {
                    this.shortError = errorDescriptions.GetString(this.ErrorDescription[0] + "-SHORT") ?? this.errorText;
                }
                catch (Exception)
                {
                    this.shortError = this.errorText;
                }
                this.TryParseCslg();
            }
        }

        public override string ToString()
        {
            return this.Message;
        }

        private bool TryParseCslg()
        {
            if (((this.ErrorDescription.Count > 2) && (this.ErrorDescription[2] != null)) && ((this.ErrorDescription[0] != null) && this.ErrorDescription[0].StartsWith("SR_BACKEND_FAILURE")))
            {
                Match match = Regex.Match(this.ErrorDescription[2], "<StorageLinkServiceError>.*</StorageLinkServiceError>", RegexOptions.Singleline);
                if (match.Success)
                {
                    XmlDocument document = new XmlDocument();
                    try
                    {
                        document.LoadXml(match.Value);
                    }
                    catch (XmlException)
                    {
                        return false;
                    }
                    XmlNodeList list = document.SelectNodes("/StorageLinkServiceError/Fault");
                    if (((list != null) && (list.Count > 0)) && !string.IsNullOrEmpty(list[0].InnerText))
                    {
                        if (string.IsNullOrEmpty(this.errorText))
                        {
                            this.errorText = list[0].InnerText;
                        }
                        else
                        {
                            this.errorText = string.Format("{0} ({1})", this.errorText, list[0].InnerText);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        public List<string> ErrorDescription
        {
            get
            {
                return this.errorDescription;
            }
        }

        public override string Message
        {
            get
            {
                return this.errorText;
            }
        }

        public string ShortMessage
        {
            get
            {
                return this.shortError;
            }
        }
    }
}

