using System.Security.Cryptography;

namespace ConsoleAppMonteCarloMethod
{
    internal class Program
    {
        const double SIDE = 1.0;
        const long TOTAL_POINTS = 10000000000;

        static void Main(string[] args)
        {
            Random rdn = new Random();

            double squaredSide = Math.Pow(SIDE, 2);
            int innerPoints = 0;
            double stimatePI = 0;
            for (int i = 0; i < TOTAL_POINTS; i++)
            {
                double x = rdn.NextDouble() * SIDE;
                double y = rdn.NextDouble() * SIDE;

                if (Math.Pow(x, 2) + Math.Pow(y, 2) <= squaredSide)
                {
                    innerPoints++;
                }

                stimatePI = 4.0 * ((double)innerPoints / (double)TOTAL_POINTS);
            }

            Console.WriteLine("Stimate PI is {0}", stimatePI);
        }
    }
}