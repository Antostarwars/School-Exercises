using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AcquarioLib
{
    public class Inanimato
    {
        protected const string IMAGE_PATH = "pack://application:,,,/Images/";

        protected Image oggetto;

        public Inanimato(string nomeFile, Thickness margine, int altezza, int larghezza, Size grandezza)
        {
            oggetto = new Image();
            oggetto.Margin = margine;
            oggetto.Height = altezza;
            oggetto.Width = larghezza;
            oggetto.RenderSize = grandezza;
            oggetto.Source = new BitmapImage(new System.Uri(IMAGE_PATH + nomeFile + ".png"));
        }

        public virtual void AggiungiOggetto(Canvas canvas)
        {
            canvas.Children.Add(oggetto);
        }
    }

}
