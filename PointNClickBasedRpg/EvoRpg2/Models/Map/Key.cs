using EvoRpg2.Services;
using EvoRpg2.ViewModels;
using EvoRpg2.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EvoRpg2.Models.Items
{
    public class Key: MapItem
    {
        public String KeyName { get; set; }

        public Key(string itemName, double startX, double startY, double endX, double endY, BitmapImage bitmapImage,String keyName) : base(itemName, startX, startY, endX, endY, bitmapImage)
        {
            this.KeyName = keyName;
        }
        public override void DoWhenClicked(InGameButton inGameButton, GameCoreServices gameCoreServices)
        {
            gameCoreServices.KeyRing.AddKey(KeyName);
            MessageBox.Show("You found a key");
            this.MakeUnavailable(inGameButton,gameCoreServices);
        }
    }
}
