using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Ticket.Controllers;
using Xunit;

namespace TicketUnitTesting
{
    public class TicketUnitTest
    {
        [Fact]
        public void TestGetTicket_InvalidValidPNR_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new TicketController(dbContext, new NullLogger<TicketController>());

            string pnr = "0af293e5-054c-4d62-a413-cb0b315b54d6";

            var response = controller.GetTicket(pnr);

            dbContext.Dispose();

            Assert.IsType<BadRequestResult>(response);
        }
    }
}
