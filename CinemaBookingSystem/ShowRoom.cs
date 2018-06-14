﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class ShowRoom
    {
        internal int RoomNumber;
        internal int RowsCount;
        internal int ColumnsCount;
        internal List<Seat> ListOfSeats = new List<Seat>();

        public ShowRoom(int roomNumber, int rows, int columns)
        {
            this.RoomNumber = roomNumber;
            this.RowsCount = rows;
            this.ColumnsCount = columns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ListOfSeats.Add(new Seat(i, j));
                }
            }

            ShowRooms.ShowRoomList.Add(this);
        }
    }
}
