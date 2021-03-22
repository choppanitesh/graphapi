using GraphDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Entities
{
    public class AddOrderPayload
    {
        public AddOrderPayload(Orders orders)
        {
            Orders = orders;
        }

        public Orders Orders { get; }
    }
}
