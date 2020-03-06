using Models.Map;

namespace Models.Entities
{
    class Enemy : Entity
    {
        #region Konstruktor

        //Ez automatikusan jött létre, még változni fog
        public Enemy(string name, Location CurrentLocation, int maxHP, int currentHP, int gold, int inventorySize) : base(name, CurrentLocation, maxHP, currentHP, gold, inventorySize)
        {
        }

        #endregion

    }
}
