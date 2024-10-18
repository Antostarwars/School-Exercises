namespace FigureGeometriche
{
    class FiguraGeometrica
    {
        public virtual double Area()
        {
            return 0;
        }

        public virtual double Perimetro()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"L'area del {GetType().Name} è {Area()}cm e il perimetro è {Perimetro()}cm";
        }
    }
}
