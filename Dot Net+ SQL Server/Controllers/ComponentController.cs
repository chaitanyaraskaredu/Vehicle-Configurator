using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Models;
using DotNetProject.Services;
using Microsoft.AspNetCore.Cors;

namespace DotNetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponent _componentService;

        public ComponentController(IComponent componentService)
        {
            _componentService = componentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComponents()
        {
            try
            {
                var components = await _componentService.GetAllComponentsAsync();
                return Ok(components);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Exception: =============================================================={ex.Message}");
                return BadRequest(new { Message = "An error occurred while processing your request." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponentById(long id)
        {
            try
            {
                var component = await _componentService.GetComponentByIdAsync(id);
                if (component == null)
                {
                    return NotFound();
                }
                return Ok(component);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return BadRequest(new { Message = "An error occurred while processing your request." });
            }
        }
    }
}
