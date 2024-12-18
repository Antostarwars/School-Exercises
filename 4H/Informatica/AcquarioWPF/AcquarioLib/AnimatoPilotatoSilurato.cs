using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace AcquarioLib
{
    public class AnimatoPilotatoSilurato : AnimatoPilotato
    {
        private Image bullet;
        private List<(Image, bool)> bullets;

        public AnimatoPilotatoSilurato(Canvas canvas, Image image, DispatcherTimer timer, Window mainWindow, Image bullet, int movementX = 5, int movementY = 5)
            : base(canvas, image, timer, mainWindow, movementX, movementY)
        {
            this.bullet = bullet;
            bullets = new List<(Image, bool)>();
        }

        protected override void CommandManager(Object sender, KeyEventArgs e)
        {
            base.CommandManager(sender, e);
            switch (e.Key)
            {
                case Key.Space:
                    Shoot();
                    break;
            }
        }

        private void Shoot()
        {
            Image bullet = new Image
            {
                Source = this.bullet.Source,
                Width = this.bullet.Width,
                Height = this.bullet.Height
            };
            if (!isFacingRight)
            {
                bullet.RenderTransformOrigin = new Point(0.5, 0.5);
                bullet.RenderTransform = new ScaleTransform(-1, 1);
            }

            bullet.Margin = new Thickness(isFacingRight ? positionX + Image.ActualWidth : positionX - Image.ActualWidth, positionY + 5, 0, 0);
            bullet.Name = "bullet";
            canvas.Children.Add(bullet);
            bullets.Add((bullet, isFacingRight));

            foreach (var Child in canvas.Children)
            {
                Image img = Child as Image;
                if (img != null)
                {
                    if (img.Name == "bullet" && double.IsNaN(Canvas.GetLeft(img)))
                    {
                        Canvas.SetLeft(img, positionX);
                    }
                }
            }
        }

        public void UpdateBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                (Image img, bool isFacingRight) item = bullets[i];
                if (item.isFacingRight)
                    Canvas.SetLeft(item.img, Canvas.GetLeft(item.img) + 5);
                else
                    Canvas.SetLeft(item.img, Canvas.GetLeft(item.img) - 5);

                Debug.WriteLine($"{Canvas.GetLeft(item.img)}, {canvas.ActualWidth}");

                if (Canvas.GetLeft(item.img) > canvas.ActualWidth || Canvas.GetLeft(item.img) < -item.img.ActualWidth)
                {
                    canvas.Children.Remove(item.img);
                    bullets.Remove(item);
                }
            }
        }

        public override void Build()
        {
            base.Build();
            timer.Tick += (sender, args) => UpdateBullets();
        }
    }
}
