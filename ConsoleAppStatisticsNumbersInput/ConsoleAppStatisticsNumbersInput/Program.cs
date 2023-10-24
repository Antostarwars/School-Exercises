
// Antonio De Rosa 3H
// Calcolo del valore minimo, massimo e media di numeri inseriti in input.
namespace ConsoleAppStatisticsNumbersInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // General Info about the program.
            Console.Clear();
            Console.Title = "Statistics Calculator by Antonio De Rosa 3H";
            Console.WriteLine("Statistics Calculator by Antonio De Rosa 3H");

            // Variables Initialization.
            int numbers = 0;
            double maxValue = double.MinValue; 
            double minValue = double.MaxValue;
            double sum = 0;
            double average;

            // inputs.
            while (true) 
            {
                Console.WriteLine("Enter a double Value. (Write end to stop)");
                string input = Console.ReadLine();

                // Check for "end".
                if (input.ToLower() == "end")
                {
                    Console.Clear();
                    Console.WriteLine("You entered: {0} numbers", numbers);
                    break;
                }
                double number;
                bool inputOK = double.TryParse(input, out number);
;               if (!inputOK)
                {
                    Console.WriteLine("Number isn't a valid Double. Try Again!");
                    continue;
                } else
                {
                    // Calculates Sum.
                    numbers++;
                    sum += number;

                    // Calculates Minimum and Maximum.
                    if (number > maxValue)
                    {
                        maxValue = number;
                    }
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }
            }
            // Calculates Average.
            if (numbers == 0)
            {
                average = 0;
                minValue = 0;
                maxValue = 0;
            } else
            {
                average = sum / numbers;
            }
           

            // Output
            Console.WriteLine("Average is: {0}", average);
            Console.WriteLine("Max Value is: {0}", maxValue);
            Console.WriteLine("Min Value is: {0}", minValue);
        }
    }
}