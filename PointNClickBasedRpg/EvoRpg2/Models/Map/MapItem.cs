using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EvoRpg2.Models.Map;
using EvoRpg2.Services;
using EvoRpg2.ViewModels;
using EvoRpg2.Views.UserControls;

namespace EvoRpg2.Models.Items
{
    public class MapItem : IClickable
    {
        public MapItem(string itemName, double startX, double startY, double endX, double endY,BitmapImage bitmapImage)
        {
            this.ClickZoneStartX = startX;
            this.ClickZoneStartY = startY;
            this.ClickZoneEndX = endX;
            this.ClickZoneEndY = endY;
            this.ItemName = itemName;
            Background.ImageSource = bitmapImage;
            
            
        }
        //storing the zone where you can click things
        public string ItemName { get; set; }
        public double ClickZoneStartX { get; set; }
        public double ClickZoneStartY { get; set; }
        public double ClickZoneEndX { get; set; }
        public double ClickZoneEndY { get; set; }
        public ImageBrush Background { get; set; } = new ImageBrush();
        
        public bool IsPickedUp { get; set; } = false;
        
        public virtual void DoWhenClicked(InGameButton inGameButton, GameCoreServices gameCoreServices)
        {
            gameCoreServices.GrabItem(ItemName);
            this.MakeUnavailable(inGameButton,gameCoreServices);
            
        }
        public void MakeUnavailable(InGameButton inGameButton,GameCoreServices gameCoreServices)
        {
            IsPickedUp = true;
            gameCoreServices.RemoveElement(inGameButton);
        }
    }

}
