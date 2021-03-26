using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.GQLModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;
    }
}
