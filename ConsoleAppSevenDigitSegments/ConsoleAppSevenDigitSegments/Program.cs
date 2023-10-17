using System;
using System.Threading;

// Antonio De Rosa 3H 2023-09-20
// Create a 7 Digit Display
namespace ConsoleAppSevenDigitSegments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n7 Segments Digit Display.\n");

            Console.WriteLine("  ▓▓▓▓▓ ");
            Console.WriteLine(" ▓     ▓");
            Console.WriteLine(" ▓     ▓");
            Console.WriteLine("  ▓▓▓▓▓ ");
            Console.WriteLine(" ▓     ▓");
            Console.WriteLine(" ▓     ▓");
            Console.WriteLine("  ▓▓▓▓▓ ");


            Console.CursorVisible = false;
            Console.WriteLine("Wait 5 Seconds then after the 4000 Hz *Beep* you'll get 9!.");
            Thread.Sleep(5000);

            Console.Beep(4000, 500);

            Console.SetCursorPosition(0, 12);
            Console.WriteLine("  ▓▓▓▓▓ ");
            Console.SetCursorPosition(0, 13);
            Console.WriteLine(" ▓     ▓");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine(" ▓     ▓");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("  ▓▓▓▓▓ ");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("       ▓ ");
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("       ▓");
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("  ▓▓▓▓▓ ");




            Console.WriteLine("\nPress a key to close the program.");
            Console.ReadKey();
        }
    }
}
