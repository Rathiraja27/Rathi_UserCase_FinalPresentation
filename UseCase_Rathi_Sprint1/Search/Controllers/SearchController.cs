using Interface.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Search.Models;
using Search.Service;
using Search.ViewModel;
using System.Linq;

/// <summary>
/// Web Api to search the Flights based on the input provided
/// </summary>
namespace Search.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/search")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {

        #region Variable Declaration

        FlightDbContext _db;
        private readonly ILogger<SearchController> _logger;
        ISearchImplementation _searchImplementation;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="SearchController" /> class.</summary>
        /// <param name="db">The database.</param>
        /// <param name="logger">The logger.</param>
        public SearchController(FlightDbContext db, ILogger<SearchController> logger)
        {
            _db = db;
            _logger = logger;
            _searchImplementation = new SearchImplementation(_db);
        }

        #endregion

        #region Action Methods

        /// <summary>Searches the specified place.</summary>
        /// <param name="summary">Flight trip summary</param>
        /// <returns>Returns Ok when the user is Authorized, else BadRequest </returns>
        [HttpPost]
        public IActionResult Search(FlightTripSummary summary)
        {
            try
            {
                if (summary != null)
                {
                    _logger.LogInformation("SearchController-Schedules search");
                    FlightTripSearchResults results = _searchImplementation.FindSchedules(summary);
                    return Ok(results);
                }

                _logger.LogInformation("SearchController-Search value is empty or it does not match with the record");
                return BadRequest();
            }
            catch
            {
                _logger.LogError("SearchController-Error occurred while Searching the Schedule details");
                return BadRequest();
            }

        }

        #endregion
    }
}
