using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.API.Constants;
using Pizzeria.Core;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Managers;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IItemManager<Item> itemManager;
        private readonly IItemManager<Pizza> pizzaManager;
        private readonly IItemManager<Topping> toppingManager;
        private readonly IItemManager<Crust> crustManager;

        public ItemsController(IItemManager<Item> itemManager, IItemManager<Topping> toppingManager,
            IItemManager<Pizza> pizzaManager, IItemManager<Crust> crustManager)
        {
            this.itemManager = itemManager;
            this.toppingManager = toppingManager;
            this.pizzaManager = pizzaManager;
            this.crustManager = crustManager;
        }

        // GET: api/<controller>
        [HttpGet("{type}")]
        [ProducesResponseType(typeof(ApiResponse<List<Item>>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetByType(string type)
        {
            try
            {
                var isParsed = Enum.TryParse(type, true, out ItemType itemType);
                if (isParsed)
                {
                    if (itemType == ItemType.Topping)
                    {
                        var topping = await toppingManager.GetAllAsync(itemType);
                        return Ok(topping);
                    }
                    else if (itemType == ItemType.Pizza)
                    {
                        var pizzas = await pizzaManager.GetAllAsync(itemType);
                        return Ok(pizzas);
                    }
                    else if (itemType == ItemType.Crust)
                    {
                        var crusts = await crustManager.GetAllAsync(itemType);
                        return Ok(crusts);
                    }

                    var items = await itemManager.GetAllAsync(itemType);
                    return Ok(items);
                }

                var response = new ApiResponse<Item>
                {
                    Result = new ApiResult<Item>
                    {
                        ErrorInfo = new ErrorInfo(string.Format(ApiConstants.InvalidItemType, type))
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Logging
                return BadRequest();
            }
        }
        
        [HttpGet("{type}/{id}")]
        [ProducesResponseType(typeof(ApiResponse<List<CrustSize>>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Get(string type, Guid id)
        {
            try
            {
                var isParsed = Enum.TryParse(type, true, out ItemType itemType);
                if (isParsed)
                {
                    if (itemType == ItemType.Topping)
                    {
                        var topping = await toppingManager.GetAsync(id);
                        return Ok(topping);
                    }
                    else if (itemType == ItemType.Pizza)
                    {
                        var pizza = await pizzaManager.GetAsync(id);
                        return Ok(pizza);
                    }
                    else if (itemType == ItemType.Crust)
                    {
                        var crust = await crustManager.GetAllAsync(itemType);
                        return Ok(crust);
                    }

                    var item = await itemManager.GetAsync(id);
                    return Ok(item);
                }

                var response = new ApiResponse<Item>
                {
                    Result = new ApiResult<Item>
                    {
                        ErrorInfo = new ErrorInfo(string.Format(ApiConstants.InvalidItemType, type))
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Logging
                return BadRequest();
            }

        }
    }
}
