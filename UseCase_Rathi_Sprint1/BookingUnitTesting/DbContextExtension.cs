using Booking.Models;
using System;

namespace BookingUnitTesting
{
    public static class DbContextExtension
    {
        public static void Seed(this FlightDbContext db)
        {
            db.Bookings.Add(new Booking.Models.Booking
            {
                CustomerName = "KIM",
                Email = "kim@gm.co",
                SeatsToBook = 2,
                FlightId = 2,
                BookedOn = Convert.ToDateTime("2022-07-02 19:36:57.070")
            }) ;

            AddPassenger(db);

            db.SaveChanges();
        }

        private static void AddPassenger(FlightDbContext db)
        {

            db.Passengers.Add(new Passenger
            {
                PassengerName = "DEF",
                PassengerAge = 5,
                Meal = "NonVeg",
                Seat = "8B",
            });

            db.Passengers.Add(new Passenger
            {
                PassengerName = "FEH",
                PassengerAge = 4,
                Meal = "Veg",
                Seat = "9C",
            });

            db.SaveChanges();
        }
    }
}
