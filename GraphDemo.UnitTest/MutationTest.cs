using FluentAssertions;
using GraphDemo.Entities;
using GraphDemo.Models;
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
        private readonly Mock<ILogger<Mutation>> mockLogger;
        private Mutation mutation;

        public MutationTest()
        {
            mockLogger = new Mock<ILogger<Mutation>>();
            mutation = new Mutation(mockLogger.Object);
        }

        [Fact]
        public async void AddOrderShouldThrowErrorForInvalidInput()
        {
            //Arrange
            var order = new AddOrderInput();

            //Act
            var mutationStatus = await  Assert.ThrowsAsync<Exception>(() => mutation.AddOrderAsync(order, null));

            //Assert
            mutationStatus.Message.Should().Be("Bad request");
        }
    }
}
