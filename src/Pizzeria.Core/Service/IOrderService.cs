using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizzeria.Core.Service
{
    public interface IOrderService
    {
        Task<List<OrderedItem>> AddPizzaItemsAsync(List<PizzaMaking.Pizza> pizzas);
        Task<List<OrderedItem>> AddNonPizzaItemsAsync(List<Item> nonPizzaItems);
        Task<Order> PlaceOrderAsync(List<PizzaMaking.Pizza> pizzas, List<Item> items, Guid customerId);
    }
}
