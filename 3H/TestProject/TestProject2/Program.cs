namespace TestProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Income Calculator by Antonio De Rosa 3H";

            /*
             * 10,000€ 15%
             * oltre 10,000€ 20%
             * 
             * Se si superano i 10k€ i primi 10k vengono tassati al 15%
             * il restante al 20%
             * Esempio: 11k€ -> 10k al 15% e 1k al 20%
             */

            double grossIncome;
            double taxes;
            bool inputOk;

            const double TAXES10K = 0.15;
            const double TAXES15K = 0.20;

            do
            {
                Console.WriteLine("How much Gross Income do you have?");
                string input = Console.ReadLine();
                inputOk = double.TryParse(input, out grossIncome);
                if (!inputOk)
                {
                    Console.WriteLine("Gross Income it's not a valid currency.");
                } else if (grossIncome < 0)
                {
                    Console.WriteLine("Gross Income can't be negative.");
                }
            } while (!inputOk);
            
            if (grossIncome <= 10000)
            {
                taxes = grossIncome * TAXES10K;
            } else
            {
                grossIncome -= 10000;
                taxes = grossIncome * TAXES15K + 1500;
            }

            Console.WriteLine($"You have to pay {taxes}$ in taxes.");
        }
    }
}