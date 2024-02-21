using System;

namespace DisplayAsciiAndUnicodeTable
{
    internal class Program
    {
        enum Table
        {
            Ascii = 127,
            AsciiExtended = 255,
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'a' to display ASCII table");
            Console.WriteLine("Enter 'e' to display ASCII Extended table");
            Console.WriteLine("Enter 'u' to display Unicode table");
            Console.WriteLine("Press any other key to exit");
            Console.WriteLine();

            char c = Console.ReadKey(true).KeyChar;
            switch (c)
            {
                case 'a':
                    Console.Clear();
                    Console.OutputEncoding = System.Text.Encoding.ASCII;
                    DisplayTable(Table.Ascii);
                    break;
                case 'e':
                    Console.Clear();
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    DisplayTable(Table.AsciiExtended);
                    break;
                case 'u':
                    Console.Clear();
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    DisplayTableUnicode(4294967296);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            Console.ReadKey();
        }

        static void DisplayTable(Table type)
        {
            int xPos = 0;
            for (int i = 0; i <= (int) type; i++)
            { 
                // 32 characters per line
                if (i % 32 == 0)
                {
                    // Skip the first line
                    if (i != 0)
                    {
                        xPos += 18;
                        Console.SetCursorPosition(xPos, 0);
                    }
                    // Print the header
                    Console.Write("{0,4} {1,9}", "Cod.", "Char");
                    Console.SetCursorPosition(xPos, Console.CursorTop + 1);
                }
                // Print the character
                char c = (char) i;
                if (char.IsWhiteSpace(c))
                {
                    Console.Write("{0,4} {1,9}", i, "Spazio");
                }
                else if (char.IsControl(c))
                {
                    Console.WriteLine("{0,4} {1,9}", i, "Controllo");
                } else
                {
                    Console.WriteLine("{0,4} {1,9}", i, c);
                }
            }
        }

        static void DisplayTableUnicode(long lenght)
        {
            for (long i = 0; i <= lenght; i++)
            {
                char c = (char) i;
                if (char.IsWhiteSpace(c))
                {
                    Console.WriteLine($"{i} | Whitespace");
                }
                else if (char.IsControl(c))
                {
                    Console.WriteLine($"{i} | Control Character");
                }
                else
                {
                    Console.WriteLine($"{i} | {c}");
                }
            }   
        }
    }
}
