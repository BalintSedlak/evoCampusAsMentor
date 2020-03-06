using EvoRpg2.Helpers;
using EvoRpg2.Helpers.DataAccess;
using EvoRpg2.Models.Characters;
using EvoRpg2.Models.Interfaces;
using EvoRpg2.Models.Items;
using EvoRpg2.Models.Map;
using EvoRpg2.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace EvoRpg2.DataAccess
{
    public class InMemoryContextHelper : IContextHelper
    {
        private List<InventoryItem> _inventoryItems;
        private readonly List<Quest> _quests;
        private List<Location> _locations;
        private IoHelper ioHelper;


        public InMemoryContextHelper()
        {
            _inventoryItems = new List<InventoryItem>()
                {
                    new InventoryItem("KeyRing"),
                };

            _quests = new List<Quest>()
            {
                new Quest(0, new InventoryItem("Sword"), QuestStatus.Inactive, 100,"Quest Key"),
            };
            _locations = new List<Location>()
            {
                new Location(new BitmapImage(new Uri(@"Resources/Images/backgrounds/field.jpg", UriKind.Relative)), "Starting Field"),
                new Location(new BitmapImage(new Uri(@"Resources/Images/backgrounds/house.jpg", UriKind.Relative)), "House with 3 way"),
                new Location(new BitmapImage(new Uri(@"Resources/Images/backgrounds/camp.png", UriKind.Relative)), "Camp with quest item"),
                new Location(new BitmapImage(new Uri(@"Resources/Images/bridgeCat.jpg", UriKind.Relative)), "QuestGiver Cat on bridge"),
                new Location(new BitmapImage(new Uri(@"Resources/Images/backgrounds/forest.jpg", UriKind.Relative)), "Forest location"),
                new Location(new BitmapImage(new Uri(@"Resources/Images/backgrounds/lighthouse.jpg", UriKind.Relative)), "lighthouse location")
            };
             ioHelper = new IoHelper();
            _locations[0].clickables.Add(new EntryPoint(_locations[1], 0.9, 0.4, 1, 0.8, true, "Open Door"));

            _locations[1].clickables.Add(new EntryPoint(_locations[0], 0.35, 0.8, 0.72, 1, true, "Open Door"));
            _locations[1].clickables.Add(new EntryPoint(_locations[3], 0.9, 0.4, 1, 0.7, true, "Open Door"));
            _locations[1].clickables.Add(new EntryPoint(_locations[2], 0, 0.4, 0.1, 0.8, true, "Open Door"));

            _locations[2].clickables.Add(new EntryPoint(_locations[1], 0.9, 0.4, 1, 0.7, true, "Open Door"));
            _locations[2].clickables.Add(new MapWeapon("Sword", 0.1, 0.7, 0.3, 0.8, ioHelper.GetBitmapImageByName(ImageLocation.Sword, "Sword"), 15));

            _locations[3].clickables.Add(new EntryPoint(_locations[1], 0, 0.6, 0.1, 1, true, "Open Door"));
            _locations[3].clickables.Add(new EntryPoint(_locations[4], 0.9, 0.4, 1, 0.8, false, "Quest Key"));
            _locations[3].clickables.Add(new NPC(0.5, 0.4, 0.85, 0.9, "I will give you a quest once its merged in","You can now cross the bridge"));


            _locations[4].clickables.Add(new EntryPoint(_locations[3], 0, 0.4, 0.1, 0.8, true, "Open Door"));
            _locations[4].clickables.Add(new EntryPoint(_locations[5], 0.9, 0.4, 1, 0.8, true, "Open Door"));

            _locations[5].clickables.Add(new EntryPoint(_locations[4], 0, 0.4, 0.1, 0.9, true, "Open Door"));
        }

        public List<T> LoadDataType<T>() where T : IEntity
        {
            List<T> returnList;

            if (typeof(InventoryItem).IsAssignableFrom(typeof(T)))
            {
                returnList = _inventoryItems.Cast<T>().ToList();
            }
            else if (typeof(Quest).IsAssignableFrom(typeof(T)))
            {
                returnList = _quests.Cast<T>().ToList();
            }
            else if (typeof(Location).IsAssignableFrom(typeof(T)))
            {
                returnList = _locations.Cast<T>().ToList();
            }
            else
            {
                throw new Exception();
            }

            return returnList;
        }

        public void SaveDataType<T>(List<T> entities) where T : IEntity
        {
            throw new NotImplementedException();
        }
        public void AddItemToInventory(string itemName)
        {
            _inventoryItems.Add(new InventoryItem(itemName));
        }

        public void SetQuestStatus(int questId, QuestStatus questStatus)
        {
            _quests[questId].QuestStatus = questStatus;
        }

        public void SetToOriginal()
        {
            _inventoryItems.Clear();
            _quests.Clear();
            _inventoryItems.Add(new InventoryItem("KeyRing"));
            _quests.Add(new Quest(0, new InventoryItem("Sword"), QuestStatus.Inactive, 100,"Quest Key"));
            _locations[2].clickables.RemoveAt(1);
            _locations[2].clickables.Add(new MapWeapon("Sword", 0.1, 0.7, 0.3, 0.8, ioHelper.GetBitmapImageByName(ImageLocation.Sword, "Sword"), 15));
            _locations[3].clickables.RemoveAt(1);
            _locations[3].clickables.RemoveAt(1);
            _locations[3].clickables.Add(new EntryPoint(_locations[4], 0.9, 0.4, 1, 0.8, false, "Quest Key"));
            _locations[3].clickables.Add(new NPC(0.5, 0.4, 0.85, 0.9, "Complete your quest and I shall let you pass","You can now cross the bridge"));

        }

    }
}
