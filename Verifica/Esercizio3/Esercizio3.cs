using System.Security;

namespace Esercizio3
{
    internal class Esercizio3
    {
        static int RisolviLabirinto(string nome_file)
        {
            // 1 - Caricare il file nome_file in una matrice di caratteri o in un List<string>

            // 2 - trovare il percorso più breve dall'angolo in alto a sinistra a quello in basso a destra,
            //     considerando che:
            //          - le mosse valide sono un passo in alto, oppure in basso ,oppure a destra, oppure a sinistra
            //          - ci si può muovere da una cella '.' ad un'alra cella '.'
            //          - le celle '#' non sono attraversabili

            // 3 - Ritornare il numero di passi minimo per andare da un angolo all'altro.

            char[,] maze;
            int column = 0;
            int row = 1;

            // Prendo la size della matrice
            using (StreamReader sr = new StreamReader(nome_file)) 
            {
                column = sr.ReadLine().Length;
                
                while (!sr.EndOfStream) 
                {
                    sr.ReadLine();
                    row++;
                }
            }

            maze = new char[row, column];

            // Carico la matrice
            using (StreamReader sr = new StreamReader(nome_file)) 
            {
                for (int i = 0; i < row; i++) 
                {
                    string currentLine = sr.ReadLine();
                    for (int j = 0; j < column; j++)
                    {
                        maze[i,j] = currentLine[j];
                    }
                }
            }

            (int row, int column) currentIndex = (0, 0);
            int interactionsNumber = 0;
            while (currentIndex.row != row-1 && currentIndex.column != column-1)
            {
                if (maze[currentIndex.row+1, currentIndex.column] == '.')
                {
                    Console.WriteLine("giù");
                    currentIndex.row++;
                    interactionsNumber++;
                    continue;
                }

                if (maze[currentIndex.row-1,currentIndex.column] == '.')
                {
                    Console.WriteLine("su");
                    currentIndex.row--;
                    interactionsNumber++;
                    continue;
                }
                
                if (maze[currentIndex.row, currentIndex.column+1] == '.')
                {
                    Console.WriteLine("destra");
                    currentIndex.column++;
                    interactionsNumber++;
                    continue;
                }

                if (maze[currentIndex.row, currentIndex.column-1] == '.')
                {
                    Console.WriteLine("sinistra");
                    currentIndex.column--;
                    interactionsNumber++;
                    continue;
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            string file_name = @"..\..\..\maze-5.txt";
            int numero_passi = RisolviLabirinto(file_name);
            Console.WriteLine($"E' possibile attraversare il labirinto '{file_name}' in {numero_passi} passi");

            /*file_name = @"..\..\..\maze-15.txt";
            numero_passi = RisolviLabirinto(file_name);
            Console.WriteLine($"E' possibile attraversare il labirinto '{file_name}' in {numero_passi} passi");

            file_name = @"..\..\..\maze-30.txt";
            numero_passi = RisolviLabirinto(file_name);
            Console.WriteLine($"E' possibile attraversare il labirinto '{file_name}' in {numero_passi} passi");
            */
        }
    }
}
