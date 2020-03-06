namespace Models.Map
{
    public class Level
    {
        #region Adattagok

        public string LevelName;
        private Room[] rooms;
        private int[] connections;

        #endregion

        #region Propertyk

        public Room[] MyRooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
            }
        }

        public int[] MyConnections
        {
            get
            {
                return connections;
            }
            set
            {
                connections = value;
            }
        }

        //Ezt a kettőt settelni nem fogjuk, különben összeomlik a pálya szerkezete
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        #endregion

        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="levelName"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Level(string levelName, int rows, int columns)
        {
            LevelName = levelName;
            Rows = rows;
            Columns = columns;
            MyRooms = new Room[(rows * columns)];
            MyConnections = new int[(rows * columns) ^ 2]; //Ebből csak az alsó háromszögre lesz szükség
        }

        #endregion

    }//endofclass
}//endofcode
