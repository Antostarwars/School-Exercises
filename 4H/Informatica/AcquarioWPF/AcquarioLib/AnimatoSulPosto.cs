using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace AcquarioLib
{
    public class AnimatoSulPosto : Inanimato
    {
        public AnimatoSulPosto(Canvas canvas, Image image, DispatcherTimer timer)
            : base(canvas, image, timer)
        {
        }

        protected void SetToBottom()
        {
            Image.Margin = new Thickness(Image.Margin.Left, canvas.ActualHeight - Image.RenderSize.Height, Image.Margin.Right, 0);
        }

        protected void Flip()
        {
            transformGroup.Children.Add(new ScaleTransform(-1, 1));
        }

        protected virtual void Animate()
        {
            SetToBottom();
            Flip();
        }

        public void Build()
        {
            timer.Tick += (sender, e) => Animate();
        }
    }
}
