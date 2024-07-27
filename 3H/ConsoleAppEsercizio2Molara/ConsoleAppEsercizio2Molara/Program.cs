using System;

namespace ConsoleAppEsercizio2Molara
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.Title = "Income Calculator by Antonio De Rosa 3H";

            /*
             * 10,000€ 15%
             * oltre 10,000€ 20%
             * 
             * Se si superano i 10k€ i primi 10k vengono tassati al 15%
             * il restante al 20%
             * Esempio: 11k€ -> 10k al 15% e 1k al 20%
             */

            double grossIncome;
            double taxes = 0;
            bool inputOk;

            const double TAXES10K = 0.15;
            const double TAXES15K = 0.20;
            const double TAXES_OVER_15K = 0.23;

            const int LIMIT1 = 10000;
            const int LIMIT2 = 15000;

            do
            {
                Console.WriteLine("How much Gross Income do you have?");
                string input = Console.ReadLine();
                inputOk = double.TryParse(input, out grossIncome);
                if (!inputOk)
                {
                    Console.WriteLine("Gross Income it's not a valid currency.");
                }
                else if (grossIncome < 0)
                {
                    Console.WriteLine("Gross Income can't be negative.");
                }
            } while (!inputOk);

            if (grossIncome <= LIMIT1)
            {
                taxes = grossIncome * TAXES10K;
            }
            else if(grossIncome > LIMIT1 && grossIncome <= LIMIT2)
            {
                taxes = LIMIT1 * TAXES10K + (grossIncome-LIMIT1) * TAXES15K;
            } else
            {
                taxes = LIMIT1 * TAXES10K + 5000 * TAXES15K + (grossIncome - LIMIT2) * TAXES_OVER_15K;
            }

            Console.WriteLine($"You have to pay {taxes:C} in taxes.");

            Console.WriteLine("Press a key to stop the program");
            Console.ReadKey();
        }
    }
}