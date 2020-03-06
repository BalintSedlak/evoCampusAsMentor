namespace TestApp.Base
{
    class Enemy : Entity
    {
        #region Konstruktor

        //Ez automatikusan jött létre, még változni fog
        public Enemy(string name, int maxHP, int currentHP, int gold, int inventorySize) : base(name, maxHP, currentHP, gold, inventorySize)
        {
        }

        #endregion

    }
}
