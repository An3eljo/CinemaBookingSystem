using System;
using CinemaBookingSystem.Model;

namespace TestingWithoutUi
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new ShowRoom(0, 6, 7);

            CreateFilm();
            CreateShow();
            CreateCustomer();
        }


        static void CreateFilm()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Film("newFilm", new TimeSpan(0, 5, 2, 3));
            var t = Film.ListOfFilms;
        }

        

        static void CreateShow()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Show(Film.ListOfFilms[0], DateTime.UtcNow, ShowRoom.ShowRooms[0]);
            var t = Show.ListOfShows;
        }

        static void CreateCustomer()
        {
            var f = new Customer(ShowRoom.ShowRooms[0].ListOfSeats[20], Show.ListOfShows[0], "Günter", "Looser");
        }
    }
}
