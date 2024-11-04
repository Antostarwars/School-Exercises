/*
 * Thread Corsa di Antonio De Rosa
 * 4H 2024-11-4
 * Programmazione usando I Thread, Simulazione di una corsa.
 */

namespace ThreadCorsa
{
    internal class Program
    {

        static int posAndrea = 0;
        static int posBaldo = 0;
        static int posCarlo = 0;
        static int classifica = 0;

        static Object lockConsole = new object();

        static void Pronti()
        {
            Console.SetCursorPosition(posAndrea, 2);
            Console.Write("Andrea");
            Console.SetCursorPosition(posAndrea, 3);
            Console.Write("  @");
            Console.SetCursorPosition(posAndrea, 4);
            Console.Write(@" /█\");
            Console.SetCursorPosition(posAndrea, 5);
            Console.Write(@" / \");

            Console.SetCursorPosition(posBaldo, 6);
            Console.Write("Baldo");
            Console.SetCursorPosition(posBaldo, 7);
            Console.Write("  @");
            Console.SetCursorPosition(posBaldo, 8);
            Console.Write(@" /█\");
            Console.SetCursorPosition(posBaldo, 9);
            Console.Write(@" / \");

            Console.SetCursorPosition(posCarlo, 10);
            Console.Write(@"Carlo");
            Console.SetCursorPosition(posCarlo, 11);
            Console.Write("  @");
            Console.SetCursorPosition(posCarlo, 12);
            Console.Write(@" /█\");
            Console.SetCursorPosition(posCarlo, 13);
            Console.Write(@" / \");
        }

        static void Andrea()
        {
            do
            {
                posAndrea++;
                Thread.Sleep(50); // Attesa di 50 millisecondi per simulare l'animazione
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posAndrea, 3);
                    Console.Write("  @");
                }
                Thread.Sleep(50);
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posAndrea, 4);
                    Console.Write(@" /█\");
                }
                Thread.Sleep(50);
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posAndrea, 5);
                    Console.Write(@" / \");
                }
            } while (posAndrea < Console.WindowWidth - 5); // Arriva a fine schermo, in base alla grandezza della finestra.

            lock (lockConsole)
            {
                classifica++;
                Console.SetCursorPosition(Console.WindowWidth - 3, 2);
                Console.Write(classifica);
            }
        }

        static void Baldo()
        {
            do
            {
                posBaldo++;
                Thread.Sleep(50); // Attesa di 50 millisecondi per simulare l'animazione
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posBaldo, 7);
                    Console.Write("  @");
                }
                Thread.Sleep(50);
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posBaldo, 8);
                    Console.Write(@" /█\");
                }
                Thread.Sleep(50);
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posBaldo, 9);
                    Console.Write(@" / \");
                }
            } while (posBaldo < Console.WindowWidth - 5); // Arriva a fine schermo, in base alla grandezza della finestra.


            lock (lockConsole)
            {
                classifica++;
                Console.SetCursorPosition(Console.WindowWidth - 3, 6);
                Console.Write(classifica);
            }
        }

        static void Carlo()
        {
            do
            {
                posCarlo++;
                Thread.Sleep(50); // Attesa di 50 millisecondi per simulare l'animazione
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posCarlo, 11);
                    Console.Write("  @");
                }
                Thread.Sleep(50);
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posCarlo, 12);
                    Console.Write(@" /█\");
                }
                Thread.Sleep(50);
                lock (lockConsole)
                {
                    Console.SetCursorPosition(posCarlo, 13);
                    Console.Write(@" / \");
                }
            } while (posCarlo < Console.WindowWidth - 5); // Arriva a fine schermo, in base alla grandezza della finestra.

            lock (lockConsole)
            {
                classifica++;
                Console.SetCursorPosition(Console.WindowWidth - 3, 10);
                Console.Write(classifica);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Thread Corsa di Antonio De Rosa 4H 2024-11-4");

            Pronti();
            Thread thAndrea = new Thread(Andrea);
            Thread thBaldo = new Thread(Baldo);
            Thread thCarlo = new Thread(Carlo);

            thAndrea.Start();
            thBaldo.Start();
            thCarlo.Start();

            /*Andrea();
            Baldo();
            Carlo();*/

            Console.ReadLine();
        }
    }
}
