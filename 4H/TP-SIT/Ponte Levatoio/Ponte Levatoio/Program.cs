using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console; // Import delle funzioni della Console


/*
 * Antonio De Rosa 4H - Ponte Levatoio
 *              24/02/2025
 * Ponte Levatoio usando i Thread.
 */
namespace Ponte_Levatoio
{
    class Program
    {
        #region Globals
        // Costanti
        const int MAX_AUTO_SUL_PONTE = 4;
        const int CONSOLE_LENGTH = 115;
        const int CONSOLE_HEIGHT = 29;
        const int MAX_WAITING_AUTO = 100;
        const int MAX_WAITING_AUTO_TO_SHOW = 10;

        // Variabili Globali
        static SemaphoreSlim _sem = new SemaphoreSlim(MAX_AUTO_SUL_PONTE);
        static List<Thread> Waiting_Threads = new List<Thread>();
        static Thread[] Active_Threads = new Thread[MAX_AUTO_SUL_PONTE];
        static int[] positions = new int[MAX_AUTO_SUL_PONTE];
        static int auto_counter = 0;
        static int waiting_auto_counter = 0;

        // Oggetti utili
        static Object _lock = new Object();
        static Random rnd = new Random();

        // Stato ponte
        static bool ponteChiuso = false;
        #endregion

        #region Funzioni video
        /// <summary>
        /// Stampa mappa iniziale a video
        /// </summary>
        static void StampaMappa()
        {
            // Stampa Mappa
            lock (_lock)
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░▓▓▓▓░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░▓▓▓░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░▓▓▓░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░▓▓░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░▓▓▓▓░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░▓░▓░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░▓▓░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░▓▓▓░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░▓░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                WriteLine("                                           ║░░░░░░░░░░░░░░░░░░░░░░░░░░░║                                           ");
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Stampa comandi a video
        /// </summary>
        static void StampaComandi()
        {
            // Stampa menu con comandi
            lock (_lock)
            {
                SetCursorPosition(90, 1);
                Write("COMMANDS");
                SetCursorPosition(90, 2);
                Write("[A] Add car");
                SetCursorPosition(90, 3);
                Write("[O] Open bridge");
                SetCursorPosition(90, 4);
                Write("[C] Close bridge");
                SetCursorPosition(90, 5);
                Write("[Q] Quit");
            }
        }

        /// <summary>
        /// Stampa ponte aperto
        /// </summary>
        static void ApriPonte()
        {
            // Aggiorna stato ponte
            ponteChiuso = false;

            lock (_lock)
            {
                // Stampa ponte (strada) aperto
                SetCursorPosition(0, 12);
                Write("═════════════════════════════════════════╗                               ╔═════════════════════════════════════════");
                SetCursorPosition(41, 13);
                Write("║                               ║");
                SetCursorPosition(41, 14);
                Write("║                               ║");
                SetCursorPosition(41, 15);
                Write("║                               ║");
                SetCursorPosition(41, 16);
                Write("║                               ║");
                SetCursorPosition(0, 17);
                Write("═════════════════════════════════════════╝                               ╚═════════════════════════════════════════");

                // Stampa Acqua
                ForegroundColor = ConsoleColor.Cyan;
                for (int i = 0; i < 7; i++)
                {
                    SetCursorPosition(43 , 12+i);
                    Write("║░░░░░░░░░░░░░░░░░░░░░░░░░░░║");
                }
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Stampa ponte chiuso
        /// </summary>
        static void ChiudiPonte()
        {
            // Se ponte già chiuso non stampare (i nomi delle macchine verrebbero sovrascritti)
            if (ponteChiuso) return;

            // Aggiorna stato ponte
            ponteChiuso = true;

            // Stampa ponte chiuso
            lock (_lock)
            {
                SetCursorPosition(0, 12);
                Write("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                SetCursorPosition(41, 13);
                Write("                                 ");
                SetCursorPosition(41, 14);
                Write("                                 ");
                SetCursorPosition(41, 15);
                Write("                                 ");
                SetCursorPosition(41, 16);
                Write("                                 ");
                SetCursorPosition(0, 17);
                Write("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            }
        }

        /// <summary>
        /// Stampa la lista delle macchine in attesa
        /// </summary>
        static void UpdateThreadList()
        {
            lock (_lock)
            {
                //Stampa tutte le macchine in attesa
                for (int i = 0; i < Waiting_Threads.Count && i <= MAX_WAITING_AUTO_TO_SHOW; i++)
                {
                    SetCursorPosition(5, i);
                    if (i == MAX_WAITING_AUTO_TO_SHOW) // Se viene superato il limite di macchine in attesa stampa ...
                        Write("...");
                    else                               // Altrimente stampa nome macchina
                        Write(Waiting_Threads[i].Name);
                }

                // Pulisci lista da macchine nonpiù in attesa
                SetCursorPosition(5, Waiting_Threads.Count > MAX_WAITING_AUTO_TO_SHOW ? MAX_WAITING_AUTO_TO_SHOW + 1 : Waiting_Threads.Count);
                Write("            ");
            }
        }
        #endregion

        #region Funzioni Auto
        /// <summary>
        /// Aggiunge auto alla lista di attesa
        /// </summary>
        static void AggiungiAuto()
        {
            // Check per non aggiungere troppe auto
            if(waiting_auto_counter >= MAX_WAITING_AUTO) return;

            // Setup Thread auto
            waiting_auto_counter += 1;
            Thread new_thread = new Thread(Auto);
            new_thread.Name = $"Auto {auto_counter++}";
            Waiting_Threads.Add(new_thread);
            UpdateThreadList();
            new_thread.Start();
        }

        /// <summary>
        /// Controlla se ci sono auto sul ponte
        /// </summary>
        /// <returns>True se ci sono, False altrimenti</returns>
        static bool CheckAutoSulPonte()
        {
            // flag booleana
            bool auto_sul_ponte = false;

            // Cerca (se presente) macchine sul ponte 
            for(int i = 0; i < Active_Threads.Length; i++)
            {
                if (Active_Threads[i] is null || Active_Threads[i].ThreadState == ThreadState.Stopped) continue; // Se la macchina non è attiva viene saltata dalla ricerca

                int current_Thread_Name_Length = Active_Threads[i].Name.Length; // Lunghezza nome auto

                if(positions[i] + current_Thread_Name_Length > 40 && positions[i] + current_Thread_Name_Length < 80) 
                    auto_sul_ponte = true; // Macchina trovata
            }

            return auto_sul_ponte;
        }

        /// <summary>
        /// Funzione di movimento dell'auto
        /// </summary>
        static void Auto()
        {
            // Aspetta che si liberi un posto
            _sem.Wait();
            Thread.Sleep(50);

            // Pulisce lista di attesa da macchina appena partita
            Waiting_Threads.RemoveAt(Waiting_Threads.IndexOf(Thread.CurrentThread));
            UpdateThreadList();
            waiting_auto_counter -= 1;

            // Setup posizione di stampa a video e inserimento nell'array di thread attivi
            int x = 0;
            int y = 13;
            for (int i = 0; i < MAX_AUTO_SUL_PONTE; i++)
            {
                if (Active_Threads[i] is null || Active_Threads[i].ThreadState == ThreadState.Stopped) // Trova il primo posto libero nei thread attivi
                {
                    y += i;
                    Active_Threads[i] = Thread.CurrentThread;
                    break;
                }
            }
            
            // Calcola velocità
            int speed = rnd.Next(50, 200);
            for(int i = 0; i < CONSOLE_LENGTH-Thread.CurrentThread.Name.Length; i++)
            {
                // Ottieni posizione macchina nell'array positions
                Thread.Sleep(speed);
                positions[y - 13] = i;

                // Se il ponte è aperto e la macchina è davanti all'apertura aspetta
                while (i == 40 - Thread.CurrentThread.Name.Length && !ponteChiuso)
                    Thread.Sleep(500);

                // Stampa a video posizione aggiornata
                lock (_lock)
                {
                    SetCursorPosition(x + i, y);
                    Write(' ' + Thread.CurrentThread.Name + ' ');
                }
            }

            // Lascia il posto alla macchina successiva
            _sem.Release();
        }
        #endregion

        /// <summary>
        /// Fa abort di tutti i thread e chiude il programma
        /// </summary>
        static void Quit()
        {
            // Abort di tutti i thread in attesa
            for (int i = 0; i < Waiting_Threads.Count; i++)
            {
                Waiting_Threads[i].Abort();
            }

            // Abort di tutti i thread attivi (se non sono già terminati)
            for (int i = 0; i < Active_Threads.Length; i++)
            {
                if (Active_Threads[i] is null || Active_Threads[i].ThreadState == ThreadState.Stopped) continue;
                Active_Threads[i].Abort();
            }
        }

        /// <summary>
        /// Funzione principale che accetta i comandi dell'utente
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Setup Console
            Title = "Antonio De Rosa 4H - Ponte Levatoio";
            OutputEncoding = Encoding.Unicode;
            CursorVisible = false;

            // Setup Mappa
            StampaMappa();
            StampaComandi();
            ApriPonte();

            // Ciclo di gioco
            while (true)
            {
                // Gestione comandi
                if (KeyAvailable)
                {
                    // Lettura comando utente
                    char c = char.ToUpper(ReadKey(true).KeyChar);
                    switch(c)
                    {
                        case 'A':
                            AggiungiAuto();
                            break;

                        case 'C':
                            ChiudiPonte();
                            break;

                        case 'O':
                            // Apri ponte solo se non ci sono auto sul ponte
                            if (!CheckAutoSulPonte()) ApriPonte();
                            break;

                        case 'Q':
                            Quit();
                            return;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
