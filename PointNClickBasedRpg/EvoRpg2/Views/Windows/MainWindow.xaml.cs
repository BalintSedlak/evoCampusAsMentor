using EvoRpg2.Services;
using EvoRpg2.Views.Pages;
using System.Windows;

namespace EvoRpg2.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationService _applicationService;
        private NavigationService _navigationService;
        public MainWindow(ApplicationService applicationService, NavigationService navigationService)
        {
            InitializeComponent();
            _applicationService = applicationService;
            _navigationService = navigationService;
            navigationService.MainWindowFrame = _MainWindowFrame;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _navigationService.MainWindowFrame.Content = _navigationService.MainMenu;
            
            
        }
    }
}
