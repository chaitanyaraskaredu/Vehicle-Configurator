using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetProject.Models;
using DotNetProject.Services;

namespace DotNetProject.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModel _modelService;

        public ModelController(IModel modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllModels()
        {
            try
            {
                var models = await _modelService.GetAllModelsAsync();
                return Ok(models);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{segId}/{manuId}")]
        public async Task<IActionResult> FetchModelsBySegmentAndManufacturer(long segId, long manuId)
        {
            try
            {
                var models = await _modelService.GetModelsBySegmentAndManufacturerAsync(segId, manuId);
                return Ok(models);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> FetchModelById(long id)
        {
            try
            {
                var model = await _modelService.GetModelByIdAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return Ok(model);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
