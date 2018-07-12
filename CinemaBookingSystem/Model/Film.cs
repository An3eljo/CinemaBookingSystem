using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Model
{
    public class Film
    {
        private static int IdCounter = 0;
        internal int Id;
        internal string Title;
        internal TimeSpan Duration;
        public static List<Film> ListOfFilms = new List<Film>();

        public Film(string title, TimeSpan duration)
        {
            this.Id = IdCounter;
            this.Title = title;
            this.Duration = duration;

            ListOfFilms.Add(this);
            IdCounter++;
        }
    }
}
