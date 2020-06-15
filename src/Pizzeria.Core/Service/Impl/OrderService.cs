using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Core.Service.Impl
{
    public class OrderService : IOrderService
    {
        private static readonly List<OrderedPizzaItem> orderedPizzaItems = new List<OrderedPizzaItem>();
        private static readonly List<OrderedNonPizzaItem> orderedNonPizzaItems = new List<OrderedNonPizzaItem>();
        private static readonly List<OrderedItem> orderedItems = new List<OrderedItem>();
        private static readonly List<Order> orders = new List<Order>();

        public async Task<List<OrderedItem>> AddPizzaItemsAsync(List<PizzaMaking.Pizza> pizzas)
        {
            List<OrderedItem> addedOrderedItems = new List<OrderedItem>();
            foreach (var item in pizzas)
            {
                var pizzaItem = new OrderedPizzaItem
                {
                    Id = Guid.NewGuid(),
                    Crust = item.Crust,
                    PizzaSize = item.Size,
                    Toppings = item.Toppings,
                    BasePizza = item.BasePizza
                };

                orderedPizzaItems.Add(pizzaItem);
                var orderedItem = new OrderedItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = pizzaItem.Id
                };

                orderedItems.Add(orderedItem);
                addedOrderedItems.Add(orderedItem);
            }

            return await Task.FromResult(addedOrderedItems);
        }

        public async Task<List<OrderedItem>> AddNonPizzaItemsAsync(List<Item> nonPizzaItems)
        {
            List<OrderedItem> addedOrderedItems = new List<OrderedItem>();
            foreach (var item in nonPizzaItems)
            {
                var nonPizzaItem = new OrderedNonPizzaItem
                {
                    Id = Guid.NewGuid(),
                    Item = item
                };

                orderedNonPizzaItems.Add(nonPizzaItem);
                var orderedItem = new OrderedItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = nonPizzaItem.Id
                };

                orderedItems.Add(orderedItem);
                addedOrderedItems.Add(orderedItem);
            }

            return await Task.FromResult(addedOrderedItems);
        }

        public async Task<Order> PlaceOrderAsync(List<PizzaMaking.Pizza> pizzas, List<Item> items, Guid customerId)
        {
            var pizzaItems = await AddPizzaItemsAsync(pizzas);
            var nonPizzaItems = await AddNonPizzaItemsAsync(items);

            var orderedItems = new List<OrderedItem>();
            orderedItems.AddRange(pizzaItems);
            orderedItems.AddRange(nonPizzaItems);

            var totalPizzaPrice = pizzas.Sum(x => x.TotalPrice);
            var totalNonPizzaPrice = items.Sum(x => x.Price);

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                OrderedItem = orderedItems,
                OrderNumber = Guid.NewGuid().ToString().Substring(0, 5),
                TotalPrice = totalPizzaPrice + totalNonPizzaPrice
            };

            orders.Add(order);
            return await Task.FromResult(order);
        }
    }


}
