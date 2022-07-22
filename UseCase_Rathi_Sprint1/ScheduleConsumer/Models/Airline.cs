using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleConsumer.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string AirlineStatus { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
