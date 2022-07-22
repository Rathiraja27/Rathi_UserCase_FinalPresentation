using AirlineConsumer.Interfaces;
using Common;

namespace AirlineConsumer.Consumer
{
    public class AirlineServiceImplementation
    {
        #region Variable Declaration

        IAirlineImplementation _airlineImplementation;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="AirlineServiceImplementation" /> class.</summary>
        public AirlineServiceImplementation()
        {
            _airlineImplementation = new AirlineImplementation();
        }

        #endregion

        #region Public Methods

        /// <summary>Registers the specified Airline Details.</summary>
        /// <param name="airlineView">The airline view.</param>
        public void Register(AirlineEvent airlineView)
        {

            if (airlineView != null)
            {
                _airlineImplementation.AddAirline(airlineView);
            }
        }

        #endregion
    }
}
