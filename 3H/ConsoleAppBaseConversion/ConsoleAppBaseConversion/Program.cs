using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBaseConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Base Converter by Antonio De Rosa 3H";
            Console.Clear();
            Console.WriteLine("Base Converter by Antonio De Rosa (2023-10-04)");

            /*
            #region I/O Int Value
            int varInt;
            bool inputOk;

            do
            {
                Console.Write("Insert Int Value -> ");
                string input = Console.ReadLine();
                inputOk = int.TryParse(input, out varInt);
                if (!inputOk)
                {
                    Console.WriteLine("Input it's not an int");
                }
            } while (!inputOk);
            #endregion

            Console.WriteLine($"Input: {varInt}\n");

            Console.WriteLine($"Input in Base 10: {Convert.ToString(varInt, 10)}"); // Convert the int in base 10
            Console.WriteLine($"Input in Base 16: {Convert.ToString(varInt, 16)}"); // Convert the int in base 16
            Console.WriteLine($"Input in Base 2: {Convert.ToString(varInt, 2)}\n"); // Convert the int in base 2
            */

            #region I/O Int Value and Base to Convert
            int valueToConvert;
            int convertBase;
            bool inputOk;

            do
            {
                Console.Write("Enter the value you want to be converted: ");
                string input = Console.ReadLine();
                inputOk = int.TryParse(input, out valueToConvert);
                if (!inputOk)
                {
                    Console.WriteLine("Input it's not an int");
                }
            } while (!inputOk);

            do
            {
                Console.Write("Enter the base with which you want to convert the value: ");
                string input = Console.ReadLine();
                inputOk = int.TryParse(input, out convertBase);
                if (!inputOk)
                {
                    Console.WriteLine("Input it's not an int");
                } else if (convertBase != 2 && convertBase != 10 && convertBase != 16 && convertBase != 8)
                {
                    inputOk = false;
                    Console.WriteLine("Use a Valid Base! (Available Base: 2, 10, 16, 8)");
                }
            } while (!inputOk);

            Console.WriteLine($"The Value {valueToConvert} Converted to Base {convertBase}: {Convert.ToString(valueToConvert, convertBase)}");
            #endregion
            Console.WriteLine("Press a Key to Stop the Program.");
            Console.ReadKey();
        }
    }
}
