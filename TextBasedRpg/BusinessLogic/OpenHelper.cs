using Models.Entities;
using Models.Items;
using Models.Map;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class OpenHelper
    {

        private readonly Player player;
        private readonly Dictionary<Location, Room> roomList;
        private readonly Dictionary<ConnectionLocation, RoomConnection> connectionList;

        public OpenHelper(Player player, Dictionary<Location, Room> roomList, Dictionary<ConnectionLocation, RoomConnection> connectionList)
        {
            this.player = player;
            this.roomList = roomList;
            this.connectionList = connectionList;
        }

        public void Open(string Direction)
        {
            switch (Direction)
            {
                case "Left":
                    var CurrentConnectionLeft = connectionList[new ConnectionLocation(
                            roomList[new Location(player.EntityPosition.X, player.EntityPosition.Y)],
                            roomList[new Location(player.EntityPosition.X - 1, player.EntityPosition.Y + 0)])];

                    if (CurrentConnectionLeft.IsOpen == false && CheckKey(CurrentConnectionLeft))
                    {
                        OpenTheRoom(CurrentConnectionLeft);
                    }

                    break;
                case "Right":
                    var CurrentConnectionRight = connectionList[new ConnectionLocation(
                            roomList[new Location(player.EntityPosition.X, player.EntityPosition.Y)],
                            roomList[new Location(player.EntityPosition.X + 1, player.EntityPosition.Y + 0)])];

                    if (CurrentConnectionRight.IsOpen == false && CheckKey(CurrentConnectionRight))
                    {
                        OpenTheRoom(CurrentConnectionRight);
                    }

                    break;
                case "Up":
                    var CurrentConnectionUp = connectionList[new ConnectionLocation(
                            roomList[new Location(player.EntityPosition.X, player.EntityPosition.Y)],
                            roomList[new Location(player.EntityPosition.X + 0, player.EntityPosition.Y + 1)])];

                    if (CurrentConnectionUp.IsOpen == false && CheckKey(CurrentConnectionUp))
                    {
                        OpenTheRoom(CurrentConnectionUp);
                    }

                    break;
                case "Down":
                    var CurrentConnectionDown = connectionList[new ConnectionLocation(
                             roomList[new Location(player.EntityPosition.X, player.EntityPosition.Y)],
                             roomList[new Location(player.EntityPosition.X + 0, player.EntityPosition.Y - 1)])];

                    if (CurrentConnectionDown.IsOpen == false && CheckKey(CurrentConnectionDown))
                    {
                        OpenTheRoom(CurrentConnectionDown);
                    }
                    break;
                default:
                    break;
            }
        }

        public bool CheckKey(RoomConnection roomConnection)
        {
            if (roomConnection == null || roomConnection.OpeningKey == null)
            {
                return false;
            }

            foreach (var item in player.MyInventory)
            {
                if (roomConnection.OpeningKey.Equals((Key)item))
                {
                    return true;
                }
                
            }

            return player.MyInventory.Contains(roomConnection.OpeningKey);
        }

        public string OpenTheRoom(RoomConnection roomConnection)
        {
            if (CheckKey(roomConnection))
            {
                roomConnection.IsOpen = true;
                return "The road is open now.";
            }

            return "It's not possible to open the road.";
        }
    }
}
