using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;


/*
 * Antonio De Rosa 4H - 24/03/2025
 * Filtri Immagini con matrice di convoluzione usando Task e ProgressBar.
 */ 
namespace WpfAppMatriceConvulzione
{
    public partial class MainWindow : Window
    {
        private string filename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void caricafoto_Click(object sender, RoutedEventArgs e)
        {
            // Apri finestra di dialogo per selezionare un file immagine
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "File immagine (*.png;*.jpeg;*.jpg;*.gif;*.bmp;*.tiff;*.webp)|*.png;*.jpeg;*.jpg;*.gif;*.tiff;*.webp";

            try
            {
                if (dlg.ShowDialog() == true)
                {
                    // Carica l'immagine selezionata
                    filename = dlg.FileName;
                    BitmapImage bitmap = new BitmapImage(new Uri(filename));
                    immagine.Source = bitmap;
                }
                else
                {
                    MessageBox.Show("Nessun file selezionato");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void trasforma_Click(object sender, RoutedEventArgs e)
        {
            // Leggi i valori della matrice di convoluzione
            int[,] mat = new int[3, 3];
            try
            {
                mat[0, 0] = int.Parse(g1.Text);
                mat[0, 1] = int.Parse(g2.Text);
                mat[0, 2] = int.Parse(g3.Text);
                mat[1, 0] = int.Parse(g4.Text);
                mat[1, 1] = int.Parse(g5.Text);
                mat[1, 2] = int.Parse(g6.Text);
                mat[2, 0] = int.Parse(g7.Text);
                mat[2, 1] = int.Parse(g8.Text);
                mat[2, 2] = int.Parse(g9.Text);
            }
            catch
            {
                MessageBox.Show("Inserire valori validi nella matrice");
                ResetMatrixFields();
                return;
            }

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(filename))
                {
                    // Applica la convoluzione all'immagine
                    var newBitmap = await ConvoluzioneAsync(bitmap, mat);
                    immagine.Source = BitmapToBitmapSource(newBitmap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<System.Drawing.Bitmap> ConvoluzioneAsync(System.Drawing.Bitmap originale, int[,] matConvol)
        {
            int width = originale.Width;
            int height = originale.Height;

            // Legge i pixel originali in un array
            var originalPixels = new System.Drawing.Color[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    originalPixels[x, y] = originale.GetPixel(x, y);
                }
            }

            var resultPixels = new System.Drawing.Color[width, height];

            // Definisce le regioni (aggiustate per rimanere entro i limiti dell'immagine)
            int midX = (width - 1) / 2;
            int midY = (height - 1) / 2;

            var regions = new[]
            {
                    new { StartX = 1, EndX = midX, StartY = 1, EndY = midY },
                    new { StartX = midX + 1, EndX = width - 2, StartY = 1, EndY = midY },
                    new { StartX = 1, EndX = midX, StartY = midY + 1, EndY = height - 2 },
                    new { StartX = midX + 1, EndX = width - 2, StartY = midY + 1, EndY = height - 2 }
                };

            var tasks = new List<Task>();
            int totalRegions = regions.Length;
            int completedRegions = 0;

            foreach (var region in regions)
            {
                if (region.StartX > region.EndX || region.StartY > region.EndY) continue;

                tasks.Add(Task.Run(() =>
                {
                    // Processa una regione dell'immagine
                    ProcessRegion(originalPixels, matConvol, resultPixels,
                                region.StartX, region.EndX,
                                region.StartY, region.EndY,
                                width, height);

                    // Aggiorna la barra di progresso
                    Dispatcher.Invoke(() =>
                    {
                        completedRegions++;
                        ImageProgressBar.Value = (double)completedRegions / totalRegions * 100;
                    });
                }));
            }

            await Task.WhenAll(tasks);

            // Crea il bitmap finale
            var modified = new System.Drawing.Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x >= 1 && x <= width - 2 && y >= 1 && y <= height - 2)
                        modified.SetPixel(x, y, resultPixels[x, y]);
                    else
                        modified.SetPixel(x, y, originalPixels[x, y]);
                }
            }

            return modified;
        }

        private void ProcessRegion(System.Drawing.Color[,] originalPixels,
                                 int[,] matrix,
                                 System.Drawing.Color[,] resultPixels,
                                 int startX, int endX,
                                 int startY, int endY,
                                 int width, int height)
        {
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    // Calcola la convoluzione per un singolo pixel
                    resultPixels[x, y] = CalculateConvolution(originalPixels, matrix, x, y, width, height);
                }
            }
        }

        private System.Drawing.Color CalculateConvolution(System.Drawing.Color[,] pixels, int[,] matrix, int x, int y, int width, int height)
        {
            int r = 0, g = 0, b = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int px = x + i;
                    int py = y + j;

                    if (px >= 0 && px < width && py >= 0 && py < height)
                    {
                        var pixel = pixels[px, py];
                        int weight = matrix[i + 1, j + 1];

                        r += pixel.R * weight;
                        g += pixel.G * weight;
                        b += pixel.B * weight;
                    }
                }
            }

            // Calcola il colore usando gli RGB
            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return System.Drawing.Color.FromArgb((byte)r, (byte)g, (byte)b);
        }

        private ImageSource BitmapToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                // Converte il bitmap in BitmapSource
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void ResetMatrixFields()
        {
            // Resetta i campi della matrice
            g1.Text = "";
            g2.Text = "";
            g3.Text = "";
            g4.Text = "";
            g5.Text = "";
            g6.Text = "";
            g7.Text = "";
            g8.Text = "";
            g9.Text = "";
        }
    }
}