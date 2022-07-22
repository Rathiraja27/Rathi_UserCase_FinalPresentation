using Airline.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineUnitTesting
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
