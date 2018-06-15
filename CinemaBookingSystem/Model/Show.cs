using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class Show
    {
        internal Film Film;
        internal DateTime Date;
        internal double Price;
        internal ShowRoom ShowRoom;
        public static List<Show> ListOfShows = new List<Show>();

        public Show(Film film, DateTime date, ShowRoom showRoom, double price = 10)
        {
            this.Film = film;
            this.Date = date;
            this.Price = price;
            this.ShowRoom = showRoom;
            ListOfShows.Add(this);
        }
    }
}
