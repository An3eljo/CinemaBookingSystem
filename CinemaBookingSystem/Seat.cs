using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class Seat
    {
        internal List<Tuple<Show, bool>> IsBooked;
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
