using DotNetProject.Models;
using DotNetProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetProject.Controllers
{
    [Route("api/alternate")]
    [ApiController]
    public class AlternateComponentController : ControllerBase
    {
        private readonly IAlternateComponent _service;

        public AlternateComponentController(IAlternateComponent service)
        {
            _service = service;
        }

        [HttpGet("{segId}/{manuId}/{modId}")]
        public ActionResult<List<AlternateComponent>> GetAllAltComp(int segId, int manuId, int modId)
        {
            return _service.GetAllAltComp(modId);
        }

        [HttpGet("{modId}/{compId}")]
        public ActionResult<List<dynamic>> GetDeltaPriceAndNameByArray(int modId, int compId)
        {
            var result = _service.GetDeltaPriceAndNameByArray(modId, compId);
            return Ok(result);
        }
    }
}
