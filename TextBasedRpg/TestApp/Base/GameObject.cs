namespace TestApp.Base
{
    public class GameObject : Room
    {
        #region Propertyk

        public int ObjID { get; set; }
        public string ObjName { get; set; }

        public int WhereTheObjetIsByRoomIndex { get; set; }

        #endregion

    }
}
