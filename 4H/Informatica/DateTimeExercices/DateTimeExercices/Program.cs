namespace DateTimeExercices
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Insert first date:");
            DateOnly firstDate = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Insert second date:");
            DateOnly secondDate = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine($"Numbers of days between the 2 dates: {Math.Abs(firstDate.DayNumber - secondDate.DayNumber)}");
        }
    }
}
