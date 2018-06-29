using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Model
{
    public class Film
    {
        internal string Title;
        internal TimeSpan Duration;
        public static List<Film> ListOfFilms = new List<Film>();

        public Film(string title, TimeSpan duration)
        {
            this.Title = title;
            this.Duration = duration;

            ListOfFilms.Add(this);
        }
    }
}
