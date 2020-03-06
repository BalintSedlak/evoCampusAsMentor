using EvoRpg2.Models.Items;
using EvoRpg2.Services;
using EvoRpg2.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace EvoRpg2.Models.Map
{
    public class MapWeapon:MapItem
    {
        private double damageModifier;
        public MapWeapon(string itemName, double startX, double startY, double endX, double endY, BitmapImage bitmapImage,double damageModifier) : base(itemName, startX, startY, endX, endY, bitmapImage)
        {
            this.damageModifier = damageModifier;
        }

        public override void DoWhenClicked(InGameButton inGameButton, GameCoreServices gameCoreServices)
        {
            gameCoreServices.PlayerStats.AttackDamage = damageModifier;
            gameCoreServices.GrabItem(ItemName);
            this.MakeUnavailable(inGameButton,gameCoreServices);
        }
    }
}
