using EvoRpg2.DataAccess;
using EvoRpg2.Helpers;
using EvoRpg2.Views.Pages;
using System.Windows.Controls;

namespace EvoRpg2.Services
{
    public class NavigationService
    {
        public Frame MainWindowFrame { get; set; }
        public Page MainMenu { get; set; }
        public Page GamePage { get; set; }
        public LogHelper LogHelper { get; set; }
        public NavigationService(ApplicationService applicationService, LogHelper logHelper, QuestHelper questHelper, InMemoryContextHelper inMemoryContextHelper) 
        {
            LogHelper = logHelper;
            MainMenu = new MainMenuPage(applicationService, this,LogHelper, questHelper, inMemoryContextHelper);
        }

        
    }
}
