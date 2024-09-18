namespace TimeOnlyInterval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeOnly time;

            while (true)
            {
                Console.WriteLine("Insert time:");
                string date = Console.ReadLine() ?? "";
                bool success = TimeOnly.TryParse(date, out time);
                if (!success)
                {
                    Console.WriteLine("ERROR! Time Format is wrong! TRY AGAIN");
                    continue;
                }
                break;
            }

            string isBetween = time.IsBetween(new TimeOnly(16, 00), new TimeOnly(22, 00)) == true ? "Time is Between 16:00 and 22:00" : "Time isn't between 16:00 and 22:00";
            Console.WriteLine(isBetween);
        }
    }
}
