namespace TestApp.Base
{
    public class Potion : GameObject
    {
        public int HPAmount { get; private set; }

        public Potion(int HPAmount)
        {
            this.HPAmount = HPAmount;
        }
    }
}
