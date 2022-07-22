using Airline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/schedule")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        FlightDbContext _db;

        public SchedulesController(FlightDbContext db)
        {
            _db = db;
        }

        [Route("getSchedule")]
        [HttpGet]
        public IEnumerable<Schedule> getData()
        {
            return _db.Schedules.ToList(); ;
        }
    }
}
