namespace PrestitiBancari
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione di una banca
            Banca banca = new Banca();

            // Creazione di alcuni clienti
            Cliente cliente1 = new Cliente("Mario", "Rossi", "RSSMRA80A01H501Z", 3000);
            Cliente cliente2 = new Cliente("Luigi", "Verdi", "VRDLGU85B01H501Y", 2500);

            // Aggiunta dei clienti alla banca
            banca.AggiungiCliente(cliente1);
            banca.AggiungiCliente(cliente2);

            // Creazione di alcuni prestiti
            PrestitoSemplice prestito1 = new PrestitoSemplice(10000, 0.05, new DateOnly(2023, 1, 1), new DateOnly(2025, 1, 1), "RSSMRA80A01H501Z");
            PrestitoComplesso prestito2 = new PrestitoComplesso(20000, 0.04, new DateOnly(2023, 1, 1), new DateOnly(2026, 1, 1), "VRDLGU85B01H501Y");

            // Aggiunta dei prestiti ai clienti
            banca.AggiungiPrestito(prestito1);
            banca.AggiungiPrestito(prestito2);

            // Ricerca di un cliente e stampa delle informazioni
            Cliente? clienteTrovato = banca.CercaCliente("RSSMRA80A01H501Z");
            if (clienteTrovato != null)
            {
                Console.WriteLine(clienteTrovato.ToString());
            }

            // Stampa del totale dei prestiti di un cliente
            double totalePrestiti = banca.TotalePrestiti("RSSMRA80A01H501Z");
            Console.WriteLine($"Totale prestiti per RSSMRA80A01H501Z: {totalePrestiti}");

            // Stampa dei prestiti di un cliente
            List<PrestitoSemplice>? prestitiCliente = banca.CercaPrestiti("VRDLGU85B01H501Y");
            if (prestitiCliente != null)
            {
                foreach (var prestito in prestitiCliente)
                {
                    Console.WriteLine(prestito.ToString());
                }
            }
        }
    }
}

