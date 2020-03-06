namespace Models.Items
{
    public class Potion : GameObject
    {
        public int HPAmount { get; private set; }

        public Potion(int objID, string objName, int HPAmount) : base(objID, objName)
        {
            this.HPAmount = HPAmount;
        }
    }
}
