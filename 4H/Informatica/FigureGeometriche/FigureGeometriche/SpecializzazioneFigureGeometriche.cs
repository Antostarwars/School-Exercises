namespace FigureGeometriche
{
    class Cerchio : FiguraGeometrica
    {
        protected double raggio;

        public Cerchio(double raggio)
        {
            this.raggio = raggio;
        }

        public double Raggio
        {
            get { return raggio; }
            set { raggio = value; }
        }

        public override double Area()
        {
            return Math.PI * raggio * raggio;
        }

        public override double Perimetro()
        {
            return 2 * Math.PI * raggio;
        }
    }

    class Triangolo : FiguraGeometrica
    {
        protected double lato1, lato2, lato3;

        public Triangolo(double lato1, double lato2, double lato3)
        {
            this.lato1 = lato1;
            this.lato2 = lato2;
            this.lato3 = lato3;
        }

        public override double Area()
        {
            return (lato1 * lato2) / 2;
        }

        public override double Perimetro()
        {
            return lato1 + lato2 + lato3;
        }
    }

    class Quadrato : FiguraGeometrica
    {
        protected double lato;

        public Quadrato(double lato)
        {
            this.lato = lato;
        }

        public override double Area()
        {
            return lato * lato;
        }

        public override double Perimetro()
        {
            return lato * 4;
        }
    }

    class Rettangolo : Quadrato
    {
        private double altezza;

        public Rettangolo(double altezza, double lato) : base(lato)
        {
            this.altezza = altezza;
        }

        public override double Area()
        {
            return lato * altezza;
        }

        public override double Perimetro()
        {
            return (lato * 2) * (altezza * 2);
        }
    }

    class Rombo : FiguraGeometrica
    {
        protected double lato1, lato2;
        protected double diagonaleMinore, diagonaleMaggiore;

        public Rombo(double diagonaleMinore, double diagonaleMaggiore)
        {
            this.diagonaleMinore = diagonaleMinore;
            this.diagonaleMaggiore = diagonaleMaggiore;
        }

        public override double Area()
        {
            return (diagonaleMaggiore * diagonaleMinore) / 2;
        }

        public override double Perimetro()
        {
            return 4 * diagonaleMaggiore;
        }
    }

    class Trapezio : FiguraGeometrica
    {
        protected double baseMinore, baseMaggiore, latoObliquo, altezza;

        public Trapezio(double baseMinore, double baseMaggiore, double latoObliquo, double altezza)
        {
            this.baseMinore = baseMinore;
            this.baseMaggiore = baseMaggiore;
            this.latoObliquo = latoObliquo;
            this.altezza = altezza;
        }

        public override double Area()
        {
            return (baseMaggiore + baseMinore) * altezza / 2;
        }

        public override double Perimetro()
        {
            return baseMaggiore + baseMinore + (latoObliquo * 2);
        }
    }
}
