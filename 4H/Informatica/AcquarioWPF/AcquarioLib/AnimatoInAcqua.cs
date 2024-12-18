using System.Windows.Controls;
using System.Windows.Threading;

namespace AcquarioLib
{
    public class AnimatoInAcqua : AnimatoSulFondo
    {
        protected double positionY;
        protected bool isUp;
        protected int movementAmountY;

        public AnimatoInAcqua(Canvas canvas, Image image, DispatcherTimer timer, int movementAmountX = 5, int movementAmountY = 5)
            : base(canvas, image, timer, movementAmountX)
        {
            this.movementAmountY = movementAmountY;
            positionX = image.Margin.Left;
            positionY = image.Margin.Top;
        }

        protected bool CheckHeightBounds() => isUp ? canvas.RenderSize.Height > positionY + Image.ActualHeight : positionY < 0;

        protected override void Animate()
        {
            isRight = CheckWidthBounds();
            isUp = CheckHeightBounds();
            positionX += isRight ? movementAmountX : -movementAmountX;
            positionY += isUp ? movementAmountY : -movementAmountY;
            Canvas.SetLeft(Image, positionX);
            Canvas.SetBottom(Image, positionY);
        }

        public override void Build()
        {
            timer.Tick += (sender, e) => Animate();
        }
    }
}
