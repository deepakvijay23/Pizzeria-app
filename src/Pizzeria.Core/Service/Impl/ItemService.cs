using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.Service.Impl
{
    public class ItemService : IItemService<Item>
    {
        private readonly ITempDataStore db;
        public ItemService(ITempDataStore dataStore)
        {
            this.db = dataStore;
        }

        public async Task<List<Item>> GetAllAsync(ItemType type)
        {
            return await db.GetItemsByTypeAsync(type);
        }

        public async Task<Item> GetAsync(Guid id)
        {
            return await db.GetItemAsync(id);
        }

        public async Task<List<Item>> GetByIds(List<Guid> ids)
        {
            if(!(ids != null && ids.Any()))
            {
                return new List<Item>();
            }

            var res = await db.QueryItemAsync(ids);
            return res.ToList();
        }
    }
    public class ToppingService : ITopping
    {
        private readonly ITempDataStore db;
        public ToppingService(ITempDataStore dataStore)
        {
            this.db = dataStore;
        }

        public async Task<List<Topping>> GetAllTypeToppings()
        {
            var toppings = await db.GetAllTypeToppings();
            return toppings;
        }
    }
    public class PizzaService : IPizzaService
    {
        private readonly ITempDataStore db;
        public PizzaService(ITempDataStore dataStore)
        {
            this.db = dataStore;
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            var pizzas = await db.GetAllToppingTypePizzas();
            return pizzas;
        }
    }
    public class CrustService : ItemService, ICrustService
    {
        private readonly ITempDataStore db;
        public CrustService(ITempDataStore dataStore) :
            base(dataStore)
        {
            this.db = dataStore;
        }

        public async Task<List<Crust>> GetAllTypeCrusts()
        {
            var crsuts = await db.GetAllTypeCrusts();
            return crsuts;
        }
    }
}
