using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;
using System.Xaml;

namespace AcquarioLib
{
    public class AnimatoSulFondo : AnimatoSulPosto
    {
        protected double positionX;
        protected bool isRight;
        protected int movementAmountX;

        public AnimatoSulFondo(Canvas canvas, Image image, DispatcherTimer timer, int movementAmountX = 10)
            : base(canvas, image, timer)
        {
            this.movementAmountX = movementAmountX;
            positionX = 0;
        }

        public new virtual void Build()
        {
            SetToBottom(); // Imposta l'immagine in basso
            timer.Tick += (sender, e) => Animate(); // Aggiunge l'animazione al timer
        }

        protected override void Animate()
        {
            isRight = CheckWidthBounds();
            positionX += isRight ? movementAmountX : -movementAmountX; // Sposta l'immagine a destra o a sinistra in base alla direzione
            Canvas.SetLeft(Image, positionX); // Imposta la posizione dell'immagine
        }

        protected bool CheckWidthBounds()
        {
            if (isRight)
            {
                if (canvas.RenderSize.Width < positionX + Image.ActualWidth) Flip();
                return canvas.RenderSize.Width > positionX + Image.ActualWidth;
            } else
            {
                if (positionX < 0) Flip();
                return positionX < 0;
            }
        }
    }
}
