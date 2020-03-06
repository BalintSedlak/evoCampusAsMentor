using Models.Entities;
using Models.Items;

namespace Models.Map
{
    public class RoomConnection
    {
        public string ConnectionName { get; private set; }

        public bool IsOpen { get; set; }

        public Key OpeningKey { get; private set; }

        //private readonly Player player;

        public RoomConnection(string ConnectionName, Key OpeningKey/*, Player player*/)
        {
            this.ConnectionName = ConnectionName;
            this.OpeningKey = OpeningKey;
            // this.player = player; (why did we do this)
        }
    }
}
