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


        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(long id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            Location location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Location>> UpdateLocation(long id, [FromBody] Location location)
        {

            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO: Do check for if it exists in DB.
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Location>> AddLocation([FromBody] Location location)
        {

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
        }

        [HttpGet]
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            List<Location> allLocations = await _context.Locations.ToListAsync();

            return allLocations;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Location>> DeleteLocation(long id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return location;
        }
        //TODO: Add Patch?
    }
}
