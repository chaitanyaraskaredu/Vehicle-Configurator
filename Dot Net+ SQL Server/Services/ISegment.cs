using DotNetProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public interface ISegment
    {
        Task<IEnumerable<Segment>> GetAllSegmentsAsync();
        Task<Segment?> GetSegmentByIdAsync(int id);
    }
}
