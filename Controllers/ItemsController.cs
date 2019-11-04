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
            Item item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
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


    }
}
