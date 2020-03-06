namespace Models.Map
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Location other = obj as Location;

            if (other == null)
            {
                return false;
            }

            if (this.X != other.X || this.Y != other.Y)
            {
                return false;
            }

            return true;
        }
    }
}
