namespace FibonacciAPI;

public class FibonacciService : IFibonacciService
{
    public async Task<ulong[]> GetFibonacciSequenceAsync(int n)
    {
        return await Task.Run(() =>
        {
            if (n == 0) return [];
            if (n == 1) return [0];

            ulong[] sequence = new ulong[n];
            sequence[0] = 0;
            sequence[1] = 1;

            for (int i = 2; i < n ; i++) 
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2];

            }
            return sequence;
        });
    }
}