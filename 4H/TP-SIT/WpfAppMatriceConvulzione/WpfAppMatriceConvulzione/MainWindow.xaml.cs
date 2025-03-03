using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using Microsoft.Win32;
using System;
using System.IO;

// Antonio De Rosa 4H 03-03-2025
// Programma wpf matrice di convulzione

namespace WpfAppMatriceConvulzione
{
    public partial class MainWindow : Window
    {
        string filename; // Variabile per memorizzare il nome del file caricato

        // Costruttore della finestra principale
        public MainWindow()
        {
            InitializeComponent();
        }

        // Metodo per caricare una foto
        private void caricafoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog(); // Creazione del dialogo per selezionare il file


            dlg.DefaultExt = ".png"; // Estensione di default
            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg; *.gif; *.bmp; *.tiff; *.webp)|*.png;*.jpeg;*.jpg; *.gif; *.tiff *.webp"; // Filtri per i tipi di file immagine

            try
            {
                if (dlg.ShowDialog() == true)
                {
                    filename = dlg.FileName; // Memorizza il nome del file selezionato
                    BitmapImage bitmap = new BitmapImage(new System.Uri(filename)); // Carica l'immagine
                    immagine.Source = bitmap; // Visualizza l'immagine nella UI
                }
                else
                {
                    MessageBox.Show("Nessun file selezionato"); // Mostra un messaggio se non viene selezionato alcun file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Mostra un messaggio d'errore se si verifica un'eccezione
            }
        }

        // Metodo per trasformare l'immagine usando la matrice di convoluzione
        private void trasforma_Click(object sender, RoutedEventArgs e)
        {
            int[,] mat = new int[3, 3]; // Matrice di convoluzione 3x3
            try
            {
                // Legge i valori dei pixel dalla UI e li assegna alla matrice
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Mostra un messaggio d'errore se si verifica un'eccezione
                g1.Text = "";
                g2.Text = "";
                g3.Text = "";
                g4.Text = "";
                g5.Text = "";
                g6.Text = "";
                g7.Text = "";
                g8.Text = "";
                g9.Text = "";
                return;
            }
            try
            {
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(filename); // Carica l'immagine originale
                System.Drawing.Bitmap newbitmap = new System.Drawing.Bitmap(bitmap.Width, bitmap.Height); // Crea una nuova bitmap con le stesse dimensioni
                newbitmap = Convoluzione(bitmap, mat); // Applica la matrice di convoluzione all'immagine
                immagine.Source = BitmapToBitmapSource(newbitmap); // Visualizza l'immagine trasformata nella UI
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Mostra un messaggio d'errore se si verifica un'eccezione
            }
        }

        // Metodo per applicare la convoluzione
        private System.Drawing.Bitmap Convoluzione(System.Drawing.Bitmap originale, int[,] matConvol)
        {
            System.Drawing.Bitmap modificata = new System.Drawing.Bitmap(originale.Width, originale.Height); // Crea una nuova bitmap con le stesse dimensioni
            for (int i = 1; i < originale.Width - 1; i++)
            {
                for (int j = 1; j < originale.Height - 1; j++)
                {
                    modificata.SetPixel(i, j, ApplicaConvoluzione(originale, i, j, matConvol)); // Applica la convoluzione pixel per pixel
                }
            }
            return modificata;
        }

        // Metodo per calcolare il colore del pixel convoluto
        private System.Drawing.Color ApplicaConvoluzione(Bitmap img, int x, int y, int[,] matrice)
        {
            int R = 0, G = 0, B = 0;
            int offset = 1;

            for (int i = -offset; i <= offset; i++)
            {
                for (int j = -offset; j <= offset; j++)
                {
                    int px = x + i;
                    int py = y + j;

                    if (px >= 0 && px < img.Width && py >= 0 && py < img.Height)
                    {
                        System.Drawing.Color pixel = img.GetPixel(px, py); // Ottiene il colore del pixel
                        int weight = matrice[i + offset, j + offset]; // Ottiene il peso dalla matrice di convoluzione

                        R += pixel.R * weight; // Moltiplica il valore del rosso per il peso e lo somma
                        G += pixel.G * weight; // Moltiplica il valore del verde per il peso e lo somma
                        B += pixel.B * weight; // Moltiplica il valore del blu per il peso e lo somma
                    }
                }
            }

            // Limita i valori tra 0 e 255
            R = Math.Min(Math.Max(R, 0), 255);
            G = Math.Min(Math.Max(G, 0), 255);
            B = Math.Min(Math.Max(B, 0), 255);

            return System.Drawing.Color.FromArgb(R, G, B); // Restituisce il nuovo colore
        }

        // Metodo per convertire una Bitmap in un ImageSource
        private ImageSource BitmapToBitmapSource(Bitmap source)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                source.Save(memory, System.Drawing.Imaging.ImageFormat.Png); // Salva la bitmap come PNG
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage; // Restituisce l'immagine convertita
            }
        }
    }
}
