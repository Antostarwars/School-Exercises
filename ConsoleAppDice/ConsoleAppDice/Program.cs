using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConsoleAppDice
{
    internal class Program
    {
        // Antonio De Rosa 3H 2023-10-10
        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Title = "Alea Iacta Est by Antonio De Rosa 3H";
            Console.WriteLine("Welcome to Alea Iacta Est!");
            Console.WriteLine("");
            Console.WriteLine("[1] Play the Game");
            Console.WriteLine("[2] Quit");
            Console.WriteLine();
            Console.Write("Select an Option: ");
                
            char choice = Console.ReadKey().KeyChar;

            switch (choice) // Different action per choice
            {
                case '1':
                    Game();
                    break;
                case '2':
                    Environment.Exit(0);
                    break;
                default: 
                    Environment.Exit(0);
                    break;

            }

            Console.WriteLine("\nPress a key to close the program.");
            Console.ReadKey();
        }

        private static void Game()
        {
            // Constants
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

                diceNumber = new Random().Next(MIN_DICE, MAX_DICE + 1); // Create a random number from 2 to 12.

                // Ask the amount of the bet.
                do
                {
                    Console.WriteLine("How many Sestertius do you want to bet? You have {0} Sestertius", sestertius);
                    inputOk = int.TryParse(Console.ReadLine(), out bet);
                    if (!inputOk)
                    {
                        Console.WriteLine("Input is not an Integer. Try Again!");
                    } else if (bet > sestertius || bet < 0)
                    {
                        inputOk = false;
                        Console.WriteLine("You cannot bet more than the Sestertius you have!");
                    } else
                    {
                        sestertius -= bet;
                    }
                } while (!inputOk);

                // Ask the Number you want to bet.
                do
                {
                    Console.WriteLine("What number you want to bet ({0}-{1})", MIN_DICE, MAX_DICE);
                    inputOk = int.TryParse(Console.ReadLine(), out numberBetted);
                    if (!inputOk)
                    {
                        Console.WriteLine("Input is not an Integer. Try Again!");
                    } else if (numberBetted < MIN_DICE || numberBetted > MAX_DICE)
                    {
                        inputOk = false;
                        Console.WriteLine("You cannot bet this number ({0}-{1})", MIN_DICE, MAX_DICE);
                    }
                } while (!inputOk);

                // Simulates the dice rolling and wait 2 seconds.
                Console.WriteLine("Dices are Rolling...");
                Thread.Sleep(2000);

                // Check is the dice and the number betted was the same.
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

                // ask to play again
                Console.WriteLine("Do you want to play again? If so press (s)");
                char choose = Console.ReadKey().KeyChar;
                if (choose == 's' || choose == 'S')
                {
                    continue;
                } else
                {
                    break;
                }
            }
        }
    }
}
