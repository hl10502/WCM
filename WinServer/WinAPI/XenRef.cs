namespace WinAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class XenRef<T> where T: XenObject<T>
    {
        private readonly string opaqueRef;

        public XenRef(string opaqueRef)
        {
            Trace.Assert(opaqueRef != null, "'opaqueRef' parameter must not be null");
            this.opaqueRef = opaqueRef;
        }

        public XenRef(T obj) : this(obj.opaque_ref)
        {
        }

        public static Dictionary<XenRef<T>, T> Create<S>(object o)
        {
            if (o == null)
            {
                throw new ArgumentNullException("o");
            }
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<T>, T> dictionary = new Dictionary<XenRef<T>, T>();
            foreach (object obj2 in hashtable.Keys)
            {
                XenRef<T> ref2 = new XenRef<T>((string) obj2);
                Hashtable table = (Hashtable) hashtable[obj2];
                dictionary[ref2] = (T) Marshalling.convertStruct(typeof(T), table);
            }
            return dictionary;
        }

        public static List<XenRef<T>> Create(object[] opaqueRefs)
        {
            List<XenRef<T>> list = new List<XenRef<T>>(opaqueRefs.Length);
            foreach (object obj2 in opaqueRefs)
            {
                list.Add(new XenRef<T>(obj2.ToString()));
            }
            return list;
        }

        public static List<XenRef<T>> Create(string[] opaqueRefs)
        {
            List<XenRef<T>> list = new List<XenRef<T>>(opaqueRefs.Length);
            foreach (string str in opaqueRefs)
            {
                list.Add(new XenRef<T>(str));
            }
            return list;
        }

        public static XenRef<T> Create(object opaqueRef)
        {
            return XenRef<T>.Create((string) opaqueRef);
        }

        public static XenRef<T> Create(string opaqueRef)
        {
            return new XenRef<T>(opaqueRef);
        }

        public override bool Equals(object obj)
        {
            XenRef<T> ref2 = obj as XenRef<T>;
            if (ref2 == null)
            {
                return false;
            }
            return this.opaqueRef.Equals(ref2.opaqueRef);
        }

        public override int GetHashCode()
        {
            return this.opaqueRef.GetHashCode();
        }

        public static implicit operator string(XenRef<T> xenRef)
        {
            if (xenRef != null)
            {
                return xenRef.opaque_ref;
            }
            return null;
        }

        public string opaque_ref
        {
            get
            {
                return this.opaqueRef;
            }
        }
    }
}

