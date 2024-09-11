using DotNetProject.Models;
using DotNetProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicle _vehicleService;

        public VehicleController(IVehicle vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("{compType}/{modId}")]
        public async Task<IActionResult> GetCompByModelID(char compType, long modId)
        {
            try
            {
                var components = await _vehicleService.GetCompByModelID(modId, compType);
                if (components == null || components.Count == 0)
                {
                    return NotFound("No components found.");
                }
                return Ok(components);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{modId:int}")]
        public async Task<IActionResult> GetVehicleDataUsingModelId(int modId)
        {
            try
            {
                var vehicleDetails = await _vehicleService.GetVehicleDataUsingModelId(modId);
                if (vehicleDetails == null || vehicleDetails.Count == 0)
                {
                    return NotFound("No vehicles found.");
                }
                return Ok(vehicleDetails);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
