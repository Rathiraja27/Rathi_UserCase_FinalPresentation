using Common;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

/// <summary>
/// Web API to store the Airline Details into the Database.
/// </summary>
namespace Airline.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/airline")]
    [ApiController]
    [Authorize]
    public class AirlineController : ControllerBase
    {

        #region Variable declaration

        private readonly IBus bus;
        private readonly ILogger<AirlineController> _logger;

        #endregion

        #region Constructor

        public AirlineController(IBus _bus, ILogger<AirlineController> logger)
        {
            bus = _bus;
            _logger = logger;
        }

        #endregion

        #region Action Methods

        /// <summary>Registers the airline.</summary>
        /// <param name="airline">The airline details.</param>
        /// <returns>ActionResult OK if it is added else BadRequest</returns>
        [HttpPost, Route("register")]
        public async Task<IActionResult> RegisterAirline(AirlineEvent airline)
        {
            if (airline != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/registerairline");
                var endpoint = await bus.GetSendEndpoint(uri);
                await endpoint.Send(airline);
                return Ok();
            }

            _logger.LogError("AirlineController-Error while calling the Airline consumer from Producer");
            return BadRequest();
        }


        /// <summary>Registers the inventory.</summary>
        /// <param name="airline">The airline.</param>
        /// <returns>ActionResult OK if it is added else BadRequest</returns>
        [HttpPost, Route("inventory/add")]
        public async Task<IActionResult> RegisterInventory(ScheduleEvent airline)
        {
            if (airline != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/registerairline");
                var endpoint = await bus.GetSendEndpoint(uri);
                await endpoint.Send(airline);
                return Ok();
            }

            _logger.LogError("AirlineController-Error while calling the Schedule consumer from Producer");
            return BadRequest();
        }

        #endregion
    }
}
