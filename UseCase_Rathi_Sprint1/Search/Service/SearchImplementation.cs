using Interface.Search;
using Search.Models;
using Search.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Search.Service
{
    public class SearchImplementation : ISearchImplementation
    {
        #region Variable Declaration

        FlightDbContext _db;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="SearchImplementation" /> class.</summary>
        /// <param name="db">The database.</param>
        public SearchImplementation(FlightDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Public Methods

        /// <summary>Finds the schedules.</summary>
        /// <param name="place">The place.</param>
        /// <returns>List of Schedules</returns>
        public FlightTripSearchResults FindSchedules(FlightTripSummary summary)
        {
            FlightTripSearchResults results = new FlightTripSearchResults();
            results.onwardFlightResults = new List<Schedule>();
            results.returnFlightResults = new List<Schedule>();

            if(summary.OnwardTrip != null)
            {
                var onwardFlight = from flight in _db.Schedules
                                   where summary.OnwardTrip.SourcePlace == flight.FromPlace &&
                                   summary.OnwardTrip.DestinationPlace == flight.ToPlace &&
                                   summary.OnwardTrip.startDateTime == flight.StartDateTime
                                   select flight;
                results.onwardFlightResults = onwardFlight.ToList();
            }

            if (summary.ReturnTrip.SourcePlace != null)
            {
                var returnFlight = from flight in _db.Schedules
                                   where summary.ReturnTrip.SourcePlace == flight.FromPlace &&
                                   summary.ReturnTrip.DestinationPlace == flight.ToPlace &&
                                   summary.ReturnTrip.startDateTime == flight.StartDateTime
                                   select flight;
                results.returnFlightResults = returnFlight.ToList();
            }

            return results;
        }

        #endregion
    }
}
