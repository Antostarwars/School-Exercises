namespace Bingo
{
    internal class Program
    {
        // Initialize static variables
        static string[] board = new string[90];
        static Random random = new Random();

        static void Main(string[] args)
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = "##";
            }

            // Print Main Menu & Ask for a choice
            while (true)
            {
                PrintMenu();
                char choice = Console.ReadKey(true).KeyChar;
                switch (choice)
                {
                    case 'E':
                        PrintBoard();
                        break;
                    case 'A':
                        System.Environment.Exit(0);
                        break;
                }
            }

            /*
            PrintBoard();
            ExtractNumber();
            Console.Clear();
            PrintBoard();
            */
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
        } 

        static void ExtractNumber()
        {

            while (true)
            {
                int number = random.Next(0, 90);
                if (board[number] == "##")
                {
                    if (number + 1 < 10) board[number] = "0" + (number + 1);
                    else board[number] = (number +1).ToString();

                    break;
                } 
            }
        }
    }
}