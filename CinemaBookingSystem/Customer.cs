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
        internal Film Film;

        public Customer(Seat seat, Film film, string name = null, string prename = null)
        {
            this.Name = name;
            this.Prename = prename;
            this.Seat = seat;
            this.Film = film;

            Seat.IsBooked.Add(new Tuple<Film, bool>(film, true));

            Film.Customers.Add(this);
        }
    }
}
