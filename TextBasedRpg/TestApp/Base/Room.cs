using System;

namespace TestApp.Base
{
    public class Room
    {
        #region Propertyk

        public string RoomName { get; set; } //pl. Trónszoba --> a játékos lekérdezheti hol van

        public string Description { get; set; } //Leírás a szobáról... Mi van benne, mit látni stb.

        public Object MyObject { get; set; }

        public Key KeyRequiredToEnter { get; set; } //Ezt lehet a táblázat helyettesíti... dunno

        #endregion
    }
}
