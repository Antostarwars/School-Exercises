using System;
using System.IO;

//Antonio De Rosa 3H Pianoforte
//Nel file .txt si possono inserire le lettere della tastiera corrispondenti alla nota desiderata.
namespace Pianoforte
{
    internal class Program
    {
      
        // Indice -->               0    1    2    3    4    5    6
        // Nota -->                 DO  DO#   RE   RE#   MI   FA  FA# SOL  SOL# LA   LA#   SI  DO   RE
        static char[] keyboard = { 'a', 'w', 's', 'e', 'd', 'f', 't', 'g', 'y' ,'h', 'u' ,'j', 'k', 'l'};
        static int[] sound_freq = { 262, 277, 294, 311, 330, 349, 370, 392, 415, 440, 466, 494, 523, 587};

        #region ReadKey
        static char ReadKey()
        {
            if (!Console.KeyAvailable) return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true);

            return key.KeyChar;
        }
        #endregion

        #region Find Frequency
        static int FindFrequency(char nota)
        {
            for (int i = 0; i < keyboard.Length; i++)
            {
                if (keyboard[i] == nota) return sound_freq[i];
            }
            return 0;
        }
        #endregion


        static void Main(string[] args)
        {
            Console.Title = "Antonio De Rosa 3H Grand Piano";

            Console.Write(" ____________________________________\r\n|\\                                    \\\r\n| \\                                    \\\r\n|  \\____________________________________\\\r\n|  |       __---_ _---__                |\r\n|  |      |======|=====|                |\r\n|  |      |======|=====|                |\r\n|  |  ____|__---_|_---_|______________  |\r\n|  | |                                | |\r\n|   \\ \\                                \\ \\\r\n|  \\ ||\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\| | \r\n|  ||| |                               || |\r\n \\ ||| |           -  -                || |\r\n  \\'|| |-----------\\\\-\\\\---------------|| |\r\n    \\|_|            \"  \"               \\|_|\r\n\r\n-------------------- Made with <3 By Antonio De Rosa & Pietro Malzone ----------------------------\r\n");

            Console.WriteLine("Benvenuto al SuonaTu!\nPremi '1' se vuoi lasciarci il comando! :0\nPremi '2' se ti piace suonare ;)");
            
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    ReadFile(@"..\..\file.txt");
                    break;
                case '2':
                    while (true)
                    {
                        char tasto = ReadKey();
                        if (tasto != '\0')
                        {
                            PlayFrequency(tasto);
                        }
                    }
            }
        }
        #region Plays the Frequency
        static void PlayFrequency(char tasto)
        {
                int frequenza = FindFrequency(tasto);
                if (frequenza != 0)
                    Console.Beep(FindFrequency(tasto), 400);
        }
        #endregion

         #region Read from file and play the frequency
        static void ReadFile(string nome)
        {
            using (StreamReader sr = new StreamReader(nome))
            {
                while (!sr.EndOfStream)
                {
                    foreach (char c in sr.ReadLine()) PlayFrequency(c);
                }
            }
        }
        #endregion
    }
}
