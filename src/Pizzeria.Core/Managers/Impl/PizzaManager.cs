using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Service;
using Pizzeria.Core.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria.Core.Managers.Impl
{
    public class PizzaManager : IItemManager<Pizza>
    {
        private readonly IItemService<Item> itemService;
        private readonly IPizzaService pizzaService;

        public PizzaManager(IItemService<Item> itemService, IPizzaService pizzaService)
        {
            this.itemService = itemService;
            this.pizzaService = pizzaService;
        }

        public async Task<ApiResponse<List<Pizza>>> GetAllAsync(CoreEnums.ItemType type)
        {
            var pizzas = await pizzaService.GetPizzas();
            ApiResponse<List<Pizza>> apiResponse = new ApiResponse<List<Pizza>>
            {
                Result = new ApiResult<List<Pizza>> { Data = pizzas }
            };

            return apiResponse;
        }

        public async Task<Pizza> GetAsync(Guid id)
        {
            var item = await itemService.GetAsync(id);
            var pizzas = await pizzaService.GetPizzas();
            var data = pizzas.FirstOrDefault(x => x.ItemId == item.ItemId);
            return data;
        }

        public Task<List<Pizza>> QueryAsync(List<Guid> Id)
        {
            throw new NotImplementedException();
        }
    }
}
