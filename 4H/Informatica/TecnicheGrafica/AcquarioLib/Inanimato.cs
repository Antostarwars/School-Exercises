using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

/*
 * Antonio De Rosa 4H 20-12-2024
 * Tecniche Grafiche WPF - Acquario
 */
namespace AcquarioLib
{
    public class Inanimato
    {
        //List that contains all instances of the class
        protected static List<Inanimato> instances = new List<Inanimato>();

        //Image and relative properties
        protected Canvas Canvas;
        protected TransformGroup trGroup;
        public Image Image { get; protected set; }

        //the dispatcher that manages the movements
        protected DispatcherTimer Dispatcher { get; set; }

        //the position of the image
        public double positionX { get; protected set; } = 0;
        public double positionY { get; protected set; } = 0;

        /// <summary>
        /// Static method to retrieve Image object from file name, it positions it if left and top are defined
        /// </summary>
        /// <param name="name">the file name</param>
        /// <param name="left">where to put the image - from the left</param>
        /// <param name="top">where to put the image - from the top</param>
        /// <returns>Image object</returns>
        public static Image ImageFromName(string name, int left = 10, int top = 10)
        {
            Image frame = new Image();
            BitmapImage tmp = new BitmapImage(new Uri($"pack://application:,,,/Immagini/{name}"));
            frame.Source = new TransformedBitmap(tmp, new ScaleTransform(170 / tmp.Width, 140 / tmp.Height));
            frame.Margin = new Thickness(left, top, 0, 0);

            return frame;
        }

        /// <summary>
        /// adds the image to the screen
        /// </summary>
        protected void AddToScreen()
        {
            Canvas.Children.Add(Image);
        }

        /// <summary>
        /// Basic constructor of Inanimato Object
        /// </summary>
        /// <param name="canvas">The Main Canvas</param>
        /// <param name="image">The image to be shown</param>
        /// <param name="dispatcher">The dispatcher that manages the movements of the object</param>
        /// <exception cref="ArgumentException">If Image.Source or Image.Margin are null an ArgumentException is thrown</exception>
        public Inanimato(Canvas canvas, Image image, DispatcherTimer dispatcher)
        {
            //check input
            if (image.Source == null) throw new ArgumentException("Image Source cannot be null.");
            if (image.Margin == null) throw new ArgumentException("Image Margin cannot be null.");

            //assign values to Class properties
            Canvas = canvas;
            Image = image;
            Dispatcher = dispatcher;
            trGroup = new TransformGroup();
            Image.RenderTransform = trGroup;

            //update Image position and add it to the screen
            positionX = Image.Margin.Left;
            positionY = Image.Margin.Top;
            AddToScreen();
            instances.Add(this);
        }
    }
}
