namespace WinAPI
{
    using CookComputing.XmlRpc;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class Maps
    {
        internal static Dictionary<long, double> convert_from_proxy_long_double(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<long, double> dictionary = new Dictionary<long, double>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        long num = long.Parse(str);
                        double num2 = Convert.ToDouble(hashtable[str]);
                        dictionary[num] = num2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<long, long> convert_from_proxy_long_long(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<long, long> dictionary = new Dictionary<long, long>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        long num = long.Parse(str);
                        long num2 = (hashtable[str] == null) ? 0L : long.Parse((string) hashtable[str]);
                        dictionary[num] = num2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<long, string[]> convert_from_proxy_long_string_array(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<long, string[]> dictionary = new Dictionary<long, string[]>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        long num = long.Parse(str);
                        string[] strArray = (hashtable[str] == null) ? new string[0] : Array.ConvertAll<object, string>((object[]) hashtable[str], new Converter<object, string>(Convert.ToString));
                        dictionary[num] = strArray;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, host_allowed_operations> convert_from_proxy_string_host_allowed_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, host_allowed_operations> dictionary = new Dictionary<string, host_allowed_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        host_allowed_operations _operations = (hashtable[str] == null) ? host_allowed_operations.provision : ((host_allowed_operations) Helper.EnumParseDefault(typeof(host_allowed_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, long> convert_from_proxy_string_long(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        long num = (hashtable[str] == null) ? 0L : long.Parse((string) hashtable[str]);
                        dictionary[str2] = num;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, network_operations> convert_from_proxy_string_network_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, network_operations> dictionary = new Dictionary<string, network_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        network_operations _operations = (hashtable[str] == null) ? network_operations.attaching : ((network_operations) Helper.EnumParseDefault(typeof(network_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, pool_allowed_operations> convert_from_proxy_string_pool_allowed_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, pool_allowed_operations> dictionary = new Dictionary<string, pool_allowed_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        pool_allowed_operations _operations = (hashtable[str] == null) ? pool_allowed_operations.ha_enable : ((pool_allowed_operations) Helper.EnumParseDefault(typeof(pool_allowed_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, storage_operations> convert_from_proxy_string_storage_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, storage_operations> dictionary = new Dictionary<string, storage_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        storage_operations _operations = (hashtable[str] == null) ? storage_operations.scan : ((storage_operations) Helper.EnumParseDefault(typeof(storage_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, string> convert_from_proxy_string_string(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        string str3 = (hashtable[str] == null) ? null : ((string) hashtable[str]);
                        dictionary[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, task_allowed_operations> convert_from_proxy_string_task_allowed_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, task_allowed_operations> dictionary = new Dictionary<string, task_allowed_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        task_allowed_operations _operations = (hashtable[str] == null) ? task_allowed_operations.cancel : ((task_allowed_operations) Helper.EnumParseDefault(typeof(task_allowed_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, vbd_operations> convert_from_proxy_string_vbd_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, vbd_operations> dictionary = new Dictionary<string, vbd_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        vbd_operations _operations = (hashtable[str] == null) ? vbd_operations.attach : ((vbd_operations) Helper.EnumParseDefault(typeof(vbd_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, vdi_operations> convert_from_proxy_string_vdi_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, vdi_operations> dictionary = new Dictionary<string, vdi_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        vdi_operations _operations = (hashtable[str] == null) ? vdi_operations.scan : ((vdi_operations) Helper.EnumParseDefault(typeof(vdi_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, vif_operations> convert_from_proxy_string_vif_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, vif_operations> dictionary = new Dictionary<string, vif_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        vif_operations _operations = (hashtable[str] == null) ? vif_operations.attach : ((vif_operations) Helper.EnumParseDefault(typeof(vif_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, vm_appliance_operation> convert_from_proxy_string_vm_appliance_operation(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, vm_appliance_operation> dictionary = new Dictionary<string, vm_appliance_operation>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        vm_appliance_operation _operation = (hashtable[str] == null) ? vm_appliance_operation.start : ((vm_appliance_operation) Helper.EnumParseDefault(typeof(vm_appliance_operation), (string) hashtable[str]));
                        dictionary[str2] = _operation;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, vm_operations> convert_from_proxy_string_vm_operations(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, vm_operations> dictionary = new Dictionary<string, vm_operations>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        vm_operations _operations = (hashtable[str] == null) ? vm_operations.snapshot : ((vm_operations) Helper.EnumParseDefault(typeof(vm_operations), (string) hashtable[str]));
                        dictionary[str2] = _operations;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<string, XenRef<Blob>> convert_from_proxy_string_XenRefBlob(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<string, XenRef<Blob>> dictionary = new Dictionary<string, XenRef<Blob>>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        string str2 = str;
                        XenRef<Blob> ref2 = (hashtable[str] == null) ? null : XenRef<Blob>.Create(hashtable[str]);
                        dictionary[str2] = ref2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<vm_operations, string> convert_from_proxy_vm_operations_string(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<vm_operations, string> dictionary = new Dictionary<vm_operations, string>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        vm_operations _operations = (vm_operations) Helper.EnumParseDefault(typeof(vm_operations), str);
                        string str2 = (hashtable[str] == null) ? null : ((string) hashtable[str]);
                        dictionary[_operations] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<Host>, string[]> convert_from_proxy_XenRefHost_string_array(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<Host>, string[]> dictionary = new Dictionary<XenRef<Host>, string[]>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<Host> ref2 = XenRef<Host>.Create(str);
                        string[] strArray = (hashtable[str] == null) ? new string[0] : Array.ConvertAll<object, string>((object[]) hashtable[str], new Converter<object, string>(Convert.ToString));
                        dictionary[ref2] = strArray;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VDI>, XenRef<WinAPI.SR>> convert_from_proxy_XenRefVDI_XenRefSR(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VDI>, XenRef<WinAPI.SR>> dictionary = new Dictionary<XenRef<VDI>, XenRef<WinAPI.SR>>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VDI> ref2 = XenRef<VDI>.Create(str);
                        XenRef<WinAPI.SR> ref3 = (hashtable[str] == null) ? null : XenRef<WinAPI.SR>.Create(hashtable[str]);
                        dictionary[ref2] = ref3;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VGPU_type>, long> convert_from_proxy_XenRefVGPU_type_long(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VGPU_type>, long> dictionary = new Dictionary<XenRef<VGPU_type>, long>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VGPU_type> ref2 = XenRef<VGPU_type>.Create(str);
                        long num = (hashtable[str] == null) ? 0L : long.Parse((string) hashtable[str]);
                        dictionary[ref2] = num;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VIF>, string> convert_from_proxy_XenRefVIF_string(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VIF>, string> dictionary = new Dictionary<XenRef<VIF>, string>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VIF> ref2 = XenRef<VIF>.Create(str);
                        string str2 = (hashtable[str] == null) ? null : ((string) hashtable[str]);
                        dictionary[ref2] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VIF>, XenRef<Network>> convert_from_proxy_XenRefVIF_XenRefNetwork(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VIF>, XenRef<Network>> dictionary = new Dictionary<XenRef<VIF>, XenRef<Network>>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VIF> ref2 = XenRef<VIF>.Create(str);
                        XenRef<Network> ref3 = (hashtable[str] == null) ? null : XenRef<Network>.Create(hashtable[str]);
                        dictionary[ref2] = ref3;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VM>, Dictionary<string, string>> convert_from_proxy_XenRefVM_Dictionary_string_string(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VM>, Dictionary<string, string>> dictionary = new Dictionary<XenRef<VM>, Dictionary<string, string>>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VM> ref2 = XenRef<VM>.Create(str);
                        Dictionary<string, string> dictionary2 = (hashtable[str] == null) ? null : convert_from_proxy_string_string(hashtable[str]);
                        dictionary[ref2] = dictionary2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VM>, string> convert_from_proxy_XenRefVM_string(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VM>, string> dictionary = new Dictionary<XenRef<VM>, string>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VM> ref2 = XenRef<VM>.Create(str);
                        string str2 = (hashtable[str] == null) ? null : ((string) hashtable[str]);
                        dictionary[ref2] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Dictionary<XenRef<VM>, string[]> convert_from_proxy_XenRefVM_string_array(object o)
        {
            Hashtable hashtable = (Hashtable) o;
            Dictionary<XenRef<VM>, string[]> dictionary = new Dictionary<XenRef<VM>, string[]>();
            if (hashtable != null)
            {
                foreach (string str in hashtable.Keys)
                {
                    try
                    {
                        XenRef<VM> ref2 = XenRef<VM>.Create(str);
                        string[] strArray = (hashtable[str] == null) ? new string[0] : Array.ConvertAll<object, string>((object[]) hashtable[str], new Converter<object, string>(Convert.ToString));
                        dictionary[ref2] = strArray;
                    }
                    catch
                    {
                    }
                }
            }
            return dictionary;
        }

        internal static Hashtable convert_to_proxy_long_double(Dictionary<long, double> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (long num in table.Keys)
                {
                    try
                    {
                        string str = num.ToString();
                        double num2 = table[num];
                        struct2[str] = num2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_long_long(Dictionary<long, long> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (long num in table.Keys)
                {
                    try
                    {
                        string str = num.ToString();
                        string str2 = table[num].ToString();
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_long_string_array(Dictionary<long, string[]> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (long num in table.Keys)
                {
                    try
                    {
                        string str = num.ToString();
                        string[] strArray = table[num];
                        struct2[str] = strArray;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_host_allowed_operations(Dictionary<string, host_allowed_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = host_allowed_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_long(Dictionary<string, long> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = table[str].ToString();
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_network_operations(Dictionary<string, network_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = network_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_pool_allowed_operations(Dictionary<string, pool_allowed_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = pool_allowed_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_storage_operations(Dictionary<string, storage_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = storage_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_string(Dictionary<string, string> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = (table[str] != null) ? table[str] : "";
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_task_allowed_operations(Dictionary<string, task_allowed_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = task_allowed_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_vbd_operations(Dictionary<string, vbd_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = vbd_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_vdi_operations(Dictionary<string, vdi_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = vdi_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_vif_operations(Dictionary<string, vif_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = vif_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_vm_appliance_operation(Dictionary<string, vm_appliance_operation> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = vm_appliance_operation_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_vm_operations(Dictionary<string, vm_operations> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = vm_operations_helper.ToString(table[str]);
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_string_XenRefBlob(Dictionary<string, XenRef<Blob>> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (string str in table.Keys)
                {
                    try
                    {
                        string str2 = (str != null) ? str : "";
                        string str3 = (table[str] != null) ? ((string) table[str]) : "";
                        struct2[str2] = str3;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_vm_operations_string(Dictionary<vm_operations, string> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (vm_operations _operations in table.Keys)
                {
                    try
                    {
                        string str = vm_operations_helper.ToString(_operations);
                        string str2 = (table[_operations] != null) ? table[_operations] : "";
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefHost_string_array(Dictionary<XenRef<Host>, string[]> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<Host> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string[] strArray = table[ref2];
                        struct2[str] = strArray;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVDI_XenRefSR(Dictionary<XenRef<VDI>, XenRef<WinAPI.SR>> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VDI> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string str2 = (table[ref2] != null) ? ((string) table[ref2]) : "";
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVGPU_type_long(Dictionary<XenRef<VGPU_type>, long> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VGPU_type> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string str2 = table[ref2].ToString();
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVIF_string(Dictionary<XenRef<VIF>, string> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VIF> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string str2 = (table[ref2] != null) ? table[ref2] : "";
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVIF_XenRefNetwork(Dictionary<XenRef<VIF>, XenRef<Network>> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VIF> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string str2 = (table[ref2] != null) ? ((string) table[ref2]) : "";
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVM_Dictionary_string_string(Dictionary<XenRef<VM>, Dictionary<string, string>> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VM> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        object obj2 = convert_to_proxy_string_string(table[ref2]);
                        struct2[str] = obj2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVM_string(Dictionary<XenRef<VM>, string> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VM> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string str2 = (table[ref2] != null) ? table[ref2] : "";
                        struct2[str] = str2;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }

        internal static Hashtable convert_to_proxy_XenRefVM_string_array(Dictionary<XenRef<VM>, string[]> table)
        {
            XmlRpcStruct struct2 = new XmlRpcStruct();
            if (table != null)
            {
                foreach (XenRef<VM> ref2 in table.Keys)
                {
                    try
                    {
                        string str = (ref2 != null) ? ((string) ref2) : "";
                        string[] strArray = table[ref2];
                        struct2[str] = strArray;
                    }
                    catch
                    {
                    }
                }
            }
            return struct2;
        }
    }
}

