using System.Collections.Concurrent;
using System.Diagnostics;

namespace S26Con;

class Program
{
    static bool IsPrime(int n)
    {
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();
        int count = 0;
        List<int> primes = new List<int>();
        ConcurrentBag<int> prime_nums = new ConcurrentBag<int>();
        Parallel.For(2, 20_000_000, i =>
        {
            if (IsPrime(i))
            {
                // lock(sw)
                // count++;
                // Interlocked.Increment(ref count);
                // lock (primes) primes.Add(i);
                prime_nums.Add(i);
                
            }
        });
        System.Console.WriteLine(sw.Elapsed.ToString());
        System.Console.WriteLine(prime_nums.Count);
    }
}
