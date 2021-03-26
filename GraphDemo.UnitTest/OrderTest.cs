using FluentAssertions;
using GraphDemo.Query;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphDemo.UnitTest
{
    public class OrderTest
    {
        private readonly Mock<ILogger<QueryResolver>> mockLogger;
        private QueryResolver queryResolver;

        public OrderTest()
        {
            mockLogger = new Mock<ILogger<QueryResolver>>();
            queryResolver = new QueryResolver(mockLogger.Object);
        }

        [Fact]
        public void GetOrderSummeryShouldThrowException()
        {
            //Arrange and Act
            var mutationStatus = Assert.Throws<InvalidOperationException>(() => queryResolver.GetOrderSummery(null, 0));

            //Assert
            mutationStatus.Message.Should().Be("Invalid OrderId");
        }
    }
}
