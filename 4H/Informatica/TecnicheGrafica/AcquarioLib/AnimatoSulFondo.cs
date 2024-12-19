using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;

/*
 * Antonio De Rosa 4H 20-12-2024
 * Tecniche Grafiche WPF - Aquario
 */
namespace AcquarioLib
{
    public class AnimatoSulFondo : AnimatoSulPosto
    {
        //variables for the movement along the X axis
        protected bool isMovingRight;
        protected int movementAmountX;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="canvas">The Main Canvas</param>
        /// <param name="image">The image to be shown</param>
        /// <param name="dispatcher">The dispatcher that manages the movements of the object</param>
        /// <param name="movementX">optional parameter that defines the movement to be made for each tick</param>
        public AnimatoSulFondo(Canvas canvas, Image image, DispatcherTimer dispatcher, int movementX = 10)
            : base(canvas, image, dispatcher)
        {
            movementAmountX = movementX;
        }

        //the center of rotation
        protected (int X, int Y) CenterOfRotation { get; set; }

        /// <summary>
        /// Changes the center of rotation
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        public void ChangeCenterOfRotation(int X, int Y) => CenterOfRotation = (X, Y);

        /// <summary>
        /// Rotates the image by the specified degrees
        /// </summary>
        /// <param name="degrees">The rotation to be made</param>
        public void Rotate(double degrees = 1.0)
        {
            trGroup.Children.Add(new RotateTransform(degrees, CenterOfRotation.X, CenterOfRotation.Y));
        }

        /// <summary>
        /// Checks the width for the Move Function
        /// </summary>
        /// <returns>True if within bounds, otherwise false</returns>
        protected bool CheckWidthBounds()
        {
            if (isMovingRight)
            {
                //If the image has reached the right bound, it is flipped and the direction is inverted
                if (Canvas.RenderSize.Width <= positionX + Image.ActualWidth) Flip();
                return Canvas.RenderSize.Width > positionX + Image.ActualWidth;
            }
            else
            {
                //If the image has reached the left bound, it is flipped and the direction is inverted
                if (positionX < 0) Flip();
                return positionX < 0;
            }
        }

        /// <summary>
        /// Moves the image to the bottom and moves it along the X axis, to be used in dispatcher event.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="a">Event arguments</param>
        public virtual void Move(object sender, EventArgs a)
        {
            //position image to the bottom
            MoveToBottom();

            isMovingRight = CheckWidthBounds();
            positionX += isMovingRight ? movementAmountX : -movementAmountX;
            Canvas.SetLeft(Image, positionX);
        }

        /// <summary>
        /// Function to be called after creating the object, starts the animation
        /// </summary>
        public virtual void Start()
        {
            //set new origin to flip correctly
            Image.RenderTransformOrigin = new Point(0.5, 0.5);

            //add event to Dispatcher
            Dispatcher.Tick += new EventHandler(Move);
        }
    }
}
