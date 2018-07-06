using System;

namespace CinemaBookingSystem.Model
{
    public class Customer
    {
        //todo: somwhere hold customer
        internal string Name;
        internal string Prename;
        internal Seat Seat;
        internal Show Show;


        public Customer(Seat seat, Show show, string name, string prename)
        {
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
        }
    }
}
