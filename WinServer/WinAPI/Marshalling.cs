namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Marshalling
    {
        public static object convertStruct(Type t, Hashtable table)
        {
            return t.GetConstructor(new Type[] { typeof(Hashtable) }).Invoke(new object[] { table });
        }

        public static Type GetWinAPIType(string name)
        {
            return Type.GetType(string.Format("WinAPI.{0}", name), false, true);
        }

        public static bool ParseBool(Hashtable table, string key)
        {
            if (!table.ContainsKey(key))
            {
                return false;
            }
            return (bool) table[key];
        }

        public static DateTime ParseDateTime(Hashtable table, string key)
        {
            if (!table.ContainsKey(key))
            {
                return DateTime.MinValue;
            }
            return (DateTime) table[key];
        }

        public static double ParseDouble(Hashtable table, string key)
        {
            if (!table.ContainsKey(key))
            {
                return 0.0;
            }
            return (double) table[key];
        }

        public static Hashtable ParseHashTable(Hashtable table, string key)
        {
            if (!table.ContainsKey(key))
            {
                return null;
            }
            return (Hashtable) table[key];
        }

        public static long ParseLong(Hashtable table, string key)
        {
            string s = table.ContainsKey(key) ? ((string) table[key]) : null;
            if (s != null)
            {
                return long.Parse(s);
            }
            return 0L;
        }

        public static long[] ParseLongArray(Hashtable table, string key)
        {
            object[] array = table.ContainsKey(key) ? ((object[]) table[key]) : null;
            if (array == null)
            {
                return new long[0];
            }
            return Array.ConvertAll<object, long>(array, o => long.Parse(o.ToString()));
        }

        public static Dictionary<XenRef<T>, T> ParseMapRefRecord<T, U>(Hashtable table, string key) where T: XenObject<T>
        {
            Hashtable o = ParseHashTable(table, key);
            if (o != null)
            {
                return XenRef<T>.Create<U>(o);
            }
            return null;
        }

        public static XenRef<T> ParseRef<T>(Hashtable table, string key) where T: XenObject<T>
        {
            string opaqueRef = ParseString(table, key);
            if (opaqueRef != null)
            {
                return XenRef<T>.Create(opaqueRef);
            }
            return null;
        }

        public static List<XenRef<T>> ParseSetRef<T>(Hashtable table, string key) where T: XenObject<T>
        {
            string[] opaqueRefs = ParseStringArray(table, key);
            if (opaqueRefs != null)
            {
                return XenRef<T>.Create(opaqueRefs);
            }
            return null;
        }

        public static string ParseString(Hashtable table, string key)
        {
            if (!table.ContainsKey(key))
            {
                return null;
            }
            return (string) table[key];
        }

        public static string[] ParseStringArray(Hashtable table, string key)
        {
            object[] array = table.ContainsKey(key) ? ((object[]) table[key]) : null;
            if (array == null)
            {
                return new string[0];
            }
            return Array.ConvertAll<object, string>(array, o => o.ToString());
        }
    }
}

