﻿using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Model
{
    public class Customer
    {
        private static int IdCounter = 0;
        internal int Id;
        internal string Name;
        internal string Prename;
        internal Seat Seat;
        internal Show Show;

        //todo: better hold Customers
        public static List<Customer> CustomerList = new List<Customer>();


        public Customer(Seat seat, Show show, string name, string prename)
        {
            this.Id = IdCounter;
            this.Name = name;
            this.Prename = prename;
            this.Seat = seat;
            this.Show = show;

            try
            {
                Show.ShowRoom.ListOfSeats
                            [Show.ShowRoom.ListOfSeats.IndexOf(Seat)]
                        .IsBooked[Seat.IsBooked.IndexOf
                            (new Tuple<Show, bool>(show, false))]
                    = new Tuple<Show, bool>(show, true);
            }
            catch (Exception)
            {
                Show.ShowRoom.ListOfSeats
                        [Show.ShowRoom.ListOfSeats.IndexOf(Seat)]
                    .IsBooked.Add(new Tuple<Show, bool>(show, true));
            }

            CustomerList.Add(this);
            IdCounter++;
        }

        public void Delete()
        {
            Show.ShowRoom.ListOfSeats[Show.ShowRoom.ListOfSeats.IndexOf(Seat)]
                    .IsBooked[Seat.IsBooked.IndexOf(new Tuple<Show, bool>(Show, true))] =
                new Tuple<Show, bool>(Show, false);

            CustomerList.Remove(this);
        }
    }
}
