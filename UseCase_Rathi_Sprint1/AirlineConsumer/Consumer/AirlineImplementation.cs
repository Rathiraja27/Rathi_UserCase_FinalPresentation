using AirlineConsumer.Interfaces;
using AirlineConsumer.Models;
using Common;

namespace AirlineConsumer.Consumer
{
    public class AirlineImplementation : IAirlineImplementation
    {
        #region Variable declaration

        FlightDbContext _db = new FlightDbContext();

        #endregion

        #region Public Methods

        /// <summary>Adds the airline details.</summary>
        /// <param name="airlineView">The airline details.</param>
        public void AddAirline(AirlineEvent airlineView)
        {
            try
            {
                Airline airline = new Airline
                {
                    Address = airlineView.Address,
                    AirlineName = airlineView.AirlineName,
                    AirlineStatus = airlineView.AirlineStatus,
                    Description = airlineView.Description,
                    Logo = airlineView.Logo,
                    PhoneNumber = airlineView.PhoneNumber
                };

                _db.Airlines.Add(airline);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }
}
