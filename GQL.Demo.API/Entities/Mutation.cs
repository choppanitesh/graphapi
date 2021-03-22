using GraphDemo.Models;
using HotChocolate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Entities
{
    public class Mutation
    {

        public readonly ILogger _logger;
        public Mutation(ILogger<Mutation> logger)
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
                Address = input.Address
            };
            _logger.LogDebug("adding order {@input}", input);

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return new AddOrderPayload(order);
        }
    }
}
