using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineConsumer.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int? PassengerAge { get; set; }
        public string Meal { get; set; }
        public string Seat { get; set; }
        public string Trip { get; set; }
        public int? BookingId { get; set; }
        public string Pnr { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
