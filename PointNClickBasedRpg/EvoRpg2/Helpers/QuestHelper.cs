using EvoRpg2.Views.UserControls;
using System.Collections.Generic;

namespace EvoRpg2.Helpers
{
    public class QuestHelper
    {
        private Dictionary<int, QuestBar> _questBarList;

        public QuestHelper()
        {
            _questBarList = new Dictionary<int, QuestBar>();
        }

        public void AddQuest(int id, QuestBar questBar)
        {
            //temporary bug fix
            //rossz helyen jön létre a Quest Helper TODO Fix
            _questBarList.Clear();
            _questBarList.Add(id, questBar);
        }

        public void RemoveQuest(int id)
        {
            _questBarList.Remove(id);
        }

        public QuestBar GetQuestById(int id)
        {
            try
            {
                return _questBarList[id];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
