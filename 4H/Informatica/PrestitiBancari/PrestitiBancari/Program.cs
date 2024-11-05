namespace PrestitiBancari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banca bank = new Banca();

            bank.AggiungiCliente(new Cliente("Mario", "Rossi", "RSS", 1000));
            bank.AggiungiCliente(new Cliente("Luca", "Bianchi", "BNC", 2000));
            bank.AggiungiCliente(new Cliente("Giovanni", "Verdi", "VRD", 3000));
            
            bank.AggiungiPrestito(new PrestitoComplesso(1000, 0.1, new DateOnly(2021, 1, 1), new DateOnly(2022, 1, 1), "RSS"));
            bank.AggiungiPrestito(new PrestitoComplesso(2000, 0.2, new DateOnly(2021, 1, 1), new DateOnly(2022, 1, 1), "BNC"));
            bank.AggiungiPrestito(new PrestitoComplesso(3000, 0.3, new DateOnly(2021, 1, 1), new DateOnly(2022, 1, 1), "VRD"));

            Console.WriteLine(bank.TotalePrestiti("RSS"));
        }
    }
}
