using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace AcquarioLib
{
    public class AnimatoPilotato : AnimatoInAcqua
    {
        protected Window mainWindow;
        protected bool isFacingRight;

        public AnimatoPilotato(Canvas canvas, Image image, DispatcherTimer timer, Window mainWindow, int movementAmountX = 5, int movementAmountY = 5)
            : base(canvas, image, timer, movementAmountX, movementAmountY)
        {
            this.mainWindow = mainWindow;
            isFacingRight = true;
        }

        protected bool CanGoUpWards() => positionY - movementAmountY > 0;
        protected bool CanGoDownWards() => canvas.ActualHeight > positionY + Image.ActualHeight + movementAmountY;
        protected bool CanGoLeftWards() => positionX - movementAmountX > 0;
        protected bool CanGoRightWards() => canvas.ActualWidth > positionX + Image.ActualWidth;

        protected virtual void CommandManager(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (CanGoUpWards()) Canvas.SetTop(Image, positionY -= movementAmountY);
                    break;
                case Key.Down:
                    if (CanGoDownWards()) Canvas.SetTop(Image, positionY += movementAmountY);
                    break;
                case Key.Left:
                    if (CanGoLeftWards())
                    {
                        if (isFacingRight)
                        {
                            Flip();
                            isFacingRight = false;
                        }
                        Canvas.SetLeft(Image, positionX -= movementAmountX);
                    }
                    break;
                case Key.Right:
                    if (CanGoRightWards())
                    {
                        if (!isFacingRight)
                        {
                            Flip();
                            isFacingRight = true;
                        }
                        Canvas.SetLeft(Image, positionX += movementAmountX);
                    }
                    break;
            }
        }

        public override void Build()
        {
            mainWindow.KeyDown += CommandManager;
        }
    }
}
