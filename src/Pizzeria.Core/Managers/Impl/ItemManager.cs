using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.Managers.Impl
{
    public class ItemManager : IItemManager<Item>
    {
        private readonly IItemService<Item> itemService;

        public ItemManager(IItemService<Item> itemService)
        {
            this.itemService = itemService;
        }

        public virtual async Task<ApiResponse<List<Item>>> GetAllAsync(ItemType type)
        {
            var items = await itemService.GetAllAsync(type);
            ApiResponse<List<Item>> apiResponse = new ApiResponse<List<Item>>
            {
                Result = new ApiResult<List<Item>> { Data = items }
            };

            return apiResponse;
        }

        public virtual async Task<Item> GetAsync(Guid id)
        {
            var item = await itemService.GetAsync(id);
            return item;
        }

        public Task<List<Item>> QueryAsync(List<Guid> Id)
        {
            throw new NotImplementedException();
        }
    }
}
