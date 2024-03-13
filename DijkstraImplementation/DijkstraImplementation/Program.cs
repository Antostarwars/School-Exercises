namespace DijkstraImplementation
{
    internal class Program
    {
        const string GRAPH = @"../../../graph.txt";

        static void Main(string[] args)
        {
            int[,] graph = loadGraph();

            ResolveGraph(graph);
        }

        static int[,] loadGraph()
        {
            using (StreamReader sr = new StreamReader(GRAPH)) 
            {
                int n = int.Parse(sr.ReadLine());

                int[,] matrix = new int[n, n];
                string[] arch = new string[3];
                while (!sr.EndOfStream)
                {
                    arch = sr.ReadLine().Split(",", StringSplitOptions.TrimEntries);
                    matrix[int.Parse(arch[0]), int.Parse(arch[1])] = int.Parse(arch[2]);
                    matrix[int.Parse(arch[1]), int.Parse(arch[0])] = int.Parse(arch[2]);
                }

                return matrix;
            }
        }

        static void ResolveGraph(int[,] graph, int source, int target)
        {
            HashSet<int> visited = new HashSet<int>();
            int[] distance = new int[graph.GetLength(0)];
            int[] previous = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distance[i] = int.MaxValue;
                previous[i] = -1;
            }

            distance[source] = 0;
           
        }
    }
}