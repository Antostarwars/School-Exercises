using System.Text;

namespace Bingo
{
    internal class Program
    {

        enum Win
        {
            Five = 5,
            Ten = 10,
            Bingo = 15
        }

        // Initialize static variables
        static string[] board = new string[90];
        static Random random = new Random();
        static int numbersExtracted = 0;
        static int lastNumber;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = "##";
            }

            // Print Main Menu & Ask for a choice
            while (numbersExtracted != board.Length)
            {   
                PrintBoard();
                PrintMenu();
                char choice = Console.ReadKey(true).KeyChar;
                switch (choice)
                {
                    case 'E':
                        ExtractNumber();
                        break;
                    case 'C':
                        CheckWin(Win.Five);
                        break;
                    case 'D':
                        CheckWin(Win.Ten);
                        break;
                    case 'T':
                        CheckWin(Win.Bingo);
                        break;
                    case 'G':
                        GenerateCard();
                        break;
                    case 'A':
                        System.Environment.Exit(0);
                        break;
                }
            }

            Console.WriteLine("You've extracted every numbers!");
            Console.WriteLine("\nPress a key to stop the program.");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            string fileName = @"..\..\..\menu.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }

                sr.Close();
            }

        }

        static void PrintBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (i % 10 == 0) Console.WriteLine();
                Console.Write(board[i] + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Last number extracted is: {0}", lastNumber);
        }

        static void ExtractNumber()
        {

            while (true)
            {
                int number = random.Next(0, 90);
                if (board[number] == "##")
                {
                    if (number + 1 < 10) board[number] = "0" + (number + 1);
                    else board[number] = (number + 1).ToString();
                    numbersExtracted++;
                    lastNumber = number + 1;
                    break;
                }
            }
        }
        static int ReadInt()
        {
            bool inputOk = false;
            int number;
            do
            {
                Console.WriteLine("Insert the number");
                inputOk = int.TryParse(Console.ReadLine(), out number);
                if (number <= 0)
                {
                    Console.WriteLine("Number must be greater than 0");
                    inputOk = false;
                }
            } while (!inputOk);

            return number;
        }

        static void CheckWin(Win type)
        {
            // Check if the number is extracted
            bool win = false;
            for (int i = 0; i < (int) type;  i++)
            {
                int number = ReadInt();
                if (number.ToString() == board[number - 1]) win = true;
            }

<<<<<<< HEAD
            Console.WriteLine(win ? "You won!" : "You lose!");
=======
            Console.WriteLine(win ? "You have made " + (int)type + " in a row!" : "You haven't made " + (int)type + " in a row!");
>>>>>>> f8775a3430f656d9e2381f112e6f7be6a4584718
        }

        static void GenerateCard()
        {
            Console.Clear();

            Console.Write("--------------");
            for (int i = 0;i < 15;i++)
            {
                int number = random.Next(0, 90);
                if (i % 5 == 0) Console.WriteLine();

                if (number < 10) Console.Write("0" + number + " ");
                else Console.Write(number + " ");
            }
            Console.WriteLine("\n--------------");
        }
    }
}