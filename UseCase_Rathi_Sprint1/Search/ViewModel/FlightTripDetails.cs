using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.ViewModel
{
    public class FlightTripDetails
    {
        public string Trip { get; set; }

        public string SourcePlace { get; set; }

        public string DestinationPlace { get; set; }

        public DateTime startDateTime { get; set; }
    }
}
