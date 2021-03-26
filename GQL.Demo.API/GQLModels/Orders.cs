using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.GQLModels
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate => System.DateTime.UtcNow;
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
    }
}
