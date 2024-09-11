using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public class ManufacturerService : IManufacturer
    {
        private readonly ApplicationDbContext _context;

        public ManufacturerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manufacturer>> GetAllManufacturersByIdAsync(long segId)
        {
            return await _context.Manufacturers
                                 .Where(m => m.SegId == segId)
                                 .ToListAsync();
        }
    }
}
