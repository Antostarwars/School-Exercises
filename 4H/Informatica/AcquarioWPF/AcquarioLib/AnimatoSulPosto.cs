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
        private ScaleTransform scale;

        public AnimatoSulPosto(string nomeFile, Thickness margine, int altezza, int larghezza, Size grandezza, double timerTick)
            : base(nomeFile, margine, altezza, larghezza, grandezza)
        {
            timer = new DispatcherTimer();
            this.timerTick = timerTick;
            scale = new ScaleTransform();
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
            scale.ScaleX *= -1;
            oggetto.RenderTransform = scale;
            
        }
        
        public override void AggiungiOggetto(Canvas canvas)
        {
            IniziaTimer();
            base.AggiungiOggetto(canvas);
        }
    }
}
