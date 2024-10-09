using System.Diagnostics;

namespace BitArrays
{
    internal class Program
    {
        static List<long> EratosthenesSieve(long max_value)
        {
            List<long> primes = new List<long>();

            BitArray sieve = new BitArray(max_value + 1, true);
            for (long n = 2; n <= max_value; ++n)
            {
                if (sieve[n])  // se true, allora n è primo
                {
                    primes.Add(n);
                    for (long mult_n = (n << 1); mult_n <= max_value; mult_n += n)  // genera tutti i multipli di n, che vanno marcati come non-primi
                    {
                        sieve[mult_n] = false;
                    }
                }
            }

            return primes;
        }

        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            List<long> primes = EratosthenesSieve(100);
            timer.Stop();

            Console.WriteLine($"Found {primes.Count:N} primes in {timer.ElapsedMilliseconds} ms");
            foreach (long n in primes)
                Console.Write($"{n}, ");
            Console.WriteLine();
        }
    }
}
