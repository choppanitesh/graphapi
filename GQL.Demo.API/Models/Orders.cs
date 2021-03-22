using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; } = System.DateTime.UtcNow;
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
