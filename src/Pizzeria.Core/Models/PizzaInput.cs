using System;
using System.Collections.Generic;
using static Pizzeria.Core.Utils.CoreEnums;

namespace Pizzeria.Core.Models
{
    public class PizzaInput
    {
        public CrustSizeType Size { get; set; }

        public Guid CrustId { get; set; }

        public List<Guid> ToppingIds { get; set; }

        // Base Pizza on top the customization performed.
        public Guid PizzaId { get; set; }
    }
}
