using System;

// Antonio De Rosa 3H 2023-09-27
namespace ConsoleAppReadInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Read Input by Antonio De Rosa 3H";
            Console.Clear();
            Console.WriteLine("Read Input by Antonio De Rosa 3H");

            Console.Write("String Input -> "); // Ask to enter a String.
            String input = Console.ReadLine(); // Read the String.
            Console.WriteLine("String inputted: " + input); // Output the String.

            // Ask and Check for a Number.
            bool inputOk = false;
            int varInt;
            do
            {
                Console.Write("Input a Integer Number -> ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out varInt); // Try to parse the String into and int, if it's valid return true

                if (!inputOk) Console.WriteLine("Input not valid. Try Again!");
            } while (!inputOk); // If number isn't valid do the do while cycle again.

            Console.WriteLine("Press a key to stop the program.");
            Console.ReadKey();
        }
    }
}
