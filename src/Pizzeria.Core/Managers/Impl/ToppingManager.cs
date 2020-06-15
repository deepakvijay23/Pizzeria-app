using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Service;
using Pizzeria.Core.Service.Impl;
using Pizzeria.Core.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria.Core.Managers.Impl
{
    public class ToppingManager : IItemManager<Topping>
    {
        private readonly IItemService<Item> itemService;
        private readonly ITopping toppingService;

        public ToppingManager(IItemService<Item> itemService, ITopping toppingService)
        {
            this.itemService = itemService;
            this.toppingService = toppingService;
        }

        public async Task<ApiResponse<List<Topping>>> GetAllAsync(CoreEnums.ItemType type)
        {
            var toppings = await this.toppingService.GetAllTypeToppings();
            ApiResponse<List<Topping>> apiResponse = new ApiResponse<List<Topping>>
            {
                Result = new ApiResult<List<Topping>> { Data = toppings }
            };

            return apiResponse;
        }

        public async Task<Topping> GetAsync(Guid id)
        {
            var item = await itemService.GetAsync(id);
            var toppings = await this.toppingService.GetAllTypeToppings();
            var data = toppings.FirstOrDefault(x => x.ItemId == item.ItemId);
            return data;
        }

        public async Task<List<Topping>> QueryAsync(List<Guid> ids)
        {
            var toppings = await this.toppingService.GetAllTypeToppings();
            return toppings.Where(x => ids.Contains(x.ItemId)).ToList();
        }
    }
}
