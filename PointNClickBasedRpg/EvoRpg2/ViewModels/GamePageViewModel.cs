using EvoRpg2.DataAccess;
using EvoRpg2.Helpers;
using EvoRpg2.Models.Items;
using EvoRpg2.Models.Map;
using EvoRpg2.Views.Pages;
using EvoRpg2.Views.UserControls;
using System.Windows.Controls;
using EvoRpg2.Models.Player;
using System.Windows;
using EvoRpg2.Services;

namespace EvoRpg2.ViewModels
{
    public class GamePageViewModel
    {
        private readonly QuestHelper _questHelper;
        private readonly InMemoryContextHelper _inMemoryContextHelper;
        public GamePage GamePage { get; set; }
        public GameCoreServices GameCoreServices { get; set; }
        public GamePageViewModel(GamePage gamePage, QuestHelper questHelper, InMemoryContextHelper inMemoryContextHelper)
        {
            GamePage = gamePage;
            _questHelper = questHelper;
            _inMemoryContextHelper = inMemoryContextHelper;
            
            GamePage.UpdateLayout();
            GamePage.MainCanvas.UpdateLayout();
        }
        public void LoadScenery(Location location)
        {
            GamePage.MainCanvas.Children.Clear();
            GamePage.MainCanvas.Background = location.Background;
            this.LoadIClickables(location);
        }

        private void LoadIClickables(Location location)
        {
            foreach (var item in location.clickables)
            {
                
                if (item is MapItem mapItem)
                {
                    if (!mapItem.IsPickedUp)
                    {
                        PlaceOnCanvas(mapItem);
                    }
                }
                else
                {
                    PlaceOnCanvas(item);
                }
                

            }
        }
        public void AddToInventoryPanel(string itemName)
        {
            GamePage._InventoryStackPanel.Children.Add(new InventoryButton(new InventoryButtonViewModel(new InventoryItem(itemName))));
        }

        public void PlaceOnCanvas(IClickable clickable)
        {
            InGameButton inGameButton = new InGameButton(clickable,GamePage.MainCanvas,GameCoreServices);
            GamePage.MainCanvas.Children.Add(inGameButton);
            Canvas.SetLeft(inGameButton, GamePage.MainCanvas.ActualWidth*clickable.ClickZoneStartX);
            Canvas.SetTop(inGameButton, GamePage.MainCanvas.ActualHeight*clickable.ClickZoneStartY);
        }

        public void AddToQuestPanel(int questID)
        {
            _questHelper.AddQuest(questID, new QuestBar(new QuestViewModel(_inMemoryContextHelper.LoadDataType<Quest>()[questID])));

            GamePage._QuestsGoHere.Children.Add(_questHelper.GetQuestById(questID));
        }

        public void RemoveFromQuestPanel(int questId)
        {
            GamePage._QuestsGoHere.Children.Remove(_questHelper.GetQuestById(questId));
            _questHelper.RemoveQuest(questId);
        }

    }
}
