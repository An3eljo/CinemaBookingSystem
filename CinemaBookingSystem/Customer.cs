﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class Customer
    {
        internal string Name;
        internal string Prename;
        internal Seat Seat;
        internal Show Show;

        public Customer(Seat seat, Show film, string name = null, string prename = null)
        {
            this.Name = name;
            this.Prename = prename;
            this.Seat = seat;
            this.Show = film;

            Seat.IsBooked.Find().

            Seat.IsBooked.Add(new Tuple<Show, bool>(film, true));

        }
    }
}
