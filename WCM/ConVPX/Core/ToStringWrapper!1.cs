namespace ConVPX.Core
{
    using System;
    using System.Diagnostics;

    public class ToStringWrapper<T> : IComparable<ToStringWrapper<T>>
    {
        public const string DisplayMember = "ToStringProperty";
        public readonly T item;
        private readonly string toString;
        private readonly ToStringDelegate<T> toStringDelegate;
        public const string ValueMember = "Self";

        public ToStringWrapper(T item, string toString)
        {
            this.item = item;
            this.toString = toString;
        }

        public ToStringWrapper(T item, ToStringDelegate<T> toStringDelegate)
        {
            this.item = item;
            this.toStringDelegate = toStringDelegate;
        }

        public int CompareTo(ToStringWrapper<T> other)
        {
            if (this.item is IComparable<T>)
            {
                return (this.item as IComparable<T>).CompareTo(other.item);
            }
            return Helpers.NaturalCompare(this.ToString(), other.ToString());
        }

        public override string ToString()
        {
            Trace.Assert((this.toString == null) ^ (this.toStringDelegate == null));
            if (this.toStringDelegate != null)
            {
                return this.toStringDelegate(this.item);
            }
            return this.toString;
        }

        public ToStringWrapper<T> Self
        {
            get
            {
                return (ToStringWrapper<T>) this;
            }
        }

        public string ToStringProperty
        {
            get
            {
                return this.ToString();
            }
        }
    }
}

