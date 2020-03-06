using EvoRpg2.Models.Player;

namespace EvoRpg2.ViewModels
{

    public class QuestViewModel
    {
        public Quest Quest { get; set; }

        public QuestViewModel(Quest quest)
        {
            this.Quest = quest;
        }
    }
}

