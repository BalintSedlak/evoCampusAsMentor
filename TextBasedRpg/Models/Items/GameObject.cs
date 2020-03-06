using Models.Map;

namespace Models.Items
{
    public class GameObject
    {
        #region Propertyk

        public int ObjID { get; private set; }
        public string ObjName { get; private set; }

        public int WhereTheObjetIsByRoomIndex { get; set; }

        #endregion

        public GameObject(int objID, string objName)
        {
            ObjID = objID;
            ObjName = objName;
        }

        public override int GetHashCode()
        {
            return ObjID.GetHashCode() + ObjName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            GameObject other = obj as GameObject;

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
