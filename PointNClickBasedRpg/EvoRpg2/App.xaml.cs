using EvoRpg2.DataAccess;
using EvoRpg2.Helpers;
using EvoRpg2.Services;
using EvoRpg2.Views.Windows;
using System.Windows;

namespace EvoRpg2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            LogHelper logHelper = new LogHelper();
            ApplicationService applicationService = new ApplicationService(logHelper);
            QuestHelper questHelper = new QuestHelper();
            InMemoryContextHelper inMemoryContextHelper = new InMemoryContextHelper();
            MainWindow window = new MainWindow(applicationService, new NavigationService(applicationService,logHelper, questHelper, inMemoryContextHelper));
            window.Show();
            base.OnStartup(e);
            logHelper.logger.Info("Program started");
        }
    }
}
