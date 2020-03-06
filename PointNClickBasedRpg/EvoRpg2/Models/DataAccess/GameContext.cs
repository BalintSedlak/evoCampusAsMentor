using EvoRpg2.Helpers.DataAccess;
using EvoRpg2.Models.Items;
using EvoRpg2.Models.Player;

namespace EvoRpg2.Models.DataAccess
{
    class GameContext
    {
        public Repository<InventoryItem> InventoryItemRepository { get; }
        public Repository<Quest> QuestRepository { get; }

        public GameContext(IContextHelper contextHelper)
        {
            InventoryItemRepository = new Repository<InventoryItem>(contextHelper.LoadDataType<InventoryItem>(), contextHelper);
            QuestRepository = new Repository<Quest>(contextHelper.LoadDataType<Quest>(), contextHelper);
        }

        public void SaveChanges()
        {
            InventoryItemRepository.Save();
            QuestRepository.Save();
        }
    }
}


