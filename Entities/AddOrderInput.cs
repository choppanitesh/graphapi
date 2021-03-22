using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Entities
{
    public class AddOrderInput
    {
        public string OrderName { get; set; }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
