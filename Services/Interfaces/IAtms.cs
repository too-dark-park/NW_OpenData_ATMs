using NW_OpenData_ATMs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NW_OpenData_ATMs.Services.Interfaces
{
    public interface IAtms
    {
        Task<IEnumerable<GeographicCoordinates>> GetAtmsGeographicCoordinatesAsync();
    }
}