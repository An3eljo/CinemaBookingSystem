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
        public static List<Film> ListOfFilms = new List<Film>();

        public Film(string title, DateTime duration)
        {
            this.Title = title;
            this.Duration = duration;

            ListOfFilms.Add(this);
        }
    }
}
