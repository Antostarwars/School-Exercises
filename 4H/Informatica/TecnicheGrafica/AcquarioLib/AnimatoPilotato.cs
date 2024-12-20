using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;

/*
 * Antonio De Rosa 4H 20-12-2024
 * Tecniche Grafiche WPF - Acquario
 */
namespace AcquarioLib
{
    public class AnimatoPilotato : AnimatoInAcqua
    {
        protected Window MainWindow { get; }
        protected bool FacingRight { get; set; } = true;

        /// <summary>
        /// Constructor for AnimatoPilotato
        /// </summary>
        /// <param name="canvas">The Main Canvas</param>
        /// <param name="image">The image to be shown</param>
        /// <param name="dispatcher">The dispatcher that manages the movements of the object</param>
        /// <param name="mainWindow">The main window</param>
        /// <param name="movementX">Movement along X axis</param>
        /// <param name="movementY">Movement along Y axis</param>
        public AnimatoPilotato(Canvas canvas, Image image, DispatcherTimer dispatcher, Window mainWindow, int movementX = 5, int movementY = 5)
            : base(canvas, image, dispatcher, movementX, movementY)
        {
            MainWindow = mainWindow;
        }

        /// <summary>
        /// Checks if the object can move upwards
        /// </summary>
        /// <returns>True if it can move upwards, otherwise false</returns>
        protected bool CanIGoUpWards() => positionY - movementAmountY > 0;

        /// <summary>
        /// Checks if the object can move downwards
        /// </summary>
        /// <returns>True if it can move downwards, otherwise false</returns>
        protected bool CanIGoDownWards() => Canvas.ActualHeight > positionY + Image.ActualHeight;

        /// <summary>
        /// Checks if the object can move left
        /// </summary>
        /// <returns>True if it can move left, otherwise false</returns>
        protected bool CanIGoLeft() => positionX - movementAmountX > 0;

        /// <summary>
        /// Checks if the object can move right
        /// </summary>
        /// <returns>True if it can move right, otherwise false</returns>
        protected bool CanIGoRight() => Canvas.RenderSize.Width > positionX + Image.ActualWidth;

        /// <summary>
        /// Handles key commands
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Key event arguments</param>
        protected virtual void GestoreComandi(Object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (CanIGoUpWards()) Canvas.SetTop(Image, positionY -= movementAmountY);
                    break;
                case Key.Down:
                    if (CanIGoDownWards()) Canvas.SetTop(Image, positionY += movementAmountY);
                    break;
                case Key.Left:
                    if (FacingRight) Flip();
                    FacingRight = false;
                    if (CanIGoLeft()) Canvas.SetLeft(Image, positionX -= movementAmountX);
                    break;
                case Key.Right:
                    if (!FacingRight) Flip();
                    FacingRight = true;
                    if (CanIGoRight()) Canvas.SetLeft(Image, positionX += movementAmountX);
                    break;
            }
        }

        /// <summary>
        /// Starts the animation
        /// </summary>
        public override void Start()
        {
            //set new origin to flip correctly
            Image.RenderTransformOrigin = new Point(0.5, 0.5);

            MainWindow.KeyDown += GestoreComandi;
        }
    }
}
