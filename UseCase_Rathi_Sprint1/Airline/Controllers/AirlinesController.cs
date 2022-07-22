using Airline.Models;
using Airline.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/airlines")]
    [ApiController]
    //[Authorize]
    public class AirlinesController : ControllerBase
    {
        FlightDbContext _db;

        public AirlinesController(FlightDbContext db)
        {
            _db = db;
        }

        [Route("getAirline")]
        [HttpGet]
        public IEnumerable<Models.Airline> getData()
        {
            var data = from airline in _db.Airlines
                       select airline;
            return data;
        }

        [HttpPut]
        public IActionResult putData(AirlineViewModel sampleViewModel)
        {
            if (_db.Airlines.Any(x => x.AirlineId == sampleViewModel.AirlineId))
            {
                var data = _db.Airlines.Where(x => x.AirlineId == sampleViewModel.AirlineId).FirstOrDefault();
                data.AirlineName = sampleViewModel.AirlineName;
                data.Address = sampleViewModel.Address;
                data.AirlineStatus = sampleViewModel.AirlineStatus;
                data.Description = sampleViewModel.Description;
                data.Logo = sampleViewModel.Logo;
                data.PhoneNumber = sampleViewModel.PhoneNumber;
                _db.Airlines.Update(data);
                _db.SaveChanges();
                return Ok(new { message = "Record have been successfully updated." });
            }

            return BadRequest("Record not found.");
        }

        [HttpDelete]
        public IActionResult deleteData(int Id)
        {
            if (_db.Airlines.Any(x => x.AirlineId == Id))
            {
                var data = _db.Airlines.Where(x => x.AirlineId == Id).FirstOrDefault();
                _db.Airlines.Remove(data);
                _db.SaveChanges();
                return Ok(new { message="Record have been successfully deleted." });
            }

            return BadRequest("Record not found.");
        }
    }
}
