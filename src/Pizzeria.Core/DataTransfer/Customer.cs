using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.DataTransfer
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int MobileNo { get; set; }
    }
}
