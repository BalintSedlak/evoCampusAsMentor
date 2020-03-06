using EvoRpg2.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EvoRpg2.Views.UserControls
{
    /// <summary>
    /// Interaction logic for QuestBar.xaml
    /// </summary>
    public partial class QuestBar : UserControl
    {
        public QuestViewModel QuestViewModel { get; }

        public QuestBar(QuestViewModel questViewModel)
        {
            InitializeComponent();
            this.DataContext = questViewModel;
            QuestViewModel = questViewModel;
        }

    }
}
