namespace PrestitiBancari
{
    public class PrestitoSemplice
    {
        private double capitale, interesse;
        private DateOnly dataInizio, dataFine;
        private string codiceFiscale;

        public PrestitoSemplice(double capitale, double interesse, DateOnly dataInizio, DateOnly dataFine, string codiceFiscale)
        {
            this.capitale = capitale;
            this.interesse = interesse;
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
            this.codiceFiscale = codiceFiscale;
        }

        public double Capitale { get { return capitale; } }
        public double Interesse { get { return interesse; } }
        public DateOnly DataInizio { get { return dataInizio; } }
        public DateOnly DataFine { get { return dataFine; } }
        public string CodiceFiscale { get { return codiceFiscale; } }

        public double Rata { get { return (Montante / Durata) / 12; } }
        public double Durata { get { return (dataFine.DayNumber - dataInizio.DayNumber) / 360; } }
        public virtual double Montante { get { return capitale * (1 + Durata * interesse); } }

        public override string ToString()
        {
            return $"Capitale: {capitale}, Interesse: {interesse}, CodiceFiscale: {codiceFiscale}, Durata: {Durata}, Rata: {Rata}, Montante: {Montante}";
        }
    }

    public class PrestitoComposto : PrestitoSemplice
    {
        public PrestitoComposto(double capitale, double interesse, DateOnly dataInizio, DateOnly dataFine, string codiceFiscale)
            : base(capitale, interesse, dataInizio, dataFine, codiceFiscale)
        {

        }

        public override double Montante { get { return Math.Pow(Capitale * (1+Interesse), Durata); } }
    }
}
