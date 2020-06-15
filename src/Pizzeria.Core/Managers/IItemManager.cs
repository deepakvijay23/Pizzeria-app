using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.Managers
{
    public interface IItemManager<T>
    {
        Task<ApiResponse<List<T>>> GetAllAsync(ItemType type);
        Task<T> GetAsync(Guid Id);
        Task<List<T>> QueryAsync(List<Guid> Id);
    }
}
