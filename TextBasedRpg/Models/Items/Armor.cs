namespace Models.Items
{
    public class Armor : GameObject
    {
        public int ArmorHP { get; private set; }

        public Armor(int objID, string objName, int ArmorHP) : base(objID, objName)
        {
            this.ArmorHP = ArmorHP;
        }
    }
}
