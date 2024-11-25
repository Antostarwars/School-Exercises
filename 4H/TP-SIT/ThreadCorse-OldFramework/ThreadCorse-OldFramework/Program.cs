/*
 * Thread Corsa di Antonio De Rosa
 * 4H Ultimo Aggiornamento: 2024-11-11 | Primo Aggiornamento: 2024-11-04
 * Programmazione usando I Thread, Simulazione di una corsa.
 */
using System;
using System.Net;
using System.Threading;

namespace ThreadCorse_OldFramework
{
    internal class Program
    {

        static int posAndrea = 0;
        static int posBaldo = 0;
        static int posCarlo = 0;
        static int classifica = 0;

        static Object lockConsole = new object();

        static Thread thAndrea;
        static Thread thBaldo;
        static Thread thCarlo;

        static string comando = "";

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
            thAndrea.Name = "Andrea";
            do
            {
                if (comando.Length == 3)
                    if (comando[1] == 'J' && comando[0] == 'A')
                    {
                        switch (comando[2])
                        {
                            case 'B':
                                thBaldo.Join();
                                break;
                            case 'C':
                                thCarlo.Join();
                                break;
                        }
                        ResetMenu();
                    }

                // Posizione Successiva animazione
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
            thBaldo.Name = "Baldo";
            do
            {
                if (comando.Length == 3)
                    if (comando[1] == 'J' && comando[0] == 'B')
                    {
                        switch (comando[2])
                        {
                            case 'A':
                                thAndrea.Join();
                                break;
                            case 'C':
                                thCarlo.Join();
                                break;
                        }
                        ResetMenu();
                    }
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
            thCarlo.Name = "Carlo";
            do
            {
                if (comando.Length == 3)
                    if (comando[1] == 'J' && comando[0] == 'C')
                    {
                        switch (comando[2])
                        {
                            case 'A':
                                thAndrea.Join();
                                break;
                            case 'B':
                                thBaldo.Join();
                                break;
                        }
                        ResetMenu();
                    }
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
            Console.WriteLine("Thread Corsa di Antonio De Rosa 4H 2024-11-11");

            Pronti();
            thAndrea = new Thread(Andrea);
            thBaldo = new Thread(Baldo);
            thCarlo = new Thread(Carlo);

            AggiornaStati(); // Aggiorna gli stati iniziali
            Console.SetCursorPosition(0, 15);
            Console.Write("Premi un tasto per iniziare la corsa!");
            Console.ReadKey();

            // Inizia tutti i Thread.
            thAndrea.Start();
            thBaldo.Start();
            thCarlo.Start();

            // Aggiorna gli stati fino a che stanno lavorando
            while (thAndrea.IsAlive || thBaldo.IsAlive || thCarlo.IsAlive)
            {
                Menu();
                AggiornaStati();
                Thread.Sleep(50); // Aggiorna ogni 50 millisecondi per non intasare le risorse della Console.
                if (Console.KeyAvailable) AccettaComandi();
            }

            // Aggiorna gli stati alla fine di tutto.
            AggiornaStati();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("");
            Console.ReadKey();
        }

        static void AggiornaStati()
        {
            lock (lockConsole)
            {
                // Scrive lo stato dei thread.
                Console.SetCursorPosition(0, 2);
                Console.Write($"Andrea -> {thAndrea.ThreadState}                                      ");
                Console.SetCursorPosition(0, 6);
                Console.Write($"Baldo -> {thBaldo.ThreadState}                                      ");
                Console.SetCursorPosition(0, 10);
                Console.Write($"Carlo -> {thCarlo.ThreadState}                                      ");

                // Scrive se i thread sono Alive o no.
                // stato di Andrea
                string messaggio = $" IsAlive = {thAndrea.IsAlive} ";
                Console.SetCursorPosition(Console.WindowWidth - messaggio.Length-10, 2); // Partendo dalla fine tolgo i caratteri del messaggio più un offset di 10
                Console.Write(messaggio);

                // stato di Baldo
                messaggio = $" IsAlive = {thBaldo.IsAlive} ";
                Console.SetCursorPosition(Console.WindowWidth - messaggio.Length-10, 6);
                Console.Write(messaggio);

                // stato di Carlo
                messaggio = $" IsAlive = {thCarlo.IsAlive} ";
                Console.SetCursorPosition(Console.WindowWidth - messaggio.Length-10, 10);
                Console.Write(messaggio);
            }
        }

        static void Menu()
        {
            lock (lockConsole) {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("[ Menu ]:");
                Console.WriteLine("Andrea (A)");
                Console.WriteLine("Baldo (B)");
                Console.WriteLine("Carlo (C)");
            }
        }

        static void AccettaComandi()
        {
            Thread thAzione;
            comando = "";
            // Legge il comando utente
            char choice = char.ToUpper(Console.ReadKey(true).KeyChar);
            // Memorizza il primo thread coinvolto nel comando
            switch (choice)
            {
                case 'A':
                    thAzione = thAndrea;
                    break;
                case 'B':
                    thAzione = thBaldo;
                    break;
                case 'C':
                    thAzione = thCarlo;
                    break;
                default:
                    return;
            }

            comando += choice;
            // Legge l'azione da intraprendere
            choice = MenuAzioni(thAzione.Name);
            switch (choice)
            {
                case 'S':
                    lock (lockConsole)
                    {
                        if (thAzione.ThreadState == ThreadState.Running || thAzione.ThreadState == ThreadState.WaitSleepJoin)
                            thAzione.Suspend();
                    }
                    break;
                case 'R':
                    if (thAzione.ThreadState == ThreadState.Suspended)
                        thAzione.Resume();
                    break;
                case 'A':
                    if (thAzione.ThreadState.Equals(ThreadState.Running) || thAzione.ThreadState.Equals(ThreadState.WaitSleepJoin))
                        thAzione.Abort();
                    break;
                case 'J':
                    comando += choice;
                    lock (lockConsole)
                    {
                        Console.SetCursorPosition(80, 20);
                        Console.WriteLine($"[ Chi Aspetta {thAzione.Name}? ]:     ");
                        Console.SetCursorPosition(80, 21);
                        Console.WriteLine("Andrea (A)");
                        Console.SetCursorPosition(80, 22);
                        Console.WriteLine("Baldo (B)");
                        Console.SetCursorPosition(80, 23);
                        Console.WriteLine("Carlo (C)");
                    }
                    choice = char.ToUpper(Console.ReadKey(true).KeyChar);
                    comando += choice;
                    break;
            }
            ResetMenu();
        }

        static char MenuAzioni(string name)
        {
            // Scrive il menu azioni
            lock (lockConsole)
            {
                Console.SetCursorPosition(40, 20);
                Console.WriteLine($"[ Menu Azioni per {name} ]:     ");
                Console.SetCursorPosition(40, 21);
                Console.WriteLine("Sospendere (S)");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("Riprendere (R)");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("Abort (A)");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("Aspetta (J)");

                char c = char.ToUpper(Console.ReadKey(true).KeyChar);

                return c;
            }
        }

        static void ResetMenu()
        {
            lock (lockConsole)
            {
                Console.SetCursorPosition(40, 20);
                Console.WriteLine("                                                                                                                               ");
                Console.SetCursorPosition(40, 21);
                Console.WriteLine("                                                                                                                               ");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("                                                                                                                               ");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("                                                                                                                               ");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("                                                                                                                               ");
            }
        }
    }
}
