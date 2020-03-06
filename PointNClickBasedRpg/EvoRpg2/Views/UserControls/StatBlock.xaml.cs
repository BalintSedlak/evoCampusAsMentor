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
    /// Interaction logic for StatBlock.xaml
    /// </summary>
    public partial class StatBlock : UserControl
    {
        public StatBlock(StatBlockViewModel statBlockViewModel)
        {
            InitializeComponent();
            this.DataContext = statBlockViewModel;
        }
        public StatBlock()
        {
            InitializeComponent();
            this.DataContext = new StatBlockViewModel(new Models.Player.PlayerStats());

        }
    }
}
