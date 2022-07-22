using Booking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/flight/discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        FlightDbContext _db;

        public DiscountController(FlightDbContext db)
        {
            _db = db;
        }

        [Route("getDiscount")]
        [HttpGet]
        public IEnumerable<Discount> getData()
        {
            return _db.Discounts.ToList();
        }

        
        [HttpPost]
        public IActionResult postData(Discount discounts)
        {
            if (discounts != null)
            {
                Discount discount = new Discount();
                discount.DiscountCode = discounts.DiscountCode;
                discount.Percentage = discounts.Percentage;
                _db.Discounts.Add(discount);
                _db.SaveChanges();
                return Ok();
            }

            return BadRequest("Record not found.");
        }

        [HttpDelete]
        public IActionResult deleteData(string discountCode)
        {
            if (_db.Discounts.Any(x => x.DiscountCode == discountCode))
            {
                var data = _db.Discounts.Where(x => x.DiscountCode == discountCode).FirstOrDefault();
                _db.Discounts.Remove(data);
                _db.SaveChanges();
                return Ok(new { message = "Record have been successfully deleted." });
            }

            return BadRequest("Record not found.");
        }
    }
}
