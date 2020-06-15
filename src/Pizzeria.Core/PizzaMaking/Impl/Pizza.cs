using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.PizzaMaking
{
    public class Pizza
    {
        // Like Fresh Veggie, Margherita etc.
        public Item BasePizza { get; set; }

        public double TotalPrice { get; private set; }

        public CrustSize Size { get; set; }

        public Crust Crust { get; set; }

        public List<Topping> Toppings { get; set; }

        public void AddToPrice(double price)
        {
            TotalPrice += price;
        }
    }
}
