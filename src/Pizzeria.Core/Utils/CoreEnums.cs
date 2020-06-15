using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Utils
{
    public class CoreEnums
    {
        public enum ToppingType
        {
            Veg,
            NonVeg
        }

        public enum ItemType
        {
            Pizza,
            Crust,
            Topping,
            Other
        }

        public enum CrustSizeType
        {
            Regular,
            Medium,
            Large
        }
    }
}
