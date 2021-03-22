using GraphDemo.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Entities
{
    public class OrderQueries
    {
        public readonly ILogger _logger;
        public OrderQueries(ILogger<OrderQueries> logger)
        {
            _logger = logger;
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Orders> GetOrders([Service] OMSOrdersContext context)
        {
            _logger.LogDebug("getting order details");
            return context.Orders;
        }
    }
}