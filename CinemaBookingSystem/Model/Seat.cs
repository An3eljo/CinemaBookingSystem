using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Model
{
    public class Seat
    {
        public List<Tuple<Show, bool>> IsBooked;
        internal int Row;
        internal int Column;

        public Seat(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            IsBooked = new List<Tuple<Show, bool>>();
        }
    }
}
