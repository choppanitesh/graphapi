using GraphDemo.GQLModels;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Query
{
    public class QueryResolver
    {
        public readonly ILogger _logger;
        public QueryResolver(ILogger<QueryResolver> logger)
        {
            _logger = logger;
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IList<Orders> GetOrders([Service] OMSOrdersContext context)
        {
            _logger.LogDebug("getting order details");
            var query = context.Orders.Select(a => new Orders
            {
                Address = a.Address,
                PhoneNumber = a.PhoneNumber,
                OrderName = a.OrderName,
                UserName = a.UserName,
                ProductId = a.ProductId,
                Email = a.Email,
                ProductName = a.Product.ProductName,
                Cost = a.Product.Cost
            });
            return query.ToList();
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts([Service] OMSOrdersContext context)
        {
            _logger.LogDebug("getting products details");
            var products = context.Products.Select(a => new Product
            {
                ProductName = a.ProductName,
                Cost = a.Cost,
                ProductId = a.ProductId
            });
            return products;
        }


        public OrderSummery GetOrderSummery([Service] OMSOrdersContext context, int orderId)
        {
            if (orderId == 0)
            {
                _logger.LogError("Invalid OrderId");
                throw new InvalidOperationException("Invalid OrderId");
            }
            _logger.LogDebug("getting order summery details by {orderId}", orderId);
            var orderData = (from order in context.Orders
                             join product in context.Products on order.ProductId equals product.ProductId
                             select new { order, product })
                             .FirstOrDefault(a => a.order.OrderId == orderId);

            return new OrderSummery
            {
                OrderDate = orderData.order.OrderDate,
                OrderId = orderData.order.OrderId,
                OrderName = orderData.order.OrderName,
                Cost = orderData.product.Cost,
                ProductName = orderData.product.ProductName
            };
        }
    }
}