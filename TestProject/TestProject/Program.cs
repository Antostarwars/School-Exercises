namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the first side of the Rectangle. (cm)");
            int firstSide = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second side value of the Rectangle. (cm)");
            int secondSide = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Format("the Rectangle Surface is {0}cm", firstSide * secondSide));
            
        }
    }
}