using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core
{
    public interface ITempDataStore
    {
        Task<List<Item>> GetItemsByTypeAsync(ItemType type);
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> QueryItemAsync(List<Guid> ids);
        Task<List<Topping>> GetAllTypeToppings();
        Task<List<Pizza>> GetAllToppingTypePizzas();
        Task<List<Crust>> GetAllTypeCrusts();
    }

    public class TempDataStore : ITempDataStore
    {
        private static List<Item> items;
        private static List<Pizza> pizzas;
        private static List<Topping> toppings;
        private static List<Crust> crusts;

        public TempDataStore()
        {
            items = GetAllItems();
        }
        public async Task<List<Item>> GetItemsByTypeAsync(ItemType type)
        {
            return await Task.FromResult(items.Where(x => x.ItemType == type).ToList());
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(x => x.ItemId == id));
        }
        public async Task<IEnumerable<Item>> QueryItemAsync(List<Guid> ids)
        {
            var res = items.Join(ids, c => c.ItemId, id => id, (c, id) => c);
            return await Task.FromResult(res);
        }
        public async Task<List<Topping>> GetAllTypeToppings()
        {
            return await Task.FromResult(toppings);
        }
        public async Task<List<Pizza>> GetAllToppingTypePizzas()
        {
            return await Task.FromResult(pizzas);
        }
        public async Task<List<Crust>> GetAllTypeCrusts()
        {
            return await Task.FromResult(crusts);
        }
        private List<Item> GetAllItems()
        {
            var pizza1 = new Item { ItemId = Guid.NewGuid(), Name = "Margherita", Price = 199, ItemType = ItemType.Pizza, ImageUrl = "margherita.jpg" };
            var pizza2 = new Item { ItemId = Guid.NewGuid(), Name = "Cheese n Corn", Price = 299, ItemType = ItemType.Pizza, ImageUrl = "cheese_n_corn.jpg" };
            var pizza3 = new Item { ItemId = Guid.NewGuid(), Name = "Fresh Veggie", Price = 349, ItemType = ItemType.Pizza, ImageUrl = "veggie_paradise.jpg" };
            var pizza4 = new Item { ItemId = Guid.NewGuid(), Name = "Pepper Barbecue Chicken", Price = 399, ItemType = ItemType.Pizza, ImageUrl = "pepper_barbeque_chicken.jpg" };
            var pizza5 = new Item { ItemId = Guid.NewGuid(), Name = "Chicken Golden Delight", Price = 450, ItemType = ItemType.Pizza, ImageUrl = "chicken_golden_delight.jpg" };
            var pizza6 = new Item { ItemId = Guid.NewGuid(), Name = "Indi Chicken Tikka", Price = 550, ItemType = ItemType.Pizza, ImageUrl = "IndianTandooriChickenTikka.jpg" };

            var pizzaItems = new List<Item>
            {
                pizza1,  pizza2, pizza3, pizza4, pizza5, pizza6
            };

            pizzas = new List<Pizza>
            {
                new Pizza(pizza1, ToppingType.Veg),
                new Pizza(pizza2, ToppingType.Veg),
                new Pizza(pizza3, ToppingType.Veg),
                new Pizza(pizza4, ToppingType.NonVeg),
                new Pizza(pizza5, ToppingType.NonVeg),
                new Pizza(pizza6, ToppingType.NonVeg),
            };

            var crustSizesFirstTwo = new List<CrustSize>
            {
                new CrustSize {  CrustSizeType = CrustSizeType.Regular, SizeToPriceRatio = 1 },
                new CrustSize {  CrustSizeType = CrustSizeType.Medium, SizeToPriceRatio = 1.5F },
                new CrustSize {  CrustSizeType = CrustSizeType.Large, SizeToPriceRatio = 1.75F }
            };

            var crustSizesLastTwo = new List<CrustSize>
            {
                new CrustSize {  CrustSizeType = CrustSizeType.Regular, SizeToPriceRatio = 1 }
            };

            var crust1 = new Item { ItemId = Guid.NewGuid(), Name = "New Hand Tossed", Price = 99, ItemType = ItemType.Crust };
            var crust2 = new Item { ItemId = Guid.NewGuid(), Name = "Wheat Thin Crust", Price = 129, ItemType = ItemType.Crust };
            var crust3 = new Item { ItemId = Guid.NewGuid(), Name = "Cheese Burst", Price = 179, ItemType = ItemType.Crust };
            var crust4 = new Item { ItemId = Guid.NewGuid(), Name = "Fresh Pan Pizza", Price = 149, ItemType = ItemType.Crust };

            var crustItems = new List<Item> { crust1, crust2, crust3, crust4 };

            crusts = new List<Crust>()
            {
                new Crust(crust1, crustSizesFirstTwo),
                new Crust(crust2, crustSizesLastTwo),
                new Crust(crust3, crustSizesLastTwo),
                new Crust(crust4, crustSizesFirstTwo),
            };

            var topping1 = new Item { ItemId = Guid.NewGuid(), Name = "Onion", Price = 12, ItemType = ItemType.Topping };
            var topping2 = new Item { ItemId = Guid.NewGuid(), Name = "Grilled Mushrooms", Price = 15, ItemType = ItemType.Topping };
            var topping3 = new Item { ItemId = Guid.NewGuid(), Name = "Crisp Capsicum", Price = 9, ItemType = ItemType.Topping };
            var topping4 = new Item { ItemId = Guid.NewGuid(), Name = "Fresh Tomato", Price = 9, ItemType = ItemType.Topping };
            var topping5 = new Item { ItemId = Guid.NewGuid(), Name = "Barbecue Chicken", Price = 49, ItemType = ItemType.Topping };
            var topping6 = new Item { ItemId = Guid.NewGuid(), Name = "Peri Chicken", Price = 59, ItemType = ItemType.Topping };
            var topping7 = new Item { ItemId = Guid.NewGuid(), Name = "Chicken Rasher", Price = 79, ItemType = ItemType.Topping };
            var topping8 = new Item { ItemId = Guid.NewGuid(), Name = "Chicken Tikka", Price = 99, ItemType = ItemType.Topping };

            var toppingItems = new List<Item> { topping1, topping2, topping3, topping4, topping5, topping6, topping7, topping8 };

            toppings = new List<Topping>()
            {
                new Topping (topping1, ToppingType.Veg),
                new Topping (topping2, ToppingType.Veg),
                new Topping (topping3, ToppingType.Veg),
                new Topping (topping4, ToppingType.Veg),
                new Topping (topping5, ToppingType.NonVeg),
                new Topping (topping6, ToppingType.NonVeg),
                new Topping (topping7, ToppingType.NonVeg),
                new Topping (topping8, ToppingType.NonVeg),
            };

            var otherItems = new List<Item>
            {
                new Item { ItemId = Guid.NewGuid(), Name = "Garlic Breadstick", Price = 99, ItemType = ItemType.Other },
                new Item { ItemId = Guid.NewGuid(), Name = "Taco Mexicana", Price = 129, ItemType = ItemType.Other },
                new Item { ItemId = Guid.NewGuid(), Name = "Veg Parcel", Price = 39, ItemType = ItemType.Other },
                new Item { ItemId = Guid.NewGuid(), Name = "Crunchy Strips", Price = 59, ItemType = ItemType.Other },
            };

            items = new List<Item>();
            items.AddRange(pizzaItems);
            items.AddRange(crustItems);
            items.AddRange(toppingItems);
            items.AddRange(otherItems);
            return items;
        }
    }
}
