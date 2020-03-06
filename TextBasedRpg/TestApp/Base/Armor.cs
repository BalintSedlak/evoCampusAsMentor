namespace TestApp.Base
{
    public class Armor : GameObject
    {
        public int ArmorHP { get; private set; }

        public Armor(int ArmorHP)
        {
            this.ArmorHP = ArmorHP;
        }
    }
}
