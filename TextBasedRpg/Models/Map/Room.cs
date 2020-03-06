using Models.Items;

namespace Models.Map
{
    public class Room
    {
        #region Propertyk

        private static int IdCounter = 0;

        public int RoomID { get; private set; }

        public string RoomName { get; set; } //pl. Trónszoba --> a játékos lekérdezheti hol van

        public string Description { get; set; } //Leírás a szobáról... Mi van benne, mit látni stb.

        public GameObject MyObject { get; set; }

        #endregion

        public Room(string rname, string desc, GameObject obj)
        {
            RoomID = IdCounter++;
            this.RoomName = rname;
            this.Description = desc;
            this.MyObject = obj;
        }
    }
}
