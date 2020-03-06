using Models.Entities;
using Models.Items;
using Models.Map;
using System.Collections.Generic;

namespace BusinessLogic
{
    public delegate void CommandEventHandler(string message);

    public class CommandHandler
    {
        public event CommandEventHandler CommandEvent;

        private Dictionary<Location, Room> RoomList = new Dictionary<Location, Room>();
        private Dictionary<ConnectionLocation, RoomConnection> ConnectionList = new Dictionary<ConnectionLocation, RoomConnection>();
        private Player player;
        private PlayerHelper playerHelper;
        private MoveHelper MH;
        private RoomHelper RH;
        private OpenHelper OH;

        public CommandHandler()
        {
            player = new Player("John Doe", new Location(2, 0), 12, 12, 0, 4);

            playerHelper = new PlayerHelper(player);

            MH = new MoveHelper(player, RoomList, ConnectionList, playerHelper);

            RH = new RoomHelper(player, RoomList, ConnectionList, playerHelper);

            OH = new OpenHelper(player, RoomList, ConnectionList);
        }

        public void Handle(string command)
        {
            switch (command)
            {
                case "Initialize":
                    InitializerHelper ih = new InitializerHelper();
                    ih.WorldInit(RoomList, ConnectionList);
                    CommandEvent($"*IntroText* {RH.GetCurrentRoomInfo()}");
                    break;
                case "getHP":
                    CommandEvent("getHP");
                    break;
                case "testDamage":
                    CommandEvent("testDamage");
                    //commands.testDamage(player);
                    break;
                case "freePotion":
                    CommandEvent("freePotion");
                    Potion poti = new Potion(2, "Potion", 6);
                    //commands.AddItem(poti);
                    break;
                case "freeArmor":
                    CommandEvent("freeArmor");
                    Armor armor = new Armor(5, "Armor", 4);
                    //commands.AddItem(armor);
                    break;
                case "freeSword":
                    CommandEvent("freeSword");
                    Weapon sword = new Weapon(3, "Sword", 3);
                    //commands.AddItem(sword);
                    break;
                case "testKey":
                    Key testKey = RoomList[new Location(4, 4)].MyObject as Key;
                    playerHelper.AddItem(testKey);
                    CommandEvent("testKey");
                    break;
                case "Right":
                    /*string messageR = MH.Move("Right");
                    messageR = $"{messageR} {RoomList[player.EntityPosition].Description}"; //OBSOLETE, if all else fails
                    CommandEvent(messageR);*/

                    string messageRight = MH.Move("Right");
                    messageRight = $"{messageRight} {RH.GetCurrentRoomInfo()}";
                    CommandEvent(messageRight);
                    break;
                case "Up":
                    /*string messageU = MH.Move("Up");
                    messageU = $"{messageU} {RoomList[player.EntityPosition].Description}"; //OBSOLETE, if all else fails
                    CommandEvent(messageU);*/

                    string messageUp = MH.Move("Up");
                    messageUp = $"{messageUp} {RH.GetCurrentRoomInfo()}";
                    CommandEvent(messageUp);
                    break;
                case "Left":
                    /*string messageL = MH.Move("Left");
                    messageL = $"{messageL} {RoomList[player.EntityPosition].Description}"; //OBSOLETE, if all else fails
                    CommandEvent(messageL);*/

                    string messageLeft = MH.Move("Left");
                    messageLeft = $"{messageLeft} {RH.GetCurrentRoomInfo()}";
                    CommandEvent(messageLeft);
                    break;
                case "Down":
                    /*string messageD = MH.Move("Down");
                    messageD = $"{messageD} {RoomList[player.EntityPosition].Description}"; //OBSOLETE, if all else fails
                    CommandEvent(messageD);*/

                    string messageDown = MH.Move("Down");
                    messageDown = $"{messageDown} {RH.GetCurrentRoomInfo()}";
                    CommandEvent(messageDown);
                    break;
                case "OpenLeft":
                    string messageOpenLeft = OH.OpenTheRoom(ConnectionList[new ConnectionLocation(RoomList[player.EntityPosition], RoomList[playerHelper.GetLeftLocation()])]);
                    CommandEvent(messageOpenLeft);
                    break;
                case "OpenUp":
                    string messageOpenUp = OH.OpenTheRoom(ConnectionList[new ConnectionLocation(RoomList[player.EntityPosition], RoomList[playerHelper.GetUpLocation()])]);
                    CommandEvent(messageOpenUp);
                    break;
                case "OpenRight":
                    string messageOpenRight = OH.OpenTheRoom(ConnectionList[new ConnectionLocation(RoomList[player.EntityPosition], RoomList[playerHelper.GetRightLocation()])]);
                    CommandEvent(messageOpenRight);
                    break;
                case "OpenDown":
                    string messageOpenDown = OH.OpenTheRoom(ConnectionList[new ConnectionLocation(RoomList[player.EntityPosition], RoomList[playerHelper.GetDownLocation()])]);
                    CommandEvent(messageOpenDown);
                    break;
                default:
                    CommandEvent("UnknownCommand");
                    break;
            }
        }
    }
}
