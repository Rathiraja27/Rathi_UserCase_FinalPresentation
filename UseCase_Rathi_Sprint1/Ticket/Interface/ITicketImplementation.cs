using Ticket.Models;

namespace Ticket.Interface
{
    public interface ITicketImplementation
    {
        /// <summary>Searches the ticket.</summary>
        /// <param name="pnr">The PNR.</param>
        /// <returns>Passenger details based on the PNR</returns>
        Booking SearchTicket(string pnr);
    }
}
