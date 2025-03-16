public interface IFibonacciService
{
    public Task<ulong[]> GetFibonacciSequenceAsync(int n);
}