using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;

/*
 * Antonio De Rosa 4H 20-12-2024
 * Tecniche Grafiche WPF - Acquario
 */
namespace AcquarioLib
{
    public class AnimatoSulPosto : Inanimato
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="canvas">The Main Canvas</param>
        /// <param name="image">The image to be shown</param>
        /// <param name="dispatcher">The dispatcher that manages the movements of the object</param>
        public AnimatoSulPosto(Canvas canvas, Image image, DispatcherTimer dispatcher)
            : base(canvas, image, dispatcher) { }

        /// <summary>
        /// Puts the image on the bottom keeping its margin from the left
        /// </summary>
        public void MoveToBottom()
        {
            //Image.Margin = new Thickness(Image.Margin.Left, Canvas.Height - Image.RenderSize.Height, Image.Margin.Right, 0);
            Canvas.SetTop(Image, Canvas.ActualHeight - Image.ActualHeight - 10);
            positionY = Canvas.ActualHeight - Image.ActualHeight;
        }

        /// <summary>
        /// Flips the image
        /// </summary>
        public void Flip()
        {
            //Image.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform flip = new ScaleTransform(-1, 1);
            trGroup.Children.Add(flip);
        }

        /// <summary>
        /// Moves the image to the bottom and flips it, to be used in dispatcher event
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="a">Event arguments</param>
        private void Animate(object sender, EventArgs a)
        {
            MoveToBottom();
            Flip();
        }

        /// <summary>
        /// Function to be called after creating the object, starts the animation
        /// </summary>
        public virtual void Start()
        {
            //set new origin to flip correctly
            Image.RenderTransformOrigin = new Point(0.5, 0.5);

            Dispatcher.Tick += new EventHandler(Animate);
        }
    }
}
