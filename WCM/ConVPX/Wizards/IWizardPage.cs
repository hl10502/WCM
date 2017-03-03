namespace WCM.ConVPX.Wizards
{
    using System;
    using System.Windows.Forms;
    using WCM.XenAdmin.Wizards;

    public interface IWizardPage
    {
        bool EnableFinish();
        bool EnableNext();
        bool EnablePrevious();
        void OnPageExit(WizardProgressEventArgs e);
        void OnPageShow(WizardProgressEventArgs e);

        MethodInvoker UpdateWizardButtons { get; set; }
    }
}

