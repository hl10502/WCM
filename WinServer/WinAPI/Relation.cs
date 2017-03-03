namespace WinAPI
{
    using System;
    using System.Collections.Generic;

    public class Relation
    {
        public readonly string field;
        public readonly string manyField;
        public readonly string manyType;

        public Relation(string field, string manyType, string manyField)
        {
            this.field = field;
            this.manyField = manyField;
            this.manyType = manyType;
        }

        public static Dictionary<Type, Relation[]> GetRelations()
        {
            Dictionary<Type, Relation[]> dictionary = new Dictionary<Type, Relation[]>();
            dictionary.Add(typeof(Proxy_Pool), new Relation[] { new Relation("metadata_VDIs", "VDI", "metadata_of_pool") });
            dictionary.Add(typeof(Proxy_SR), new Relation[] { new Relation("VDIs", "VDI", "SR"), new Relation("PBDs", "PBD", "SR") });
            dictionary.Add(typeof(Proxy_GPU_group), new Relation[] { new Relation("VGPUs", "VGPU", "GPU_group"), new Relation("PGPUs", "PGPU", "GPU_group") });
            dictionary.Add(typeof(Proxy_Session), new Relation[] { new Relation("tasks", "task", "session") });
            dictionary.Add(typeof(Proxy_Subject), new Relation[] { new Relation("roles", "subject", "roles") });
            dictionary.Add(typeof(Proxy_Bond), new Relation[] { new Relation("slaves", "PIF", "bond_slave_of") });
            dictionary.Add(typeof(Proxy_Role), new Relation[] { new Relation("subroles", "role", "subroles") });
            dictionary.Add(typeof(Proxy_Pool_patch), new Relation[] { new Relation("host_patches", "host_patch", "pool_patch") });
            dictionary.Add(typeof(Proxy_VM_appliance), new Relation[] { new Relation("VMs", "VM", "appliance") });
            dictionary.Add(typeof(Proxy_PIF), new Relation[] { new Relation("tunnel_transport_PIF_of", "tunnel", "transport_PIF"), new Relation("tunnel_access_PIF_of", "tunnel", "access_PIF"), new Relation("VLAN_slave_of", "VLAN", "tagged_PIF"), new Relation("bond_master_of", "Bond", "master") });
            dictionary.Add(typeof(Proxy_DR_task), new Relation[] { new Relation("introduced_SRs", "SR", "introduced_by") });
            dictionary.Add(typeof(Proxy_Network), new Relation[] { new Relation("PIFs", "PIF", "network"), new Relation("VIFs", "VIF", "network") });
            dictionary.Add(typeof(Proxy_Task), new Relation[] { new Relation("subtasks", "task", "subtask_of") });
            dictionary.Add(typeof(Proxy_PGPU), new Relation[] { new Relation("resident_VGPUs", "VGPU", "resident_on") });
            dictionary.Add(typeof(Proxy_VGPU_type), new Relation[] { new Relation("enabled_on_GPU_groups", "GPU_group", "enabled_VGPU_types"), new Relation("supported_on_GPU_groups", "GPU_group", "supported_VGPU_types"), new Relation("enabled_on_PGPUs", "PGPU", "enabled_VGPU_types"), new Relation("supported_on_PGPUs", "PGPU", "supported_VGPU_types"), new Relation("VGPUs", "VGPU", "type") });
            dictionary.Add(typeof(Proxy_VDI), new Relation[] { new Relation("crash_dumps", "crashdump", "VDI"), new Relation("VBDs", "VBD", "VDI"), new Relation("snapshots", "VDI", "snapshot_of") });
            dictionary.Add(typeof(Proxy_VMPP), new Relation[] { new Relation("VMs", "VM", "protection_policy") });
            dictionary.Add(typeof(Proxy_VM), new Relation[] { new Relation("attached_PCIs", "PCI", "attached_VMs"), new Relation("VGPUs", "VGPU", "VM"), new Relation("consoles", "console", "VM"), new Relation("VTPMs", "VTPM", "VM"), new Relation("VIFs", "VIF", "VM"), new Relation("crash_dumps", "crashdump", "VM"), new Relation("VBDs", "VBD", "VM"), new Relation("children", "VM", "parent"), new Relation("snapshots", "VM", "snapshot_of") });
            dictionary.Add(typeof(Proxy_Host), new Relation[] { new Relation("PGPUs", "PGPU", "host"), new Relation("PCIs", "PCI", "host"), new Relation("patches", "host_patch", "host"), new Relation("crashdumps", "host_crashdump", "host"), new Relation("host_CPUs", "host_cpu", "host"), new Relation("resident_VMs", "VM", "resident_on"), new Relation("PIFs", "PIF", "host"), new Relation("PBDs", "PBD", "host") });
            return dictionary;
        }
    }
}

