using Models.Entities;
using Models.Map;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class MoveHelper
    {
        private Player player;
        private readonly Dictionary<Location, Room> roomList;
        private readonly Dictionary<ConnectionLocation, RoomConnection> connectionList;
        private readonly PlayerHelper playerHelper;

        public MoveHelper(
            Player player,
            Dictionary<Location, Room> roomList,
            Dictionary<ConnectionLocation, RoomConnection> connectionList,
            PlayerHelper playerHelper)
        {
            this.player = player;
            this.roomList = roomList;
            this.connectionList = connectionList;
            this.playerHelper = playerHelper;
        }

        public string Move(string Direction)
        {
            if (CanMove(Direction))
            {
                DoMove(Direction);
                return ("You moved " + Direction + ".");

            }
            else
            {
                return ("Can't move " + Direction + ".");
            }
        }


        public bool CanMove(string Direction)
        {
            try
            {
                switch (Direction)
                {
                    case "Left":
                        if (roomList[playerHelper.GetLeftLocation()] != null)
                        {
                            var PlayerLocationVarLeft = new Location(player.EntityPosition.X, player.EntityPosition.Y);

                            var ConnectionLocationVarLeft = new ConnectionLocation(
                                roomList[PlayerLocationVarLeft],
                                roomList[playerHelper.GetLeftLocation()]);


                            if (connectionList[ConnectionLocationVarLeft] == null || connectionList[ConnectionLocationVarLeft].IsOpen == true && roomList[playerHelper.GetLeftLocation()] != null)
                            {
                                return true;
                            }
                        }
                        break;
                    case "Right":
                        if (roomList[playerHelper.GetRightLocation()] != null)
                        {
                            var PlayerLocationVarRight = new Location(player.EntityPosition.X, player.EntityPosition.Y);

                            var ConnectionLocationVarRight = new ConnectionLocation(
                                roomList[PlayerLocationVarRight],
                                roomList[playerHelper.GetRightLocation()]);


                            if (connectionList[ConnectionLocationVarRight] == null || connectionList[ConnectionLocationVarRight].IsOpen == true && roomList[playerHelper.GetRightLocation()] != null)
                            {
                                return true;
                            }
                        }
                        break;
                    case "Up":
                        if (roomList[playerHelper.GetUpLocation()] != null)
                        {
                            var PlayerLocationVarUp = new Location(player.EntityPosition.X, player.EntityPosition.Y);

                            var ConnectionLocationVarUp = new ConnectionLocation(
                                roomList[PlayerLocationVarUp],
                                roomList[playerHelper.GetUpLocation()]);


                            if (connectionList[ConnectionLocationVarUp] == null || connectionList[ConnectionLocationVarUp].IsOpen == true && roomList[playerHelper.GetUpLocation()] != null)
                            {
                                return true;
                            }
                        }
                        break;
                    case "Down":
                        if (roomList[playerHelper.GetDownLocation()] != null)
                        {
                            var PlayerLocationVarDown = new Location(player.EntityPosition.X, player.EntityPosition.Y);

                            var ConnectionLocationVarDown = new ConnectionLocation(
                                roomList[PlayerLocationVarDown],
                                roomList[playerHelper.GetDownLocation()]);


                            if (connectionList[ConnectionLocationVarDown] == null || connectionList[ConnectionLocationVarDown].IsOpen == true && roomList[playerHelper.GetDownLocation()] != null)
                            {
                                return true;
                            }
                        }
                        break;
                    default:
                        break;
                }
                return false;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }

        private void DoMove(string Direction)
        {
            switch (Direction)
            {
                case "Left":
                    player.EntityPosition = new Location(player.EntityPosition.X - 1, player.EntityPosition.Y + 0);
                        break;
                case "Right":
                    player.EntityPosition = new Location(player.EntityPosition.X + 1, player.EntityPosition.Y + 0);
                    break;
                case "Up":
                    player.EntityPosition = new Location(player.EntityPosition.X + 0, player.EntityPosition.Y + 1);
                    break;
                case "Down":
                    player.EntityPosition = new Location(player.EntityPosition.X + 0, player.EntityPosition.Y - 1);
                    break;
                default:
                    break;
            }
            
        }
    }
}





