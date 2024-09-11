using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.Services
{
    public interface IModel
    {
        Task<List<Model>> GetAllModelsAsync();
        Task<List<Model>> GetModelsBySegmentAndManufacturerAsync(long segId, long manuId);
        Task<Model?> GetModelByIdAsync(long id);
    }
}
