using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.Service
{
    public interface IItemService<T>
    {
        Task<List<T>> GetAllAsync(ItemType type);

        Task<T> GetAsync(Guid Id);

        Task<List<T>> GetByIds(List<Guid> ids);
    }

    public interface ITopping
    {
        Task<List<Topping>> GetAllTypeToppings();
    }

    public interface IPizzaService
    {
        Task<List<Pizza>> GetPizzas();
    }

    public interface ICrustService
    {
        Task<List<Crust>> GetAllTypeCrusts();
    }
}
