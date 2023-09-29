namespace TestProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            try
            {
                int.Parse(s);
            } catch (Exception e)
            {
                Console.WriteLine("Value was not a int.");
            }

            Console.WriteLine(string.Format("You have written: {0}", s));
        }
    }
}