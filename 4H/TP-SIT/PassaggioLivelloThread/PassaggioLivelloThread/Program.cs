using System;
using System.IO;
using static System.Console;

namespace PassaggioLivelloThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuIniziale(); // Interfaccia del menu iniziale.

            MenuBinari();
            ReadKey();
        }

        static void MenuIniziale()
        {
            CursorVisible = false;
            ForegroundColor = (ConsoleColor)new Random().Next(1, 16);
            string s = "Ciao! Benvenuto nel simulatore di Treni e Passaggi a Livello.";
            SetCursorPosition((WindowWidth - s.Length) / 2, WindowHeight / 2);
            WriteLine(s);
            s = "Creato da Antonio De Rosa 4H. Premi un tasto per continuare";
            SetCursorPosition((WindowWidth - s.Length) / 2, (WindowHeight / 2) + 1);
            WriteLine(s);

            ReadKey();
            Clear();
        }

        static void MenuBinari()
        {
            ForegroundColor = ConsoleColor.White;

            using (StreamReader sr = new StreamReader("../../MenuBinari.txt"))
                while (!sr.EndOfStream)
                    WriteLine(sr.ReadLine());
        }
    }
}
