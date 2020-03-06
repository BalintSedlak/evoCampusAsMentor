namespace TestApp.Base
{
    public class Player : Entity
    {
        public Player(string name, int maxHP, int currentHP, int gold, int inventorySize) : base(name, maxHP, currentHP, gold, inventorySize)
        {
        }


        #region Metódusok

        public void CheckInventory()
        {
            
        }

        public void CheckStat()
        {

        }

        public void Move()
        {

        }

        public void LookAround()
        {

        }

        public void AddItemToInventory(GameObject objektum)
        {
            //Player.MyInventory.Add(objektum);
        }


        #endregion
    }
}
