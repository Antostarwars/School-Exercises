using System.Text;

/*
 * Antonio De Rosa 3H 2023-12-19
 * Mastermind Game - Find the right code
 */
namespace MastermindGame
{
    internal class Program
    {
        static Random random = new Random(); // Generate Random Object

        const string header = "🧠 | M A S T E R M I N D | 🧠\n"; // Title used in more actions
        
        // Enum for the attempts
        enum Difficulty
        {
            Extreme = 1,
            Hard = 3, // This means 3 Attempts
            Medium = 6,
            Easy = 9
        }

        static Difficulty currentDifficulty = Difficulty.Easy; // Default Difficulty is Easy

        static void Main(string[] args)
        {
            // Main Menu Actions
            Console.OutputEncoding = Encoding.UTF8; // Encoding to UTF-8 for Emojis
            Console.Title = "Antonio De Rosa 3H Mastermind"; // Console Title
            while (true)
            {
                MainMenu(); // Prints Main Menu
                char choice = Console.ReadKey(true).KeyChar; // Get a char from the keyboard
                switch (choice)
                {
                    case '1':
                        ChangeDifficulty(); // Change Difficulty Menu
                        break;
                    case '2':
                        Game(); // Game Logic
                        break;
                    case '3':
                        return; // Exit Program
                }
            }
        }

        // Prints Main Menu
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine("Welcome to Mastermind Game!\n");
            Console.WriteLine("Choose an Option:");
            Console.WriteLine($"[1] Change Difficulty | Current Difficulty: {currentDifficulty}");
            Console.WriteLine("[2] Play the Game");
            Console.WriteLine("[3] Exit");
        }

        // Change Difficulty Menu and Logic
        static void ChangeDifficulty()
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine("Choose the new difficulty:");
            Console.WriteLine($"[1] Easy | Attemps: {(int) Difficulty.Easy}");
            Console.WriteLine($"[2] Medium | Attemps: {(int)Difficulty.Medium}");
            Console.WriteLine($"[3] Hard | Attemps: {(int)Difficulty.Hard}");
            Console.WriteLine($"[4] Extreme | Attemps: {(int)Difficulty.Extreme}");

            char choice = Console.ReadKey(true).KeyChar; // Get a Char from the Keyboard
            switch (choice)
            {
                case '1':
                    currentDifficulty = Difficulty.Easy; // Set to Easy
                    break;
                case '2':
                    currentDifficulty = Difficulty.Medium; // Set to Medium
                    break;
                case '3':
                    currentDifficulty = Difficulty.Hard; // Set to Hard
                    break;
                case '4':
                    currentDifficulty = Difficulty.Extreme; // Set to Extreme
                    break;
            }
        }

        // Main Game Function
        static void Game()
        {
            Console.Clear();
            int[] code = generateCode(); // Generate the code

            string[] hints;

            Console.WriteLine(header);
            // Write the code and find out if you have won
            for (int i = 0; i < (int)currentDifficulty; i++) // Iterate from 0 to Difficulty Attempts (Easy = 9)
            {
                Console.WriteLine($"Current Attempt: {i+1}/{(int)currentDifficulty}"); // Prints the current attempt
                if (checkWin(readCode(), code, out hints)) // If you win the game it will print the win text
                {
                    Console.WriteLine($"Congrats you won in {i+1} Attempts!");
                    Thread.Sleep(2000); // Delay then go into the Main Menu
                    break;
                } else
                {
                    // Prints the Hints
                    Console.WriteLine($"{hints[0]}\n{hints[1]}\n");
                }
            }
            // If you exit from the for loop it means you've lose the game
            Console.Write("\nYou lose... Try Again another time!\nThe code was: ");
            // Prints the code in console
            foreach (int ind in code)
            {
                Console.Write(ind);
            }
            Thread.Sleep(2000);
        }

        // Generate the Code
        static int[] generateCode()
        {
            int[] code = new int[4];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = random.Next(10); // Random from 0 to 9
            }

            return code;
        }

        // Read the code (String) and put it into int array
        static int[] readCode()
        {
            int[] code = new int[4];
            bool inputOk = false;
            do
            {
                Console.WriteLine("Write your attempt to find the right code! (4 Numbers)");
                string input = Console.ReadLine();
                if (input != null && input.Length >= 4)
                {
                    for (int i = 0; i < 4; i++) // Get every Char of the string and parse to Int
                    {
                        inputOk = int.TryParse(input[i].ToString(), out code[i]);
                        if (!inputOk)
                        {
                            Console.WriteLine("Code is not an integer.");
                            break;
                        }
                    }
                } else
                {
                    Console.WriteLine("Code must be 4 numbers!");
                }
            } while (!inputOk);

            return code;
        }

        // Check for the win
        static bool checkWin(int[] userCode, int[] code, out string[] hints)
        {
            string[] hintsFormatted = new string[2];
            int numbersRightPlace = 0;
            int numbersWrongPlace = 0;

            for (int i = 0; i < code.Length; i++)
            {
                if (userCode[i] == code[i]) numbersRightPlace++; // If the number is right add the counter
                if (code.Contains(userCode[i])) numbersWrongPlace++; // If the number is contained in the code add the counter
            }

            numbersWrongPlace -= numbersRightPlace; // If the number is contained but also right it will remove it from the wrong counter
            
            // Set messages
            hintsFormatted[0] = $"You got {numbersRightPlace} digit in the Right Place";
            hintsFormatted[1] = $"You got {numbersWrongPlace} digit in the Wrong Place";

            Console.WriteLine(string.Join(", ", code));

            // return things (out + return)
            hints = hintsFormatted;
            return numbersRightPlace == 4;
        }
    }
}