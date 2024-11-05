namespace PrestitiBancari
{
    public class Banca
    {
        private List<Cliente> clienti;

        public Banca()
        {
            clienti = new List<Cliente>();
        }

        public void AggiungiCliente(Cliente cliente) => clienti.Add(cliente);

        public void RimuoviCliente(string codiceFiscale) => clienti.RemoveAll(x => x.CodiceFiscale == codiceFiscale);

        public Cliente? CercaCliente(string codiceFiscale) => clienti.Find(x => x.CodiceFiscale == codiceFiscale);

        public void AggiungiPrestito(PrestitoSemplice prestito) => CercaCliente(prestito.CodiceFiscale)?.AggiungiPrestito(prestito);

        public List<PrestitoSemplice>? CercaPrestiti(string codiceFiscale) => CercaCliente(codiceFiscale)?.Prestiti;

        public double TotalePrestiti(string codiceFiscale)
        {
            double totale = 0;
            Cliente? cliente = CercaCliente(codiceFiscale);
            if (cliente == null) return totale;
            foreach (var prestito in cliente.Prestiti)
            {
                totale += prestito.Montante;
            }

            return totale;
        }
    }
}
