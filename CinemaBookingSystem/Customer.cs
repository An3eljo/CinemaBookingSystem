using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class Customer
    {
        internal string Name;
        internal string Prename;
        internal Seat Seat;
        internal Show Show;

        public Customer(Seat seat, Show show, string name = null, string prename = null)
        {
            this.Name = name;
            this.Prename = prename;
            this.Seat = seat;
            this.Show = show;

            Seat.IsBooked[Seat.IsBooked.IndexOf(new Tuple<Show, bool>(show, false))] = null;

            var t = Show.ListOfShows[0].ShowRoom.ListOfSeats[0].IsBooked[0].Item1;

            Seat.IsBooked.Add(new Tuple<Show, bool>(show, true));

        }
    }
}
