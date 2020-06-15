using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Managers;
using Pizzeria.Core.Managers.Impl;
using Pizzeria.Core.PizzaMaking;
using Pizzeria.Core.Service;
using Pizzeria.Core.Service.Impl;
using System;

namespace Pizzeria.Core
{
    public static class DIConfigCore
    {
        public static void RegisterService(IServiceCollection services)
        {
            // Temp db service
            services.AddSingleton<ITempDataStore, TempDataStore>();

            #region Services
            services.AddTransient<IItemService<Item>, ItemService>();
            services.AddTransient<ITopping, ToppingService>();
            services.AddTransient<ICrustService, CrustService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IOrderService, OrderService>();
            #endregion

            #region Managers
            services.AddTransient<IItemManager<Item>, ItemManager>();
            services.AddTransient<IItemManager<DataTransfer.Pizza>, PizzaManager>();
            services.AddTransient<IItemManager<Topping>, ToppingManager>();
            services.AddTransient<IItemManager<Crust>, CrustManager>();
            services.AddTransient<IPizzaMaker, PizzaMaker>();
            services.AddTransient<IOrderManager, OrderManager>();

            #endregion
        }
    }
}
