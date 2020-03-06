using Models.Entities;
using Models.Items;
using Models.Map;

namespace BusinessLogic
{
    public class PlayerHelper
    {
        private readonly Player player;

        public PlayerHelper(Player player)
        {
            this.player = player;
        }

        public void AddItem(GameObject addedItem)
        {
            player.MyInventory.Add(addedItem);
        }

        public Location GetLeftLocation()
        {
            return new Location(player.EntityPosition.X - 1, player.EntityPosition.Y);
        }
        public Location GetRightLocation()
        {
            return new Location(player.EntityPosition.X + 1, player.EntityPosition.Y);
        }
        public Location GetUpLocation()
        {
            return new Location(player.EntityPosition.X, player.EntityPosition.Y + 1);
        }
        public Location GetDownLocation()
        {
            return new Location(player.EntityPosition.X, player.EntityPosition.Y - 1);
        }
    }
}
