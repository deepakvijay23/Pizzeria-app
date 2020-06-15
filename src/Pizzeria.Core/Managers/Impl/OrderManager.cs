using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Models;
using Pizzeria.Core.PizzaMaking;
using Pizzeria.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Core.Managers.Impl
{
    public class OrderManager : IOrderManager
    {
        private readonly IPizzaMaker pizzaMaker;
        private readonly IItemManager<Crust> crustManager;
        private readonly IItemManager<Topping> toppingManager;
        private readonly IItemService<Item> itemService;
        private readonly IOrderService orderService;

        public OrderManager(IPizzaMaker pizzaMaker, IItemManager<Crust> crustManager,
        IItemManager<Topping> toppingManager, IItemService<Item> itemService, IOrderService orderService)
        {
            this.pizzaMaker = pizzaMaker;
            this.crustManager = crustManager;
            this.itemService = itemService;
            this.orderService = orderService;
            this.toppingManager = toppingManager;
        }

        public async Task<ApiResponse<Order>> PlaceOrder(OrderInput orderInput)
        {
            List<PizzaMaking.Pizza> pizzas = new List<PizzaMaking.Pizza>();
            if (orderInput.PizzaInputs != null && orderInput.PizzaInputs.Any())
            {
                foreach (var pizzaInput in orderInput.PizzaInputs)
                {
                    var basePizza = await itemService.GetAsync(pizzaInput.PizzaId);
                    var pizzaCrust = await crustManager.GetAsync(pizzaInput.CrustId);
                    var toppings = await toppingManager.QueryAsync(pizzaInput.ToppingIds);

                    var pizza = pizzaMaker.StartWith(basePizza)
                          .ChangeCrust(pizzaCrust, pizzaInput.Size)
                          .AddToppings(toppings)
                          .Build();

                    pizzas.Add(pizza);
                }
            }

            var nonPizzaItems = orderInput.NonPizzaItemInputs?.Select(x => x.ItemId).ToList();
            var otherItems = await itemService.GetByIds(nonPizzaItems);
            var orderPlaced = await orderService.PlaceOrderAsync(pizzas, otherItems, orderInput.CustomerId);
            ApiResponse<Order> apiResponse = new ApiResponse<Order>
            {
                Result = new ApiResult<Order>
                {
                    Data = orderPlaced
                }
            };

            return apiResponse;
        }
    }
}
