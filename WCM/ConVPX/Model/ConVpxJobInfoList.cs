namespace WCM.ConVPX.Model
{
    using ExportImport.CommonTypes;
    using System;
    using System.Collections.Generic;

    public class ConVpxJobInfoList : List<ConVpxJobInfo>
    {
        public ConVpxJobInfoList()
        {
        }

        public ConVpxJobInfoList(JobInstance[] jobs)
        {
            foreach (JobInstance instance in jobs)
            {
                ConVpxJobInfo item = new ConVpxJobInfo(instance);
                base.Add(item);
            }
            base.Sort(new JobInfoComparer());
        }

        private class JobInfoComparer : IComparer<ConVpxJobInfo>
        {
            public int Compare(ConVpxJobInfo job1, ConVpxJobInfo job2)
            {
                int num = 1;
                if ((job1 != null) && (job2 != null))
                {
                    num = job2.JobId.CompareTo(job1.JobId);
                }
                return num;
            }
        }
    }
}

