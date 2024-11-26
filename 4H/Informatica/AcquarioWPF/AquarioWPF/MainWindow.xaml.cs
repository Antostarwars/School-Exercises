﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        private Image currentFish;

        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
            AddFish(new Uri("pack://application:,,,/Images/fish-2.png"));
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
            img.Height = 100;
            img.Width = 100;

            // Randomizza la posizione dell'immagine inserita
            double posX = random.NextDouble() * CanvasAcquario.ActualWidth;
            double posY = random.NextDouble() * CanvasAcquario.ActualHeight;
            img.Margin = new Thickness(posX, posY, 0, 0);

            CanvasAcquario.Children.Add(img);
        }


        int x = 0;
        int y = 0;
        double scalaX = 1.0;
        double scalaY = 1.0;
        int gradi = 0;
        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            Image fish = CanvasAcquario.FindName("immaginePesceDefault") as Image ?? throw new Exception("Image not exists");

            TranslateTransform translate = new TranslateTransform(--x, --y);
            fish.RenderTransform = translate;
        }

        private void RotateButton_Click(object sender, RoutedEventArgs e)
        {
            Image fish = CanvasAcquario.FindName("immaginePesceDefault") as Image ?? throw new Exception("Image not exists");

            gradi += 10;
            RotateTransform rotate = new RotateTransform(gradi, 0, 0);
            fish.RenderTransform = rotate;
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            Image fish = CanvasAcquario.FindName("immaginePesceDefault") as Image ?? throw new Exception("Image not exists");

            ScaleTransform scale = new ScaleTransform(scalaX++, scalaY++, 0, 0);
            fish.RenderTransform = scale;
        }
    }
}