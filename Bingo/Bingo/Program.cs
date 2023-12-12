using System.Text;

// Antonio De Rosa 3H 2023-11-28
// Bingo Game (Card Generator, Numbers Extractor, Win Check)
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
            Console.Title = "Antonio De Rosa 3H 2023-11-28";
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
                        int[,] card = GenerateCard();
                        Console.WriteLine(WriteCard(card));
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
            for (int i = 0; i < (int)type; i++)
            {
                int number = ReadInt();
                if (number.ToString() == board[number - 1]) win = true;
            }
            Console.WriteLine(win ? "You have made " + (int)type + " in a row!" : "You haven't made " + (int)type + " in a row!");
        }

        static int[,] GenerateCard()
        {
            int[,] card = new int[9, 3];
            int[] numExtracted = new int[9];
            bool[] valUsciti = new bool[board.Length];

            for (int i = 0; i < 15; i++)
            {
                bool continua = true;
                while (continua)
                {
                    int valore = random.Next(90) + 1; // Generate a Random Number
                    if (valore == 90) // Case 1: 90/10 != 8
                    {
                        if (numExtracted[8] == 3)
                            continue;
                        numExtracted[8]++;
                        valUsciti[valore - 1] = true;
                        for (int e = 0; e < 3; e++)
                        {
                            if (card[8, e] == 0)
                            {
                                card[8, e] = valore;
                                continua = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (numExtracted[valore / 10] == 3 || valUsciti[valore - 1])   // 3 Numbers are generated so i continue with tens range
                            continue;
                        numExtracted[valore / 10]++; // Counter + 1
                        valUsciti[valore - 1] = true;
                        for (int e = 0; e < 3; e++)
                        {
                            if (card[valore / 10, e] == 0)        // If it's not inizialized it means it's not extracted
                            {
                                card[valore / 10, e] = valore;    // set the value
                                continua = false;                   // Exit the while loop
                                break;
                            }
                        }
                    }
                }
            }
            return card;
        }

        static string WriteCard(int[,] card)
        {
            string[] righe = new string[4];

            for (int x = 0; x < 3; x++)
            {
                righe[x] = "|";
                for (int y = 0; y < 9; y++)
                {
                    if (card[y, x] == 0)    // Value not extracted
                        righe[x] += "  ##";     // Default Symbol
                    else
                        righe[x] += $"  {card[y, x]:00}";   // Value
                }
            }


            return "+--------------------------------------+\n" +
                                    string.Join("  |\n", righe) +
                   "+--------------------------------------+";  // String format
        }
    }
}