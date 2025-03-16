using Microsoft.AspNetCore.Mvc;
using Moq;
using FibonacciAPI;
using Xunit;

namespace FibonacciAPITests;

public class FibonacciServiceTests
{
    [Fact]
    public async Task ThinkOfAGoodNameForThisTest()
    {
        // Arrange
        FibonacciService service = new FibonacciService();

        // Act
        var result = service.GetFibonacciSequenceAsync(1);

        // Assert
        Assert.Equal(0, 0);
    }
}