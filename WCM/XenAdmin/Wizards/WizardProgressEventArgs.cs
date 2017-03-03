namespace WCM.XenAdmin.Wizards
{
    using System;

    public class WizardProgressEventArgs : EventArgs
    {
        public bool Cancelled;
        public readonly bool IsForwardsTransition;

        public WizardProgressEventArgs(bool isForwardsTransition)
        {
            this.IsForwardsTransition = isForwardsTransition;
        }
    }
}

