using EvoRpg2.Services;
using EvoRpg2.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EvoRpg2.Models.Map
{
    public class EntryPoint:IClickable
    {
        public EntryPoint(Location location, double startX, double startY, double endX, double endY, bool isOpen,String lockName)
        {
            this.ToGoLocation = location;
            this.ClickZoneStartX = startX;
            this.ClickZoneStartY = startY;
            this.ClickZoneEndX = endX;
            this.ClickZoneEndY = endY;
            this.IsOpen = isOpen;
            
            this.Lock = lockName;
        }
        public bool IsOpen { get; set; }
        public string Lock { get; set; }
        public Location ToGoLocation { get; set; }
        //storing the zone where you can click things
        public double ClickZoneStartX { get; set; }
        public double ClickZoneStartY { get; set; }
        public double ClickZoneEndX { get; set; }
        public double ClickZoneEndY { get; set; }
        
        
        
        public void DoWhenClicked(InGameButton inGameButton,GameCoreServices gameCoreServices)
        {
            if (IsOpen)
            {
                gameCoreServices.LoadLocation(ToGoLocation);
            }
            else
            {
                if(OpenEntryPoint(Lock,gameCoreServices))
                {
                    MessageBox.Show("This Door is now unlocked");
                }
                else
                {
                    MessageBox.Show("This door is closed");
                }
            }

        }
       
        
        public bool OpenEntryPoint(String lockName,GameCoreServices gameCoreServices)
        {
            if(gameCoreServices.CheckEntryPointLock(lockName))
            {
                IsOpen = true;
                return true;
            }
            return false;
        }

    }
}
