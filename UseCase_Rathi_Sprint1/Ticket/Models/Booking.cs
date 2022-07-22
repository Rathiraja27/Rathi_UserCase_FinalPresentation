using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int? SeatsToBook { get; set; }
        public int? FlightId { get; set; }
        public DateTime? BookedOn { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public int? Price { get; set; }
        public string Pnr { get; set; }
        public string Trip { get; set; }

        public virtual Schedule Flight { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
