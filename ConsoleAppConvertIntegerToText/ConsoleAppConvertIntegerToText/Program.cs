using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Antonio De Rosa 3H 2023-10-17
// Converts Integer to Text Example: 100 -> one hundred.
namespace ConsoleAppConvertIntegerToText
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Formatting Console.
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.Title = "Convert Integer to Text by Antonio De Rosa 3H";
            Console.WriteLine("Convert Integer to Text by Antonio De Rosa 3H");

            int numberToConvert;
            bool inputOK = false;
            do
            {
                Console.WriteLine("Insert the number you want to convert (0-9999)");
                inputOK = int.TryParse(Console.ReadLine(), out numberToConvert);
                if (!inputOK)
                {
                    Console.WriteLine("Number is not a Valid Integer");
                }
                else if (numberToConvert < 0 || numberToConvert > 9999)
                {
                    inputOK = false;
                    Console.WriteLine("Number is not in the range (0-9999)");
                }
            } while (inputOK == false);

            string result = "";

            int thousands = numberToConvert / 1000;
            int hundreds = (numberToConvert % 1000) / 100;
            int tens = (numberToConvert % 100) / 10;
            int ones = numberToConvert % 10;

            switch (thousands)
            {
                case 1:
                    result += "one thousand ";
                    break;
                case 2:
                    result += "two thousand ";
                    break;
                case 3:
                    result += "three thousand ";
                    break;
                case 4:
                    result += "four thousand ";
                    break;
                case 5:
                    result += "five thousand ";
                    break;
                case 6:
                    result += "six thousand ";
                    break;
                case 7:
                    result += "seven thousand ";
                    break;
                case 8:
                    result += "eight thousand ";
                    break;
                case 9:
                    result += "nine thousand ";
                    break;
            }
            switch (hundreds)
            {
                case 1:
                    result += "one hundred ";
                    break;
                case 2:
                    result += "two hundred ";
                    break;
                case 3:
                    result += "three hundred ";
                    break;
                case 4:
                    result += "four hundred ";
                    break;
                case 5:
                    result += "five hundred ";
                    break;
                case 6:
                    result += "six hundred ";
                    break;
                case 7:
                    result += "seven hundred ";
                    break;
                case 8:
                    result += "eight hundred ";
                    break;
                case 9:
                    result += "nine hundred ";
                    break;
            }

            if (tens >= 2)
            {
                switch (tens)
                {
                    case 2:
                        result += "twenty ";
                        break;
                    case 3:
                        result += "thirty ";
                        break;
                    case 4:
                        result += "fourty ";
                        break;
                    case 5:
                        result += "fifty ";
                        break;
                    case 6:
                        result += "sixty ";
                        break;
                    case 7:
                        result += "seventy ";
                        break;
                    case 8:
                        result += "eighty ";
                        break;
                    case 9:
                        result += "ninety ";
                        break;
                }

                switch (ones)
                {
                    case 1:
                        result += "one ";
                        break;
                    case 2:
                        result += "two ";
                        break;
                    case 3:
                        result += "three ";
                        break;
                    case 4:
                        result += "four ";
                        break;
                    case 5:
                        result += "five ";
                        break;
                    case 6:
                        result += "six ";
                        break;
                    case 7:
                        result += "seven ";
                        break;
                    case 8:
                        result += "eight ";
                        break;
                    case 9:
                        result += "nine ";
                        break;
                }
            }
            else
            {
                int twoDigitNumber = tens * 10 + ones;
                switch (twoDigitNumber)
                {
                    case 10:
                        result += "ten ";
                        break;
                    case 11:
                        result += "eleven ";
                        break;
                    case 12:
                        result += "twelve ";
                        break;
                    case 13:
                        result += "thirteen ";
                        break;
                    case 14:
                        result += "fourteen ";
                        break;
                    case 15:
                        result += "fifteen ";
                        break;
                    case 16:
                        result += "sixteen ";
                        break;
                    case 17:
                        result += "seventeen ";
                        break;
                    case 18:
                        result += "eighteen ";
                        break;
                    case 19:
                        result += "nineteen ";
                        break;

                    default:
                        switch (ones)
                        {
                            case 1:
                                result += "one ";
                                break;
                            case 2:
                                result += "two ";
                                break;
                            case 3:
                                result += "three ";
                                break;
                            case 4:
                                result += "four ";
                                break;
                            case 5:
                                result += "five ";
                                break;
                            case 6:
                                result += "six ";
                                break;
                            case 7:
                                result += "seven ";
                                break;
                            case 8:
                                result += "eight ";
                                break;
                            case 9:
                                result += "nine ";
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine("The number {0} in text is {1}", numberToConvert, result);

            Console.WriteLine("Press a key to stop the program");
            Console.ReadKey();
        }
    }
}
