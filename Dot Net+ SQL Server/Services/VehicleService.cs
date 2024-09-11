using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public class VehicleService : IVehicle
    {
        private readonly ApplicationDbContext _context;

        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetVehicleDataUsingModelId(int modId)
        {
            return await _context.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Segment)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
                .Include(v => v.Component)
                .Where(v => v.ModId == modId)
                .ToListAsync();
        }


        public async Task<List<object>> GetCompByModelID(long modelId, char compType)
        {
            var components = await _context.Vehicles
                .Where(v => v.ModId == modelId && v.CompType == compType.ToString())
                .Select(v => new
                {
                    mod_id = v.ModId,
                    is_configurable = v.IsConfigurable,
                    comp_type = v.CompType,
                    comp_id = v.CompId,
                    comp_name = v.Component.CompName,
                    id = v.Id
                })
                .ToListAsync();

            return components.Cast<object>().ToList();
        }

        /*    public async Task<List<object>> GetCompByModelID(long modelId, char compType)
            {
                var components = await _context.Vehicles
                    .Where(v => v.ModId == modelId && v.CompType == compType.ToString())
                    .Select(v => new
                    {
                        v.ModId,
                        v.IsConfigurable,
                        v.CompType,
                        v.CompId,
                        CompName = v.Component.CompName,  // 'Component' is a navigation property
                        v.Id
                    })
                    .ToListAsync();

                return components.Cast<object>().ToList();
            }
        */

    }
}
