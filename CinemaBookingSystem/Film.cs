using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class Film
    {
        internal string Title;
        internal DateTime Duration;
        internal DateTime Date;
        internal double Price;
        internal ShowRoom ShowRoom;
        public static List<Film> ListOFilms;

        public Film(string title, DateTime duration, DateTime date, ShowRoom showRoom, double price = 10)
        {
            this.Title = title;
            this.Duration = duration;
            this.Date = date;
            this.Price = price;
            this.ShowRoom = showRoom;
            Film.ListOFilms.Add(this);
        }
    }
}
