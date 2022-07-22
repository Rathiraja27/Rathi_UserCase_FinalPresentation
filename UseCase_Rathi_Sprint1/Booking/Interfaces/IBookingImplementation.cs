using Booking.ViewModel;
using System.Collections.Generic;

namespace Booking.Interfaces
{
    public interface IBookingImplementation
    {

        /// <summary>Adds the booking Details.</summary>
        /// <param name="bookingView">The booking Details.</param>
        void AddBooking(BookingViewModel bookingView);

        /// <summary>Gets the booking by email.</summary>
        /// <param name="email">The email.</param>
        /// <returns>List of Bookings</returns>
        List<BookingViewModel> GetBookingByEmail(string email);

        /// <summary>Gets the booking</summary>
        /// <returns>List of Bookings</returns>
        List<BookingViewModel> GetBookedTicketHistory();

        /// <summary>Cancels the booking using the PNR.</summary>
        /// <param name="pnr">The PNR.</param>
        void CancelBooking(string pnr);
    }
}
