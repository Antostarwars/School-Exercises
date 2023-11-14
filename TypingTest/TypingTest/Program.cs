using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

// Antonio De Rosa 3H Typing Test Program
// Typing Test
namespace TypingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Typing Test");
            TypingTest(GetRandomSentence());
        }

        static void TypingTest(string sentence)
        {
            // Crea il timer
            Stopwatch sw = new Stopwatch();
            Console.Write(sentence);

            Console.SetCursorPosition(0, 1);
            sw.Restart();
            int errors = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                char key = Console.ReadKey(true).KeyChar;
                // Check if the letter is correct and chnage the color
                if (sentence[i] == key)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(sentence[i]);
                }
                else
                {
                    errors++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(sentence[i]);
                }
            }
            // Stop the Timer
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.White;

            // Output Time, CPM and Errors
            Console.WriteLine($"\nTime Elapsed: {sw.Elapsed}");
            Console.WriteLine($"Characters per Minute: {(int)(sentence.Length / ((double)sw.ElapsedMilliseconds / 60000.0))}");
            Console.WriteLine($"Errors: {errors}");
            Console.ReadKey();
        }

        static string GetRandomSentence()
        {
            // Read from a file all the sentences
            string filePath = @"..\..\sentences.txt";
            List<string> lines = new List<string>();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

            // Return a random sentence from the list
            return lines[new Random().Next(0, lines.Count)];
        }
    }
}
