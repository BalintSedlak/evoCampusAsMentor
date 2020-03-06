using Models.Items;
using Models.Map;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Entity
    {

        #region Propertyk

        public string Name { get; set; }
        public Location EntityPosition { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }
        public int InventorySize { get; set; }
        public List<GameObject> MyInventory { get; set; }

        #endregion

        #region Konstruktor

        public Entity(string name, Location StartingPosition, int maxHP, int currentHP, int gold, int inventorySize)
        {
            Name = name;
            EntityPosition = StartingPosition;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            Gold = gold;
            InventorySize = inventorySize;
            MyInventory = new List<GameObject>();
        }

        #endregion

    }
}
