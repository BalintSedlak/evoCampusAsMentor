using EvoRpg2.DataAccess;
using EvoRpg2.Helpers;
using EvoRpg2.Helpers.DataAccess;
using EvoRpg2.Models.DataAccess;
using EvoRpg2.Models.Map;
using EvoRpg2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvoRpg2.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private ApplicationService _applicationService;
        private NavigationService _navigationService;
        private LogHelper _logHelper;
        private readonly QuestHelper _questHelper;
        private readonly InMemoryContextHelper _inMemoryContextHelper;

        public MainMenuPage(ApplicationService applicationService, NavigationService navigationService, LogHelper logHelper, QuestHelper questHelper, InMemoryContextHelper inMemoryContextHelper)
        {
            InitializeComponent();
            _applicationService = applicationService;
            _navigationService = navigationService;
            _logHelper = logHelper;
            _questHelper = questHelper;
            _inMemoryContextHelper = inMemoryContextHelper;
        }

        private void _ExitButton_Click(object sender, RoutedEventArgs e)
        {
            
            _applicationService.ApplicationShutdown();
        }

        private void _StartButton_Click(object sender, RoutedEventArgs e)
        {
            IContextHelper contextHelper = new InMemoryContextHelper();
            GameContext gameContext = new GameContext(contextHelper);

            _navigationService.GamePage = new GamePage(_applicationService, _navigationService, _logHelper, _questHelper, _inMemoryContextHelper);
            _navigationService.MainWindowFrame.Content = _navigationService.GamePage;
            _ContinueButton.Opacity = 1;
            _ContinueButton.IsEnabled = true;
            _inMemoryContextHelper.SetToOriginal();
        }

        private void _ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.MainWindowFrame.Content = _navigationService.GamePage;
        }
    }
}
