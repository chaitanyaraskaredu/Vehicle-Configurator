using Microsoft.AspNetCore.Mvc;
using DotNetProject.Services;
using DotNetProject.Models;
using System.Threading.Tasks;

namespace DotNetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegmentsController : ControllerBase
    {
        private readonly ISegment _segmentService;

        public SegmentsController(ISegment segmentService)
        {
            _segmentService = segmentService;
        }

        // GET: api/segments
        [HttpGet]
        public async Task<IActionResult> GetAllSegments()
        {
            var segments = await _segmentService.GetAllSegmentsAsync();
            return Ok(segments);
        }

        // GET: api/segments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSegmentById(int id)
        {
            var segment = await _segmentService.GetSegmentByIdAsync(id);
            if (segment == null)
            {
                return NotFound();
            }
            return Ok(segment);
        }
    }
}
