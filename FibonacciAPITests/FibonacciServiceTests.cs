using FibonacciAPI;
using Xunit;

namespace FibonacciAPITests;

public class FibonacciServiceTests
{
    [Theory]
    [InlineData(new ulong[] { }, 0)]
    [InlineData(new ulong[] { 0 }, 1)]
    [InlineData(new ulong[] { 0, 1 }, 2)]
    [InlineData(new ulong[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 }, 9)]
    public async Task FibonacciTest(ulong[] expected, int length)
    {
        // Arrange
        FibonacciService service = new FibonacciService();

        // Act
        var result = await service.GetFibonacciSequenceAsync(length);

        // Assert
        Assert.Equal(expected, result);
    }
}