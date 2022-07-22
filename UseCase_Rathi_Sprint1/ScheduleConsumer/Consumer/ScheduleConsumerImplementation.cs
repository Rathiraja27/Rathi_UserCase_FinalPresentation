using Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ScheduleConsumer.Consumer
{
    public class ScheduleConsumerImplementation : IConsumer<ScheduleEvent>
    {
        #region Variable Declaration

        private readonly ILogger<ScheduleConsumerImplementation> _logger;
        ScheduleServiceImplementation _implementation;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="ScheduleConsumerImplementation" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public ScheduleConsumerImplementation(ILogger<ScheduleConsumerImplementation> logger)
        {
            _logger = logger;
            _implementation = new ScheduleServiceImplementation();
        }

        #endregion

        #region Consumer Methods

        /// <summary>Consumes the Schedule Details.</summary>
        /// <param name="context">The context.</param>
        public async Task Consume(ConsumeContext<ScheduleEvent> context)
        {
            try
            {
                _implementation.AddInventory(context.Message);
                _logger.LogInformation("ScheduleConsumerImplementation-Schedule Details added successfully");
            }
            catch
            {
                _logger.LogError("ScheduleConsumerImplementation-Error while adding the Schedule Details to the database");
            }

        }

        #endregion
    }
}
