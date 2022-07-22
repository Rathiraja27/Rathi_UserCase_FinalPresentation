using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingUnitTesting
{
    public static class DbContextMocker
    {
        public static FlightDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<FlightDbContext>()
               .UseInMemoryDatabase(databaseName: "FlightDb")
               .Options;

            var dbContext = new FlightDbContext(options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
