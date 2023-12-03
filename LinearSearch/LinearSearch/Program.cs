// Antonio De Rosa 3H 2023-11-17
// Linear Search in names list.

namespace LinearSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Marco", "Lucia", "Giorgio", "Pamela", "Antonio", "Carla", "Fabio" };

            Console.WriteLine("Enter a name");
            string name = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower() == name.ToLower())
                {
                    Console.WriteLine("Name {0} found in position {1}", name, i+1);
                    found = true;
                    break;
                }
            }

            if (!found) Console.WriteLine("Name {0} doesn't exist in names.", name);
        }
    }
}