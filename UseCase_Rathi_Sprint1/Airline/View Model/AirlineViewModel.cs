using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.View_Model
{
    public class AirlineViewModel
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string AirlineStatus { get; set; }
    }
}
