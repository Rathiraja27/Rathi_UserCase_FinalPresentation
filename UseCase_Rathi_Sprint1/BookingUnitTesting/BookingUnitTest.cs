using Booking.Controllers;
using Booking.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using Xunit;

namespace BookingUnitTesting
{
    public class BookingUnitTest
    {
        [Fact]
        public void TestBookTicket_ViewModelHasValue_Pass()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new BookingController(dbContext, new NullLogger<BookingController>());

            BookingViewModel viewModel = new BookingViewModel
            {
                CustomerName = "RIC",
                Email = "ric@gm.co",
                SeatsToBook = 2,
                FlightId = 1,
                passengers = new List<PassengerViewModel>
                {
                    new PassengerViewModel
                    {
                         PassengerName = "OPE",
                         PassengerAge = 6,
                         Meal = "NonVeg",
                         Seat = "4G",
                         Trip = "Oneway"
                    },

                     new PassengerViewModel
                    {
                         PassengerName = "DGU",
                         PassengerAge = 10,
                         Meal = "NonVeg",
                         Seat = "8O",
                         Trip = "Oneway"
                    }
                }
            };

            var response = controller.BookTicket(viewModel);

            dbContext.Dispose();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public void TestBookTicket_ViewModelIsNull_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new BookingController(dbContext, new NullLogger<BookingController>());
            int flightId = new int();

            BookingViewModel viewModel = null;

            var response = controller.BookTicket(viewModel);

            dbContext.Dispose();

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void TestGetBookedTicketsByEmail_ValidEmail_Pass()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new BookingController(dbContext, new NullLogger<BookingController>());

            string email = "kim@gm.co";

            var response = controller.GetBookedTicketsByEmail(email);

            dbContext.Dispose();

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void TestGetBookedTicketsByEmail_InValidEmail_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new BookingController(dbContext, new NullLogger<BookingController>());

            string email = "abc@gm.co";

            var response = controller.GetBookedTicketsByEmail(email);

            dbContext.Dispose();

            Assert.IsType<BadRequestResult>(response);
        }


        [Fact]
        public void TestCancel_InvalidValidPNR_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new BookingController(dbContext, new NullLogger<BookingController>());

            string pnr = "0af293e5-054c-4d62-a413-cb0b315b54d6";

            var response = controller.GetBookedTicketsByEmail(pnr);

            dbContext.Dispose();

            Assert.IsType<BadRequestResult>(response);
        }
    }
}
