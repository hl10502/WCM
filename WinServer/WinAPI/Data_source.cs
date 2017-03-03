namespace WinAPI
{
    using System;
    using System.Collections;

    public class Data_source : XenObject<Data_source>
    {
        private bool _enabled;
        private double _max;
        private double _min;
        private string _name_description;
        private string _name_label;
        private bool _standard;
        private string _units;
        private double _value;

        public Data_source()
        {
        }

        public Data_source(Hashtable table)
        {
            this.name_label = Marshalling.ParseString(table, "name_label");
            this.name_description = Marshalling.ParseString(table, "name_description");
            this.enabled = Marshalling.ParseBool(table, "enabled");
            this.standard = Marshalling.ParseBool(table, "standard");
            this.units = Marshalling.ParseString(table, "units");
            this.min = Marshalling.ParseDouble(table, "min");
            this.max = Marshalling.ParseDouble(table, "max");
            this.value = Marshalling.ParseDouble(table, "value");
        }

        public Data_source(Proxy_Data_source proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public Data_source(string name_label, string name_description, bool enabled, bool standard, string units, double min, double max, double value)
        {
            this.name_label = name_label;
            this.name_description = name_description;
            this.enabled = enabled;
            this.standard = standard;
            this.units = units;
            this.min = min;
            this.max = max;
            this.value = value;
        }

        public bool DeepEquals(Data_source other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || ((((Helper.AreEqual2<string>(this._name_label, other._name_label) && Helper.AreEqual2<string>(this._name_description, other._name_description)) && (Helper.AreEqual2<bool>(this._enabled, other._enabled) && Helper.AreEqual2<bool>(this._standard, other._standard))) && ((Helper.AreEqual2<string>(this._units, other._units) && Helper.AreEqual2<double>(this._min, other._min)) && Helper.AreEqual2<double>(this._max, other._max))) && Helper.AreEqual2<double>(this._value, other._value)));
        }

        public override string SaveChanges(Session session, string opaqueRef, Data_source server)
        {
            if (opaqueRef != null)
            {
                throw new InvalidOperationException("This type has no read/write properties");
            }
            return "";
        }

        public Proxy_Data_source ToProxy()
        {
            return new Proxy_Data_source { name_label = (this.name_label != null) ? this.name_label : "", name_description = (this.name_description != null) ? this.name_description : "", enabled = this.enabled, standard = this.standard, units = (this.units != null) ? this.units : "", min = this.min, max = this.max, value = this.value };
        }

        public override void UpdateFrom(Data_source update)
        {
            this.name_label = update.name_label;
            this.name_description = update.name_description;
            this.enabled = update.enabled;
            this.standard = update.standard;
            this.units = update.units;
            this.min = update.min;
            this.max = update.max;
            this.value = update.value;
        }

        internal void UpdateFromProxy(Proxy_Data_source proxy)
        {
            this.name_label = (proxy.name_label == null) ? null : proxy.name_label;
            this.name_description = (proxy.name_description == null) ? null : proxy.name_description;
            this.enabled = proxy.enabled;
            this.standard = proxy.standard;
            this.units = (proxy.units == null) ? null : proxy.units;
            this.min = Convert.ToDouble(proxy.min);
            this.max = Convert.ToDouble(proxy.max);
            this.value = Convert.ToDouble(proxy.value);
        }

        public virtual bool enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                if (!Helper.AreEqual(value, this._enabled))
                {
                    this._enabled = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("enabled");
                }
            }
        }

        public virtual double max
        {
            get
            {
                return this._max;
            }
            set
            {
                if (!Helper.AreEqual(value, this._max))
                {
                    this._max = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("max");
                }
            }
        }

        public virtual double min
        {
            get
            {
                return this._min;
            }
            set
            {
                if (!Helper.AreEqual(value, this._min))
                {
                    this._min = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("min");
                }
            }
        }

        public virtual string name_description
        {
            get
            {
                return this._name_description;
            }
            set
            {
                if (!Helper.AreEqual(value, this._name_description))
                {
                    this._name_description = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("name_description");
                }
            }
        }

        public virtual string name_label
        {
            get
            {
                return this._name_label;
            }
            set
            {
                if (!Helper.AreEqual(value, this._name_label))
                {
                    this._name_label = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("name_label");
                }
            }
        }

        public virtual bool standard
        {
            get
            {
                return this._standard;
            }
            set
            {
                if (!Helper.AreEqual(value, this._standard))
                {
                    this._standard = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("standard");
                }
            }
        }

        public virtual string units
        {
            get
            {
                return this._units;
            }
            set
            {
                if (!Helper.AreEqual(value, this._units))
                {
                    this._units = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("units");
                }
            }
        }

        public virtual double value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (!Helper.AreEqual(value, this._value))
                {
                    this._value = value;
                    base.Changed = true;
                    base.NotifyPropertyChanged("value");
                }
            }
        }
    }
}

