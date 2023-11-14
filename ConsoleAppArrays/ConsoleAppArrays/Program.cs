using System;

// Antonio De Rosa 3H 11-14-2023.
// Calculate the Average from an array and then print all the values >= of the average.
namespace ConsoleAppArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculate the Average from an array and then print all the values >= of the average by Antonio De Rosa 3H");
            int N;
            double average = 0.0, sum = 0.0;
            bool inputOk;

            #region Read double Input.
            do
            {
                Console.WriteLine("Insert how many double you want to add");
                inputOk = int.TryParse(Console.ReadLine(), out N);
                if (!inputOk)
                {
                    Console.WriteLine("Input isn't an Integer Number!");
                } else if (N <= 0)
                {
                    Console.WriteLine("Number is negative!");
                    inputOk = false;
                }
            } while (!inputOk);
            #endregion

            // Allocate the array with N size.
            double[] numbers = new double[N];

            #region Read double numbers and set it to the every indices.
            for (int i = 0; i < N; i++)
            {
                do
                {
                    Console.WriteLine("Insert a Double Value");
                    inputOk = double.TryParse(Console.ReadLine(), out numbers[i]);
                    if (!inputOk)
                    {
                        Console.WriteLine("Input isn't an double Number!");
                    }
                } while (!inputOk);

                sum += numbers[i];
            }
            #endregion

            // calculate the average.
            average = sum/N;
            #region Print only numbers than are greater than the average.
            for (int i = 0; i<N; i++) 
            {
                if (numbers[i] >= average)
                {
                    Console.WriteLine("{0} is greater than the average {1}", numbers[i], average);
                }
            }
            #endregion
        }
    }
}