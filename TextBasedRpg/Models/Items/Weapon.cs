namespace Models.Items
{
    public class Weapon : GameObject
    {
        public int Damage { get; private set; }

        public Weapon(int objID, string objName, int Damage) : base(objID, objName)
        {
            this.Damage = Damage;
        }
    }
}
