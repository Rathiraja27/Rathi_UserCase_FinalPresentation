using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
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

        public virtual Schedule Flight { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
