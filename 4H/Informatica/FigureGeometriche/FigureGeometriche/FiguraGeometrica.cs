namespace FigureGeometriche
{
    abstract class FiguraGeometrica
    {
        public abstract double Area();

        public abstract double Perimetro();

        public override string ToString()
        {
            return $"L'area del {GetType().Name} è {Area()}cm e il perimetro è {Perimetro()}cm";
        }
    }
}
