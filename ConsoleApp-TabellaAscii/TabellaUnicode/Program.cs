using System;
using System.Collections.Generic;

/*
 * Antonio De Rosa 3H 2024-02-28
 */
namespace TabellaUnicode
{
    internal class Program
    {
        const int SIZE_TABLE = 65536;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Title = "Antonio De Rosa 3H 2024-02-28";
            for (int i = 0; i < SIZE_TABLE / 8; i++)
            {
                List<string> chars = new List<string>();
                for (int e = i; e < SIZE_TABLE; e += 32)
                    chars.Add($"{(char)e}".Replace(" ", "Spc"));

                for (int e = 0; e < chars.Count; e++)
                    chars[e] = (char.IsControl(chars[e][0])) ? "Controllo" : chars[e];

                for (int e = i; e < SIZE_TABLE; e += 32)
                    Console.Write($" {e.ToString().PadLeft(4)}  |  {chars[(e - i) / 32].PadLeft(9)} ");
                Console.WriteLine();
            }

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
