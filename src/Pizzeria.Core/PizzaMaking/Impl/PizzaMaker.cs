using System;
using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Service;
using System.Collections.Generic;
using System.Linq;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.PizzaMaking
{
    internal class PizzaMaker : IPizzaMaker
    {
        private Pizza pizza;

        public IPizzaMaker StartWith(Item basePizza)
        {
            pizza = new Pizza
            {
                BasePizza = basePizza
            };
            pizza.AddToPrice(basePizza.Price);
            return this;
        }

        public IPizzaMaker ChangeCrust(Crust pizzaCrust, CrustSizeType crustSizeType)
        {
            pizza.Crust = pizzaCrust ?? throw new InvalidOperationException("Crust is not defined.");
            var availableCrust = pizzaCrust.AvailableSizes.FirstOrDefault(x => x.CrustSizeType == crustSizeType);
            if(availableCrust == null)
            {
                throw new InvalidOperationException("Crust size is not available.");
            }

            pizza.Size = pizzaCrust.AvailableSizes.FirstOrDefault(x => x.CrustSizeType == crustSizeType);
            var price = pizza.Crust.Price * pizza.Size.SizeToPriceRatio;
            pizza.AddToPrice(price);
            return this;
        }

        public IPizzaMaker AddToppings(List<Topping> pizzaToppings)
        {
            if (pizzaToppings != null && pizzaToppings.Any())
            {
                pizza.Toppings = pizzaToppings;
                float price = pizzaToppings.Sum(x => x.Price);
                pizza.AddToPrice(price);
            }
            return this;
        }

        public Pizza Build()
        {
            return pizza;
        }
    }
}
