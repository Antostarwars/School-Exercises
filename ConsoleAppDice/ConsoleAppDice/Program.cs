using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

            Console.WriteLine("Press a key to close the program.");
            Console.ReadKey();
        }

        private static void Game()
        {
            const int STARTING_SESTERTIUS = 50;
            const int MIN_DICE = 2;
            const int MAX_DICE = 12;
            const int BET_MULTIPLIER = 10;

            int sestertius = STARTING_SESTERTIUS;

            bool inputOk;
            int bet;
            int numberBetted;
            int diceNumber;
            while (true)
            {
                Console.Clear();
                if (sestertius <= 0)
                {
                    Console.WriteLine("You don't have any more sestertius!");
                    break;
                }

                diceNumber = new Random().Next(MIN_DICE, MAX_DICE);
                do
                {
                    Console.WriteLine("How many Sestertius do you want to bet? You have {0} Sestertius", sestertius);
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

                do
                {
                    Console.WriteLine("What number you want to bet ({0}-{1})", MIN_DICE, MAX_DICE);
                    inputOk = int.TryParse(Console.ReadLine(), out numberBetted);
                    if (!inputOk)
                    {
                        Console.WriteLine("Input is not an Integer. Try Again!");
                    } else if (numberBetted < MIN_DICE && numberBetted > MAX_DICE)
                    {
                        inputOk = false;
                        Console.WriteLine("You cannot bet this number ({0}-{1})", MIN_DICE, MAX_DICE);
                    }
                } while (!inputOk);

                if (numberBetted == diceNumber)
                {
                    Console.WriteLine("You won {0} Sestertius! You're bet was right!", bet * BET_MULTIPLIER);
                    sestertius += bet * BET_MULTIPLIER;
                    Console.WriteLine("You now have {0} Sestertius!", sestertius);
                } else
                {
                    Console.WriteLine("You Lose! You're bet was {0} but the dice was {1}", numberBetted, diceNumber);
                    Console.WriteLine("You now have {0} Sestertius!", sestertius);
                }

                Console.WriteLine("Do you want to play again? If so press (s)");
                char choose = Console.ReadKey().KeyChar;
                if (choose != 's')
                {
                    break;
                }
            }
        }
    }
}
