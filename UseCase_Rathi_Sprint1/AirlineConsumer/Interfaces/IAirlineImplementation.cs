using Common;

namespace AirlineConsumer.Interfaces
{
    public interface IAirlineImplementation
    {
        /// <summary>Adds the airline details.</summary>
        /// <param name="airlineView">The airline details.</param>
        void AddAirline(AirlineEvent airlineView);

    }
}
