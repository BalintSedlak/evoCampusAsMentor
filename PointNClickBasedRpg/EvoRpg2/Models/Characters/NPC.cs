using EvoRpg2.Models.Map;
using EvoRpg2.Services;
using EvoRpg2.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EvoRpg2.Models.Characters
{
    public class NPC : IClickable
    {
        public NPC( double startX, double startY, double endX, double endY,  string conversation,string secondaryConversation)
        {
            this.ClickZoneStartX = startX;
            this.ClickZoneStartY = startY;
            this.ClickZoneEndX = endX;
            this.ClickZoneEndY = endY;
            this.conversation = conversation;
            this.secondaryConversation = secondaryConversation;
        }
        //storing the zone where you can click things
        
        public double ClickZoneStartX { get; set; }
        public double ClickZoneStartY { get; set; }
        public double ClickZoneEndX { get; set; }
        public double ClickZoneEndY { get; set; }
        
        public string conversation { get; set; }
        private int talkedTo = 0;
        private readonly string secondaryConversation;

        public void DoWhenClicked(InGameButton inGameButton,GameCoreServices gameCoreServices)
        {
            talkedTo += 1;

            if (talkedTo == 1 && gameCoreServices.InInventory("Sword") && gameCoreServices.QuestIsInactive(0))
            {
                gameCoreServices.AddToQuestPanel(0);
                gameCoreServices.RemoveFromQuestPanel(0);
                gameCoreServices.GiveQuestReward(0);
                MessageBox.Show(secondaryConversation, "Cat said:", MessageBoxButton.OK);
            }
            else if (gameCoreServices.InInventory("Sword") && talkedTo != 1 && gameCoreServices.QuestIsActive(0))
            {
                gameCoreServices.GiveQuestReward(0);
                gameCoreServices.RemoveFromQuestPanel(0);
                MessageBox.Show(secondaryConversation, "Cat said:", MessageBoxButton.OK);
            }
            else if (!gameCoreServices.InInventory("Sword") && gameCoreServices.QuestIsInactive(0))
            {
                gameCoreServices.AddToQuestPanel(0);
                MessageBox.Show(conversation, "Cat said:", MessageBoxButton.OK);
            }
            else if(!gameCoreServices.InInventory("Sword") && gameCoreServices.QuestIsActive(0))
            {
                MessageBox.Show(conversation, "Cat said:", MessageBoxButton.OK);
            }
            else if(gameCoreServices.QuestIsDone(0))
            {
                MessageBox.Show(secondaryConversation, "Cat said:", MessageBoxButton.OK);
            }
            
        }
    }
}
