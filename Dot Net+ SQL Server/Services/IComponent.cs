using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.Services
{
    public interface IComponent
    {
        Task<IEnumerable<Component>> GetAllComponentsAsync();
        Task<Component> GetComponentByIdAsync(long id);
    }
}
