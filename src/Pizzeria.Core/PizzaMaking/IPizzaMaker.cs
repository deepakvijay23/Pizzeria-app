using Pizzeria.Core.DataTransfer;
using System;
using System.Collections.Generic;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.PizzaMaking
{
    public interface IPizzaMaker
    {
        IPizzaMaker StartWith(Item basePizza);
        IPizzaMaker ChangeCrust(Crust pizzaCrust, CrustSizeType crustSizeType);
        IPizzaMaker AddToppings(List<Topping> pizzaToppings);
        Pizza Build();
    }
}
