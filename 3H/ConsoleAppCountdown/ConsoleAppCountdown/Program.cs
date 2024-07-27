// Antonio De Rosa 3H 2023-09-26

using System;
using System.Threading;

namespace ConsoleAppCountdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Countdown from 9-0 by Antonio De Rosa 3H";
            Console.WriteLine("Press a key to start the countdown from 9 to 0.\n");
            Console.ReadKey();
            Console.CursorVisible = false;


            #region Write 9
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.Write("  ████████ ");
            Console.SetCursorPosition(1, 3);
            Console.Write("█");
            Console.SetCursorPosition(10, 3);
            Console.Write("█");
            Console.SetCursorPosition(1, 4);
            Console.Write("█");
            Console.SetCursorPosition(10, 4);
            Console.Write("█");
            Console.SetCursorPosition(1, 5);
            Console.Write("█");
            Console.SetCursorPosition(10, 5);
            Console.Write("█");
            Console.SetCursorPosition(1, 6);
            Console.Write("█");
            Console.SetCursorPosition(10, 6);
            Console.Write("█");
            Console.SetCursorPosition(0, 7);
            Console.Write("  ████████ ");
            Console.SetCursorPosition(10, 8);
            Console.Write("█");
            Console.SetCursorPosition(10, 9);
            Console.Write("█");
            Console.SetCursorPosition(10, 10);
            Console.Write("█");
            Console.SetCursorPosition(10, 11);
            Console.Write("█");
            Console.SetCursorPosition(0, 12);
            Console.Write("  ████████ ");
            #endregion

            #region Write 8
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("█");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("█");
            Console.SetCursorPosition(1, 10);
            Console.WriteLine("█"); ;
            Console.SetCursorPosition(1, 11);
            Console.WriteLine("█");
            #endregion

            #region Write 7
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(1, 3);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 5);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 7);
            Console.Write("           ");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 10);
            Console.WriteLine(" ");
            Console.SetCursorPosition(1, 11);
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 12);
            Console.Write("           ");
            #endregion

            #region Write 6
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(1, 3);
            Console.Write("█");
            Console.SetCursorPosition(10, 3);
            Console.Write(" ");
            Console.SetCursorPosition(1, 4);
            Console.Write("█");
            Console.SetCursorPosition(10, 4);
            Console.Write(" ");
            Console.SetCursorPosition(1, 5);
            Console.Write("█");
            Console.SetCursorPosition(10, 5);
            Console.Write(" ");
            Console.SetCursorPosition(1, 6);
            Console.Write("█");
            Console.SetCursorPosition(10, 6);
            Console.Write(" ");
            Console.SetCursorPosition(0, 7);
            Console.Write("  ████████ ");
            Console.SetCursorPosition(1, 8);
            Console.Write("█");
            Console.SetCursorPosition(1, 9);
            Console.Write("█");
            Console.SetCursorPosition(1, 10);
            Console.Write("█");
            Console.SetCursorPosition(1, 11);
            Console.Write("█");
            Console.SetCursorPosition(0, 12);
            Console.Write("  ████████ ");
            #endregion

            #region Write 5
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(1, 8);
            Console.Write(" ");
            Console.SetCursorPosition(1, 9);
            Console.Write(" ");
            Console.SetCursorPosition(1, 10);
            Console.Write(" ");
            Console.SetCursorPosition(1, 11);
            Console.Write(" ");
            #endregion

            #region Write 4
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(0, 2);
            Console.Write("           ");
            Console.SetCursorPosition(10, 3);
            Console.Write("█");
            Console.SetCursorPosition(10, 4);
            Console.Write("█");
            Console.SetCursorPosition(10, 5);
            Console.Write("█");
            Console.SetCursorPosition(10, 6);
            Console.Write("█");
            Console.SetCursorPosition(0, 12);
            Console.Write("           ");
            #endregion

            #region Write 3
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(0, 2);
            Console.Write("  ████████ ");
            Console.SetCursorPosition(1, 3);
            Console.Write(" ");
            Console.SetCursorPosition(1, 4);
            Console.Write(" ");
            Console.SetCursorPosition(1, 5);
            Console.Write(" ");
            Console.SetCursorPosition(1, 6);
            Console.Write(" ");
            Console.SetCursorPosition(0, 12);
            Console.Write("  ████████ ");
            #endregion

            #region Write 2
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(1, 8);
            Console.Write("█");
            Console.SetCursorPosition(10, 8);
            Console.Write(" ");
            Console.SetCursorPosition(1, 9);
            Console.Write("█");
            Console.SetCursorPosition(10, 9);
            Console.Write(" ");
            Console.SetCursorPosition(1, 10);
            Console.Write("█");
            Console.SetCursorPosition(10, 10);
            Console.Write(" ");
            Console.SetCursorPosition(1, 11);
            Console.Write("█");
            Console.SetCursorPosition(10, 11);
            Console.Write(" ");
            #endregion

            #region Write 1
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(0, 2);
            Console.Write("           ");
            Console.SetCursorPosition(0, 7);
            Console.Write("           ");
            Console.SetCursorPosition(1, 8);
            Console.Write(" ");
            Console.SetCursorPosition(10, 8);
            Console.Write("█");
            Console.SetCursorPosition(1, 9);
            Console.Write(" ");
            Console.SetCursorPosition(10, 9);
            Console.Write("█");
            Console.SetCursorPosition(1, 10);
            Console.Write(" ");
            Console.SetCursorPosition(10, 10);
            Console.Write("█");
            Console.SetCursorPosition(1, 11);
            Console.Write(" ");
            Console.SetCursorPosition(10, 11);
            Console.Write("█");
            Console.SetCursorPosition(0, 12);
            Console.Write("           ");
            #endregion

            #region Write 0
            Thread.Sleep(1000);
            Console.Beep(4000, 500);
            Console.SetCursorPosition(0, 2);
            Console.Write("  ████████ ");
            Console.SetCursorPosition(1, 3);
            Console.Write("█");
            Console.SetCursorPosition(1, 4);
            Console.Write("█");
            Console.SetCursorPosition(1, 5);
            Console.Write("█");
            Console.SetCursorPosition(1, 6);
            Console.Write("█");
            Console.SetCursorPosition(1, 8);
            Console.Write("█");
            Console.SetCursorPosition(1, 9);
            Console.Write("█");
            Console.SetCursorPosition(1, 10);
            Console.Write("█");
            Console.SetCursorPosition(1, 11);
            Console.Write("█");
            Console.SetCursorPosition(0, 12);
            Console.Write("  ████████ ");
            #endregion

            Console.Beep(4000, 500);
            Console.Beep(4000, 500);
            Console.Beep(4000, 500);

            Console.SetCursorPosition(0, 14);
            Console.WriteLine("Press to Continue.");
            Console.ReadKey();
        }
    }
}