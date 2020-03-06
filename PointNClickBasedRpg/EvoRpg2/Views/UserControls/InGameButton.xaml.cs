using EvoRpg2.Models.Items;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EvoRpg2.Views.UserControls
{
    /// <summary>
    /// Interaction logic for InGameButton.xaml
    /// </summary>
    public partial class InGameButton : UserControl
    {
        public GameCoreServices GameCoreServices { get; set; }
        public InGameButton(IClickable clickable, Canvas canvas,GameCoreServices gameCoreServices)
        {
            InitializeComponent();
            this.clickable = clickable;
            GameCoreServices = gameCoreServices;
            this.LoadItemImage();
            this.Height= canvas.ActualHeight*(clickable.ClickZoneEndY - clickable.ClickZoneStartY);
            this.Width = canvas.ActualWidth*(clickable.ClickZoneEndX - clickable.ClickZoneStartX);
        }

        private IClickable clickable;
        
        private void LoadItemImage()
        {
            MapItem item = clickable as MapItem;
            if (item != null)
            {
                ItemImage.Height = this.Height;
                ItemImage.Width = this.Width;
                ItemImage.Fill = item.Background;
            }
        }
        

        private void BestButton_Click(object sender, RoutedEventArgs e)
        {
            clickable.DoWhenClicked(this,GameCoreServices);
        }
    }
}
