using System.Windows;
using ViewModels;

namespace ConsoleAdventure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new ViewModel();
            this.DataContext = ViewModel;
        }
    }
}
