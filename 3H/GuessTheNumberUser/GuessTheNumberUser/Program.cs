using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuessTheNumberUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Think of a number in the range of 1-100");
            bool guessed = false;
            int start = 1;
            int end = 101;
            while (!guessed)
            {

                int number = new Random().Next(start, end);

                Console.WriteLine($"The number you're thinking is {number}?");
                Console.WriteLine("Use = if guessed, < if too low or > if too high");
                char symbol = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (symbol)
                {
                    case '=':
                        guessed = true;
                        break;
                    case '<':
                        start = number;
                        break;
                    case '>':
                        end = number;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("The machine won this time!");

            Console.WriteLine("Press a key to stop the program.");
            Console.ReadKey();
        }
    }
}
