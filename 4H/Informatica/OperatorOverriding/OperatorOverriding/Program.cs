namespace OperatorOverriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber rA = new RationalNumber(3, 10);
            RationalNumber rB = new RationalNumber(7, -15);

            Console.WriteLine($"{rA} + {rB}\t= {rA + rB}");
            Console.WriteLine($"{rA} - {rB}\t= {rA - rB}");
            Console.WriteLine($"{rA} * {rB}\t= {rA * rB}");
            Console.WriteLine($"{rA} / {rB}\t= {rA / rB}");
            Console.WriteLine($"{rA} < {rB}\t= {rA < rB}");
            Console.WriteLine($"{rA} <= {rB}\t= {rA <= rB}");
            Console.WriteLine($"{rA} > {rB}\t= {rA > rB}");
            Console.WriteLine($"{rA} >= {rB}\t= {rA >= rB}");
            Console.WriteLine($"{rA} == {rB}\t= {rA == rB}");
            Console.WriteLine($"{rA} != {rB}\t= {rA != rB}");
            Console.WriteLine($"++{rA} \t\t= {++rA}");
            Console.WriteLine($"--{rB} \t= {--rB}");
        }
    }
}
