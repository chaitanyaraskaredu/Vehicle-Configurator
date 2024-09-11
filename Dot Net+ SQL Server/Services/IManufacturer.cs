using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.Services
{
    public interface IManufacturer
    {
        Task<List<Manufacturer>> GetAllManufacturersByIdAsync(long segId);
    }
}
