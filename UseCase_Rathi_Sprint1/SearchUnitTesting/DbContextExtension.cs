using Search.Models;
using System;

namespace SearchUnitTesting
{
    public static class DbContextExtension
    {
        public static void Seed(this FlightDbContext db)
        {
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
