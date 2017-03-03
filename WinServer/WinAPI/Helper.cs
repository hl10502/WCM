namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class Helper
    {
        public const string NullOpaqueRef = "OpaqueRef:NULL";

        internal static int APIVersionCompare(Session session, API_Version v)
        {
            return (int) (session.APIVersion - v);
        }

        internal static bool APIVersionMeets(Session session, API_Version v)
        {
            return (APIVersionCompare(session, v) >= 0);
        }

        public static string APIVersionString(API_Version v)
        {
            switch (v)
            {
                case API_Version.API_1_1:
                    return "1.1";

                case API_Version.API_1_2:
                    return "1.2";

                case API_Version.API_1_3:
                    return "1.3";

                case API_Version.API_1_4:
                    return "1.4";

                case API_Version.API_1_5:
                    return "1.5";

                case API_Version.API_1_6:
                    return "1.6";

                case API_Version.API_1_7:
                    return "1.7";

                case API_Version.API_1_8:
                    return "1.8";

                case API_Version.API_1_9:
                    return "1.9";

                case API_Version.API_1_10:
                    return "1.10";

                case API_Version.API_2_0:
                    return "2.0";

                case API_Version.API_2_1:
                    return "2.1";

                case API_Version.API_2_2:
                    return "2.2";

                case API_Version.API_2_3:
                    return "2.3";

                case API_Version.API_2_4:
                    return "2.4";

                case API_Version.API_2_5:
                    //return "2.5";
                    return "WS-2.0"; //兼容WinServer
            }
            return "Unknown";
        }

        private static bool AreCollectionsEqual(ICollection c1, ICollection c2)
        {
            if (c1.Count != c2.Count)
            {
                return false;
            }
            IEnumerator enumerator = c1.GetEnumerator();
            IEnumerator enumerator2 = c2.GetEnumerator();
            while (enumerator.MoveNext() && enumerator2.MoveNext())
            {
                if (!AreEqual(enumerator.Current, enumerator2.Current))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool AreDictEqual(IDictionary d1, IDictionary d2)
        {
            if (d1.Count != d2.Count)
            {
                return false;
            }
            foreach (object obj2 in d1.Keys)
            {
                if (!d2.Contains(obj2) || !AreEqual(d2[obj2], d1[obj2]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreEqual(object o1, object o2)
        {
            if ((o1 == null) && (o2 == null))
            {
                return true;
            }
            if ((o1 == null) || (o2 == null))
            {
                return false;
            }
            if (o1 is IDictionary)
            {
                return AreDictEqual((IDictionary) o1, (IDictionary) o2);
            }
            if (o1 is ICollection)
            {
                return AreCollectionsEqual((ICollection) o1, (ICollection) o2);
            }
            return o1.Equals(o2);
        }

        public static bool AreEqual2<T>(T o1, T o2)
        {
            if ((o1 == null) && (o2 == null))
            {
                return true;
            }
            if ((o1 == null) || (o2 == null))
            {
                return (((o1 == null) && IsEmptyCollection(o2)) || ((o2 == null) && IsEmptyCollection(o1)));
            }
            if (typeof(T) is IDictionary)
            {
                return AreDictEqual((IDictionary) o1, (IDictionary) o2);
            }
            if (typeof(T) is ICollection)
            {
                return AreCollectionsEqual((ICollection) o1, (ICollection) o2);
            }
            return o1.Equals(o2);
        }

        public static bool DictEquals<K, V>(Dictionary<K, V> d1, Dictionary<K, V> d2)
        {
            if ((d1 != null) || (d2 != null))
            {
                if ((d1 == null) || (d2 == null))
                {
                    return false;
                }
                if (d1.Count != d2.Count)
                {
                    return false;
                }
                foreach (K local in d1.Keys)
                {
                    if (!d2.ContainsKey(local) || !EqualOrEquallyNull(d2[local], d1[local]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        internal static object EnumParseDefault(Type t, string s)
        {
            object obj2;
            try
            {
                obj2 = Enum.Parse(t, (s == null) ? null : s.Replace('-', '_'));
            }
            catch (ArgumentException)
            {
                try
                {
                    obj2 = Enum.Parse(t, "unknown");
                }
                catch (ArgumentException)
                {
                    try
                    {
                        obj2 = Enum.Parse(t, "Unknown");
                    }
                    catch (ArgumentException)
                    {
                        obj2 = 0;
                    }
                }
            }
            return obj2;
        }

        internal static bool EqualOrEquallyNull(object o1, object o2)
        {
            if (o1 != null)
            {
                return o1.Equals(o2);
            }
            return (o2 == null);
        }

        public static API_Version GetAPIVersion(string version)
        {
            if (version != null)
            {
                int num;
                int num2;
                string[] strArray = version.Split(new char[] { '.' });
                if (((strArray.Length == 2) && int.TryParse(strArray[0], out num)) && int.TryParse(strArray[1], out num2))
                {
                    return GetAPIVersion((long) num, (long) num2);
                }
            }
            return API_Version.UNKNOWN;
        }

        public static API_Version GetAPIVersion(long major, long minor)
        {
            try
            {
                return (API_Version) Enum.Parse(typeof(API_Version), string.Format("API_{0}_{1}", major, minor));
            }
            catch (ArgumentException)
            {
                return API_Version.UNKNOWN;
            }
        }

        private static bool IsEmptyCollection(object obj)
        {
            ICollection is2 = obj as ICollection;
            return ((is2 != null) && (is2.Count == 0));
        }

        public static bool IsNullOrEmptyOpaqueRef(string opaqueRef)
        {
            if (!string.IsNullOrEmpty(opaqueRef))
            {
                return (string.Compare(opaqueRef, "OpaqueRef:NULL", true) == 0);
            }
            return true;
        }

        internal static string[] LongArrayToStringArray(long[] input)
        {
            string[] strArray = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    strArray[i] = input[i].ToString();
                }
                catch (ArgumentException)
                {
                }
            }
            return strArray;
        }

        internal static List<T> ObjectArrayToEnumList<T>(object[] input)
        {
            List<T> list = new List<T>();
            foreach (object obj2 in input)
            {
                try
                {
                    list.Add((T) Enum.Parse(typeof(T), obj2.ToString()));
                }
                catch (ArgumentException)
                {
                }
            }
            return list;
        }

        internal static string[] ObjectListToStringArray<T>(List<T> list)
        {
            string[] strArray = new string[list.Count];
            int num = 0;
            foreach (T local in list)
            {
                strArray[num++] = local.ToString();
            }
            return strArray;
        }

        internal static List<Data_source> Proxy_Data_sourceArrayToData_sourceList(Proxy_Data_source[] input)
        {
            List<Data_source> list = new List<Data_source>();
            foreach (Proxy_Data_source _source in input)
            {
                list.Add(new Data_source(_source));
            }
            return list;
        }

        internal static List<Message> Proxy_MessageArrayToMessageList(Proxy_Message[] input)
        {
            List<Message> list = new List<Message>();
            foreach (Proxy_Message message in input)
            {
                list.Add(new Message(message));
            }
            return list;
        }

        internal static string[] RefListToStringArray<T>(List<XenRef<T>> opaqueRefs) where T: XenObject<T>
        {
            string[] strArray = new string[opaqueRefs.Count];
            int num = 0;
            foreach (XenRef<T> ref2 in opaqueRefs)
            {
                strArray[num++] = ref2.opaque_ref;
            }
            return strArray;
        }

        internal static List<T> StringArrayToEnumList<T>(string[] input)
        {
            List<T> list = new List<T>();
            foreach (string str in input)
            {
                try
                {
                    list.Add((T) Enum.Parse(typeof(T), str));
                }
                catch (ArgumentException)
                {
                }
            }
            return list;
        }

        internal static long[] StringArrayToLongArray(string[] input)
        {
            long[] numArray = new long[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    numArray[i] = long.Parse(input[i]);
                }
                catch (ArgumentException)
                {
                }
            }
            return numArray;
        }
    }
}

