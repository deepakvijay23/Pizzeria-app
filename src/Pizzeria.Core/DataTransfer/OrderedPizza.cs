using System;
using System.Collections.Generic;

namespace Pizzeria.Core.DataTransfer
{
    public class OrderedItem
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }
    }

    public class OrderedPizzaItem
    {
        public Guid Id { get; set; }

        public CrustSize PizzaSize { get; set; }

        public Crust Crust { get; set; }

        public List<Topping> Toppings { get; set; }

        public Item BasePizza { get; set; }
    }

    public class OrderedNonPizzaItem
    {
        public Guid Id { get; set; }

        public Item Item { get; set; }
    }
}
