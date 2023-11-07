using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsole
{
    internal class Program
    {
        static void TestColorAndKeys(string[] args)
        {
            // Change Background Color and Foreground Color
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
          
            char symbol = '#';
            while (true)
            {
                Console.Write(symbol);
                // Console.ReadKey(true); // Con parametro intercept == true non viene scritto sulla console il tasto premuto.
                ReadKey();
                char key = ReadKey();
                if (key == 'x')
                    symbol = '@';
            }
        }

        static char ReadKey()
        {
            // Return the key pressed, or '\0' if no key is pressed
            if (!Console.KeyAvailable) return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.KeyChar;
        }

        static void Main(String[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Press a key when you think 10 seconds are elapsed.");

            stopwatch.Restart();
            while (ReadKey() == '\0')
            {
            }
            stopwatch.Stop();

            Console.WriteLine($"stopwatch.Elapsed = {stopwatch.Elapsed}");
            Console.WriteLine($"stopwatch.ElapsedMilliseconds = {stopwatch.ElapsedMilliseconds}");

            Console.ReadKey();
        }
    }
}
