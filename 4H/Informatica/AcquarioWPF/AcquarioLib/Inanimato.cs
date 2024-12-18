using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace AcquarioLib
{
    public class Inanimato
    {
        protected Canvas canvas;
        protected TransformGroup transformGroup;
        public Image Image { get; protected set; }
        protected DispatcherTimer timer;

        public Inanimato(Canvas canvas, Image image, DispatcherTimer timer)
        {
            this.canvas = canvas;
            this.Image = image;
            this.timer = timer;
            transformGroup = new TransformGroup();
            image.RenderTransform = transformGroup;
            image.RenderTransformOrigin = new Point(0.5, 0.5); // Imposta il punto di rotazione al centro dell'immagine
        }

        public void AddToCanvas() => canvas.Children.Add(Image);
    }

}
