using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIfElseSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Formatting Console.
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.Title = "Convert Integer to Text by Antonio De Rosa 3H";

            int numberToConvert;
            bool inputOK = false;
            do
            {
                Console.WriteLine("Insert the number you want to convert (0-9)");
                inputOK = int.TryParse(Console.ReadLine(), out numberToConvert);
                if (!inputOK)
                {
                    Console.WriteLine("Number is not a Valid Integer");
                }
                else if (numberToConvert < 0 || numberToConvert > 9)
                {
                    inputOK = false;
                    Console.WriteLine("Number is not in the range (0-9)");
                }
            } while (inputOK == false);
            #region Switch
            Console.WriteLine("Using Switch:");
            switch (numberToConvert)
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eight");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
            }
            #endregion

            #region If
            Console.WriteLine("Using IF and Else:");
            if (numberToConvert == 0)
            {
                Console.WriteLine("zero");
            }
            else if (numberToConvert == 1)
            {
                Console.WriteLine("one");
            }
            else if (numberToConvert == 2)
            {
                Console.WriteLine("two");
            }
            else if (numberToConvert == 3)
            {
                Console.WriteLine("three");
            }
            else if (numberToConvert == 4)
            {
                Console.WriteLine("four");
            }
            else if (numberToConvert == 5)
            {
                Console.WriteLine("five");
            }
            else if (numberToConvert == 6)
            {
                Console.WriteLine("six");
            }
            else if (numberToConvert == 7)
            {
                Console.WriteLine("seven");
            }
            else if (numberToConvert == 8)
            {
                Console.WriteLine("eight");
            }
            else if (numberToConvert == 9)
            {
                Console.WriteLine("nine");
            }
            #endregion

            Console.WriteLine("Press a key to stop the program.");
            Console.ReadKey();
        }
    }
}
