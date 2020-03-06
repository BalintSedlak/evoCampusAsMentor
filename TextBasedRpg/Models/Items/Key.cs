namespace Models.Items
{
    public class Key : GameObject
    {
        public Key(int objID, string objName) : base(objID, objName)
        {
        }

        public override string ToString()
        {
            return ObjName;
        }

        public override int GetHashCode()
        {
            return ObjID.GetHashCode() + ObjName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Key other = obj as Key;

            if (other == null)
            {
                return false;
            }

            if (this.ObjID != other.ObjID || this.ObjName != other.ObjName)
            {
                return false;
            }

            return true;
        }
    }
}
