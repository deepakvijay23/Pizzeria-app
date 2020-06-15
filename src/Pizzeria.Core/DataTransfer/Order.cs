using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.DataTransfer
{
    public class Order
    {
        public Guid Id { get; set; }

        public List<OrderedItem> OrderedItem { get; set; }

        public Guid CustomerId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }
    }
}
