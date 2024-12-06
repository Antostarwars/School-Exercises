using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AcquarioLib
{
    public class AnimatoSulFondo : AnimatoSulPosto
    {
        private TranslateTransform translate;
        private ScaleTransform flip;
        private int inizioX, fineX;
        private int spostamento;

        public AnimatoSulFondo(string nomeFile, Thickness margine, int altezza, int larghezza, Size grandezza, double timerTick, int inizioX, int fineX)
            : base(nomeFile, margine, altezza, larghezza, grandezza, timerTick)
        {
            this.translate = new TranslateTransform();
            this.flip = new ScaleTransform();
            this.inizioX = inizioX;
            this.fineX = fineX;
            this.spostamento = 0;
        }

        protected override void Animazione(object sender, EventArgs e)
        {
            // Implemento la funzione dell'animazione.
            TransformGroup group = new TransformGroup();


            /*
            oggetto.RenderTransformOrigin = new Point(0.5, 0.5);

            if (oggetto.Margin.Right >= fineX)
            {
                spostamento -= 50;
                translate = new TranslateTransform(spostamento, 0); // Se è alla fine va indietro.
            } else
            {
                spostamento += 50;
                translate = new TranslateTransform(spostamento, 0); // Se è all'inizio va avanti.
            }*/

            // Renderizzo la transformazione.
            oggetto.RenderTransform = translate;
        }

        public override void AggiungiOggetto(Canvas canvas)
        {
            oggetto.Margin = new Thickness(oggetto.Margin.Left, canvas.Height - oggetto.Height, oggetto.Margin.Right, oggetto.Margin.Bottom);
            base.AggiungiOggetto(canvas);
        }
    }
}
