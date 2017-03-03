namespace WinAPI
{
    using System;
    using System.Collections.Generic;

    public class UserDetails
    {
        private readonly Session _session;
        private string[] groupMembershipNames;
        private string[] groupMembershipSids;
        private static Dictionary<string, UserDetails> sid_To_UserDetails = new Dictionary<string, UserDetails>();
        private string userDisplayName;
        private string userName;
        private string userSid;

        private UserDetails(Session session)
        {
            this._session = session;
            this.userSid = session.UserSid;
            try
            {
                Subject subject = new Subject {
                    other_config = Auth.get_subject_information_from_identifier(session, this.userSid)
                };
                this.userDisplayName = subject.DisplayName;
                this.userName = subject.SubjectName;
                this.groupMembershipSids = Auth.get_group_membership(session, this.userSid);
            }
            catch (Failure)
            {
            }
        }

        private string[] GetGroupMembershipNames(Session session)
        {
            try
            {
                if (this.groupMembershipSids != null)
                {
                    string[] strArray = new string[this.groupMembershipSids.Length];
                    for (int i = 0; i < this.groupMembershipSids.Length; i++)
                    {
                        string str = this.groupMembershipSids[i];
                        Dictionary<string, string> dictionary = Auth.get_subject_information_from_identifier(session, str);
                        string str2 = "";
                        if (dictionary.TryGetValue("subject-displayname", out str2))
                        {
                            strArray[i] = str2;
                        }
                        else if (dictionary.TryGetValue("subject-name", out str2))
                        {
                            strArray[i] = str2;
                        }
                        else
                        {
                            strArray[i] = str;
                        }
                    }
                    return strArray;
                }
            }
            catch (Failure)
            {
            }
            return null;
        }

        public static void UpdateDetails(string SID, Session session)
        {
            lock (sid_To_UserDetails)
            {
                sid_To_UserDetails.Remove(SID);
                sid_To_UserDetails.Add(SID, new UserDetails(session));
            }
        }

        public string[] GroupMembershipNames
        {
            get
            {
                return (this.groupMembershipNames ?? (this.groupMembershipNames = this.GetGroupMembershipNames(this._session)));
            }
        }

        public string[] GroupMembershipSids
        {
            get
            {
                return this.groupMembershipSids;
            }
        }

        public static Dictionary<string, UserDetails> Sid_To_UserDetails
        {
            get
            {
                lock (sid_To_UserDetails)
                {
                    return sid_To_UserDetails;
                }
            }
        }

        public string UserDisplayName
        {
            get
            {
                return this.userDisplayName;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
        }

        public string UserSid
        {
            get
            {
                return this.userSid;
            }
        }
    }
}

