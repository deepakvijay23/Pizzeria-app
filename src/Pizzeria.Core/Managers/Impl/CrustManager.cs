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
    public class CrustManager : IItemManager<Crust>
    {
        private readonly IItemService<Item> itemService;
        private readonly ICrustService crustService;

        public CrustManager(IItemService<Item> itemService, ICrustService crustService)
        {
            this.itemService = itemService;
            this.crustService = crustService;
        }

        public async Task<ApiResponse<List<Crust>>> GetAllAsync(CoreEnums.ItemType type)
        {
            var crusts = await this.crustService.GetAllTypeCrusts();
            ApiResponse<List<Crust>> apiResponse = new ApiResponse<List<Crust>>
            {
                Result = new ApiResult<List<Crust>> { Data = crusts }
            };

            return apiResponse;
        }

        public async Task<Crust> GetAsync(Guid id)
        {
            var item = await itemService.GetAsync(id);
            var crusts = await this.crustService.GetAllTypeCrusts();
            var data = crusts.FirstOrDefault(x => x.ItemId == item.ItemId);
            return data;
        }

        public Task<List<Crust>> QueryAsync(List<Guid> Id)
        {
            throw new NotImplementedException();
        }
    }
}
