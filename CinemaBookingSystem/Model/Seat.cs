using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Model
{
    public class Seat
    {
        private static int IdCounter = 0;
        internal int Id;
        internal int Row;
        internal int Column;
        public List<Tuple<Show, bool>> IsBooked;

        public Seat(int row, int column)
        {
            this.Id = IdCounter;
            this.Row = row;
            this.Column = column;
            IsBooked = new List<Tuple<Show, bool>>();

            IdCounter++;
        }
    }
}
