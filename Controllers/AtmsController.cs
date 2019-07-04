using Microsoft.AspNetCore.Mvc;
using NW_OpenData_ATMs.Models;
using NW_OpenData_ATMs.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NW_OpenData_ATMs.Controllers
{
    [Route("api/[controller]")]
    public class AtmsController : Controller
    {
        private readonly IAtms _atms;

        public AtmsController(IAtms atms)
        {
            _atms = atms;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GeographicCoordinates>> GetAtmsGeographicCoordinatesAsync()
        {
            return await _atms.GetAtmsGeographicCoordinatesAsync();
        }
    }
}
