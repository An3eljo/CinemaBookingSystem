using System;
using System.Collections.Generic;
using CinemaBookingSystem.Library;

namespace CinemaBookingSystem.Model
{
    static class Init
    {
        public static void Initialize()
        {
            Errors.Init();
            Navigation.PageChange += Navigation.OnPageChanged;

            //todo: remove when program is finished
            InitForTest();
        }

        private static void InitForTest()
        {
            var list = new List<ShowRoom>();
            list.AddRange(new[]
            {
                //new Tuple<int, int, int>(1, 10, 40),
                //new Tuple<int, int, int>(2, 3, 5),
                //new Tuple<int, int, int>(3, 6, 15),
                //new Tuple<int, int, int>(5, 10, 18),
                //new Tuple<int, int, int>(7, 20, 30),
                new ShowRoom(1, 10, 40),
                new ShowRoom(2, 3, 5),
                new ShowRoom(3, 6, 15),
                new ShowRoom(5, 10, 18),
                new ShowRoom(7, 20, 30),
            });
            ShowRoom.ShowRooms = list;


            new Show(new Film("Solo: A Star Wars Story", new TimeSpan(0, 1, 40, 20)),
                new DateTime(2018, 05, 25, 19, 50, 0), ShowRoom.ShowRooms[0], 7);

            new Show(new Film("I Feel Pretty", new TimeSpan(0, 1, 50, 33)),
                new DateTime(2018, 05, 25, 20, 45, 0), ShowRoom.ShowRooms[1]);

            new Show(new Film("Avengers: Infinity War", new TimeSpan(2, 40, 0)),
                new DateTime(2018, 05, 25, 18, 45, 0), ShowRoom.ShowRooms[3]);

            new Show(new Film("Deadpool 2", new TimeSpan(2, 13, 0)), new DateTime(2018, 05, 25, 19, 20, 0),
                ShowRoom.ShowRooms[2]);

            new Show(new Film("Jim Knopf und Lukas der Lokomotivführer", new TimeSpan(2, 27, 0)),
                new DateTime(2018, 05, 25, 18, 45, 0), ShowRoom.ShowRooms[2]);
        }
    }
}
