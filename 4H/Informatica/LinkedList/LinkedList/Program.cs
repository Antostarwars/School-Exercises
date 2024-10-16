namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Testing della classe LinkedList
            Console.WriteLine("LinkedList Test\n");
            LinkedList list = new LinkedList();

            // Aggiungo elementi alla lista
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);

            // Stampo il valore alla posizione 1 della lista
            Console.WriteLine($"list[1] = {list[1]}");
            list[1] = 200; // Modifico il valore alla posizione 1
            Console.WriteLine($"list[1] = {list[1]}");

            // Stampo il count degli elementi totali
            Console.WriteLine($"list.Count = {list.Count}");
            
            // Stampo il valore della ricerca del valore 40
            Console.WriteLine($"List.Search(40) = {list.Search(40)}");

            // Rimuovo l'elemento alla posizione 2
            list.RemoveAt(2);
            Console.WriteLine($"list.Count = {list.Count}");

            // Rimuovo il valore 40
            list.RemoveValue(40);
            Console.WriteLine($"list.Count = {list.Count}");
        }
    }
}
