using Airline.Controllers;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Xunit;

namespace AirlineUnitTesting
{
    public class AirlineUnitTest
    {

        [Fact]
        public void TestAirlineRegister_ViewModelHasValue_Pass()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new AirlineController();

            AirlineEvent viewModel = new AirlineEvent
            {
                Address = "XYZ",
                AirlineName = "XYZ Airlines",
                AirlineStatus = "Active",
                Description = "Good",
                Logo = "path7",
                PhoneNumber = "34567890122"
            };

            var response = controller.RegisterAirline(viewModel);

            dbContext.Dispose();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public void TestAirlineRegister_ViewModelIsNull_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new AirlineController();

            AirlineEvent viewModel = null;
            var response = controller.RegisterAirline(viewModel);

            dbContext.Dispose();

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void TestAirlineAddInventory_ViewModelHasValue_Pass()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new AirlineController();

            ScheduleEvent viewModel = new ScheduleEvent
            {
                FlightName = "Rathi",
                InstrumentUsed = "BHABHA",
                FromPlace = "Kerala",
                ToPlace = "Pondicherry",
                StartDateTime = Convert.ToDateTime("2022-07-27T00:00:00"),
                EndDateTime = Convert.ToDateTime("2022-07-28T00:00:00"),
                SceduledDays = "Daily",
                BusinessClassSeats = 10,
                NonBusinessClassSeats = 30,
                TicketPrice = 2000,
                Rows = 10,
                Meal = "Veg",
                AirlineId = 2
            };

            var response = controller.RegisterInventory(viewModel);

            dbContext.Dispose();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public void TestAirlineAddInventory_ViewModelHasValue_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new AirlineController();

            ScheduleEvent viewModel = null;

            var response = controller.RegisterInventory(viewModel);

            dbContext.Dispose();

            Assert.IsType<BadRequestResult>(response);
        }
    }
}
