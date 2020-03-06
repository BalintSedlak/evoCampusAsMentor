using EvoRpg2.DataAccess;
using EvoRpg2.Helpers;
using EvoRpg2.Models.Player;
using EvoRpg2.Services;
using EvoRpg2.ViewModels;
using EvoRpg2.Views.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace EvoRpg2.Views.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        ApplicationService _applicationService;
        NavigationService _navigationService;
        GameCoreServices _gameCoreServices;
        GamePageViewModel _gamePageViewModel;
        PlayerStats playerStats;

        public LogHelper LogHelper { get; }
        public QuestHelper QuestHelper { get; }
        public InMemoryContextHelper InMemoryContextHelper { get; }
        private bool firstStart = true;

        public GamePage(ApplicationService applicationService, NavigationService navigationService, LogHelper logHelper, QuestHelper questHelper, InMemoryContextHelper inMemoryContextHelper)
        {
            InitializeComponent();
            playerStats = new PlayerStats();
            _StatsGoHere.Children.Add(new StatBlock(new StatBlockViewModel(playerStats)));
            this.Loaded += new RoutedEventHandler(this.Page_Loaded);
            _applicationService = applicationService;
            _navigationService = navigationService;
            LogHelper = logHelper;
            QuestHelper = questHelper;
            InMemoryContextHelper = inMemoryContextHelper;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (firstStart)
            {
                _gamePageViewModel = new GamePageViewModel(this, QuestHelper, InMemoryContextHelper);
                _gameCoreServices = new GameCoreServices(this, _gamePageViewModel, playerStats, LogHelper, InMemoryContextHelper);
                _gamePageViewModel.GameCoreServices = _gameCoreServices;
                _gamePageViewModel.AddToInventoryPanel("Keyring");
                _gameCoreServices.LoadFirstLocation();
            }
            firstStart = false;
        }

        private void _ExitButton_Click(object sender, RoutedEventArgs e)
        {            
            _applicationService.ApplicationShutdown();
        }

        

        
        

        private void _BackButton_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.MainWindowFrame.GoBack();
        }

        private void _SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your game is now saved,have some money ");
            playerStats.Money = 100;
            //TODO implement saving
        }
    }
}
