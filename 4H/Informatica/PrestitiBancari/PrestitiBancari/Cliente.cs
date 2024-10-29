namespace PrestitiBancari
{
    public class Cliente
    {
        private string nome, cognome, codiceFiscale;
        private double stipendio;
        private List<PrestitoSemplice> prestiti;

        public string Nome { get {  return nome; } }
        public string Cognome { get {  return nome; } }
        public string CodiceFiscale { get {  return nome; } }
        public double Stipendio { get { return stipendio; } }
    }
}
