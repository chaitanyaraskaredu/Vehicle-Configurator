using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.Services
{
    public class ComponentService : IComponent
    {
        private readonly ApplicationDbContext _context;

        public ComponentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Component>> GetAllComponentsAsync()
        {
            return await _context.Components.ToListAsync();
        }

        public async Task<Component> GetComponentByIdAsync(long id)
        {
            return await _context.Components.FindAsync(id);
        }
    }
}
