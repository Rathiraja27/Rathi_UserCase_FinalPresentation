using Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AirlineConsumer.Consumer
{
    public class AirlineConsumerImplementation : IConsumer<AirlineEvent>
    {
        #region Variable Declaration

        private readonly ILogger<AirlineConsumerImplementation> _logger;
        AirlineServiceImplementation _implementation;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="AirlineConsumerImplementation" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AirlineConsumerImplementation(ILogger<AirlineConsumerImplementation> logger)
        {
            _logger = logger;
            _implementation = new AirlineServiceImplementation();
        }

        #endregion

        #region Consumer Methods

        /// <summary>Consumes the specified Airline Details.</summary>
        /// <param name="context">The context.</param>
        public async Task Consume(ConsumeContext<AirlineEvent> context)
        {
            try
            {
                _implementation.Register(context.Message);
                _logger.LogInformation("AirlineConsumerImplementation-Airline Details added successfully");
            }
            catch
            {
                _logger.LogError("AirlineConsumerImplementation-Error while adding the Airline Details to the database");
            }
            
        }

        #endregion
    }
}
