using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Ticket.Interface;
using Ticket.Models;
using Ticket.Service;

/// <summary>
/// Web Api to Fetch Ticket information using PNR
/// </summary>
namespace Ticket.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/ticket")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        #region Variable Declaration

        FlightDbContext _db;
        private readonly ILogger<TicketController> _logger;
        ITicketImplementation _ticketImplementation;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="TicketController" /> class.</summary>
        /// <param name="db">The database.</param>
        /// <param name="logger">The logger.</param>
        public TicketController(FlightDbContext db, ILogger<TicketController> logger)
        {
            _db = db;
            _logger = logger;
            _ticketImplementation = new TicketImplementation(_db);
        }

        #endregion

        #region Action Methods

        /// <summary>Posts the ticket.</summary>
        /// <param name="pnr">The PNR.</param>
        /// <returns>ActionResult OK if it is success else will return Badrequest.</returns>
        [HttpGet]
        public IActionResult GetTicket(string pnr)
        {
            try
            {
                if (pnr != null && _db.Bookings.Any(x => x.Pnr == pnr))
                {
                    _logger.LogInformation("TicketController-Passenger search by PNR");
                    return Ok(_ticketImplementation.SearchTicket(pnr));
                }

                _logger.LogInformation("TicketController-PNR is null or not found in the record");
                return BadRequest();
            }
            catch
            {
                _logger.LogInformation("TicketController-Error occurred while Searching the PNR");
                return BadRequest();
            }
        }

        #endregion
    }
}
