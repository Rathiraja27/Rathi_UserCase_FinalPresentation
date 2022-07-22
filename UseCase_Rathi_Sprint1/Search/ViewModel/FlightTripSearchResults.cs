using Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.ViewModel
{
    public class FlightTripSearchResults
    {
       public List<Schedule> onwardFlightResults { get; set; }

        public List<Schedule> returnFlightResults { get; set; }
    }
}
