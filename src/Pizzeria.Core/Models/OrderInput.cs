using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Core.Models
{
    public class OrderInput
    {
        public List<PizzaInput> PizzaInputs { get; set; }

        public List<NonPizzaItemInput> NonPizzaItemInputs { get; set; }

        public Guid CustomerId { get; set; }
    }
}
