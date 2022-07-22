using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.ViewModel
{
    public class FlightTripSummary
    {
        public FlightTripDetails OnwardTrip { get; set; }

        public FlightTripDetails ReturnTrip { get; set; }
    }
}
