using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int? PassengerAge { get; set; }
        public string Meal { get; set; }
        public string Seat { get; set; }
        public int? BookingId { get; set; }
        public string Gender { get; set; }
        public string SeatType { get; set; }
        public string ReturnSeat { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
