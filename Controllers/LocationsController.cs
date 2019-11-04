using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using WarehouseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WarehouseApi.Controllers
{
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    [Route("api/v1/[controller]")]
    public class LocationsController : ControllerBase
    {

        private readonly ILogger<LocationsController> _logger;
        private readonly WarehouseContext _context;

        public LocationsController(ILogger<LocationsController> logger, WarehouseContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Location>> GetAllLocations()
        {

            List<Location> locations = await _context.Locations.ToListAsync();
            return locations;
        }
    }
}
