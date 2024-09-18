namespace DateTimeExercices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateOnly firstDate;
            DateOnly secondDate;

            while (true)
            {
                Console.WriteLine("Insert first date:");
                string date = Console.ReadLine() ?? "";
                bool success = DateOnly.TryParse(date, out firstDate);
                if (!success)
                {
                    Console.WriteLine("ERROR! Date Format is wrong! TRY AGAIN");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Insert second date:");
                string date = Console.ReadLine() ?? "";
                bool success = DateOnly.TryParse(date, out secondDate);
                if (!success)
                {
                    Console.WriteLine("ERROR! Date Format is wrong! TRY AGAIN");
                    continue;
                }
                break;
            }

            Console.WriteLine($"Numbers of days between the 2 dates: {Math.Abs(firstDate.DayNumber - secondDate.DayNumber)}");
        }
    }
}
