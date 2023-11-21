
// Antonio De Rosa 3H
// Countdown using arrays
namespace Countdown
{
    internal class Program
    {
        static string[] cifra_0 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_1 = {
            "       ▓",
            "       ▓",
            "       ▓",
            "        ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_2 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
            "▓       ",
            "▓       ",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_3 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_4 = {
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_5 = {
            " ▓▓▓▓▓▓ ",
            "▓      ",
            "▓      ",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_6 = {
            " ▓▓▓▓▓▓ ",
            "▓      ",
            "▓      ",
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_7 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "        ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_8 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_9 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };

        static void PrintNumber(string[] number, int column, int row)
        {
            Console.Clear();
            Console.SetCursorPosition(column, row);

            for (int i = 0; i < number.Length; i++) 
            {
                Console.WriteLine(number[i]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start the countdown");
            Console.ReadKey();

            PrintNumber(cifra_9, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_8, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_7, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_6, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_5, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_4, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_3, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_2, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_1, 0, 2);
            Thread.Sleep(1000);
            PrintNumber(cifra_0, 0, 2);
            Thread.Sleep(1000);
        }
    }
}