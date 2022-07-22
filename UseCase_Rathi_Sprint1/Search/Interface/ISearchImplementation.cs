using Search.Models;
using Search.ViewModel;
using System.Collections.Generic;

namespace Interface.Search
{
    public interface ISearchImplementation
    {

        /// <summary>Finds the schedules.</summary>
        /// <returns>List of Schedules</returns>
        FlightTripSearchResults FindSchedules(FlightTripSummary summary);
    }
}
