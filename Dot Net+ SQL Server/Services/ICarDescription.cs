using DotNetProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public interface ICarDescription
    {
        Task<List<CarDescription>> GetAllCarsAsync();
        Task<CarDescription?> GetCarByIdAsync(long id);
    }
}
