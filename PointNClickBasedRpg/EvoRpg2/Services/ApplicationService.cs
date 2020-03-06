using EvoRpg2.Helpers;
using System.Diagnostics;
using System.Windows;

namespace EvoRpg2.Services
{
    public class ApplicationService
    {
        public LogHelper LogHelper { get; set; }
        public ApplicationService(LogHelper logHelper) 
        {
            LogHelper = logHelper;
        }

        public void ApplicationShutdown() 
        {
            LogHelper.logger.Info("Program shutdown");
            Process.Start("notepad.exe", "EvoRpg2.log");
            Application.Current.Shutdown();
        }
    }
}
