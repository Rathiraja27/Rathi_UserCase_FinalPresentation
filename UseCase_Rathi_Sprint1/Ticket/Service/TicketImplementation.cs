using System.Linq;
using Ticket.Interface;
using Ticket.Models;

namespace Ticket.Service
{
    public class TicketImplementation : ITicketImplementation
    {
        #region Variable declaration

        FlightDbContext _db;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="TicketImplementation" /> class.</summary>
        /// <param name="db">The database.</param>
        public TicketImplementation(FlightDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Public Methods

        /// <summary>Searches the ticket.</summary>
        /// <param name="pnr">The PNR.</param>
        /// <returns>Passenger details based on the PNR</returns>
        public Booking SearchTicket(string pnr)
        {
            var data = _db.Bookings.Where(x => x.Pnr == pnr).FirstOrDefault();
            return data;
        }

        #endregion
    }
}
