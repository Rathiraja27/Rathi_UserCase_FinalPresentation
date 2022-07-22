using Booking.Interfaces;
using Booking.Models;
using Booking.Service;
using Booking.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Booking.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        #region Variable Declaration

        FlightDbContext _db;
        IBookingImplementation _bookingImplementation;
        private readonly ILogger<BookingController> _logger;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="BookingController" /> class.</summary>
        /// <param name="db">The database.</param>
        /// <param name="logger">The logger.</param>
        public BookingController(FlightDbContext db, ILogger<BookingController> logger)
        {
            _db = db;
            _logger = logger;
            _bookingImplementation = new BookingImplementation(_db);
        }

        #endregion

        #region Action Results

        /// <summary>Books the ticket.</summary>
        /// <param name="flightid">The flightid.</param>
        /// <param name="bookingView">The booking view.</param>
        /// <returns>Returns OK if ticket is booked successfully else BadRequest</returns>
        [HttpPost]
        public IActionResult BookTicket(BookingViewModel bookingView)
        {
            try
            {
                if (bookingView != null && bookingView.passengers != null)
                {
                    _bookingImplementation.AddBooking(bookingView);
                    _logger.LogInformation("BookingController-Booking Information Added successfully");
                    return Ok();
                }

                _logger.LogInformation("BookingController-Booking Information is empty");
                return BadRequest();
            }
            catch
            { 
                _logger.LogError("BookingController-Error while adding Booking information to the database");
                return BadRequest();
            }
        }


        /// <summary>Gets the booked tickets by email.</summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns OK if ticket is fetched using Email else BadRequest</returns>
        [HttpGet, Route("history")]
        public IActionResult GetBookedTicketsByEmail(string email)
        {
            try
            {
                if (email != null && _db.Bookings.Any(x => x.Email == email))
                {
                    var data = _bookingImplementation.GetBookingByEmail(email);
                    _logger.LogInformation("BookingController-Booked Tickets Filtered by Email");
                    return Ok(data);
                }

                _logger.LogInformation("BookingController-Email Id is empty or it does not match with the record");
                return BadRequest();
            }
            catch
            {
                _logger.LogError("BookingController-Error occurred while filtering tickets by Email");
                return BadRequest();
            }
        }

        /// <summary>Gets the booked tickets</summary>
        /// <returns>Returns OK if ticket is fetched using Email else BadRequest</returns>
        [HttpGet, Route("bookedHistory")]
        public IActionResult GetBookedTicketHistory()
        {
            try
            {
                var data = _bookingImplementation.GetBookedTicketHistory();
                _logger.LogInformation("BookingController-Booked Tickets History");
                return Ok(data);

            }
            catch
            {
                _logger.LogError("BookingController-Error occurred while filtering tickets");
                return BadRequest();
            }
        }

        /// <summary>Cancels the specified PNR.</summary>
        /// <param name="pnr">the PNR</param>
        /// <returns>Returns OK if ticket is cancelled using PNR else BadRequest </returns>
        [HttpPut, Route("cancel/{pnr}")]
        public IActionResult Cancel(string pnr)
        {
            try
            {
                if (pnr != null && _db.Bookings.Any(x => x.Pnr == pnr))
                {
                    _bookingImplementation.CancelBooking(pnr);
                    _logger.LogInformation("BookingController-Booking Cancelled successfully");
                    return Ok();
                }

                _logger.LogInformation("BookingController-PNR is empty or it does not match with the record");
                return BadRequest();
            }
            catch
            {
                _logger.LogError("BookingController-Error occured while cancelling booking");
                return BadRequest();
            }
        }

        #endregion
    }
}
