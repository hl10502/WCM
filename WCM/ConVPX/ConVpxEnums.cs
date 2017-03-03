namespace WCM.ConVPX
{
    using System;
    using System.Reflection;

    public static class ConVpxEnums
    {
        public static string GetDisplayText<TEnum>(TEnum value)
        {
            Type type = typeof(TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException("TEnum is not an enum.", "TEnum");
            }
            uint num = Convert.ToUInt32(value);
            foreach (FieldInfo info in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
            {
                object obj2 = info.GetValue(null);
                uint num2 = Convert.ToUInt32(obj2);
                if (num == num2)
                {
                    string str = Messages.ResourceManager.GetString("CONVPX_" + type.Name.ToUpper() + "_" + obj2.ToString().ToUpper());
                    //return (string.IsNullOrEmpty(str) ? obj2.ToString() : str);
					return (string.IsNullOrEmpty(str) ? "未知" : str);
                }
            }
            return value.ToString();
        }

        public enum JobState
        {
            Created,
            Queued,
            Running,
            Completed,
            Aborted,
            UserAborted,
            Incomplete
        }

        public enum VmState
        {
            Off,
            Running,
            Suspended
        }
    }
}

