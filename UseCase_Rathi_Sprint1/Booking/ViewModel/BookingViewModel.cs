using System;
using System.Collections.Generic;

namespace Booking.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int SeatsToBook { get; set; }
        public int FlightId { get; set; }
        public DateTime BookedOn { get; set; }
        public DateTime StartDateTime { get; set; }
        public string FromPlace {get; set; }
        public string ToPlace { get; set; }
        public string Trip { get; set; }
        public int Price { get; set; }
        public string Pnr { get; set; }
        public int CancelDuration { get; set; }
        public string IsCancelled { get; set; }
        public List<PassengerViewModel> passengers { get; set; }
    }

}
