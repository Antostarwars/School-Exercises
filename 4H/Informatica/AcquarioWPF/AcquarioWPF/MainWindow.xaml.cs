using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using AcquarioLib;

// Antonio De Rosa 4H - Acquario WPF 2024-11-22 
namespace AcquarioWPF
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer fishTimer, propsTimer;
        private const string IMAGES_PATH = "pack://application:,,,/Images/";
        private int fishCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
            SetupTimers();
            AddObjects();
            LabelContatore.Content = "Pesci nell'aquario: " + fishCounter;
        }

        private void SetupTimers()
        {
            fishTimer = new DispatcherTimer();
            fishTimer.Interval = TimeSpan.FromMilliseconds(16);
            fishTimer.Start();

            propsTimer = new DispatcherTimer();
            propsTimer.Interval = TimeSpan.FromMilliseconds(1000);
            propsTimer.Start();
        }

        private void AddObjects()
        {
            Image immagine = new Image();
            Uri source = new Uri(IMAGES_PATH + "fish-3.png");
            immagine = new Image();
            BitmapImage tmp = new BitmapImage(source);
            immagine.Source = new TransformedBitmap(tmp, new ScaleTransform(170 / tmp.Width, 140 / tmp.Height));
            immagine.Margin = new Thickness(10, 10, 0, 0);

            AnimatoInAcqua acqua = new AnimatoInAcqua(CanvasAcquario, immagine, fishTimer);
            acqua.AddToCanvas();
            fishCounter++;

            Image frame1 = new Image();
            tmp = new BitmapImage(new Uri(IMAGES_PATH + "algae-1.png"));
            frame1.Source = new TransformedBitmap(tmp, new ScaleTransform(170 / tmp.Width, 140 / tmp.Height));
            frame1.Margin = new Thickness(10, 10, 0, 0);
            AnimatoSulPosto alga = new AnimatoSulPosto(CanvasAcquario, frame1, propsTimer);

            alga.AddToCanvas();

            Image submarine = new Image();
            tmp = new BitmapImage(new Uri(IMAGES_PATH + "fish-1.png"));
            submarine.Source = new TransformedBitmap(tmp, new ScaleTransform(170 / tmp.Width, 140 / tmp.Height));
            submarine.Margin = new Thickness(10, 10, 0, 0);
            // AnimatoPilotato sub = new AnimatoPilotato(CanvasAcquario, submarine, fishTimer, this); // !!! DECOMMENTA QUESTA RIGA PER FAR FUNZIONARE IL SOTTOMARINO NON SILURATO !!!

            Image bullet = new Image();
            tmp = new BitmapImage(new Uri(IMAGES_PATH + "bullet-1.png"));
            bullet.Source = new TransformedBitmap(tmp, new ScaleTransform(170 / tmp.Width, 140 / tmp.Height));
            bullet.Margin = new Thickness(10, 10, 0, 0);
            AnimatoPilotatoSilurato sub = new AnimatoPilotatoSilurato(CanvasAcquario, submarine, fishTimer, this, bullet);

            sub.AddToCanvas();

            sub.Build();
            acqua.Build();
            alga.Build();
        }
    }
}