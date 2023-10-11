using System;
using System.Linq;
using System.Text;

// Antonio De Rosa 3H 2023-11-10
// Base conversion from 10 to 2 and from 10 to 16
namespace ConsoleAppConversionBase16and2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Title = "Antonio De Rosa 3H 2023-11-10";
            Console.Clear();

            #region Variables Declaration
            int numberBase10;
            string input;
            bool inputOK;
            #endregion

            #region Input Number Base 10
            do
            {
                Console.Write("Enter a Base 10 Number (Greater or Equals to 0): ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out numberBase10);

                if (!inputOK)
                {
                    Console.WriteLine("Input You Entered is not Valid!");
                }
                else if (numberBase10 < 0)
                {
                    Console.WriteLine("Number must be Greater or Equals to 0");
                    inputOK = false;
                }
            } while (!inputOK);
            #endregion

            Console.WriteLine("Number Entered in base 2 is equals to: {0}", ConvertToBinary(numberBase10));
            Console.WriteLine("Number Entered in base 16 is equals to: {0}", ConvertToHex(numberBase10));

            Console.Write("Press a key to stop the program.");
            Console.ReadKey();
        }

        #region Function that convert base 10 to binary
        private static string ConvertToBinary(int numberBase10)
        {
            string numberBase2 = "";
            int tempNumber = numberBase10;
            do
            {
                numberBase2 += (tempNumber % 2).ToString();
                tempNumber /= 2;
            } while (tempNumber > 0);
            return new string(numberBase2.ToCharArray().Reverse().ToArray());
        }
        #endregion

        #region Function that convert base 10 to hex
        private static string ConvertToHex(int numberBase10)
        {
            int tempNumber = numberBase10;
            string numberBase16 = "";
            do
            {
                if (tempNumber % 16 >= 10)
                {
                    numberBase16 += (char)((tempNumber % 16) - 10 + 'A');
                }
                else
                {
                    numberBase16 += $"{tempNumber % 16}";
                }

                if (tempNumber < 16) break;

                tempNumber /= 16;
            } while (tempNumber > 0);

            return new string(numberBase16.ToCharArray().Reverse().ToArray());
        }
        #endregion
    }
}
