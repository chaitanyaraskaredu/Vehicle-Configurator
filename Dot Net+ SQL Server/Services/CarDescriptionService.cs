using Microsoft.EntityFrameworkCore;
using DotNetProject.Models;
using DotNetProject.Repositories;

namespace DotNetProject.Services
{
    public class CarDescriptionService : ICarDescription
    {
        private readonly ApplicationDbContext _context;

        public CarDescriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarDescription>> GetAllCarsAsync()
        {
            return await _context.CarDescriptions.ToListAsync();
        }

        public async Task<CarDescription?> GetCarByIdAsync(long id)
        {
            return await _context.CarDescriptions.FindAsync(id);
        }
    }
}
