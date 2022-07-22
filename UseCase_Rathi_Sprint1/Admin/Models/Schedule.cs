using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Bookings = new HashSet<Booking>();
        }

        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string InstrumentUsed { get; set; }
        public int? AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string SceduledDays { get; set; }
        public int? BusinessClassSeats { get; set; }
        public int? NonBusinessClassSeats { get; set; }
        public int? TicketPrice { get; set; }
        public int? Rows { get; set; }
        public string Meal { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
