using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Search.Controllers;
using Xunit;

namespace SearchUnitTesting
{
    public class SearchUnitTest
    {
        [Fact]
        public void TestSearch_ValidPlace_Pass()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new SearchController(dbContext, new NullLogger<SearchController>());

            string place = "Banglore";

           // var response = controller.Search();

            dbContext.Dispose();

           // Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void TestSearch_InValidPlace_Fail()
        {
            var dbContext = DbContextMocker.GetDbContext();
            var controller = new SearchController(dbContext, new NullLogger<SearchController>());

            string place = "Kerala";

            //var response = controller.Search();

            dbContext.Dispose();


            //Assert.IsType<BadRequestResult>(response);
        }
    }
}
