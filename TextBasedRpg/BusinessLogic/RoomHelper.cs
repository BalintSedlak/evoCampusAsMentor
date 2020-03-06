using Models.Entities;
using Models.Map;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class RoomHelper
    {
        private readonly Player player;
        private readonly Dictionary<Location, Room> roomList;
        private readonly Dictionary<ConnectionLocation, RoomConnection> connectionList;
        private readonly PlayerHelper PH;

        public RoomHelper(Player player, Dictionary<Location, Room> roomList, Dictionary<ConnectionLocation, RoomConnection> connectionList, PlayerHelper playerHelper)
        {
            this.player = player;
            this.roomList = roomList;
            this.connectionList = connectionList;
            PH = playerHelper;
        }

        public string GetCurrentRoomInfo()
        {
            string message = roomList[player.EntityPosition]?.Description;

            if (roomList[player.EntityPosition].MyObject != null)
            {
                message += $" This place contains a/an {roomList[player.EntityPosition].MyObject.ObjName}.";
            }

            try
            {
                if (roomList[PH.GetLeftLocation()] != null)
                {
                    var leftConnection = connectionList[new ConnectionLocation(roomList[player.EntityPosition], roomList[PH.GetLeftLocation()])];

                    if (leftConnection != null)
                    {
                        if (leftConnection.IsOpen)
                        {
                            message += $" There is a/an {roomList[PH.GetLeftLocation()].RoomName} to your left";
                        }
                        else
                        {
                            message += $" There is a/an {leftConnection.ConnectionName} is in your left, that you may open with a/an {leftConnection.OpeningKey}";
                        }

                    }
                }

                if (roomList[PH.GetUpLocation()] != null)
                {
                    var upConnection = connectionList[new ConnectionLocation(roomList[player.EntityPosition], roomList[PH.GetUpLocation()])];

                    if (upConnection != null)
                    {
                        if (upConnection.IsOpen)
                        {
                            message += $" There is a/an {roomList[PH.GetUpLocation()].RoomName} to your left";
                        }
                        else
                        {
                            message += $" There is a/an {upConnection.ConnectionName} is in your left, that you may open with a/an {upConnection.OpeningKey}";
                        }

                    }
                }

                if (roomList[PH.GetRightLocation()] != null)
                {
                    var rightConnection = connectionList[new ConnectionLocation(roomList[player.EntityPosition], roomList[PH.GetRightLocation()])];

                    if (rightConnection != null)
                    {
                        if (rightConnection.IsOpen)
                        {
                            message += $" There is a/an {roomList[PH.GetRightLocation()].RoomName} to your left";
                        }
                        else
                        {
                            message += $" There is a/an {rightConnection.ConnectionName} is in your left, that you may open with a/an {rightConnection.OpeningKey}";
                        }

                    }
                }


                if (roomList[PH.GetDownLocation()] != null)
                {
                    var downConnection = connectionList[new ConnectionLocation(roomList[player.EntityPosition], roomList[PH.GetDownLocation()])];

                    if (downConnection != null)
                    {
                        if (downConnection.IsOpen)
                        {
                            message += $" There is a/an {roomList[PH.GetDownLocation()].RoomName} to your left";
                        }
                        else
                        {
                            message += $" There is a/an {downConnection.ConnectionName} is in your left, that you may open with a/an {downConnection.OpeningKey}";
                        }
                    }
                }
            }
            catch (System.Exception)
            {
            }


            return message;
        }
    }
}
