using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetProject.Models;
using DotNetProject.Repositories;

namespace DotNetProject.Services
{
    public class ModelService : IModel
    {
        private readonly ApplicationDbContext _context;

        public ModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Model>> GetAllModelsAsync()
        {
            return await _context.Models
                .Include(m => m.Manufacturer)
                .Include(m => m.Segment)
                .ToListAsync();
        }

        public async Task<List<Model>> GetModelsBySegmentAndManufacturerAsync(long segId, long manuId)
        {
            return await _context.Models
                .Include(m => m.Manufacturer)
                .Include(m => m.Segment)
                .Where(m => m.SegId == segId && m.ManuId == manuId)
                .ToListAsync();
        }

        public async Task<Model?> GetModelByIdAsync(long id)
        {
            return await _context.Models
                .Include(m => m.Manufacturer)
                .Include(m => m.Segment)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
