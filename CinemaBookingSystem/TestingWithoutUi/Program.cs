using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaBookingSystem;
using CinemaBookingSystem.Model;

namespace TestingWithoutUi
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            //var printlistone = new List<string>();
            //printlistone.AddRange(new []
            //{
            //    "booking",
            //    "film",
            //    "show"
            //});
            //Console.WriteLine();
            //Console.WriteLine();
            //var firstinput = PrintOut(printlistone, true);
            //string secondInput = null;
            //switch (firstinput)
            //{
            //    case "0":
            //        var printlistsecond = new List<string>();
            //        printlistsecond.AddRange(new []
            //        {
            //            "new booking",
            //            "manage booking"
            //        });
            //        secondInput = PrintOut(printlistsecond, true);
            //        break;

            //    case "1":
                    
            //        break;

            //    case "2":
            //        break;
            //}

            //switch (secondInput)
            //{
            //    case "0":
            //        switch (firstinput)
            //        {
            //            case "0":
            //                Console.WriteLine();
            //                CreateFilm();
            //        }
            //        break;
            //}

            //string PrintOut(List<string> printList, bool shouldread = false)
            //{
            //    for (int i = 0; i < printList.Count; i++)
            //    {
            //        Console.WriteLine(i + @".  " + printList[i] + @":");
            //    }

            //    if (shouldread)
            //    {
            //        return Console.ReadLine();
            //    }

            //    return null;
            //}

            //List<T> AddToList<T>(List<T> list, T item)
            //{
            //    list.Add(item);
            //    return list;
            //}

            new ShowRoom(0, 6, 7);

            CreateFilm();
            CreateShow();
            CreateCustomer();
        }


        static void CreateFilm()
        {
            new Film("newFilm", new TimeSpan(0, 5, 2, 3));
            var t = Film.ListOfFilms;
        }

        

        static void CreateShow()
        {
            new Show(Film.ListOfFilms[0], DateTime.UtcNow, ShowRoom.ShowRooms[0]);
            var t = Show.ListOfShows;
        }

        static void CreateCustomer()
        {
            var f = new Customer(ShowRoom.ShowRooms[0].ListOfSeats[20], Show.ListOfShows[0], "Günter", "Looser");
        }
    }
}
