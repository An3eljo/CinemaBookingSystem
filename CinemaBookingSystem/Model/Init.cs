using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Model
{
    static class Init
    {
        public static void Initialize()
        {
            var list = new List<Tuple<int, int, int>>();
            list.AddRange(new[]
            {
                new Tuple<int, int, int>(1, 10, 40),
                new Tuple<int, int, int>(2, 3, 5),
                new Tuple<int, int, int>(3, 6, 15),
                new Tuple<int, int, int>(5, 10, 18),
                new Tuple<int, int, int>(7, 20, 30),
            });
            ShowRooms.Create(list);


            new Show(new Film("Solo: A Star Wars Story", new DateTime().AddHours(1).AddMinutes(40).AddSeconds(20)),
                new DateTime(2018, 05, 25, 19, 50, 0), ShowRooms.ShowRoomList[0], 7);

            new Show(new Film("I Feel Pretty", new DateTime().AddHours(1).AddMinutes(50).AddSeconds(33)),
                new DateTime(2018, 05, 25, 20, 45, 0), ShowRooms.ShowRoomList[1]);

            new Show(new Film("Avengers: Infinity War", new DateTime().AddHours(2).AddMinutes(40)),
                new DateTime(2018, 05, 25, 18, 45, 0), ShowRooms.ShowRoomList[3]);

            new Show(new Film("Deadpool 2", new DateTime().AddHours(2).AddMinutes(13)), new DateTime(2018, 05, 25, 19, 20, 0),
                ShowRooms.ShowRoomList[2]);

            new Show(new Film("Jim Knopf und Lukas der Lokomotivführer", new DateTime().AddHours(2).AddMinutes(27)),
                new DateTime(2018, 05, 25, 18, 45, 0), ShowRooms.ShowRoomList[2]);
        }
    }
}
