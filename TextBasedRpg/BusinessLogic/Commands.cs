using Models.Entities;
using Models.Items;

namespace BusinessLogic
{
    //OBSELETE PLEASE DELETE ME
    public class Commands
    {
        private readonly Player player;

        public Commands(Player player)
        {
            this.player = player;
        }

        //Öngyilkosság megkísérlése
        public bool testDamage(Player testPlayer)
        {
            testPlayer.CurrentHP -= 10;
            if (testPlayer.CurrentHP < 0)
            {
                testPlayer.CurrentHP = 0;
            }
            //System.Console.WriteLine("Sebződtél 10 HP-t és most a HP-d: " + testPlayer.CurrentHP);
            if (testPlayer.CurrentHP == 0)
            {
                /*System.Console.WriteLine("Meghaltál :(");
                System.Console.ReadLine();*/
                return true;
            }
            return false;
        }

        public void AddItem(GameObject addedItem)
        {
            player.AddItemToInventory(addedItem);
        }
    }
}
