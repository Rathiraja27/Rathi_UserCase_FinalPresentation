using Airline.Models;
using System;

namespace AirlineUnitTesting
{
    public static class DbContextExtension
    {
        public static void Seed(this FlightDbContext db)
        {
            db.Airlines.Add(new Airline.Models.Airline
            {
                AirlineName = "UAE Airlines",
                PhoneNumber = "2345678904",
                Address = "UAE",
                AirlineStatus = "Active",
                Description = "Excel",
                Logo = "Path4"
            });

            db.Airlines.Add(new Airline.Models.Airline
            {
                AirlineName = "ABC Airlines",
                PhoneNumber = "2345678906",
                Address = "ABC",
                AirlineStatus = "Active",
                Description = "Excel",
                Logo = "Path4"
            });

            db.Schedules.Add(new Schedule
            {
                FlightName = "ALK",
                InstrumentUsed = "BAH",
                FromPlace = "Banglore",
                ToPlace = "Kerala",
                StartDateTime = Convert.ToDateTime("2022-07-17T00:00:00"),
                EndDateTime = Convert.ToDateTime("2022-07-18T00:00:00"),
                SceduledDays = "Weekends",
                BusinessClassSeats = 10,
                NonBusinessClassSeats = 30,
                TicketPrice = 2000,
                Rows = 10,
                Meal = "NonVeg",
                AirlineId = 1
            });

            db.Schedules.Add(new Schedule
            {
                FlightName = "ALMJ",
                InstrumentUsed = "BHA",
                FromPlace = "Delhi",
                ToPlace = "Kolkata",
                StartDateTime = Convert.ToDateTime("2022-07-20T00:00:00"),
                EndDateTime = Convert.ToDateTime("2022-07-21T00:00:00"),
                SceduledDays = "Daily",
                BusinessClassSeats = 10,
                NonBusinessClassSeats = 30,
                TicketPrice = 2000,
                Rows = 10,
                Meal = "Veg",
                AirlineId = 2
            });

            db.SaveChanges();
        }
    }
}
