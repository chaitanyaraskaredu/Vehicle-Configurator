using Microsoft.AspNetCore.Mvc;
using DotNetProject.Models;
using DotNetProject.Services;

namespace DotNetProject.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly ICarDescription _service;

        public CarDescriptionController(ICarDescription service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                var cars = await _service.GetAllCarsAsync();
                return Ok(cars);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(long id)
        {
            try
            {
                var car = await _service.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound();
                }
                return Ok(car);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
