using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class Show
    {
        internal string Title;
        internal DateTime Duration;
        internal DateTime Date;
        internal double Price;
        internal ShowRoom ShowRoom;
        internal List<Customer> Customers;
        public static List<Show> ListOfShows;

        public Show(string title, DateTime duration, DateTime date, ShowRoom showRoom, double price = 10)
        {
            this.Title = title;
            this.Duration = duration;
            this.Date = date;
            this.Price = price;
            this.ShowRoom = showRoom;
            Show.ListOfShows.Add(this);
        }
    }
}
