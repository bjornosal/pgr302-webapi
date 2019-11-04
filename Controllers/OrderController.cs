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
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly WarehouseContext _context;

        public OrdersController(ILogger<OrdersController> logger, WarehouseContext context)
        {
            _logger = logger;
            _context = context;
        }



        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {

            List<Order> allOrders = await _context.Orders.ToListAsync();
            return allOrders;
        }
    }
}
