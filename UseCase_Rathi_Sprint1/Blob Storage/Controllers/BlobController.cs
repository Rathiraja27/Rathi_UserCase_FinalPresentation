using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blob_Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        public static IConfiguration _configuration { get; private set; }

        public BlobController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost ]
        public async Task<IActionResult> BlobImage(IFormFile formFile)
        {
           BlobService.BlobService service = new BlobService.BlobService(_configuration);
           string image =  await service.Upload(formFile);
           return Ok(image);
        }

    }
}
