using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace AcquarioLib
{
    public class AnimatoSulPosto : Inanimato
    {
        private DispatcherTimer timer;
        private double timerTick;
        private int gradi;
        private ScaleTransform flip;
        public AnimatoSulPosto(string nomeFile, Thickness margine, int altezza, int larghezza, Size grandezza, double timerTick)
            : base(nomeFile, margine, altezza, larghezza, grandezza)
        {
            timer = new DispatcherTimer();
            gradi = 0;
            this.timerTick = timerTick;
            flip = new ScaleTransform();
        }


        private void IniziaTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(timerTick);
            timer.Tick += new EventHandler(Animazione!);
            timer.Start();
        }

        protected virtual void Animazione(object sender, EventArgs e)
        {
            // Implementa l'animazione 
            oggetto.RenderTransformOrigin = new Point(0.5, 0.5);
            flip.ScaleX = flip.ScaleX * -1;
            oggetto.RenderTransform = flip;
            
        }
        
        public override void AggiungiOggetto(Canvas canvas)
        {
            IniziaTimer();
            base.AggiungiOggetto(canvas);
        }
    }
}
