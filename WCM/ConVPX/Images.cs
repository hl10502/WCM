namespace WCM.ConVPX
{
    using ExportImport.CommonTypes;
    using WCM.ConVPX.Model;
    using WCM.ConVPX.Properties;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using WinAPI;

    internal class Images
    {
        public static readonly ImageList ImageList16 = new ImageList();

        static Images()
        {
            ImageList16.ColorDepth = ColorDepth.Depth32Bit;
            ImageList16.TransparentColor = Color.Transparent;
            LoadImageList16();
        }

        public static Icons GetIconFor(VmInstance vm)
        {
            if (vm.Template)
            {
                return Icons.VM_Template;
            }
            if (vm.PowerState == 0)
            {
                return Icons.VM_Off;
            }
            if (vm.PowerState == 1)
            {
                return Icons.VM_Running;
            }
            if (vm.PowerState == 2)
            {
                return Icons.VM_Suspended;
            }
            return Icons.VM_Default;
        }

        public static Icons GetIconFor(ConVpxJobInfo job)
        {
            if (job.State == 1)
            {
                return Icons.JobStateQueued;
            }
            if (job.State == 2)
            {
                return Icons.JobStateRunning;
            }
            if (job.State == 3)
            {
                return Icons.JobStateCompleted;
            }
            if (job.State == 6)
            {
                return Icons.JobStateIncomplete;
            }
            if (job.State == 4)
            {
                return Icons.JobStateAborted;
            }
            if (job.State == 5)
            {
                return Icons.JobStateUserAborted;
            }
            return Icons.JobStateDefault;
        }

        public static Icons GetIconFor(object o)
        {
            if (o is VmInstance)
            {
                return GetIconFor((VmInstance) o);
            }
            if (o is WinAPI.SR)
            {
                return GetIconFor((WinAPI.SR) o);
            }
            if (o is ConVpxJobInfo)
            {
                return GetIconFor((ConVpxJobInfo) o);
            }
            return Icons.VM_Default;
        }

        public static Icons GetIconFor(WinAPI.SR sr)
        {
            return Icons.SR_Default;
        }

        public static Image GetImage16For(object o)
        {
            Icons iconFor = GetIconFor(o);
            return ImageList16.Images[(int) iconFor];
        }

        public static int GetImageIndex16For(object o)
        {
            int num = 1;
            if (o is VmInstance)
            {
                VmInstance instance = (VmInstance) o;
                if (instance.Template)
                {
                    return 13;
                }
                if (instance.PowerState == 0)
                {
                    return 2;
                }
                if (instance.PowerState == 1)
                {
                    return 3;
                }
                if (instance.PowerState == 2)
                {
                    num = 4;
                }
                return num;
            }
            if (o is WinAPI.SR)
            {
                return 5;
            }
            if (o is ConVpxJobInfo)
            {
                num = 6;
                ConVpxJobInfo info = (ConVpxJobInfo) o;
                if (info.State == 1)
                {
                    return 7;
                }
                if (info.State == 2)
                {
                    return 8;
                }
                if (info.State == 3)
                {
                    return 9;
                }
                if (info.State == 6)
                {
                    return 10;
                }
                if (info.State == 4)
                {
                    return 11;
                }
                if (info.State == 5)
                {
                    num = 12;
                }
            }
            return num;
        }

        public static Image GetProgressImage(long p)
        {
            long num = p;
            if ((num <= 10L) && (num >= 1L))
            {
                switch (((int) (num - 1L)))
                {
                    case 0:
                        return Resources.usagebar_1;

                    case 1:
                        return Resources.usagebar_2;

                    case 2:
                        return Resources.usagebar_3;

                    case 3:
                        return Resources.usagebar_4;

                    case 4:
                        return Resources.usagebar_5;

                    case 5:
                        return Resources.usagebar_6;

                    case 6:
                        return Resources.usagebar_7;

                    case 7:
                        return Resources.usagebar_8;

                    case 8:
                        return Resources.usagebar_9;

                    case 9:
                        return Resources.usagebar_10;
                }
            }
            return Resources.usagebar_0;
        }

        private static void LoadImageList16()
        {
            ImageList16.Images.Add("transparent_16.png", Resources.transparent_16);
            ImageList16.Images.Add("virtual_machine_16.png", Resources.virtual_machine_16);
            ImageList16.Images.Add("virtual_machine_off_16.png", Resources.virtual_machine_off_16);
            ImageList16.Images.Add("virtual_machine_running_16.png", Resources.virtual_machine_running_16);
            ImageList16.Images.Add("virtual_machine_suspended_16.png", Resources.virtual_machine_suspended_16);
            ImageList16.Images.Add("000_Storage_h32bit_16.png", Resources._000_Storage_h32bit_16);
            ImageList16.Images.Add("job_status_default_16.png", Resources.job_status_default_16);
            ImageList16.Images.Add("job_status_queued_16.png", Resources.job_status_queued_16);
            ImageList16.Images.Add("job_status_running_16.png", Resources.job_status_running_16);
            ImageList16.Images.Add("job_status_complete_16.png", Resources.job_status_complete_16);
            ImageList16.Images.Add("job_status_warn_16.png", Resources.job_status_warn_16);
            ImageList16.Images.Add("job_status_failed_16.png", Resources.job_status_failed_16);
            ImageList16.Images.Add("job_status_canceled_16.png", Resources.job_status_canceled_16);
            ImageList16.Images.Add("vm_template_16.png", Resources.vm_template_16);
        }
    }
}

