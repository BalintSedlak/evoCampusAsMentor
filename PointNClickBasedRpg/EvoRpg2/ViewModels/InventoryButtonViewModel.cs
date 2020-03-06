using EvoRpg2.Helpers;
using EvoRpg2.Models.Items;
using System.Windows.Media.Imaging;

namespace EvoRpg2.ViewModels
{
    public class InventoryButtonViewModel
    {
        public InventoryItem inventoryItem { get; set; }

        public InventoryButtonViewModel(InventoryItem inventoryItem)
        {
            this.inventoryItem = inventoryItem;
        }
    }
}
