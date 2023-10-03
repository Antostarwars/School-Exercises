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

            #region Read Int & Double
            /*
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
                inputOk = int.TryParse(input, out varInt); // Try to parse the String into an int, if it's valid return true

                if (!inputOk) Console.WriteLine("Input not valid. Try Again!");
            } while (!inputOk); // If number isn't valid do the do while cycle again.

            // Ask and Check for a Double Number.
            Double varDouble;
            do
            {
                Console.Write("Input a Double Number -> ");
                input = Console.ReadLine();
                inputOk = Double.TryParse(input, out varDouble); // Try to parse the String into a Double, if it's valid return true

                if (!inputOk) Console.WriteLine("Input not valid. Try Again!");
            } while (!inputOk); // If number isn't valid do the do while cycle again.
            */
            #endregion

            /*
            #region Read Students
            int students;
            bool studentsInputOk;
            const int MINIMUMSTUDENTS = 10;
            const int MAXIMUMSTUDENTS = 35;
            do
            {
                Console.WriteLine($"Insert Students Number. ({MINIMUMSTUDENTS}-{MAXIMUMSTUDENTS})");
                String input = Console.ReadLine();
                studentsInputOk = int.TryParse(input, out students);
                if (!studentsInputOk)
                {
                    Console.WriteLine("Input it's not an int.");
                }
                else if (students < MINIMUMSTUDENTS || students > MAXIMUMSTUDENTS)
                {
                    studentsInputOk = false;
                    Console.WriteLine($"Students it's out of range. ({MINIMUMSTUDENTS}-{MAXIMUMSTUDENTS})");
                }
            } while (!studentsInputOk);

            Console.WriteLine($"You entered {students} students");
            #endregion
            */

            #region Read Height
            double height;
            bool heightInputOk;
            const double MINIMUMHEIGHT = 0.24;
            const double MAXIMUMHEIGHT = 2.51;
            do
            {
                Console.WriteLine($"Insert Height Number in Meters. ({MINIMUMHEIGHT}m-{MAXIMUMHEIGHT}m)");
                String input = Console.ReadLine();
                heightInputOk = double.TryParse(input, out height);
                if (!heightInputOk)
                {
                    Console.WriteLine("Input it's not a double.");
                }
                else if (height < MINIMUMHEIGHT || height > MAXIMUMHEIGHT)
                {
                    heightInputOk = false;
                    Console.WriteLine($"Height it's out of range. ({MINIMUMHEIGHT}m-{MAXIMUMHEIGHT}m)");
                }
            } while (!heightInputOk);
            Console.WriteLine($"You entered {height}m");
            #endregion

            Console.WriteLine("Press a key to stop the program.");
            Console.ReadKey();

        }
    }
}
