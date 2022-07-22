using Microsoft.EntityFrameworkCore;
using Ticket.Models;

namespace TicketUnitTesting
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
