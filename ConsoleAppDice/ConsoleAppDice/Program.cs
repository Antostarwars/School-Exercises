using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleAppDice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Alea Iacta Est by Antonio De Rosa 3H";
            Console.WriteLine("Welcome to Alea Iacta Est!");
            Console.WriteLine("");
            Console.WriteLine("[1] Play the Game");
            Console.WriteLine("[2] Quit");
            Console.WriteLine();
            Console.Write("Select an Option: ");
                
            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case '1':
                    Game();
                    break;
                case '2':
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Game()
        {   
            Console.Clear();
            const int STARTING_SESTERTIUS = 50;
            const int MIN_DICE = 2;
            const int MAX_DICE = 12;

            int sestertius = STARTING_SESTERTIUS;

            bool inputOk;
            int bet;
            while (true)
                do
                {
                    Console.WriteLine("How many Sestertius do you want to bet?");
                    inputOk = int.TryParse(Console.ReadLine(), out bet);
                    if (!inputOk)
                    {
                        Console.WriteLine("Input is not an Integer. Try Again!");
                    } else if (bet > sestertius) 
                    {
                        inputOk = false;
                        Console.WriteLine("You cannot bet more than the Sestertius you have!");
                    } else
                    {
                        sestertius -= bet;
                    }
                } while (!inputOk);
            
            }
        }
    }
}
