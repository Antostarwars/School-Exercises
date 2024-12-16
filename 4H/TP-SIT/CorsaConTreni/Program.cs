// Antonio De Rosa 4H 2024-12-16
// Corsa con i Treni

using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace CorsaConTreni
{
    internal class Program
    {
        static Object _lock = new Object(); // lock for resources used by threads
        static Random _random = new Random(); // object to generate random speeds
        static Thread[] _trains = new Thread[2]; // array of threads for the various trains

        #region Method to write at a position with the default color
        private static void WriteAt(int left, int top, string text)
        {
            lock (_lock) // lock the console resource
            {
                SetCursorPosition(left, top); // set the cursor position
                Write(text); // write the requested text
            }
        }
        #endregion

        #region Method to write at a position with a custom color
        private static void WriteAt(int left, int top, string text, ConsoleColor color)
        {
            lock (_lock) // lock the console resource
            {
                var currentColor = ForegroundColor;

                SetCursorPosition(left, top); // set the cursor position
                ForegroundColor = color; // update the color
                Write(text); // write the requested text
                ForegroundColor = currentColor; // reset the color to the previous one
            }
        }
        #endregion

        #region Train Class
        class Train
        {
            private int number; // train identifier used for threads
            private int speed; // random speed of the train

            #region Train Ascii Art
            private string[] train =
            {
                    "╔═══╗",
                    "║   ║",
                    "║   ║",
                    "║   ║",
                    "╚═══╝",
                    "  |  ",
                    "╔═══╗",
                    "║   ║",
                    "║   ║",
                    "║   ║",
                    "╚═══╝",
                    "  |  ",
                    "╔═══╗",
                    "║   ║",
                    "║   ║",
                    "║   ║",
                    "╚═══╝",
                };
            #endregion

            #region Train Class Constructor
            public Train(int n)
            {
                number = n; // assign the identifier to the train
                speed = _random.Next(50, 500); // assign a random speed
            }
            #endregion

            #region Method to print the train and update it with an animation
            public void PrintTrain()
            {
                // calculate the coordinates of the train
                int x = 30 * number + (6 * (number - 1)), y = 0, y1;

                #region Update the color of the traffic lights to red
                WriteAt(29 + 36 * (number - 1), 9, "■", ConsoleColor.Red);
                WriteAt(35 + 36 * (number - 1), 9, "■", ConsoleColor.Red);
                WriteAt(29 + 36 * (number - 1), 13, "■", ConsoleColor.Red);
                WriteAt(35 + 36 * (number - 1), 13, "■", ConsoleColor.Red);
                for (int x1 = 0; x1 < 3; x1++) // write the gates to block the entrance to the railway
                {
                    WriteAt(29 + 36 * (number - 1), 10 + x1, "|", ConsoleColor.DarkRed);
                    WriteAt(35 + 36 * (number - 1), 10 + x1, "|", ConsoleColor.DarkRed);
                }
                #endregion

                #region Initial animation for the train entering partially into the railway
                for (int y2 = 0; y2 < train.Length; y2++)
                {
                    for (int y3 = 0; y3 <= y2; y3++)
                        WriteAt(x, y2 - y3, train[train.Length - y3 - 1]); // partial animation of the train

                    Thread.Sleep(speed); // sleep to manage the speed
                }
                #endregion

                while (y < 29) // while the train is on the screen
                {
                    y1 = y; // 
                    foreach (var r in train) // for each row of the train
                    {
                        if (y1 == 29) // end of the console vertically
                            break;
                        WriteAt(x, y1++, r); // write the row of the train
                    }
                    Thread.Sleep(speed); // sleep to manage the speed
                                         // overwrite the last row of the last carriage with an empty row
                    WriteAt(x, y++, new string(' ', 5));
                }

                #region Update the color of the traffic lights to green
                WriteAt(29 + 36 * (number - 1), 9, "■", ConsoleColor.Green);
                WriteAt(35 + 36 * (number - 1), 9, "■", ConsoleColor.Green);
                WriteAt(29 + 36 * (number - 1), 13, "■", ConsoleColor.Green);
                WriteAt(35 + 36 * (number - 1), 13, "■", ConsoleColor.Green);
                for (int x1 = 0; x1 < 3; x1++) // remove the railway gates
                {
                    WriteAt(29 + 36 * (number - 1), 10 + x1, " ");
                    WriteAt(35 + 36 * (number - 1), 10 + x1, " ");
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region Person Class
        class Person
        {
            public int Position { get; private set; } // position of the person
            public string Name { get; private set; } // name of the person

            #region Person Ascii Art
            private string[] person =
            {
                    @"  [] ",
                    @" -||-",
                    @"  /\ "
                };
            #endregion

            #region Person Class Constructor
            public Person(int position, string name)
            {
                this.Position = position; // initialize the position
                this.Name = name; // assign the name
            }
            #endregion

            #region Method to move the person
            public void Move()
            {
                while (Position < 114) // while inside the console
                {
                    if (Position == 25 && _trains[0].IsAlive) // wait for the first train to pass
                    { Thread.Sleep(50); continue; }
                    if (Position == 60 && _trains[1].IsAlive) // wait for the second train to pass
                    { Thread.Sleep(50); continue; }

                    for (int i = 0; i < person.Length; i++) // draw each row of the person
                        WriteAt(Position, 10 + i, person[i]);
                    Position++; // increase the x-coordinate by one
                    Thread.Sleep(50); // manage the speed
                }
            }
            #endregion
        }
        #endregion

        #region Method to print the initial railway
        static private void PrintRailway()
        {
            WriteLine("                             |" + new string(' ', 5) + "|Train 1 Status                |" + new string(' ', 5) + "|Train 2 Status");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|Is alive =                   |" + new string(' ', 5) + "|Is alive = ");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|" + string.Concat(Enumerable.Repeat("█ ", 24)));
            WriteLine("                             ■" + new string(' ', 5) + "■                             ■" + new string(' ', 5) + "■");
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             ■" + new string(' ', 5) + "■                             ■" + new string(' ', 5) + "■");
            WriteLine("█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|" + string.Concat(Enumerable.Repeat("█ ", 24)));
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
        }
        #endregion

        #region Method to update the train status on the console
        static void UpdateStatus()
        {
            bool train0, train1; // variables to manage the train status
            do
            {
                train0 = _trains[0].IsAlive; // update the status of the first train
                train1 = _trains[1].IsAlive; // update the status of the second train
                WriteAt(47, 2, train0.ToString()); // write the status of the first train
                WriteAt(83, 2, train1.ToString()); // write the status of the second train
                Thread.Sleep(20); // sleep to not occupy too much CPU time
            } while (train0 || train1); // while both trains are running
        }
        #endregion

        static void Main(string[] args)
        {
            Title = "Alan Davide Bovo 4H 2024-12-02";
            CursorVisible = false; // set the cursor as not visible

            Train train1 = new Train(1), train2 = new Train(2); // instantiate the train classes
            _trains[0] = new Thread(train1.PrintTrain); // instantiate the thread for the first train animation
            _trains[1] = new Thread(train2.PrintTrain); // instantiate the thread for the second train animation
            PrintRailway(); // print the initial state of the railway

            _trains[0].Start(); // start the first train animation
            _trains[1].Start(); // start the second train animation

            Thread status = new Thread(UpdateStatus); // instantiate the thread to update the status
            status.Start(); // start the thread to update the status

            Person mario = new Person(0, "Mario"); // create the person Mario
            Thread person = new Thread(mario.Move); // instantiate the thread for Mario's animation
            person.Start(); // Mario starts walking

            while (person.IsAlive) // while Mario is alive
                Thread.Sleep(10); // wait for him

            SetCursorPosition(0, 29); // set the cursor at the end of the console
            Write("Press any key to terminate the program execution ...");
            ReadKey();
        }
    }
}
