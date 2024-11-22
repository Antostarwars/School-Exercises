using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

// Antonio De Rosa 4H - Acquario WPF 2024-11-22 
namespace AquarioWPF
{

    public partial class MainWindow : Window
    {
        private const int TICK_MILLISECONDS = 1000;
        DispatcherTimer timer;
        private int numeroPesci = 0;

        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
            AddFish(new Uri("pack://application:,,,/Images/fish-1.png"));
        }

        private void SetupTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(TICK_MILLISECONDS);
            timer.Tick += new EventHandler(TimerTickEvent!);
            timer.Start();
        }

        private void TimerTickEvent(object sender, EventArgs args)
        {
            numeroPesci++;
            LabelContatore.Content = $"Pesci nell'acquario: {numeroPesci}";
        }

        private void AddFish(Uri imgPath)
        {
            Random random = new Random();
            Image img = new Image();
            img.Source = new BitmapImage(imgPath);

            // Randomizza la posizione dell'immagine inserita
            double posX = random.NextDouble() * CanvasAcquario.ActualWidth;
            double posY = random.NextDouble() * CanvasAcquario.ActualHeight;
            img.Margin = new Thickness(posX, posY, 0, 0);

            CanvasAcquario.Children.Add(img);
        }
    }
}