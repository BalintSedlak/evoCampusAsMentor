using EvoRpg2.Models.Interfaces;
using EvoRpg2.Models.Items;

namespace EvoRpg2.Models.Player
{
    public class Quest : IEntity
    {
        public int QuestID { get; private set; }
        public string QuestName { get { return $"Pick up the {QuestObject?.ItemName}"; } }
        public InventoryItem QuestObject { get; private set; }
        public QuestStatus QuestStatus { get; set; }
        public int Reward { get; private set; }

       //ha ne adjon kulcsot akkor null,vagy írd be hogy awudhakehguakad
        public string KeyReward { get; set; }
        

        public Quest(int questID, IEntity questObject, QuestStatus questStatus, int reward,string key)
        {
            QuestID = questID;
            QuestObject = questObject as InventoryItem;
            QuestStatus = questStatus;
            Reward = reward;
            KeyReward = key;
        }
    }
}
