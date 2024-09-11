using DotNetProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public interface IVehicle
    {
        
        Task<List<Vehicle>> GetVehicleDataUsingModelId(int modId);

        Task<List<object>> GetCompByModelID(long modelId, char compType);
    }
}
