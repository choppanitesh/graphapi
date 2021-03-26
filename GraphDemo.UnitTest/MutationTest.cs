using FluentAssertions;
using GraphDemo.Entities;
using GraphDemo.Models;
using GraphDemo.Mutations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphDemo.UnitTest
{
    public class MutationTest
    {
        private readonly Mock<ILogger<MutationResolver>> mockLogger;
        private MutationResolver mutation;

        public MutationTest()
        {
            mockLogger = new Mock<ILogger<MutationResolver>>();
            mutation = new MutationResolver(mockLogger.Object);
        }

        [Fact]
        public async void AddOrderShouldThrowErrorForInvalidInput()
        {
            //Arrange
            var order = new AddOrderInput();

            //Act
            var mutationStatus = await Assert.ThrowsAsync<Exception>(() => mutation.AddOrderAsync(order, null));

            //Assert
            mutationStatus.Message.Should().Be("Bad request");
        }


        [Fact]
        public async void AddProductShouldThrowErrorForInvalidInput()
        {
            //Arrange
            var product = new AddProductInput();

            //Act
            var mutationStatus = await Assert.ThrowsAsync<Exception>(() => mutation.AddProductAsync(product, null));

            //Assert
            mutationStatus.Message.Should().Be("Bad request");
        }
    }
}
