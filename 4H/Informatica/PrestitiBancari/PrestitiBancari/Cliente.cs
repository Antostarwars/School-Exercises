namespace PrestitiBancari
{
    public class Cliente
    {
        private string nome, cognome, codiceFiscale;
        private double stipendio;
        private List<PrestitoSemplice> prestiti;

        public string Nome { get {  return nome; } }
        public string Cognome { get {  return cognome; } }
        public string CodiceFiscale { get {  return codiceFiscale; } }
        public double Stipendio { get { return stipendio; } }
        public List<PrestitoSemplice> Prestiti { get { return [.. prestiti]; } } // Copia la lista in un'altra lista (Passa per valore e non per riferimento)

        public Cliente(string nome, string cognome, string codiceFiscale, double stipendio)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.codiceFiscale = codiceFiscale;
            this.stipendio = stipendio;
            prestiti = new List<PrestitoSemplice>();
        }

        public void AggiungiPrestito(PrestitoSemplice prestito)
        {
            prestiti.Add(prestito);
        }

        public override string ToString()
        {
            return $"Nome: {nome}, Cognome: {cognome}, CodiceFiscale: {codiceFiscale}, Stipendio: {stipendio}, NumeroPrestiti: {prestiti.Count}";
        }
    }
}
