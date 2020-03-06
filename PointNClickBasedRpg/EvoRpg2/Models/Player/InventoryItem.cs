using EvoRpg2.Helpers;
using EvoRpg2.Models.Interfaces;
using System.Windows.Media.Imaging;

namespace EvoRpg2.Models.Items
{
    public class InventoryItem : IEntity
    {
        public string ItemName { get; set; }

        public BitmapImage ItemIconBitmap { get; set; }

        public InventoryItem(string itemName)
        {
            ItemName = itemName;

            //TODO
            IoHelper ioHelper = new IoHelper();
            ItemIconBitmap = ioHelper.GetBitmapImageByName(ImageLocation.Inventory, itemName);
        }
    }
}
