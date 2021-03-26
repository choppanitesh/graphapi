using GraphDemo.Entities;
using GraphDemo.Models;
using HotChocolate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Mutations
{
    public class MutationResolver
    {

        private readonly ILogger _logger;

        public MutationResolver(ILogger<MutationResolver> logger)
        {
            _logger = logger;
        }

        public async Task<AddOrderPayload> AddOrderAsync(
          AddOrderInput input,
          [Service] OMSOrdersContext context)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.UserName)
                || string.IsNullOrWhiteSpace(input.OrderName) || string.IsNullOrWhiteSpace(input.Address))
            {
                _logger.LogError("invalid input {@input}", input);
                throw new Exception("Bad request");
            }

            var order = new Orders
            {
                OrderName = input.OrderName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                UserName = input.UserName,
                Address = input.Address,
                ProductId = input.ProductId
            };
            _logger.LogDebug("adding order {@input}", input);

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return new AddOrderPayload(new GQLModels.Orders
            {
                OrderName = input.OrderName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                UserName = input.UserName,
                Address = input.Address
            });
        }


        public async Task<AddProductPayload> AddProductAsync(
          AddProductInput input,
          [Service] OMSOrdersContext context)
        {
            if (string.IsNullOrWhiteSpace(input.ProductName))
            {
                _logger.LogError("invalid input {@input}", input);
                throw new Exception("Bad request");
            }

            var product = new Product
            {
                ProductName = input.ProductName,
                Cost = Convert.ToDecimal(input.Cost)
            };
            _logger.LogDebug("adding product {@input}", input);

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return new AddProductPayload(new GQLModels.Product
            {
                ProductName = input.ProductName,
                Cost = input.Cost
            });
        }
    }
}
