namespace Models.Map
{
    public class ConnectionLocation
    {
        public Room RoomA { get; private set; }
        public Room RoomB { get; private set; }

        public ConnectionLocation(Room RoomA, Room RoomB)
        {
            if (RoomA.RoomID < RoomB.RoomID)
            {
                this.RoomA = RoomA;
                this.RoomB = RoomB;
            }
            else
            {
                this.RoomA = RoomB;
                this.RoomB = RoomA;
            }
            
        }

        public override int GetHashCode()
        {
            return RoomA.GetHashCode() + RoomB.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ConnectionLocation other = obj as ConnectionLocation;

            if (other == null)
            {
                return false;
            }

            if (this.RoomA != other.RoomA || this.RoomB != other.RoomB)
            {
                return false;
            }

            return true;
        }
    }
}