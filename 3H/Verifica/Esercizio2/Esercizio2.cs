namespace Esercizio2
{
    internal class Esercizio2
    {
        static double[,] LeggiMatrice(string file_name)
        {
            double[,] matrice;
            using (StreamReader sr = new StreamReader(file_name)) 
            {
                string[] length = sr.ReadLine().Split('#');
                int N, M = 0;
                if (!int.TryParse(length[0], out N) || !int.TryParse(length[1], out M))
                {
                    Console.WriteLine("Errore nella lettura della dimensione della matrice!");
                    sr.Close(); // Dovrebbe chiudersi da solo ma per sicurezza lo metto.
                    return null;
                }
                matrice = new double[N, M];

                while (!sr.EndOfStream)
                {
                    string[] linee = sr.ReadLine().Split('#');
                    if (linee.Length < 3 || linee.Length > 3) continue;

                    // 3 Valori presi dal file
                    int riga, colonna;
                    double valore;
                    if (!int.TryParse(linee[0], out riga) || !int.TryParse(linee[1], out colonna) || !double.TryParse(linee[2], out valore)) continue;
                    if (riga < 0 || riga > N) continue;
                    if (colonna < 0 || colonna > M) continue;
                    if (valore < 1.0 || riga > 10.0) continue;

                    matrice[riga, colonna] = valore;
                }
            }
            return matrice;
        }

        static void Main(string[] args)
        {
            double[,] matr = LeggiMatrice(@"..\..\..\dati.txt");
        }
    }
}
