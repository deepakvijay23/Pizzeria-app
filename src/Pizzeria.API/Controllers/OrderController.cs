using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Core.Models;
using Pizzeria.Core.Managers;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core;
using System;

namespace Pizzeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Order>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Post([FromBody]OrderInput orderInput)
        {
            try
            {
                var response = await orderManager.PlaceOrder(orderInput);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}