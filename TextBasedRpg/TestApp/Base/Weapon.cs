namespace TestApp.Base
{
    public class Weapon : GameObject
    {
        public int Damage { get; private set; }

        public Weapon(int Damage)
        {
            this.Damage = Damage;
        }
    }
}
