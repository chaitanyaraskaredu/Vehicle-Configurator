using DotNetProject.Models;
using DotNetProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturer _manufacturerService;

        public ManufacturerController(IManufacturer manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("{segId}")]
        public async Task<ActionResult<List<Manufacturer>>> GetManufacturers(long segId)
        {
            var manufacturers = await _manufacturerService.GetAllManufacturersByIdAsync(segId);

            if (manufacturers == null || manufacturers.Count == 0)
            {
                return NotFound();
            }

            return Ok(manufacturers);
        }
    }
}
