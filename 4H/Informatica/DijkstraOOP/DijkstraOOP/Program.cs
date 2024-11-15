/*
 * Implementazione di Grafi Diretti e Non Diretti usando la programmazione ad oggetti
 * Progetto di Antonio De Rosa 4H 2024-11-15
 */
namespace DijkstraOOP
{
    internal class Program
    {
        static bool Dijkstra(GrafoDiretto g, int nodo_partenza, int nodo_arrivo, List<int> path, List<int> dist)
        {
            if (!g.ControllaIndiceNodo(nodo_partenza))
                throw new Exception("Nodo di partenza non valido");

            if (nodo_arrivo >= 0 && !g.ControllaIndiceNodo(nodo_arrivo))
                throw new Exception("Nodo di arrivo non valido");

            // STEP 1 : inizializzazione
            List<int> V = new List<int>();

            path.Clear();
            path.InsertRange(0, Enumerable.Repeat(-1, g.NumeroNodi));

            dist.Clear();
            dist.InsertRange(0, Enumerable.Repeat(int.MaxValue, g.NumeroNodi));
            dist[nodo_partenza] = 0;

            while (true)
            {
                // STEP 2 : ricerca del nodo da visitare
                int nodo_min = -1;
                for (int nodo = 0; nodo < g.NumeroNodi; ++nodo)
                {
                    if (V.Contains(nodo))  // salta i nodi già visitati
                        continue;
                    if (nodo_min < 0 || dist[nodo_min] > dist[nodo])
                        nodo_min = nodo;
                }

                // STEP 3 : condizione di uscita
                if (nodo_min < 0)
                {
                    // tutti i nodi sono stati visitati!
                    // Questa situazione dovrebbe capitare solo se nodo_arrivo < 0 e,
                    // in questo caso, l'algoritmo procede fino ad etichettare tutti i nodi
                    return (V.Count == g.NumeroNodi);
                }
                if (dist[nodo_min] == int.MaxValue)
                    return false;  // il grafo non è interconnesso (manca il persorso da nodo_partenza a nodo_arrivo)

                // STEP 4 : visita il nodo nodo_min
                V.Add(nodo_min);
                foreach (GrafoDiretto.Arco a in g.ArchiUscenti(nodo_min))
                {
                    if (V.Contains(a.nodo_arrivo))  // se l'arco è verso un nodo già espanso, occorre ignorare
                        continue;

                    int nuova_dist = dist[nodo_min] + a.costo;
                    if (dist[a.nodo_arrivo] > nuova_dist)  // aggiorna solo se il valore è migliorativo
                    {
                        dist[a.nodo_arrivo] = nuova_dist;
                        path[a.nodo_arrivo] = nodo_min;
                    }
                }

                // STEP 5 : condizione di terminazione
                if (nodo_min == nodo_arrivo)
                    return true;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Antonio De Rosa 4H 2024-11-15");
            GrafoNonDiretto g = new GrafoNonDiretto();

            g.AggiungiNodo("A");  // 0
            g.AggiungiNodo("B");  // 1
            g.AggiungiNodo("C");  // 2
            g.AggiungiNodo("D");  // 3
            g.AggiungiNodo("E");  // 4
            g.AggiungiNodo("F");  // 5
            g.AggiungiNodo("G");  // 6
            g.AggiungiNodo("H");  // 7

            g.AggiungiArco("A", "B", 5);
            g.AggiungiArco("A", "C", 2);
            g.AggiungiArco("B", "C", 3);
            g.AggiungiArco("B", "G", 3);
            g.AggiungiArco("C", "D", 1);
            g.AggiungiArco("C", "E", 3);
            g.AggiungiArco("C", "G", 5);
            g.AggiungiArco("D", "E", 1);
            g.AggiungiArco("D", "F", 3);
            g.AggiungiArco("E", "F", 6);
            g.AggiungiArco("E", "H", 4);
            g.AggiungiArco("F", "H", 1);

            string nodo_partenza = "A";
            string nodo_arrivo = "H";

            List<int> path = new List<int>();
            List<int> dist = new List<int>();
            bool esito = Dijkstra(g, g[nodo_partenza], g[nodo_arrivo], path, dist);
            if (esito)
            {
                string percorso = "";
                for (int nodo = g[nodo_arrivo]; nodo >= 0; nodo = path[nodo])
                {
                    if (nodo != g[nodo_arrivo])
                        percorso = " -> " + percorso;
                    percorso = g[nodo] + percorso;
                }
                Console.WriteLine($"Il percorso migliore da '{nodo_partenza}' verso '{nodo_arrivo}' è {percorso}");
                Console.WriteLine($"Il costo complessivo è {dist[g[nodo_arrivo]]}");
            }
            else
                Console.WriteLine($"Non esiste un percorso fra '{nodo_partenza}' e '{nodo_arrivo}'");
        }
    }
}
