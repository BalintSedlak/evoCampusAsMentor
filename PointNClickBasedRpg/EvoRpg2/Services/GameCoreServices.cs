using EvoRpg2.DataAccess;
using EvoRpg2.Helpers;
using EvoRpg2.Models.Items;
using EvoRpg2.Models.Map;
using EvoRpg2.Models.Player;
using EvoRpg2.ViewModels;
using EvoRpg2.Views.Pages;
using EvoRpg2.Views.UserControls;
using System;
using System.Windows.Controls;

namespace EvoRpg2.Services
{
    /// <summary>
    /// Manages the core gameplay mechanics of the Game
    /// </summary>
    public class GameCoreServices
    {
        public LogHelper LogHelper { get; set; }
        public Canvas GameCanvas { get; set; }
        public StackPanel StackPanel { get; set; }
        public GamePageViewModel GamePageViewModel { get; set; }
        public KeyRing KeyRing { get; set; } 
        public PlayerStats PlayerStats { get; set; }
        private InMemoryContextHelper _inMemoryContextHelper;
        public GameCoreServices(GamePage gamePage,GamePageViewModel gamePageViewModel,PlayerStats playerStats, LogHelper logHelper, InMemoryContextHelper inMemoryContextHelper)
        {
            LogHelper = logHelper;
            KeyRing = new KeyRing();
            GameCanvas = gamePage.MainCanvas;
            StackPanel = gamePage._InventoryStackPanel;
            
            GamePageViewModel = gamePageViewModel;
            PlayerStats = playerStats;
            PlayerStats.CurrentLocation = inMemoryContextHelper.LoadDataType<Location>()[0];
         
            _inMemoryContextHelper = inMemoryContextHelper;
        }


        public void LoadFirstLocation()
        { 
            LoadLocation(PlayerStats.CurrentLocation); 
        }
        /// <summary>
        /// Loads the given <see cref="Location"/> into the <see cref="GameCanvas"/>.
        /// </summary>
        /// <param name="location"> What location you want.</param>
        /// <returns>Void method</returns>
        public void LoadLocation(Location location)
        {
            GamePageViewModel.LoadScenery(location);
            PlayerStats.CurrentLocation = location;
            LogHelper.logger.Info($"Loaded {location.LocationName}");
        }



        /// <summary>
        /// Checks if a lock can be opened.
        /// </summary>
        /// <param name="lockName"> The name of the lock.</param>
        /// <returns>True if it can be opened, False if not.</returns>
        public bool CheckEntryPointLock(String lockName)
        {
            if(KeyRing.CheckKey(lockName))
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// Adds an "item" to the inventory
        /// </summary>
        /// <param name="itemName"> Name of the item you want to add.</param>
        /// <returns> Void Method</returns>
        public void GrabItem(string itemName)
        {
            GamePageViewModel.AddToInventoryPanel(itemName);
            _inMemoryContextHelper.AddItemToInventory(itemName);
        }

        public void RemoveElement(InGameButton inGameButton)
        {
            GameCanvas.Children.Remove(inGameButton);
        }

        //Checks the status of a quest
        public bool QuestIsInactive(int questId)
        {
            if (_inMemoryContextHelper.LoadDataType<Quest>()[questId].QuestStatus == QuestStatus.Inactive)
            {
                return true;
            }
            return false;

        }

        //Checks the status of a quest
        public bool QuestIsActive(int questId)
        {
            if (_inMemoryContextHelper.LoadDataType<Quest>()[questId].QuestStatus == QuestStatus.Active )
            {
                return true;
            }
            return false;
        }
        public bool QuestIsDone(int questId)
        {
            if (_inMemoryContextHelper.LoadDataType<Quest>()[questId].QuestStatus == QuestStatus.Done)
            {
                return true;
            }
            return false;
        }

        //Hozzá ad egy questet a questpanelhez questId alapján
        public void AddToQuestPanel(int questId)
        {
            GamePageViewModel.AddToQuestPanel(questId);
            _inMemoryContextHelper.SetQuestStatus(questId,QuestStatus.Active);
        }

        //Eltávolít egy questet a questpanelről questId alapján
        public void RemoveFromQuestPanel(int questId)
        {
            GamePageViewModel.RemoveFromQuestPanel(questId);
            _inMemoryContextHelper.SetQuestStatus(questId, QuestStatus.Done);
        }

        //Egy metódus, annak az ellenőrzésére, hogy az adott item benne van-e az inventorynkban
        public bool InInventory(string itemName)
        {
            foreach (var item in _inMemoryContextHelper.LoadDataType<InventoryItem>())
            {
                if (item.ItemName == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        //Megadjaegy questnek a rewardját questId alapján
        public void GiveQuestReward(int questId)
        {
            PlayerStats.Money = _inMemoryContextHelper.LoadDataType<Quest>()[questId].Reward;
            if (_inMemoryContextHelper.LoadDataType<Quest>()[questId].KeyReward!=null)
            {
            KeyRing.AddKey(_inMemoryContextHelper.LoadDataType<Quest>()[questId].KeyReward);
            }
        }

    }
}
