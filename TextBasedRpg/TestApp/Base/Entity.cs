using System.Collections.Generic;

namespace TestApp.Base
{
    public class Entity
    {

        #region Propertyk

        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }
        public int InventorySize { get; set; }
        public List<GameObject> MyInventory { get; set; }

        #endregion

        #region Konstruktor

        public Entity(string name, int maxHP, int currentHP, int gold, int inventorySize)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            Gold = gold;
            InventorySize = inventorySize;
            MyInventory = new List<GameObject>();
        }

        #endregion

    }
}
