using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public class SegmentService : ISegment
    {
        private readonly ApplicationDbContext _context;

        public SegmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Segment>> GetAllSegmentsAsync()
        {
            return await _context.Segments.ToListAsync();
        }

        public async Task<Segment?> GetSegmentByIdAsync(int id)
        {
            return await _context.Segments.FindAsync(id);
        }
    }
}
