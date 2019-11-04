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
    public class ItemsController : ControllerBase
    {

        private readonly ILogger<ItemsController> _logger;
        private readonly WarehouseContext _context;

        public ItemsController(ILogger<ItemsController> logger, WarehouseContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(long id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            Item item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, Item item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO: Check if exists, if it does, throw error
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Item>> AddItem([FromBody] Item item)
        {

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            List<Item> allItems = await _context.Items.ToListAsync();

            return allItems;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(long id)
        {
            var Item = await _context.Items.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();

            return Item;
        }
    }
}
