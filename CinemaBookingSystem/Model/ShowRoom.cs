using System.Collections.Generic;

namespace CinemaBookingSystem.Model
{
    public sealed class ShowRoom
    {
        //Not used
        #region Singleton

        //private static volatile ShowRoom _instance;
        //private static object locker = new object();

        //public static ShowRoom Instance
        //{
        //    get
        //    {
        //        lock (locker)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new ShowRoom();
        //            }
        //        }

        //        return _instance;
        //    }
        //}

        #endregion


        internal int RoomNumber;
        internal int RowsCount;
        internal int ColumnsCount;
        public List<Seat> ListOfSeats = new List<Seat>();
        public static List<ShowRoom> ShowRooms;


        public ShowRoom(int roomNumber, int rows, int columns)
        {
            this.RoomNumber = roomNumber;
            this.RowsCount = rows;
            this.ColumnsCount = columns;
            
            MakeShowRoomInterior(rows, columns);
            if (ShowRooms == null)
            {
                ShowRooms = new List<ShowRoom>();
            }
            ShowRooms.Add(this);
        }

        private void MakeShowRoomInterior(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ListOfSeats.Add(new Seat(i, j));
                }
            }
        }

        public ShowRoom()
        {
            
        }
    }
}
