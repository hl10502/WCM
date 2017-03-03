namespace ExportImport.CommonTypes
{
    using System;

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
}

