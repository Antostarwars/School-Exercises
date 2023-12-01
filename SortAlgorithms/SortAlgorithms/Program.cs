namespace SortAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 7, 9, 1, 4, 2 };

            SelectionSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void SelectionSort(int[] array)
        {
            // This algortihm is O(N^2)

            // Search for N-1 times
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        // Change [i] <-> [j]
                        int aux = array[i];
                        array[i] = array[j];
                        array[j] = aux;
                    }
                }
            }
        }

        static void Sort2(int[] array)
        {
            // Find the index minJ for the minumum index range [0]-[lenght-1]

            int minJ = 0; // We start from index [0]
            for (int j = 1;  j < array.Length; j++)
            {
                if (array[minJ] > array[j])
                {
                    minJ = j;
                }
            }

            /*
             * TODO:
             * - FINISH SORT ALGORITHM
             */ 
        }
    }
}