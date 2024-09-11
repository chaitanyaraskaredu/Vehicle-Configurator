using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotNetProject.Services
{
    public class AlternateComponentService : IAlternateComponent
    {
        private readonly ApplicationDbContext _context;

        public AlternateComponentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AlternateComponent> GetAllAltComp(int modId)
        {
            return _context.AlternateComponents
                           .Where(ac => ac.ModId == modId)
                           .ToList();
        }
 
        public List<dynamic> GetDeltaPriceAndNameByArray(int modId, int compId)
        {
            return _context.AlternateComponents
                           .Where(ac => ac.ModId == modId && ac.CompId == compId)
                           .Select(ac => new
                           {
                               mod_id = ac.ModId,
                               comp_name = _context.Components
                                                 .Where(c => c.Id == ac.AltCompId)
                                                 .Select(c => c.CompName)
                                                 .FirstOrDefault(), 
                               alt_comp_id = ac.AltCompId,
                               delta_price = ac.DeltaPrice
                           })
                           .ToList<dynamic>();
        }

    }

}
