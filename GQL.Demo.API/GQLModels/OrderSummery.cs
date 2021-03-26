using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.GQLModels
{
    public class OrderSummery
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
    }
}
