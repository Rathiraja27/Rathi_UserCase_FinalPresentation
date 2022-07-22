using Ticket.Models;

namespace TicketUnitTesting
{
    public static class DbContextExtension
    {
        public static void Seed(this FlightDbContext db)
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
