using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Diagnostics;

/*
 * Antonio De Rosa 4H 20-12-2024
 * Tecniche Grafiche WPF - Acquario
 */
namespace AcquarioLib
{
    public class AnimatoPilotatoSilurante : AnimatoPilotato
    {
        private Image Bullet { get; }
        private List<(Image, bool)> Bullets { get; } = new List<(Image, bool)>();

        /// <summary>
        /// Constructor for AnimatoPilotatoSilurante
        /// </summary>
        /// <param name="canvas">The Main Canvas</param>
        /// <param name="image">The image to be shown</param>
        /// <param name="dispatcher">The dispatcher that manages the movements of the object</param>
        /// <param name="mainWindow">The main window</param>
        /// <param name="bullet">The bullet image</param>
        /// <param name="movementX">Movement along X axis</param>
        /// <param name="movementY">Movement along Y axis</param>
        public AnimatoPilotatoSilurante(Canvas canvas, Image image, DispatcherTimer dispatcher, Window mainWindow, Image bullet, int movementX = 5, int movementY = 5)
            : base(canvas, image, dispatcher, mainWindow, movementX, movementY)
        {
            Bullet = bullet;
        }

        private int cooldown = 15;
        private int cooldownCounter = 15;

        /// <summary>
        /// Converts Image to Point
        /// </summary>
        /// <param name="img">The image</param>
        /// <returns>Point</returns>
        private Point ImageToPoint(Image img) => new Point(Canvas.GetLeft(img) + img.ActualWidth / 2, Canvas.ActualHeight - Canvas.GetTop(img) + img.ActualHeight / 2);

        /// <summary>
        /// Converts Image to Point with specified coordinates
        /// </summary>
        /// <param name="img">The image</param>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        /// <returns>Point</returns>
        private static Point ImageToPoint(Image img, double X, double Y) => new Point(X + img.ActualWidth / 2, Y + img.ActualHeight / 2);

        /// <summary>
        /// Checks if there is a collision between fish and bullet
        /// </summary>
        /// <param name="Fish">Fish point</param>
        /// <param name="bullet">Bullet point</param>
        /// <returns>True if collision, otherwise false</returns>
        private static bool IsCollision(Point Fish, Point bullet)
        {
            Debug.Write(Math.Abs(Fish.X - bullet.X) <= 100 && Math.Abs(Fish.Y - bullet.Y) <= 100);
            return Math.Abs(Fish.X - bullet.X) <= 100 && Math.Abs(Fish.Y - bullet.Y) <= 100;
        }

        /// <summary>
        /// Checks for hits between bullets and objects
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void CheckHits(Object sender, EventArgs e)
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                (Image img, bool isFacingRight) bullet = Bullets[i];
                Point bulletPoint = ImageToPoint(bullet.img);
                Debug.WriteLine($"bullet: {bulletPoint}");

                for (int j = 0; j < instances.Count; j++)
                {
                    Inanimato inanimato = instances[j];
                    if (inanimato is AnimatoSulFondo)
                        Debug.WriteLine("fish");
                    Point fishPoint = ImageToPoint(inanimato.Image, inanimato.positionX, Canvas.ActualHeight - inanimato.positionY);
                    Debug.WriteLine($"fish: {fishPoint}");

                    if (inanimato is AnimatoPilotatoSilurante) continue;

                    if (IsCollision(fishPoint, bulletPoint))
                    {
                        Canvas.Children.Remove(inanimato.Image);
                        instances.Remove(inanimato);
                        Canvas.Children.Remove(bullet.img);
                        Bullets.Remove(bullet);
                    }
                }
            }
        }

        /// <summary>
        /// Handles key commands
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Key event arguments</param>
        protected override void GestoreComandi(object sender, KeyEventArgs e)
        {
            base.GestoreComandi(sender, e);
            switch (e.Key)
            {
                case Key.Space:
                    Shoot();
                    break;
            }
        }

        /// <summary>
        /// Updates the bullets' positions
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void UpdateSiluri(Object sender, EventArgs e)
        {
            cooldownCounter++;
            for (int i = 0; i < Bullets.Count; i++)
            {
                (Image img, bool isFacingRight) item = Bullets[i];
                if (item.isFacingRight)
                    Canvas.SetLeft(item.img, Canvas.GetLeft(item.img) + 5);
                else
                    Canvas.SetLeft(item.img, Canvas.GetLeft(item.img) - 5);

                Debug.WriteLine($"{Canvas.GetLeft(item.img)}, {Canvas.ActualWidth}");

                if (Canvas.GetLeft(item.img) > Canvas.ActualWidth || Canvas.GetLeft(item.img) < -item.img.ActualWidth)
                {
                    Canvas.Children.Remove(item.img);
                    Bullets.Remove(item);
                }
            }
        }

        /// <summary>
        /// Shoots a bullet
        /// </summary>
        private void Shoot()
        {
            if (cooldownCounter < cooldown) return;
            else cooldownCounter = 0;

            Image bullet = new Image();
            bullet.Source = Bullet.Source;
            bullet.Width = Bullet.Width;
            bullet.Height = Bullet.Height;
            if (!FacingRight)
            {
                bullet.RenderTransformOrigin = new Point(0.5, 0.5);
                bullet.RenderTransform = new ScaleTransform(-1, 1);
            }
            bullet.Name = "bullet";
            Canvas.Children.Add(bullet);
            Bullets.Add((bullet, FacingRight));

            //idk it just works
            foreach (var Child in Canvas.Children)
            {
                Image img = Child as Image;
                if (img is not null)
                {
                    if (img.Name == "bullet" && double.IsNaN(Canvas.GetLeft(img)))
                    {
                        Canvas.SetTop(img, Canvas.GetTop(Image) + Image.ActualHeight / 4);
                        Canvas.SetLeft(img, FacingRight ? Canvas.GetLeft(Image) + Image.ActualWidth : Canvas.GetLeft(Image) - Image.ActualWidth);
                    }
                }
            }
        }

        /// <summary>
        /// Starts the animation
        /// </summary>
        public override void Start()
        {
            base.Start();
            Image.Name = "player";
            Dispatcher.Tick += new EventHandler(UpdateSiluri);
            Dispatcher.Tick += new EventHandler(CheckHits);
        }
    }
}
