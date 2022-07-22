using System;

namespace Common
{
    public class ScheduleEvent
    {
        public string FlightName { get; set; }
        public string InstrumentUsed { get; set; }
        public int AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string SceduledDays { get; set; }
        public int BusinessClassSeats { get; set; }
        public int NonBusinessClassSeats { get; set; }
        public int TicketPrice { get; set; }
        public int Rows { get; set; }
        public string Meal { get; set; }
    }
}
