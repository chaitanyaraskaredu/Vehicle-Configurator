using DotNetProject.Models;
using System.Collections.Generic;

namespace DotNetProject.Services
{
    public interface IAlternateComponent
    {
        List<AlternateComponent> GetAllAltComp(int modId);
        List<dynamic> GetDeltaPriceAndNameByArray(int modId, int compId);
    }
}
